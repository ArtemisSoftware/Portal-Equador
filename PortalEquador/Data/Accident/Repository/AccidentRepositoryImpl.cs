using AutoMapper;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortalEquador.Data.Accident.Entities;
using PortalEquador.Data.Generic;
using PortalEquador.Data.Migrations;
using PortalEquador.Domain.Accident.Repository;
using PortalEquador.Domain.Accident.ViewModels;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Languages.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Files;
using PortalEquador.Util.Files.models;
using static PortalEquador.Util.Constants.GroupTypesConstants;
using static PortalEquador.Util.Constants.GroupTypesConstants.ItemFromGroup;

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

        private async Task<int> GetLatestAccidentNumber()
        {
            if (!await context.AccidentEntity.AnyAsync())
                return 1;

            var index = await context.AccidentEntity.MaxAsync(item => item.Number);
            return index + 1;
        }

        public async Task<AccidentDetailViewModel> GetAccident(int id)
        {
            var result = await context.AccidentEntity
                .Include(a => a.ApplicationUserEntity)
                .Include(a => a.PersonalInformationEntity)
                .Include(a => a.VehicleEntity)
                .Include(a => a.ContractGroupItemEntity)
                .Include(a => a.CityGroupItemEntity)
                .Include(a => a.EstimatedValueGroupItemEntity)
                .Include(a => a.LevelGroupItemEntity)
                .Include(a => a.Accidents) // causes
                    .ThenInclude(c => c.CauseGroupItemEntity) // cause details
                .FirstOrDefaultAsync(a => a.Id == id);

            var mapped = mapper.Map<AccidentDetailViewModel>(result);

            var list = new List<AccidentDetailViewModel>();
            list.Add(mapped);
            await AddDocuments(list, mapped.PersonaInformationId);

            return mapped;
        }

        public async Task<AccidentEditViewModel> GetAccidentForEdition(int id)
        {
            var result = await context.AccidentEntity
                .Include(a => a.PersonalInformationEntity)
                .Include(a => a.VehicleEntity)
                .Include(a => a.Accidents) // causes
                    .ThenInclude(c => c.CauseGroupItemEntity) // cause details
                .FirstOrDefaultAsync(a => a.Id == id);

            var model = mapper.Map<AccidentEditViewModel>(result);

            var cities = GroupItems(Groups.PROVINCE, OrderType.Alphabetic);
            var contracts = GroupItems(Groups.MECHANICAL_SHOP_CONTRACTS, OrderType.Alphabetic);

            var accidents = await GroupItemsList(Groups.ACCIDENT_CAUSES, OrderType.Alphabetic);
            var accidentsList = mapper.Map<List<AccidentCauseViewModel>>(accidents);
            accidentsList.ForEach(vm => vm.Id = 0);

            var estimatedValue = GroupItems(Groups.ESTIMATED_VALUE);
            var accidentLevel = GroupItems(Groups.OCORRED_ACCIDENT_LEVEL, OrderType.Alphabetic);

            model.Cities = cities;
            model.EstimatedValues = estimatedValue;
            model.Levels = accidentLevel;
            model.Contracts = contracts;
            model.AllCauses = accidentsList;
            model.SelectedCauses = new List<bool>(new bool[accidentsList.Count]);
            model.UpdateCurrentCauses();
            return model;
        }

        public async Task<AccidentEditViewModel> GetAccidentForEdition(int id, AccidentEditViewModel model)
        {

            var cities = GroupItems(Groups.PROVINCE, OrderType.Alphabetic);
            var contracts = GroupItems(Groups.MECHANICAL_SHOP_CONTRACTS, OrderType.Alphabetic);

            var accidents = await GroupItemsList(Groups.ACCIDENT_CAUSES, OrderType.Alphabetic);
            var accidentsList = mapper.Map<List<AccidentCauseViewModel>>(accidents);
            accidentsList.ForEach(vm => vm.Id = 0);

            var estimatedValue = GroupItems(Groups.ESTIMATED_VALUE);
            var accidentLevel = GroupItems(Groups.OCORRED_ACCIDENT_LEVEL, OrderType.Alphabetic);

            var result = await context.AccidentEntity
                .Include(a => a.PersonalInformationEntity)
                .Include(a => a.VehicleEntity)
                .Include(a => a.Accidents) // causes
                    .ThenInclude(c => c.CauseGroupItemEntity) // cause details
                .FirstOrDefaultAsync(a => a.Id == id);

            var helperModel = mapper.Map<AccidentEditViewModel>(result);

            model.Vehicle = helperModel.Vehicle;
            model.Cities = cities;
            model.EstimatedValues = estimatedValue;
            model.Levels = accidentLevel;
            model.Contracts = contracts;
            model.AllCauses = accidentsList;
            model.UpdateCurrentCauses();

            return model;
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

    
            var mapped = mapper.Map<List<AccidentDetailViewModel>>(result);

            await AddDocuments(mapped, personalInformationId);

            return mapped;
        }

        private async Task AddDocuments(List<AccidentDetailViewModel> accidents, int personalInformationId)
        {
            var documents = await context.DocumentEntity
          .Where(d => d.PersonalInformationId == personalInformationId && d.DocumentTypeId == Documents.ACCIDENT)
          .ToListAsync();

            if (!documents.IsNullOrEmpty())
            {
                foreach (var accident in accidents)
                {
                    var document = documents.FirstOrDefault(d => d.ParentId == accident.Id);
                    if (document != null)
                    {
                        var resource = new FileResource(
                            directory: Util.EnumTypes.FolderType.Accident,
                            extension: document.Extension,
                            folder: accident.PersonaInformationId,
                            fileName: accident.Id.ToString()
                         );
                        accident.Url = FileUtil.GetFileLink(resource);
                    }
                }
            }
        }

        public async Task<AccidentViewModel> GetCreateModel(int personalInformationId, string fullName)
        {
            var cities = GroupItems(Groups.PROVINCE, OrderType.Alphabetic);
            var contracts = GroupItems(Groups.MECHANICAL_SHOP_CONTRACTS, OrderType.Alphabetic);

            var accidents = await GroupItemsList(Groups.ACCIDENT_CAUSES, OrderType.Alphabetic);
            var accidentsList = mapper.Map<List<AccidentCauseViewModel>>(accidents);
            accidentsList.ForEach(vm => vm.Id = 0);

            var estimatedValue = GroupItems(Groups.ESTIMATED_VALUE);
            var accidentLevel = GroupItems(Groups.OCORRED_ACCIDENT_LEVEL, OrderType.Alphabetic);

            var number = await GetLatestAccidentNumber();

            var model = new AccidentViewModel
            {
                Number = number,
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
            var cities = GroupItems(Groups.PROVINCE, OrderType.Alphabetic);
            var contracts = GroupItems(Groups.MECHANICAL_SHOP_CONTRACTS, OrderType.Alphabetic);

            var accidents = await GroupItemsList(Groups.ACCIDENT_CAUSES, OrderType.Alphabetic);
            var accidentsList = mapper.Map<List<AccidentCauseViewModel>>(accidents);
            accidentsList.ForEach(vm => vm.Id = 0);

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
            var tracked = context.ChangeTracker.Entries<AccidentEntity>()
                     .FirstOrDefault(e => e.Entity.Id == model.Id);

            if (tracked != null)
            {
                context.Entry(tracked.Entity).State = EntityState.Detached;
            }

            var editorId = GetCurrentUserId();
            var entity = mapper.Map<AccidentEntity>(model);
            entity.EditorId = editorId;
            
            var entities = mapper.Map<List<AccidentCauseEntity>>(model.GetCurrentCauses());
            entities.ForEach(vm => vm.Id = 0);
            entities.ForEach(vm => vm.EditorId = editorId);

            entity.Accidents = entities;
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

        public async Task DeleteAccident(int accidentId)
        {

            var accident = await context.AccidentEntity
                .Include(a => a.Accidents) // make sure causes are loaded if no cascade
                .FirstOrDefaultAsync(a => a.Id == accidentId);

            if (accident != null)
            {
                context.AccidentEntity.Remove(accident);
                await context.SaveChangesAsync();
            }
        }
    }
}
