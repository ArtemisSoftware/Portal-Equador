using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Util;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.DriversLicence.UseCases
{
    public class SaveDriversLicenceUseCase(IDriversLicenceRepository driversLicenceRepository, IDocumentRepository documentRepository)
    {

        public async Task Invoke(DriversLicenceViewModel model)
        {
           var driversLicenceId = await driversLicenceRepository.Save(model);
            await SaveDocument(model, driversLicenceId);
        }

        private async Task SaveDocument(DriversLicenceViewModel model, int driversLicenceId)
        {
            if (model.ImageFile != null)
            {
                var document = new DocumentViewModel
                {
                    PersonaInformationId = model.PersonaInformationId,
                    FullName = model.FullName,
                    ImageFile = model.ImageFile,
                    DocumentTypeId = ItemFromGroup.Documents.DRIVERS_LICENCE,
                    SubTypeId = model.LicenceId,
                    ParentId = driversLicenceId,
                    Extension = ImagesUtil.GetImageExtension(model.ImageFile)
                };

                await documentRepository.Save(document, Util.EnumTypes.FolderType.DriversLicence);
            }
        }

    }
}
