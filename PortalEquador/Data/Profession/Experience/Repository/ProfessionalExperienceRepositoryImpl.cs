using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.Profession.Experience.Entity;
using PortalEquador.Domain.Languages.Repository;
using PortalEquador.Domain.Languages.ViewModels;
using PortalEquador.Domain.Profession.Experience.Repository;
using PortalEquador.Domain.Profession.Experience.ViewModels;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Data.Profession.Experience.Repository
{
    public class ProfessionalExperienceRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<ProfessionalExperienceEntity>(context, httpContextAccessor), IProfessionalExperienceRepository
    {
        public async Task<List<ProfessionalExperienceDetailViewModel>> GetAll(int personalInformationId)
        {
            var result = await context.ProfessionalExperienceEntity
                .Include(d => d.CompanyGroupItemEntity)
                .Include(d => d.WorkstationGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .Where(item => item.PersonalInformationId == personalInformationId)
                .ToListAsync();

            return mapper.Map<List<ProfessionalExperienceDetailViewModel>>(result);
        }

        public async Task<ProfessionalExperienceViewModel> GetCreateModel(int personalInformationId, string fullName)
        {
            var companies = GroupItems(Groups.COMPANIES);
            var workstations = GroupItems(Groups.WORKSTATIONS);

            var model = new ProfessionalExperienceViewModel
            {
                PersonaInformationId = personalInformationId,
                FullName = fullName,
                Workstations = workstations,
                Companies = companies,
            };

            return model;
        }

        public async Task<ProfessionalExperienceViewModel> GetCreateModel(ProfessionalExperienceViewModel model)
        {
            var companies = GroupItems(Groups.COMPANIES);
            var workstations = GroupItems(Groups.WORKSTATIONS);

            model.Workstations = workstations;
            model.Companies = companies;
            return model;
        }

        public async Task<ProfessionalExperienceViewModel> GetProfessionalExperience(int id)
        {
            var result = await context.ProfessionalExperienceEntity
                .Include(d => d.CompanyGroupItemEntity)
                .Include(d => d.WorkstationGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .Where(item => item.Id == id)
                .FirstOrDefaultAsync();

            var model = mapper.Map<ProfessionalExperienceViewModel>(result);
            model.Years = model.Months / 12;
            model.Months = model.Months % 12;

            return model;
        }

        public async  Task<bool> ProfessionalExperienceExists(int personalInformationId, int companyId, int workstationId)
        {
            return await context.ProfessionalExperienceEntity.AnyAsync(item => item.PersonalInformationId == personalInformationId & item.CompanyId == companyId & item.WorkstationId == workstationId);
        }

        public async Task Save(ProfessionalExperienceViewModel model)
        {
            var entity = mapper.Map<ProfessionalExperienceEntity>(model);
            entity.EditorId = GetCurrentUserId();
            entity.Months = model.NumberOfMonths();

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
    }
}
