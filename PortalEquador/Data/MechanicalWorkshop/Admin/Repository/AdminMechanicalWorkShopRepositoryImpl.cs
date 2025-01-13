using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Education.University.Entity;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MechanicalWorkshop.Admin.Entity;
using PortalEquador.Data.MechanicalWorkshop.CarWash.Entity;
using PortalEquador.Domain.Education.University.ViewModels;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Admin.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Admin.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
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

        public async Task<AdminMechanicalWorkshopCreateViewModel> GetCreateModel()
        {
            var query = await GetUsers();
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
            var query = await GetUsers();
            var users = new SelectList(query, "UserId", "UserName");

            var contracts = await GroupItemsList(Groups.MECHANICAL_SHOP_CONTRACTS);
            var contractList = mapper.Map<List<GroupItemViewModel>>(contracts);

            model.Contracts = contractList;
            model.Users = users;
            model.UserDetails = query;

            return model;
        }

        public async Task Save(AdminMechanicalWorkshopCreateViewModel model)
        {
            var entity = mapper.Map<AdminMechanicalWorkShopContractEntity>(model);
           
            //remove first

            for (int index = 0; index < model.ContractsToMonitor().Count; index++)
            {
                var contract = model.Contracts[index];
                entity.ContractId = contract.Id;
                //await AddAsync(entity);
            }
        }

        public async Task<AdminMechanicalWorkshopViewModel> GetAdmin(string userId)
        {
            var query = await (from user in context.Users
                               join userRole in context.UserRoles on user.Id equals userRole.UserId
                               join role in context.Roles on userRole.RoleId equals role.Id
                               where user.Id == userId
                               select new AdminUser
                               {
                                   UserId = user.Id,
                                   UserName = user.FirstName + " " + user.LastName,
                                   Role = role.Name
                               }).ToListAsync();
            /*
                        var result = await context.AdminMechanicalWorkShopContractEntity
                            .Include(item => item.ContractGroupItemEntity)
                            .ToListAsync();

                       var contracts = mapper.Map<List<AdminMechanicalWorkshopContractViewModel>>(result);
            */
            var contracts_ = new List<AdminMechanicalWorkshopContractViewModel>();
            var contract = new AdminMechanicalWorkshopContractViewModel
            {
                Id = 1,
                ContractId = 1,
            };
            contracts_.Add(contract);

            var contracts = await GroupItemsList(Groups.MECHANICAL_SHOP_CONTRACTS);
            var contractList = mapper.Map<List<GroupItemViewModel>>(contracts);

            return new AdminMechanicalWorkshopViewModel
            {
                user = new AdminUser { UserId = "1", UserName = "Name", Role = "Role" },
                //user = query.First(),
                AllContracts = contractList,
                SelectedContracts = new List<bool>(new bool[contractList.Count]),
            };
        }


        public async Task DeleteContracts(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AdminMechanicalWorkshopViewModel>> GetAdmins()
        {

            var looll = await Task.FromResult(userManager.Users.ToList());

            var models = new List<AdminMechanicalWorkshopViewModel>();
            var contracts = await GroupItemsList(Groups.MECHANICAL_SHOP_CONTRACTS);
            var contractList = mapper.Map<List<GroupItemViewModel>>(contracts);

            models.Add(
                new AdminMechanicalWorkshopViewModel
                {
                    user = new AdminUser { UserId = "1", UserName = "Name", Role = "Role" },
                    Contracts = contractList
                }
            );
            return models;
        }


        private async Task<List<AdminUser>> GetUsers()
        {
            var query = await(from user in context.Users
                              join userRole in context.UserRoles on user.Id equals userRole.UserId
                              join role in context.Roles on userRole.RoleId equals role.Id
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
