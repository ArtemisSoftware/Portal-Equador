using PortalEquador.Contracts;
using PortalEquador.Data.GroupTypes;
using PortalEquador.Data.PersonalInformation.Entities;
using PortalEquador.Data.PInformation;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;

namespace PortalEquador.Domain.PersonalInformation.Repository
{
    public interface PersonalInformationRepository : IGenericRepository<PersonalInformationEntity>
    {
        Task<PersonalInformationViewModel> GetPersonalInformationAsync(int id);

        Task<bool> PersonalInformationExists(string identityCard);

        Task<List<PersonalInformationViewModel>> GetAll();

        Task<PersonalInformationDetailViewModel> GetPersonalInformationDetailAsync(int id);

    }
}
