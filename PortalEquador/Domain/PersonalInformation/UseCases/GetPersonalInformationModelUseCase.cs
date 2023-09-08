using AutoMapper;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.PersonalInformation.ViewModels;

namespace PortalEquador.Domain.PersonalInformation.UseCases
{
    public class GetPersonalInformationModelUseCase
    {
        private readonly PersonalInformationRepository personalInformationRepository;

        public GetPersonalInformationModelUseCase(PersonalInformationRepository personalInformationRepository)
        {
            this.personalInformationRepository = personalInformationRepository;
        }

        public async Task<PersonalInformationViewModel> Invoke(int curriculumId)
        {
            /*
            var nationalities = personalInformationRepository.GroupItems(Groups.NATIONALITY);
            var neighbourhoods = personalInformationRepository.GroupItems(Groups.NEIGHBOURHOOD);
            var provinces = personalInformationRepository.GroupItems(Groups.PROVINCE);
            */

            var model = await personalInformationRepository.GetPersonalInformationAsync(curriculumId);
            return model;
        }
    }
}
