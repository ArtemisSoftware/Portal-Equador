using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.ProfessionalCompetence.Entities;
using PortalEquador.Data.ProfessionalExperience.Entities;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.ProfessionalCompetence.Repository;
using PortalEquador.Domain.ProfessionalExperience.Repository;
using PortalEquador.Domain.ProfessionalExperience.ViewModels;
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

        public  async Task<List<ProfessionalExperienceDetailViewModel>> GetAllProfessionalExperience(int personalInformationId)
        {
            var result = await context.ProfessionalExperienceEntity
                .Include(d => d.CompanyGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .Where(item => item.PersonalInformationId == personalInformationId)
                .ToListAsync();

            return _mapper.Map<List<ProfessionalExperienceDetailViewModel>>(result);
        }
    }
}
