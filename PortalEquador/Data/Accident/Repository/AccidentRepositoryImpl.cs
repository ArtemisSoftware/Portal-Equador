using AutoMapper;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Accident.Entities;
using PortalEquador.Data.Contract.Entities;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Accident.Repository;
using PortalEquador.Domain.Accident.ViewModels;
using PortalEquador.Domain.Contract.Repository;
using PortalEquador.Domain.Languages.ViewModels;
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

        public async Task<List<AccidentDetailViewModel>> GetAll()
        {
            var result = await context.AccidentEntity
                .Include(d => d.PersonalInformationEntity)
                .Include(d => d.CityGroupItemEntity)
                .Include(d => d.EstimatedValueGroupItemEntity)
                .Include(d => d.LevelGroupItemEntity)
                .Include(d => d.VehicleEntity)
                .ToListAsync();

            return mapper.Map<List<AccidentDetailViewModel>>(result);
        }

        public async Task<AccidentViewModel> GetCreateModel(int personalInformationId, string fullName)
        {
            var cities = GroupItems(Groups.CITIES, OrderType.Alphabetic);
            var estimatedValue = GroupItems(Groups.ESTIMATED_VALUE, OrderType.Alphabetic);
            var accidentLevel = GroupItems(Groups.ACCIDENT_LEVEL, OrderType.Alphabetic);
            var contracts = GroupItems(Groups.MECHANICAL_SHOP_CONTRACTS, OrderType.Alphabetic);

            var model = new AccidentViewModel
            {
                PersonaInformationId = personalInformationId,
                FullName = fullName,
                Cities = cities,
                EstimatedValues = estimatedValue,
                Levels = accidentLevel,
                Contracts = contracts
            };

            return model;
        }

        public async Task<AccidentViewModel> GetCreateModel(AccidentViewModel model)
        {
            var cities = GroupItems(Groups.CITIES, OrderType.Alphabetic);
            var estimatedValue = GroupItems(Groups.ESTIMATED_VALUE, OrderType.Alphabetic);
            var accidentLevel = GroupItems(Groups.ACCIDENT_LEVEL, OrderType.Alphabetic);
            var contracts = GroupItems(Groups.MECHANICAL_SHOP_CONTRACTS, OrderType.Alphabetic);

            model.Cities = cities;
            model.EstimatedValues = estimatedValue;
            model.Levels = accidentLevel;
            model.Contracts = contracts;

            return model;
        }

        public Task Save(AccidentViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
