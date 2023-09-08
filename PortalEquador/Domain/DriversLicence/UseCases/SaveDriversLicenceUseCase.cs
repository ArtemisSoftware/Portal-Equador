using AutoMapper;
using PortalEquador.Constants;
using PortalEquador.Domain.Documents.Repository;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Domain.Repositories;
using PortalEquador.Domain.UseCases;

namespace PortalEquador.Domain.DriversLicence.UseCases
{
    public class SaveDriversLicenceUseCase
    {
        private readonly DriversLicenceRepository _driversLicenceRepository;
        private readonly DocumentRepository _documentRepository;

        public SaveDriversLicenceUseCase(
            DriversLicenceRepository driversLicenceRepository,
            DocumentRepository documentRepository
            )
        {
            _driversLicenceRepository = driversLicenceRepository;
            _documentRepository = documentRepository;
        }

        public async Task Invoke(DriversLicenceViewModel_Finak model, OperationType operationType)
        {
            await SaveDocument(model, operationType);
            await _driversLicenceRepository.Save(model, operationType);
        }

        private async Task SaveDocument(DriversLicenceViewModel_Finak model, OperationType operationType)
        {
            if (model.ImageFile != null)
            {
                var document = new DocumentViewModel
                {
                    PersonaInformationId = model.PersonaInformationId,
                    ImageFile = model.ImageFile,
                    DocumentTypeId = ItemFromGroup.Documents.DRIVERS_LICENCE
                };

                if (operationType == OperationType.Update && model.DriverLicenceDocumentId != null)
                {
                    document.Id = (int)model.DriverLicenceDocumentId;
                }

                await _documentRepository.SaveDocument(document);
            }
        }
    }
}
