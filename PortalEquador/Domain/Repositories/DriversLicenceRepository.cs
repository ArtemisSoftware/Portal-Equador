using PortalEquador.Contracts;
using PortalEquador.Data.DriversLicence.Entities;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.UseCases;

namespace PortalEquador.Domain.Repositories
{
    public interface DriversLicenceRepository : IGenericRepository<DriversLicenceEntity>
    {

        public Task Save(DriversLicenceViewModel_Finak model, OperationType operationType);

        public Task<DriversLicenceDetailViewModel> GetDriversLicenceDetailAsync(int curriculumId);

        public Task<DriversLicenceViewModel_Finak> GetDriversLicenceAsync(int curriculumId);

        public Task<List<DriversLicenceDetailViewModel>> GetAllDriversLicenceAsync();

    }
}
