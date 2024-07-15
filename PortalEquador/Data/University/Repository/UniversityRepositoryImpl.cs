using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.ProfessionalExperience.Entities;
using PortalEquador.Data.University.Entity;
using PortalEquador.Domain.ProfessionalExperience.Repository;
using PortalEquador.Domain.ProfessionalExperience.ViewModels;
using PortalEquador.Domain.University.Repository;
using PortalEquador.Domain.University.ViewModels;
using PortalEquador.Domain.UseCases;
using PortalEquador.Repositories;

namespace PortalEquador.Data.University.Repository
{
    public class UniversityRepositoryImpl : GenericRepository<UniversityEntity>, UniversityRepository
    {
        private readonly IMapper _mapper;

        public UniversityRepositoryImpl(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<UniversityViewModel> Get(int id)
        {
            var result = await context.UniversityEntity
               .Include(d => d.PersonalInformationEntity)
               .Include(d => d.DegreeGroupItemEntity)
               .Include(d => d.InstitutionGroupItemEntity)
               .Where(item => item.Id == id).FirstAsync();

            return _mapper.Map<UniversityViewModel>(result);
        }

        public async Task<List<UniversityDetailViewModel>> GetAll(int personalInformationId)
        {
            var result = await context.UniversityEntity
               .Include(d => d.PersonalInformationEntity)
               .Include(d => d.DegreeGroupItemEntity)
               .Include(d => d.InstitutionGroupItemEntity)
               .Where(item => item.PersonalInformationId == personalInformationId)
                .ToListAsync();

            return _mapper.Map<List<UniversityDetailViewModel>>(result);
        }

        public async Task Save(UniversityViewModel model)
        {

            var entity = _mapper.Map<UniversityEntity>(model);

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
    }
}
