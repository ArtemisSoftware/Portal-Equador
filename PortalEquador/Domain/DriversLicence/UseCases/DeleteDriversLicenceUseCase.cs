using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.DriversLicence.ViewModels;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.DriversLicence.UseCases
{
    public class DeleteDriversLicenceUseCase(
        IDriversLicenceRepository driversLicenceRepository, 
        IDocumentRepository documentRepository
        )
    {

        public async Task Invoke(int driversLicenceId, int personaInformationId)
        {
            await driversLicenceRepository.DeleteAsync(driversLicenceId);

            var provisionalDocument = await documentRepository.GetDocumentByParentId(driversLicenceId, ItemFromGroup.Documents.DRIVERS_LICENCE_PROVISIONAL);

            if (provisionalDocument != null)
            {
                await documentRepository.DeleteDocument(personaInformationId, provisionalDocument);
            }

            var driversLicence = await documentRepository.GetDocumentByParentId(driversLicenceId, ItemFromGroup.Documents.DRIVERS_LICENCE);

            if (driversLicence != null)
            {
                await documentRepository.DeleteDocument(personaInformationId, driversLicence);
            }
        }
    }
}