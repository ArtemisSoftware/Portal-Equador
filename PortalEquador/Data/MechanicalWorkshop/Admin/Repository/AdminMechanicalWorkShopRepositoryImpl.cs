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
using PortalEquador.Domain.PersonalInformation.ViewModels;
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

            var query = await (from user in context.Users
                               join userRole in context.UserRoles on user.Id equals userRole.UserId
                               join role in context.Roles on userRole.RoleId equals role.Id
                               select new AdminUser
                               {
                                   UserId = user.Id,
                                   UserName = user.FirstName + " " + user.LastName,
                                   Role = role.Name
                               }).ToListAsync();

            var users = new SelectList(query, "UserId", "UserName");


            var contracts = GroupItemsList(Groups.MECHANICAL_SHOP_CONTRACTS);
            var contractList = mapper.Map<List<GroupItemViewModel>>(contracts);


            var model = new AdminMechanicalWorkshopCreateViewModel
            {
                Contracts = contractList,
                Users = users,
                UserDetails = query
            };

            return model;
        }



        public async Task DeleteContracts(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AdminMechanicalWorkshopViewModel>> GetAdmins()
        {

            var looll = await Task.FromResult(userManager.Users.ToList());

            var models = new List<AdminMechanicalWorkshopViewModel>();
            var contracts = new List<AdminMechanicalWorkshopContractViewModel>();

            var contract = new AdminMechanicalWorkshopContractViewModel
            {
                Id = 1,
                ContractId = 1,
            };
            contracts.Add( contract );

            models.Add(
                new AdminMechanicalWorkshopViewModel
                {
                    Name = "Name",
                    Role = "Role",
                    Contracts = contracts
                }
            );
            return models;
        }

        public async Task Save(AdminMechanicalWorkshopContractViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
