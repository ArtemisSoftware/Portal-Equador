
using PortalEquador.Constants;
using PortalEquador.Domain.Documents.Repository;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.Repositories;

namespace PortalEquador.Domain.DriversLicence.UseCases
{
    public class GetDriversLicenceDetailModelUseCase
    {
        private readonly DriversLicenceRepository _driversLicenceRepository;
        private readonly DocumentRepository _documentRepository;
        private readonly PersonalInformationRepository personalInformationRepository;

        public GetDriversLicenceDetailModelUseCase(PersonalInformationRepository personalInformationRepository, DriversLicenceRepository driversLicenceRepository, DocumentRepository documentRepository)
        {
            _driversLicenceRepository = driversLicenceRepository;
            _documentRepository = documentRepository;
            this.personalInformationRepository = personalInformationRepository;
        }

        public async Task<DriversLicenceDetailViewModel> Invoke(int personalInformationId)
        {
            var model = await _driversLicenceRepository.GetDriversLicenceDetailAsync(personalInformationId);
            model.Documents = await _documentRepository.GetDocumentsDetails(personalInformationId, DriverLicenceUtil.DocumentIds());
            return model;
        }
    }
}

