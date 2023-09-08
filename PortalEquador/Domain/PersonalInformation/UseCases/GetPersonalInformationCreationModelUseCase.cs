using PortalEquador.Constants;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.PersonalInformation.ViewModels;

namespace PortalEquador.Domain.PersonalInformation.UseCases
{
    public class GetPersonalInformationCreationModelUseCase
    {
        private readonly PersonalInformationRepository personalInformationRepository;

        public GetPersonalInformationCreationModelUseCase(PersonalInformationRepository personalInformationRepository)
        {
            this.personalInformationRepository = personalInformationRepository;
        }

        public async Task<PersonalInformationViewModel> Invoke(PersonalInformationViewModel? model)
        {

            var nationalities = personalInformationRepository.GroupItems(Groups.NATIONALITY);
            var neighbourhoods = personalInformationRepository.GroupItems(Groups.NEIGHBOURHOOD);
            var provinces = personalInformationRepository.GroupItems(Groups.PROVINCE);

            if(model == null)
            {
                return new PersonalInformationViewModel
                {
                    Neighbourhoods = neighbourhoods,
                    Nationalities = nationalities,
                    Provinces = provinces
                };
            }
            else
            {
                model.Neighbourhoods = neighbourhoods;
                model.Nationalities = nationalities;
                model.Provinces = provinces;
                return model;
            }
        }
    }
}
