using PortalEquador.Contracts;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Domain.Repositories;
using PortalEquador.Models.CurriculumVitae;

namespace PortalEquador.Domain.UseCases.PersonalInformation
{
    public class GetPersonalInformationUseCase
    {
        private readonly IPersonalInformationRepository _personalInformationRepository;

        public GetPersonalInformationUseCase(IPersonalInformationRepository personalInformationRepository)
        {
            _personalInformationRepository = personalInformationRepository;
        }

    }
}
