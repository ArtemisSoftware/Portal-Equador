using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MechanicalWorkshop.Vehicle.Entity;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util.Constants;
using System.Text.RegularExpressions;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Data.MechanicalWorkshop.Vehicle.Repository
{
    public class MechanicalWorkshopVehicleRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment hostEnvironment) : GenericRepository<MechanicalWorkshopVehicleEntity>(context, httpContextAccessor), IMechanicalWorkshopVehicleRepository
    {

        public async Task<List<VehicleDetailViewModel>> GetVehicles()
        {
            var result = await context.MechanicalWorkshopVehicleEntity
            .Include(item => item.ContractGroupItemEntity)
            .ToListAsync();

            return mapper.Map<List<VehicleDetailViewModel>>(result);
        }

        public async Task<VehicleViewModel> GetCreateModel(VehicleViewModel? model)
        {

            var contracts = GroupItems(GroupTypesConstants.Groups.MECHANICAL_SHOP_CONTRACTS);

            if (model == null)
            {
                return new VehicleViewModel
                {
                    Contracts = contracts
                };
            }
            else
            {
                model.Contracts = contracts;
                return model;
            }
        }

        public async Task<bool> LicencePlateExists(string licencePlate)
        {
            return await context.MechanicalWorkshopVehicleEntity.AnyAsync(item => item.LicencePlate == licencePlate);
        }

        public async Task Save(VehicleViewModel model)
        {
            MechanicalWorkshopVehicleEntity entity = mapper.Map<MechanicalWorkshopVehicleEntity>(model);
            entity.EditorId = GetCurrentUserId();

            if (model.Id == 0)
            {
                await AddAsync(entity);
            }
            else
            {
                entity.DateModified = DateTime.UtcNow;
                await UpdateAsync(entity);
            }
        }

        public async Task<VehicleViewModel> GetVehicle(int id)
        {
            var result = await context.MechanicalWorkshopVehicleEntity
                .Include(item => item.ContractGroupItemEntity)
                .FirstOrDefaultAsync(m => m.Id == id);

            return mapper.Map<VehicleViewModel>(result);
        }

        public async Task<VehicleDetailViewModel> GetVehicleDetail(int id)
        {
            var result = await context.MechanicalWorkshopVehicleEntity
                .Include(item => item.ContractGroupItemEntity)
               .Include(item => item.ApplicationUserEntity)
                .FirstOrDefaultAsync(m => m.Id == id);

            return mapper.Map<VehicleDetailViewModel>(result);
        }

        public async Task UpdateState(int vehicleId, bool isActive)
        {
            MechanicalWorkshopVehicleEntity? entity = await GetAsync(vehicleId);

            if (entity != null)
            {
                entity.Active = isActive;
                entity.EditorId = GetCurrentUserId();
                entity.DateModified = DateTime.UtcNow;
                await UpdateAsync(entity);
            }
        }
    }
}
