using AutoMapper;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Domain.Repositories;
using PortalEquador.Data.DriversLicence.Entities;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;

namespace PortalEquador.Domain.UseCases.DriversLicence
{
    public class SaveDriversLicenceUseCase__
    {
        private readonly IMapper _mapper;
        private readonly DriversLicenceRepository _driversLicenceRepository;

        public SaveDriversLicenceUseCase__(DriversLicenceRepository driversLicenceRepository, IMapper mapper)
        {
            _driversLicenceRepository = driversLicenceRepository;
            _mapper = mapper;
        }

        public async Task Invoke(DriversLicenceViewModel__ model, OperationType type)
        {
            DriversLicenceEntity entity = _mapper.Map<DriversLicenceEntity>(model);

            switch (type)
            {
                case OperationType.Create:
                    // Code to execute if expression matches value1
                    break;
                case OperationType.Update:
                    await _driversLicenceRepository.UpdateAsync(entity);
                    break;
                // Add more cases as needed
                default:
                    // Code to execute if expression doesn't match any case
                    break;
            }

        }
    }
}
