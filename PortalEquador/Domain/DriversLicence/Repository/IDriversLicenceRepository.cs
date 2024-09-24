using PortalEquador.Data.DriversLicence.Entity;
using PortalEquador.Data.Profession.Competence.Entity;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.Profession.Competence.ViewModels;
using PortalEquador.Util;

namespace PortalEquador.Domain.DriversLicence.Repository
{
    public interface IDriversLicenceRepository : IGenericRepository<DriversLicenceEntity>
    {
        Task<List<DriversLicenceDetailViewModel>> GetAll(int personalInformationId);
        Task<DriversLicenceViewModel> GetCreateModel(int personalInformationId, string fullName);
        Task<DriversLicenceViewModel> GetCreateModel(DriversLicenceViewModel model);
        Task<DriversLicenceDetailViewModel> GetDriversLicence(int id);
        Task Save(DriversLicenceViewModel model);
        Task<bool> LicenceExists(int personalInformationId, int licenceTypeId);

    }
}