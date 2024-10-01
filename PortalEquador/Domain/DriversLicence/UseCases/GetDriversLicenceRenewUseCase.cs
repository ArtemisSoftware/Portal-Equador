using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.DriversLicence.ViewModels;
using static PortalEquador.Util.Constants.GroupTypesConstants.ItemFromGroup;

namespace PortalEquador.Domain.DriversLicence.UseCases
{
    public class GetDriversLicenceRenewUseCase(IDriversLicenceRepository driversLicenceRepository, IDocumentRepository documentRepository)
    {
        public async Task<DriversLicenceRenewViewModel> Invoke(int id)
        {
            var model = await driversLicenceRepository.GetDriversLicenceRenew(id);
            model.Documents = await documentRepository.GetDocumentByParentId(model.Id, Documents.GetDriversLicenceDocuments());
            return model;
        }
    }
}
