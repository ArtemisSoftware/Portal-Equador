using Microsoft.IdentityModel.Tokens;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.PersonalInformation.Repository;

namespace PortalEquador.Domain.DriversLicence.UseCases
{
    public class GetDriversLicenceCreateModelUseCase(
        IDriversLicenceRepository driversLicenceRepository, 
        IPersonalInformationRepository personalInformationRepository
        )
    {
        public async Task<DriversLicenceViewModel> Invoke(int personalInformationId, string fullName)
        {
            if (fullName.IsNullOrEmpty())
            {
                fullName = (await personalInformationRepository.GetPersonalInformation(personalInformationId)).FullName;
            }


            return await driversLicenceRepository.GetCreateModel(personalInformationId, fullName);
        }
    }
}
