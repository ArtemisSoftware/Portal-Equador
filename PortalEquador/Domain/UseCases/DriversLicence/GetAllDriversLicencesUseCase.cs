using AutoMapper;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Domain.Repositories;

namespace PortalEquador.Domain.UseCases.DriversLicence
{
    public class GetAllDriversLicencesUseCase
    {
        private readonly DriversLicenceRepository _driversLicenceRepository;

        public GetAllDriversLicencesUseCase(DriversLicenceRepository driversLicenceRepository)
        {
            _driversLicenceRepository = driversLicenceRepository;
        }

        public async Task<List<DriversLicenceViewModel>> Invoke()
        {
            return await _driversLicenceRepository.GetAllDriversLicenceAsync();
        }
    }
}
