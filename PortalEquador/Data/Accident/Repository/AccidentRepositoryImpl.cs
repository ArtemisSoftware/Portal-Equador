using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Accident.Entities;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Accident.Repository;
using PortalEquador.Domain.Accident.ViewModels;
using PortalEquador.Domain.GroupTypes.ViewModels;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Data.Accident.Repository
{
    public class AccidentRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        IWebHostEnvironment hostEnvironment
        ) : GenericRepository<AccidentEntity>(context, httpContextAccessor), IAccidentRepository
    {
        public async Task<bool> AccidentNumberExists(int numberId)
        {
            return await context.AccidentEntity.AnyAsync(item => item.Number == numberId);
        }

        public Task<AccidentViewModel> GetAccident(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AccidentDetailViewModel>> GetAll(int personalInformationId)
        {
            var result = await context.AccidentEntity
                .Include(d => d.PersonalInformationEntity)
                .Include(d => d.CityGroupItemEntity)
                .Include(d => d.EstimatedValueGroupItemEntity)
                .Include(d => d.LevelGroupItemEntity)
                .Include(d => d.VehicleEntity)
                .Where(d => d.PersonalInformationId == personalInformationId)
                .ToListAsync();

            return mapper.Map<List<AccidentDetailViewModel>>(result);
        }

        public async Task<AccidentViewModel> GetCreateModel(int personalInformationId, string fullName)
        {
            var cities = GroupItems(Groups.CITIES, OrderType.Alphabetic);
            var contracts = GroupItems(Groups.MECHANICAL_SHOP_CONTRACTS, OrderType.Alphabetic);

            var accidents = await GroupItemsList(Groups.ACCIDENT_CAUSES, OrderType.Alphabetic);
            var accidentsList = mapper.Map<List<GroupItemViewModel>>(accidents);

            var estimatedValue = GroupItems(Groups.ESTIMATED_VALUE);
            var accidentLevel = GroupItems(Groups.OCORRED_ACCIDENT_LEVEL, OrderType.Alphabetic);

            var model = new AccidentViewModel
            {
                PersonaInformationId = personalInformationId,
                FullName = fullName,
                Cities = cities,
                EstimatedValues = estimatedValue,
                Levels = accidentLevel,
                Contracts = contracts,
                Causes = accidentsList,
                SelectedCauses = new List<bool>(new bool[accidentsList.Count]),
            };

            return model;
        }

        public async Task<AccidentViewModel> GetCreateModel(AccidentViewModel model)
        {
            var cities = GroupItems(Groups.CITIES, OrderType.Alphabetic);
            var contracts = GroupItems(Groups.MECHANICAL_SHOP_CONTRACTS, OrderType.Alphabetic);

            var accidents = await GroupItemsList(Groups.ACCIDENT_CAUSES, OrderType.Alphabetic);
            var accidentsList = mapper.Map<List<GroupItemViewModel>>(accidents);

            var estimatedValue = GroupItems(Groups.ESTIMATED_VALUE);
            var accidentLevel = GroupItems(Groups.OCORRED_ACCIDENT_LEVEL, OrderType.Alphabetic);

            model.Cities = cities;
            model.EstimatedValues = estimatedValue;
            model.Levels = accidentLevel;
            model.Contracts = contracts;
            model.Causes = accidentsList;

            return model;
        }

        public async Task<int> Save(AccidentViewModel model)
        {
            var entity = mapper.Map<AccidentEntity>(model);
            entity.EditorId = GetCurrentUserId();

            var id = 0;

            if (model.Id == 0)
            {
                id = (await AddAsync(entity)).Id;
            }
            else
            {
                entity.DateModified = DateTime.UtcNow;
                await UpdateAsync(entity);
                id = entity.Id;
            }

            return id;
        }

        
    }
}
