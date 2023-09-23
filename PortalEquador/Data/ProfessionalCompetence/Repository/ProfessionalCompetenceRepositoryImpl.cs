using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PortalEquador.Data.Document.Entities;
using PortalEquador.Data.ProfessionalCompetence.Entities;
using PortalEquador.Domain.CurriculumVitae.ViewModels;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.ProfessionalCompetence.Repository;
using PortalEquador.Domain.ProfessionalCompetence.ViewModels;
using PortalEquador.Domain.UseCases;
using PortalEquador.Repositories;
using PortalEquador.Util;

namespace PortalEquador.Data.ProfessionalCompetence.Repository
{
    public class ProfessionalCompetenceRepositoryImpl : GenericRepository<ProfessionalCompetenceEntity>, ProfessionalCompetenceRepository
    {
        private readonly IMapper _mapper;

        public ProfessionalCompetenceRepositoryImpl(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<ProfessionalCompetenceResumeViewModel>> GetAll()
        {
            var query = from personal in context.PersonalInformationEntity

                        join competences in
                            (from competences in context.ProfessionalCompetenceEntity
                             group competences by competences.PersonalInformationId into grouped
                             select new
                             {
                                 PersonalInformationId = grouped.Key,
                                 Registers = grouped.Count()
                             })
                        on personal.Id equals competences.PersonalInformationId into resultCompetences
                        from personalCompetences in resultCompetences.DefaultIfEmpty()
                       
                        select new ProfessionalCompetenceResumeViewModel
                        {
                            PersonalInformationId = personalCompetences.PersonalInformationId,
                            FullName = personal.FirstName + " " + personal.LastName,
                            TotalRegisters = personalCompetences.Registers == null ? 0 : personalCompetences.Registers
                        };

            return await query.ToListAsync();

        }


        public async Task<List<ProfessionalCompetenceDetailViewModel>> GetAll(int personalInformationId)
        {
            var result = await context.ProfessionalCompetenceEntity
                .Include(d => d.CompetenceGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .Where(item => item.PersonalInformationId == personalInformationId)
                .ToListAsync();

            return _mapper.Map<List<ProfessionalCompetenceDetailViewModel>>(result);
        }

        public async Task<ProfessionalCompetenceDetailViewModel> GetDetail(int id)
        {
            var result = await context.ProfessionalCompetenceEntity
                .Include(d => d.CompetenceGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .Where(item => item.Id == id)
                .ToListAsync();

            return _mapper.Map<ProfessionalCompetenceDetailViewModel>(result);
        }

        public async Task<bool> Exists(int personalInformationId, int competenceId)
        {
            return await context.ProfessionalCompetenceEntity.AnyAsync(item => item.PersonalInformationId == personalInformationId & item.CompetenceId == competenceId);
        }

        public async Task Save(ProfessionalCompetenceViewModel model)
        {

            var entity = _mapper.Map<ProfessionalCompetenceEntity>(model);

            var operationType = OperationType.Create;
            if(entity.Id != 0)
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

        public async Task<ProfessionalCompetenceViewModel> Get(int id)
        {
            var result = await context.ProfessionalCompetenceEntity
               .Include(d => d.PersonalInformationEntity)
               .Include(d => d.CompetenceGroupItemEntity)
               .Where(item => item.Id == id).FirstAsync();

            return _mapper.Map<ProfessionalCompetenceViewModel>(result);
        }
    }
}
