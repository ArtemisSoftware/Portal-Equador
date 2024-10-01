using PortalEquador.Data.DriversLicence.Entity;
using PortalEquador.Data.Profession.Competence.Entity;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.Profession.Competence.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.EnumTypes;

namespace PortalEquador.Domain.DriversLicence.Repository
{
    public interface IDriversLicenceRepository : IGenericRepository<DriversLicenceEntity>
    {
        Task<List<DriversLicenceDetailViewModel>> GetAll(int personalInformationId);
        Task<DriversLicenceViewModel> GetCreateModel(int personalInformationId, string fullName);
        Task<DriversLicenceViewModel> GetCreateModel(DriversLicenceViewModel model);
        Task<DriversLicenceDetailViewModel> GetDriversLicenceDetail(int id);
        Task<DriversLicenceProvisionalViewModel> GetDriversLicenceProvisional(int id);
        Task<DriversLicenceProvisionalRenewViewModel> GetDriversLicenceProvisionalRenew(int id);
        Task<DriversLicenceRenewViewModel> GetDriversLicenceRenew(int id);
        Task<DriversLicenceViewModel> GetDriversLicence(int id);
        Task<int> Save(DriversLicenceViewModel model);
        Task<int> Save(DriversLicenceRenewViewModel model);
        Task<int> Save(DriversLicenceProvisionalViewModel model);
        Task<int> Save(DriversLicenceProvisionalRenewViewModel model);
        Task<bool> LicenceExists(int personalInformationId, int licenceTypeId);

    }
}