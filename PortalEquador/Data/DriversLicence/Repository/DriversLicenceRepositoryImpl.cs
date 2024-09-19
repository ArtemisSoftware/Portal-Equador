using AutoMapper;
using PortalEquador.Data.DriversLicence.Entity;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.Languages.Repository;

namespace PortalEquador.Data.DriversLicence.Repository
{
    public class DriversLicenceRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<DriversLicenceEntity>(context, httpContextAccessor), IDriversLicenceRepository
    {
        Task<List<DriversLicenceDetailViewModel>> IDriversLicenceRepository.GetAll(int personalInformationId)
        {
            throw new NotImplementedException();
        }

        Task<DriversLicenceViewModel> IDriversLicenceRepository.GetCreateModel(int personalInformationId, string fullName)
        {
            throw new NotImplementedException();
        }

        Task<DriversLicenceViewModel> IDriversLicenceRepository.GetCreateModel(DriversLicenceViewModel model)
        {
            throw new NotImplementedException();
        }

        Task<DriversLicenceDetailViewModel> IDriversLicenceRepository.GetDriversLicence(int id)
        {
            throw new NotImplementedException();
        }

        Task IDriversLicenceRepository.Save(DriversLicenceViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
