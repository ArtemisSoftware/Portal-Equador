using AutoMapper;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.PersonalInformation.ViewModels;

namespace PortalEquador.Domain.PersonalInformation.UseCases
{
    public class GetPersonalInformationDetailModelUseCase
    {
        private readonly PersonalInformationRepository personalInformationRepository;

        public GetPersonalInformationDetailModelUseCase(PersonalInformationRepository personalInformationRepository)
        {
            this.personalInformationRepository = personalInformationRepository;
        }

        public async Task<PersonalInformationDetailViewModel> Invoke(int id)
        {
            var model = await personalInformationRepository.GetPersonalInformationDetailAsync(id);
            return model;
        }
    }
}
