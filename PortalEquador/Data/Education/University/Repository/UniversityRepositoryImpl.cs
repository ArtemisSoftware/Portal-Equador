using AutoMapper;
using PortalEquador.Data.DriversLicence.Entity;
using PortalEquador.Data.Education.University.Entity;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.Education.University.Repository;
using PortalEquador.Domain.Education.University.ViewModels;

namespace PortalEquador.Data.Education.University.Repository
{
    public class UniversityRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<UniversityEntity>(context, httpContextAccessor), IUniversityRepository
    {
        Task<List<UniversityDetailViewModel>> IUniversityRepository.GetAll(int personalInformationId)
        {
            throw new NotImplementedException();
        }

        Task<UniversityViewModel> IUniversityRepository.GetCreateModel(int personalInformationId, string fullName)
        {
            throw new NotImplementedException();
        }

        Task<UniversityViewModel> IUniversityRepository.GetCreateModel(UniversityViewModel model)
        {
            throw new NotImplementedException();
        }

        Task<UniversityViewModel> IUniversityRepository.GetUniversity(int id)
        {
            throw new NotImplementedException();
        }

        Task IUniversityRepository.Save(UniversityViewModel model)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUniversityRepository.UniversityExists(int personalInformationId, int universityId)
        {
            throw new NotImplementedException();
        }
    }
}
