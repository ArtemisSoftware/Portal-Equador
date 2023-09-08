using PortalEquador.Domain.PersonalInformation.Repository;

namespace PortalEquador.Domain.PersonalInformation.UseCases
{
    public class ValidateIdentityCardNumberUseCase
    {
        private readonly PersonalInformationRepository personalInformationRepository;

        public ValidateIdentityCardNumberUseCase(PersonalInformationRepository personalInformationRepository)
        {
            this.personalInformationRepository = personalInformationRepository;
        }

        public async Task<bool> Invoke(string identityCardNumber)
        {
            return await personalInformationRepository.PersonalInformationExists(identityCardNumber);
        }
    }
}
