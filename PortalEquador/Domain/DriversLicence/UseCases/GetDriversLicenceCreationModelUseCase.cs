using PortalEquador.Constants;
using PortalEquador.Domain.Documents.Repository;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.PersonalInformation.Repository;

namespace PortalEquador.Domain.DriversLicence.UseCases
{
    public class GetDriversLicenceCreationModelUseCase
    {
        private readonly PersonalInformationRepository personalInformationRepository;
        private readonly DocumentRepository documentRepository;

        public GetDriversLicenceCreationModelUseCase(PersonalInformationRepository personalInformationRepository, DocumentRepository documentRepository)
        {
            this.personalInformationRepository = personalInformationRepository;
            this.documentRepository = documentRepository;
        }

        public async Task<DriversLicenceViewModel_Finak> Invoke(int id)
        {

            var licenceTypes = personalInformationRepository.GroupItems(Groups.DRIVERS_LICENCE);
            var personalInformation = await personalInformationRepository.GetPersonalInformationAsync(id);
            List<int> documentsId = new List<int>();
            documentsId.Add(ItemFromGroup.Documents.DRIVERS_LICENCE);
            documentsId.Add(ItemFromGroup.Documents.PROVISIONAL_DRIVERS_LICENCE);
            var documents = await documentRepository.GetDocumentsDetails(id, documentsId);

            int? driverLicenceDocumentId = null;
            var driverLicence = documents.Find(item => item.Document.Id == ItemFromGroup.Documents.DRIVERS_LICENCE);
            if(driverLicence != null)
            {
                driverLicenceDocumentId = driverLicence.Id;
            }


            return new DriversLicenceViewModel_Finak
            {
                LicenceTypes = licenceTypes,
                PersonaInformationId = id,
                PersonalInformation = personalInformation,
                Documents = documents,
                DriverLicenceDocumentId = driverLicenceDocumentId
            };
        }
    }
}
