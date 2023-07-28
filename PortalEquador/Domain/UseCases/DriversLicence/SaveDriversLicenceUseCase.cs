using AutoMapper;
using PortalEquador.Data.DriversLicence.Entities;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Domain.Repositories;

namespace PortalEquador.Domain.UseCases.DriversLicence
{
    public class SaveDriversLicenceUseCase
    {
        private readonly IMapper _mapper;
        private readonly DriversLicenceRepository _driversLicenceRepository;

        public SaveDriversLicenceUseCase(DriversLicenceRepository driversLicenceRepository, IMapper mapper)
        {
            _driversLicenceRepository = driversLicenceRepository;
            _mapper = mapper;
        }

        public async Task Invoke(DriversLicenceCreateViewModel model)
        {
            DriversLicenceEntity entity = _mapper.Map<DriversLicenceEntity>(model);
            await _driversLicenceRepository.AddAsync(entity);
        }
    }
}
