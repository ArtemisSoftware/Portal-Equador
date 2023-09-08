using AutoMapper;
using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Domain.UseCases;

namespace PortalEquador.Domain.CurriculumVitae.UseCases
{
    public class GetAllCurriculumsUseCase
    {
        private readonly PersonalInformationRepository _personalInformationRepository;

        public GetAllCurriculumsUseCase(PersonalInformationRepository personalInformationRepository)
        {
            _personalInformationRepository = personalInformationRepository;
        }

        public async Task<List<PersonalInformationViewModel>> Invoke()
        {
            return await _personalInformationRepository.GetAll();
        }

    }
}
