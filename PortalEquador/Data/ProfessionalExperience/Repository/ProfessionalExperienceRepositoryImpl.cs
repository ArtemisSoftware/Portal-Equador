using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.ProfessionalCompetence.Entities;
using PortalEquador.Data.ProfessionalExperience.Entities;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.ProfessionalCompetence.Repository;
using PortalEquador.Domain.ProfessionalExperience.Repository;
using PortalEquador.Domain.ProfessionalExperience.ViewModels;
using PortalEquador.Domain.UseCases;
using PortalEquador.Repositories;

namespace PortalEquador.Data.ProfessionalExperience.Repository
{
    public class ProfessionalExperienceRepositoryImpl : GenericRepository<ProfessionalExperienceEntity>, ProfessionalExperienceRepository
    {
        private readonly IMapper _mapper;

        public ProfessionalExperienceRepositoryImpl(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public  async Task<List<ProfessionalExperienceDetailViewModel>> GetAll(int personalInformationId)
        {
            var result = await context.ProfessionalExperienceEntity
                 .Include(d => d.WorkstationGroupItemEntity)
                .Include(d => d.CompanyGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .Where(item => item.PersonalInformationId == personalInformationId)
                .ToListAsync();

            return _mapper.Map<List<ProfessionalExperienceDetailViewModel>>(result);
        }

        public async Task<ProfessionalExperienceDetailViewModel> GetDetail(int id)
        {
            var result = await context.ProfessionalExperienceEntity
                .Include(d => d.CompanyGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .Where(item => item.Id == id)
                .ToListAsync();

            return _mapper.Map<ProfessionalExperienceDetailViewModel>(result);
        }

        public async Task<bool> Exists(int personalInformationId, int companyId, int workstationId)
        {
            return await context.ProfessionalExperienceEntity.AnyAsync(item => item.PersonalInformationId == personalInformationId & item.CompanyId == companyId & item.WorkstationId == workstationId);
        }

        public async Task Save(ProfessionalExperienceViewModel model)
        {

            var entity = _mapper.Map<ProfessionalExperienceEntity>(model);
            entity.Months = model.Years * 12 + model.Months;

            var operationType = OperationType.Create;
            if (entity.Id != 0)
            {
                operationType = OperationType.Update;
            }

            switch (operationType)
            {
                case OperationType.Create:

                    await AddAsync(entity);
                    break;
                case OperationType.Update:

                    entity.DateModified = DateTime.UtcNow;
                    await UpdateAsync(entity);
                    break;
            }
        }

        public async Task<ProfessionalExperienceViewModel> Get(int id)
        {
            var result = await context.ProfessionalExperienceEntity
               .Include(d => d.PersonalInformationEntity)
               .Include(d => d.CompanyGroupItemEntity)
               .Include(d => d.WorkstationGroupItemEntity)
               .Where(item => item.Id == id).FirstAsync();

            return _mapper.Map<ProfessionalExperienceViewModel>(result);
        }
    }
}
