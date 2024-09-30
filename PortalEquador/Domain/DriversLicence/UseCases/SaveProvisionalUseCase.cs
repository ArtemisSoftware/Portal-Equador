using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Util;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.DriversLicence.UseCases
{
    public class SaveProvisionalUseCase(IDriversLicenceRepository driversLicenceRepository, IDocumentRepository documentRepository)
    {
        public async Task Invoke(DriversLicenceProvisionalViewModel model)
        {
            var driversLicenceId = await driversLicenceRepository.Save(model);
            var provisionalDocument = await documentRepository.GetDocumentByParentId(driversLicenceId, ItemFromGroup.Documents.DRIVERS_LICENCE_PROVISIONAL);
            await SaveDocument(model.ImageFile, model.PersonaInformationId, model.FullName, model.LicenceId, driversLicenceId, GetDocumentId(provisionalDocument));
        }

        public async Task Invoke(DriversLicenceProvisionalRenewViewModel model)
        {
            var driversLicenceId = await driversLicenceRepository.Save(model);
            var provisionalDocument = await documentRepository.GetDocumentByParentId(driversLicenceId, ItemFromGroup.Documents.DRIVERS_LICENCE_PROVISIONAL);
            await SaveDocument(model.ImageFile, model.PersonaInformationId, model.FullName, model.LicenceId, driversLicenceId, GetDocumentId(provisionalDocument));
        }

        private int GetDocumentId(DocumentViewModel? model)
        {
            if(model == null)
            {
                return 0;
            }
            else
            {
                return model.Id;
            }
        }

        private async Task SaveDocument(IFormFile? imageFIle, int personaInformationId, string fullName, int licenceId,   int driversLicenceId, int documentId)
        {
            if (imageFIle != null)
            {
                var document = new DocumentViewModel
                {
                    PersonaInformationId = personaInformationId,
                    FullName = fullName,
                    ImageFile = imageFIle,
                    DocumentTypeId = ItemFromGroup.Documents.DRIVERS_LICENCE_PROVISIONAL,
                    SubTypeId = licenceId,
                    ParentId = driversLicenceId,
                };
                await documentRepository.DeleteAsync(documentId);
                await documentRepository.Save(document, Util.EnumTypes.FolderType.DriversLicence);
            }
        }
    }
}
