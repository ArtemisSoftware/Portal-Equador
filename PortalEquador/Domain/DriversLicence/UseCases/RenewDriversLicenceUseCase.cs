using AutoMapper;
using PortalEquador.Domain.Documents.Repository;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.Repositories;
using PortalEquador.Domain.UseCases;

namespace PortalEquador.Domain.DriversLicence.UseCases
{
    public class RenewDriversLicenceUseCase
    {
        private readonly IMapper _mapper;
        private readonly DriversLicenceRepository _driversLicenceRepository;
        private readonly DocumentRepository _documentRepository;

        public RenewDriversLicenceUseCase(
            DriversLicenceRepository driversLicenceRepository,
            DocumentRepository documentRepository,
            IMapper mapper)
        {
            _driversLicenceRepository = driversLicenceRepository;
            _documentRepository = documentRepository;
            _mapper = mapper;
        }

        public async Task Invoke(DriversLicenceViewModel_Finak model)
        {
            
            model.ProvisionalExpirationDate = null;
            model.ProvisionalRenewalNumber = null;
            await _driversLicenceRepository.Save(model, OperationType.Update);
        }
    }
}
