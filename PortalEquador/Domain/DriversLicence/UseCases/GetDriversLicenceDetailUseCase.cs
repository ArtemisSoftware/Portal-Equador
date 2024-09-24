using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.DriversLicence.ViewModels;

namespace PortalEquador.Domain.DriversLicence.UseCases
{
    public class GetDriversLicenceDetailUseCase(IDriversLicenceRepository driversLicenceRepository, IDocumentRepository documentRepository)
    {
        public async Task<DriversLicenceDetailViewModel> Invoke(int id)
        {
            var model = await driversLicenceRepository.GetDriversLicence(id);
            //model.Documents = await documentRepository.GetAllDocuments GetDocumentsDetails(personalInformationId, DriverLicenceUtil.DocumentIds());
            return model;
        }
    }
}
