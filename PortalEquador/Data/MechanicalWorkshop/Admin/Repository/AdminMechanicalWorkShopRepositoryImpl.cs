using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Education.University.Entity;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MechanicalWorkshop.Admin.Entity;
using PortalEquador.Data.MechanicalWorkshop.CarWash.Entity;
using PortalEquador.Data.Migrations;
using PortalEquador.Domain.Education.University.ViewModels;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Admin.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Admin.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util;
using System.Data;
using System.Diagnostics.Contracts;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Data.MechanicalWorkshop.Admin.Repository
{
    public class AdminMechanicalWorkShopRepositoryImpl(
         ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        UserManager<ApplicationUser> userManager
        ) : GenericRepository<AdminMechanicalWorkShopContractEntity>(context, httpContextAccessor), IAdminMechanicalWorkShopRepository
    {

        public async Task<List<AdminMechanicalWorkshopViewModel>> GetAdmins()
        {
            var contracts = await GroupItemsList(Groups.MECHANICAL_SHOP_CONTRACTS);
            var contractList = mapper.Map<List<GroupItemViewModel>>(contracts);
            
            var usersWithContracts = await (
                                            from user in context.Users
                                            join userRole in context.UserRoles on user.Id equals userRole.UserId
                                            join role in context.Roles on userRole.RoleId equals role.Id
                                            join contract in context.AdminMechanicalWorkShopContractEntity  on user.Id equals contract.UserId  into userContracts
                                            where role.Name != Roles.Administrator && userContracts.ToList().Count  != 0
                                            select new AdminMechanicalWorkshopViewModel
                                            {
                                                user = new AdminUser
                                                {
                                                    UserId = user.Id,
                                                    UserName = user.FirstName + " " + user.LastName,
                                                    Role = role.Name
                                                },
                                                AllContracts = contractList,
                                                Contracts = mapper.Map<List<AdminMechanicalWorkshopContractViewModel>>(userContracts.ToList()),
                                            }).ToListAsync();

            return usersWithContracts;
        }

        public async Task<AdminMechanicalWorkshopCreateViewModel> GetCreateModel()
        {
            var query = await GetUsersWithNoContracts();
            var users = new SelectList(query, "UserId", "UserName");

            var contracts = await GroupItemsList(Groups.MECHANICAL_SHOP_CONTRACTS);
            var contractList = mapper.Map<List<GroupItemViewModel>>(contracts);

            var model = new AdminMechanicalWorkshopCreateViewModel
            {
                Contracts = contractList,
                SelectedContracts = new List<bool>(new bool[contractList.Count]),
                Users = users,
                UserDetails = query
            };

            return model;
        }

        public async Task<AdminMechanicalWorkshopCreateViewModel> GetCreateModel(AdminMechanicalWorkshopCreateViewModel model)
        {
            var query = await GetUsersWithNoContracts();
            var users = new SelectList(query, "UserId", "UserName");

            var contracts = await GroupItemsList(Groups.MECHANICAL_SHOP_CONTRACTS);
            var contractList = mapper.Map<List<GroupItemViewModel>>(contracts);

            model.Contracts = contractList;
            model.Users = users;
            model.UserDetails = query;

            return model;
        }

        public async Task<AdminMechanicalWorkshopViewModel> RecoverModel(AdminMechanicalWorkshopViewModel model)
        {
            var contracts = await GroupItemsList(Groups.MECHANICAL_SHOP_CONTRACTS);
            var contractList = mapper.Map<List<GroupItemViewModel>>(contracts);

            model.AllContracts = contractList;

            return model;
        }

        public async Task Save(AdminMechanicalWorkshopCreateViewModel model)
        {
            var entities = mapper.Map<List<AdminMechanicalWorkShopContractEntity>>(model.ContractsToMonitor());
           
            await DeleteContracts(model.UserId);

            foreach(var entity in entities)
            {
                entity.Id = 0;
                entity.UserId = model.UserId;
                entity.EditorId = GetCurrentUserId();
                await AddAsync(entity);
            }
        }

        public async Task Save(AdminMechanicalWorkshopViewModel model)
        {
            var entities = mapper.Map< List<AdminMechanicalWorkShopContractEntity>>(model.ContractsToMonitor());
            await DeleteContracts(model.user.UserId);

            foreach (var entity in entities)
            {
                entity.Id = 0;
                entity.UserId = model.user.UserId;
                entity.EditorId = GetCurrentUserId();
                await AddAsync(entity);
            }
        }

        public async Task<AdminMechanicalWorkshopViewModel> GetAdmin(string userId)
        {

            var contracts = await GroupItemsList(Groups.MECHANICAL_SHOP_CONTRACTS);
            var contractList = mapper.Map<List<GroupItemViewModel>>(contracts);

            var query = await (
                                            from user in context.Users
                                            join userRole in context.UserRoles on user.Id equals userRole.UserId
                                            join role in context.Roles on userRole.RoleId equals role.Id
                                            join contract in context.AdminMechanicalWorkShopContractEntity on user.Id equals contract.UserId into userContracts
                                            where user.Id == userId
                                            select new AdminMechanicalWorkshopViewModel
                                            {
                                                user = new AdminUser
                                                {
                                                    UserId = user.Id,
                                                    UserName = user.FirstName + " " + user.LastName,
                                                    Role = role.Name
                                                },
                                                AllContracts = contractList,
                                                Contracts = mapper.Map<List<AdminMechanicalWorkshopContractViewModel>>(userContracts.ToList()),
                                            }).FirstAsync();

            query.SelectedContracts = GetSelectedContractsMarkers(contractList, query.Contracts);
            return query;
        }

        private List<bool> GetSelectedContractsMarkers(
            List<GroupItemViewModel> contracts, 
            List<AdminMechanicalWorkshopContractViewModel> selectedContracts
            )
        {
            var markedContracts = new List<bool>(new bool[contracts.Count]);

            for (int index = 0; index < contracts.Count; index++)
            {
                bool contains = selectedContracts.Any(item => item.ContractId == contracts[index].Id);

                if (contains)
                {
                    markedContracts[index] = true;
                }
            }

            return markedContracts;
        }


        public async Task DeleteContracts(string userId)
        {
            await context.AdminMechanicalWorkShopContractEntity
                .Where(item => item.UserId == userId)
                .ExecuteDeleteAsync();
        }



        private async Task<List<AdminUser>> GetUsers()
        {
            var query = await(from user in context.Users
                              join userRole in context.UserRoles on user.Id equals userRole.UserId
                              join role in context.Roles on userRole.RoleId equals role.Id
                              join contracts in context.AdminMechanicalWorkShopContractEntity on userRole.UserId equals contracts.UserId
                              where role.Name != Roles.Administrator
                              select new AdminUser
                              {
                                  UserId = user.Id,
                                  UserName = user.FirstName + " " + user.LastName, 
                                  Role = role.Name
                              }).ToListAsync();

            return query;
        }

        private async Task<List<AdminUser>> GetUsersWithNoContracts()
        {
            var query = await (from user in context.Users
                               join userRole in context.UserRoles on user.Id equals userRole.UserId
                               join role in context.Roles on userRole.RoleId equals role.Id
                               join contracts in context.AdminMechanicalWorkShopContractEntity on userRole.UserId equals contracts.UserId into userContracts
                               from contract in userContracts.DefaultIfEmpty() 
                               where role.Name != Roles.Administrator && contract == null

                               select new AdminUser
                               {
                                   UserId = user.Id,
                                   UserName = user.FirstName + " " + user.LastName,
                                   Role = role.Name
                               }).ToListAsync();

            return query;
        }



    }
}
