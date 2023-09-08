using AutoMapper;
using PortalEquador.Constants;
using PortalEquador.Domain.Documents.Repository;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.Repositories;
using PortalEquador.Domain.UseCases;

namespace PortalEquador.Domain.DriversLicence.UseCases
{
    public class RenewProvisionalUseCase
    {
        private readonly DriversLicenceRepository _driversLicenceRepository;
        private readonly DocumentRepository _documentRepository;

        public RenewProvisionalUseCase(
            DriversLicenceRepository driversLicenceRepository,
            DocumentRepository documentRepository,
            IMapper mapper)
        {
            _driversLicenceRepository = driversLicenceRepository;
            _documentRepository = documentRepository;
        }

        public async Task Invoke(DriversLicenceViewModel_Finak model)
        {

            var renewalNumber = 1;
            if(model.ProvisionalRenewalNumber != null)
            {
                renewalNumber = (int)model.ProvisionalRenewalNumber + 1;
            }

            model.ProvisionalRenewalNumber = renewalNumber;
            await _driversLicenceRepository.Save(model, OperationType.Update);
            await SaveDocument(model);
        }

        private async Task SaveDocument(DriversLicenceViewModel_Finak model)
        {
            if (model.ImageFile != null)
            {
                var document = new DocumentViewModel
                {
                    PersonaInformationId = model.PersonaInformationId,
                    ImageFile = model.ImageFile,
                    DocumentTypeId = ItemFromGroup.Documents.PROVISIONAL_DRIVERS_LICENCE
                };

                if (model.ProvisionalLicenceDocumentId != null)
                {
                    document.Id = (int)model.ProvisionalLicenceDocumentId;
                }

                await _documentRepository.SaveDocument(document);
            }
        }
    }
}