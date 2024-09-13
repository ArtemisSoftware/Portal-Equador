using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.Profession.Competence.Entity;
using PortalEquador.Data.Profession.Experience.Entity;
using PortalEquador.Domain.Languages.Repository;
using PortalEquador.Domain.Languages.ViewModels;
using PortalEquador.Domain.Profession.Competence.Repository;
using PortalEquador.Domain.Profession.Competence.ViewModels;
using PortalEquador.Domain.Profession.Experience.ViewModels;
using System.ComponentModel.Design;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Data.Profession.Competence.Repository
{
    public class ProfessionalCompetenceRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<ProfessionalCompetenceEntity>(context, httpContextAccessor), IProfessionalCompetenceRepository
    {
        public async Task<List<ProfessionalCompetenceDetailViewModel>> GetAll(int personalInformationId)
        {
            var result = await context.ProfessionalCompetenceEntity
                .Include(d => d.CompetenceGroupItemEntity)
                .Where(item => item.PersonalInformationId == personalInformationId)
                .ToListAsync();

            return mapper.Map<List<ProfessionalCompetenceDetailViewModel>>(result);
        }

        public async Task<ProfessionalCompetenceViewModel> GetCreateModel(int personalInformationId, string fullName)
        {
            var competences = GroupItems(Groups.COMPETENCES);

            var model = new ProfessionalCompetenceViewModel
            {
                PersonaInformationId = personalInformationId,
                FullName = fullName,
                Competences = competences,
            };

            return model;
        }

        public async Task<ProfessionalCompetenceViewModel> GetCreateModel(ProfessionalCompetenceViewModel model)
        {
            var competences = GroupItems(Groups.COMPETENCES);
            model.Competences = competences;
            return model;
        }

        public async Task<ProfessionalCompetenceViewModel> GetProfessionalCompetence(int id)
        {
            var result = await context.ProfessionalCompetenceEntity
                .Include(d => d.CompetenceGroupItemEntity)
                .Where(item => item.Id == id)
                .FirstOrDefaultAsync();

            return mapper.Map<ProfessionalCompetenceViewModel>(result);
        }

        public async Task<bool> ProfessionalCompetenceExists(int personalInformationId, int professionalCompetenceId)
        {
            return await context.ProfessionalCompetenceEntity.AnyAsync(item => item.PersonalInformationId == personalInformationId & item.CompetenceId == professionalCompetenceId);
        }

        public async Task Save(ProfessionalCompetenceViewModel model)
        {
            var entity = mapper.Map<ProfessionalCompetenceEntity>(model);
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
    }
}
