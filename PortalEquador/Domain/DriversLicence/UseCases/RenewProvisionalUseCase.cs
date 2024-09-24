using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Util;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.DriversLicence.UseCases
{
    public class RenewProvisionalUseCase(IDriversLicenceRepository driversLicenceRepository, IDocumentRepository documentRepository)
    {
        public async Task Invoke(DriversLicenceViewModel model)
        {
            var renewalNumber = 1;
            if (model.ProvisionalRenewalNumber != null)
            {
                renewalNumber = (int)model.ProvisionalRenewalNumber + 1;
            }

            model.ProvisionalRenewalNumber = renewalNumber;
            await driversLicenceRepository.Save(model);
            await SaveDocument(model);
        }

        private async Task SaveDocument(DriversLicenceViewModel model)
        {
            if (model.ImageFile != null)
            {
                var document = new DocumentViewModel
                {
                    PersonaInformationId = model.PersonaInformationId,
                    FullName = model.FullName, 
                    ImageFile = model.ImageFile,
                    DocumentTypeId = ItemFromGroup.Documents.DRIVERS_LICENCE_PROVISIONAL
                };
                /*
                if (model.ProvisionalLicenceDocumentId != null)
                {
                    document.Id = (int)model.ProvisionalLicenceDocumentId;
                }

                await _documentRepository.SaveDocument(document);
                */
            }
        }
    }
}
