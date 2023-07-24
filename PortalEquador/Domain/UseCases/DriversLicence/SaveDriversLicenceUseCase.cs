using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PortalEquador.Contracts;
using PortalEquador.Data.DriversLicence.Entities;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Domain.Repositories;
using PortalEquador.Models.Documents;
using PortalEquador.Repositories;

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
