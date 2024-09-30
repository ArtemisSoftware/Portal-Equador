using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.DriversLicence.ViewModels;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.DriversLicence.UseCases
{
    public class RenewDriversLicenceUseCase(IDriversLicenceRepository driversLicenceRepository, IDocumentRepository documentRepository)
    {

        public async Task Invoke(DriversLicenceRenewViewModel model)
        {
            var driversLicenceId = await driversLicenceRepository.Save(model);
            var provisionalDocument = await documentRepository.GetDocumentByParentId(driversLicenceId, ItemFromGroup.Documents.DRIVERS_LICENCE_PROVISIONAL);

            if (provisionalDocument != null)
            {
                await documentRepository.DeleteDocument(model.PersonaInformationId, provisionalDocument);
            }
        }
    }
}