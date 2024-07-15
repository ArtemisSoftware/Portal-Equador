using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.ProfessionalExperience.Entities;
using PortalEquador.Data.School.Entity;
using PortalEquador.Data.University.Entity;
using PortalEquador.Domain.ProfessionalExperience.ViewModels;
using PortalEquador.Domain.School.Repository;
using PortalEquador.Domain.School.ViewModels;
using PortalEquador.Domain.University.Repository;
using PortalEquador.Domain.UseCases;
using PortalEquador.Repositories;

namespace PortalEquador.Data.School.Repository
{
    public class SchoolRepositoryImpl : GenericRepository<SchoolEntity>, SchoolRepository
    {
        private readonly IMapper _mapper;

        public SchoolRepositoryImpl(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }


        public async Task<SchoolViewModel> Get(int id)
        {
            var result = await context.SchoolEntity
               .Include(d => d.PersonalInformationEntity)
               .Include(d => d.DegreeGroupItemEntity)
               .Include(d => d.InstitutionGroupItemEntity)
               .Where(item => item.Id == id).FirstAsync();

            return _mapper.Map<SchoolViewModel>(result);
        }

        public async Task Save(SchoolViewModel model)
        {

            var entity = _mapper.Map<SchoolEntity>(model);

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