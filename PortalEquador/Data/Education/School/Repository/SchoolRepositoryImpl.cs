using AutoMapper;
using PortalEquador.Data.Education.School.Entity;
using PortalEquador.Data.Education.University.Entity;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Education.School.Repository;
using PortalEquador.Domain.Education.School.ViewModels;
using PortalEquador.Domain.Education.University.Repository;

namespace PortalEquador.Data.Education.School.Repository
{
    public class SchoolRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<SchoolEntity>(context, httpContextAccessor), ISchoolRepository
    {
        Task<List<SchoolDetailViewModel>> ISchoolRepository.GetAll(int personalInformationId)
        {
            throw new NotImplementedException();
        }

        Task<SchoolViewModel> ISchoolRepository.GetCreateModel(int personalInformationId, string fullName)
        {
            throw new NotImplementedException();
        }

        Task<SchoolViewModel> ISchoolRepository.GetCreateModel(SchoolViewModel model)
        {
            throw new NotImplementedException();
        }

        Task<SchoolViewModel> ISchoolRepository.GetSchool(int id)
        {
            throw new NotImplementedException();
        }

        Task ISchoolRepository.Save(SchoolViewModel model)
        {
            throw new NotImplementedException();
        }

        Task<bool> ISchoolRepository.SchoolExists(int personalInformationId, int universityId)
        {
            throw new NotImplementedException();
        }
    }
}
