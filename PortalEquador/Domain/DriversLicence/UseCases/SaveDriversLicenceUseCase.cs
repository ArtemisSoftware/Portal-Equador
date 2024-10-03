using Microsoft.CodeAnalysis;
using NuGet.Packaging.Signing;
using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Util;
using System.Xml.XPath;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.DriversLicence.UseCases
{
    public class SaveDriversLicenceUseCase(IDriversLicenceRepository driversLicenceRepository, IDocumentRepository documentRepository)
    {

        public async Task Invoke(DriversLicenceViewModel model)
        {
           var driversLicenceId = await driversLicenceRepository.Save(model);
            var document = await documentRepository.GetDocumentByParentId(driversLicenceId, ItemFromGroup.Documents.DRIVERS_LICENCE);

            await SaveDocument(model, driversLicenceId, document);
        }

        private int GetDocumentId(DocumentViewModel? model)
        {
            if (model == null)
            {
                return 0;
            }
            else
            {
                return model.Id;
            }
        }

        private async Task SaveDocument(DriversLicenceViewModel model, int driversLicenceId, DocumentViewModel? document)
        {
            if (model.ImageFile != null)
            {
                if (document == null)
                {
                    document = new DocumentViewModel
                    {
                        PersonaInformationId = model.PersonaInformationId,
                        FullName = model.FullName,
                        ImageFile = model.ImageFile,
                        DocumentTypeId = ItemFromGroup.Documents.DRIVERS_LICENCE,
                        SubTypeId = model.LicenceId,
                        ParentId = driversLicenceId,
                        Extension = ImagesUtil.GetImageExtension(model.ImageFile)
                    };
                }
                else
                {
                    document.ImageFile = model.ImageFile;
                    document.Extension = ImagesUtil.GetImageExtension(model.ImageFile);
                }

                await documentRepository.Save(document, Util.EnumTypes.FolderType.DriversLicence);
            }
        }

    }
}
