using AutoMapper;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.Repositories;

namespace PortalEquador.Domain.DriversLicence.UseCases
{
    public class GetAllDriversLicencesUseCase
    {
        private readonly DriversLicenceRepository _driversLicenceRepository;

        public GetAllDriversLicencesUseCase(DriversLicenceRepository driversLicenceRepository)
        {
            _driversLicenceRepository = driversLicenceRepository;
        }

        public async Task<List<DriversLicenceDetailViewModel>> Invoke()
        {
            return await _driversLicenceRepository.GetAllDriversLicenceAsync();
        }
    }
}
