using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.DriversLicence.ViewModels;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.DriversLicence.UseCases
{
    public class RenewDriversLicenceUseCase(IDriversLicenceRepository driversLicenceRepository, IDocumentRepository documentRepository)
    {

        public async Task Invoke(DriversLicenceViewModel model)
        {
            model.ProvisionalExpirationDate = null;
            model.ProvisionalRenewalNumber = null;

            await driversLicenceRepository.Save(model);
            //await documentRepository.
        }


    }
}