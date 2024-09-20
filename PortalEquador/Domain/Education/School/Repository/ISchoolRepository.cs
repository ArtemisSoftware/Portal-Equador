using PortalEquador.Data.Education.School.Entity;
using PortalEquador.Data.Education.University.Entity;
using PortalEquador.Domain.Education.School.ViewModels;
using PortalEquador.Domain.Education.University.ViewModels;
using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Education.School.Repository
{
    public interface ISchoolRepository : IGenericRepository<SchoolEntity>
    {
        Task<List<SchoolDetailViewModel>> GetAll(int personalInformationId);
        Task<SchoolViewModel> GetCreateModel(int personalInformationId, string fullName);
        Task<SchoolViewModel> GetCreateModel(SchoolViewModel model);
        Task Save(SchoolViewModel model);
        Task<bool> SchoolExists(int personalInformationId, int schoolId, int courseId);
        Task<SchoolViewModel> GetSchool(int id);
    }
}
