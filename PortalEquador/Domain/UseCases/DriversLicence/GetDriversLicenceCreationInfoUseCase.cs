using PortalEquador.Constants;
using PortalEquador.Contracts;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Domain.Repositories;

namespace PortalEquador.Domain.UseCases.DriversLicence
{
    public class GetDriversLicenceCreationInfoUseCase
    {
        private readonly IPersonalInformationRepository personalInformationRepository;

        public GetDriversLicenceCreationInfoUseCase(IPersonalInformationRepository personalInformationRepository)
        {
            this.personalInformationRepository = personalInformationRepository;
        }

        public async Task<DriversLicenceCreateViewModel> Invoke(int curriculumId)
        {

            var licenceTypes = personalInformationRepository.GroupItems(Groups.DRIVERS_LICENCE);
            var profile = await personalInformationRepository.GetProfileInformation(curriculumId);

            var model = new DriversLicenceCreateViewModel
            {
                CurriculumId = curriculumId,
                Profile = profile,
                LicenceTypes = licenceTypes
            };

            return model;
        }
    }
}
