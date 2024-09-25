using PortalEquador.Data.Education.University.Entity;
using PortalEquador.Data.Profession.Competence.Entity;
using PortalEquador.Domain.Education.University.ViewModels;
using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Education.University.Repository
{
    public interface IUniversityRepository : IGenericRepository<UniversityEntity>
    {
        Task<List<UniversityDetailViewModel>> GetAll(int personalInformationId);
        Task<UniversityViewModel> GetCreateModel(int personalInformationId, string fullName);
        Task<UniversityViewModel> GetCreateModel(UniversityViewModel model);
        Task Save(UniversityViewModel model);
        Task<bool> UniversityExists(int personalInformationId, int institutionId, int majorId, int degreeId);
        Task<UniversityViewModel> GetUniversity(int id);
    }
}
