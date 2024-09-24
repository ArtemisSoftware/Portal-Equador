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
                    DocumentTypeId = ItemFromGroup.Documents.DRIVERS_LICENCE
                };

                await documentRepository.Save(document);
            }
        }

    }
}
