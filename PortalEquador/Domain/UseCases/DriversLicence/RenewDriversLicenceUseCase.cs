using AutoMapper;
using PortalEquador.Constants;
using PortalEquador.Contracts;
using PortalEquador.Domain.Models.Document;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Domain.Repositories;
using PortalEquador.Repositories;
using System;

namespace PortalEquador.Domain.UseCases.DriversLicence
{
    public class RenewDriversLicenceUseCase
    {
        private readonly IMapper _mapper;
        private readonly DriversLicenceRepository _driversLicenceRepository;
        private readonly IDocumentRepository _documentRepository;

        public RenewDriversLicenceUseCase(
            DriversLicenceRepository driversLicenceRepository,
            IDocumentRepository documentRepository,
            IMapper mapper)
        {
            _driversLicenceRepository = driversLicenceRepository;
            _documentRepository = documentRepository;
            _mapper = mapper;
        }

        public async Task Invoke(DriversLicenceViewModel__ model)
        {
            model.ProvisionalExpirationDate = null;
            model.ProvisionalRenewalNumber = null;

            await _driversLicenceRepository.RenewLicence(model);

            DocumentViewModel? document = model.Documents.FirstOrDefault(p => p.GroupItemId == ItemFromGroup.Documents.PROVISIONAL_DRIVERS_LICENCE);

            if (document != null)
            {
                File.Delete(document.FilePath);
                await _documentRepository.DeleteAsync(document.Id);
             }
        }
    }
}
