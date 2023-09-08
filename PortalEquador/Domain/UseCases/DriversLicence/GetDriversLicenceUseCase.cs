using PortalEquador.Constants;
using PortalEquador.Domain.Documents.Repository;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.DriversLicence;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.Repositories;
using System;
using static PortalEquador.Constants.ItemFromGroup;

namespace PortalEquador.Domain.UseCases.DriversLicence
{
    public class GetDriversLicenceUseCase
    {
        private readonly DriversLicenceRepository _driversLicenceRepository;
        private readonly DocumentRepository _documentRepository;

        public GetDriversLicenceUseCase(DriversLicenceRepository driversLicenceRepository, DocumentRepository documentRepository)
        {
            _driversLicenceRepository = driversLicenceRepository;
            _documentRepository = documentRepository;
        }

        public async Task<DriversLicenceViewModel_Finak> Invoke(int id)
        {

            var documents = await _documentRepository.GetDocumentsDetails(id, DriverLicenceUtil.DocumentIds());
            var model = await _driversLicenceRepository.GetDriversLicenceAsync(id);
            model.Documents = documents;

            var driverLicence = documents.Find(item => item.Document.Id == ItemFromGroup.Documents.DRIVERS_LICENCE);
            if (driverLicence != null)
            {
                model.DriverLicenceDocumentId = driverLicence.Id;
            }

            var provisionalLicence = documents.Find(item => item.Document.Id == ItemFromGroup.Documents.PROVISIONAL_DRIVERS_LICENCE);
            if (provisionalLicence != null)
            {
                model.ProvisionalLicenceDocumentId = provisionalLicence.Id;
            }

            return model;
        }
    }
}