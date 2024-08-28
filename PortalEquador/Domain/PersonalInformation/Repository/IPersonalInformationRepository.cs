using PortalEquador.Data.PersonalInformation.Entity;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.PersonalInformation.ViewModels;

namespace PortalEquador.Domain.PersonalInformation.Repository
{
    public interface IPersonalInformationRepository : IGenericRepository<PersonalInformationEntity>
    {
        //Task<PersonalInformationViewModel> GetPersonalInformationAsync(int id);
        //Task<bool> PersonalInformationExists(string identityCard);
        Task<List<PersonalInformationViewModel>> GetAll();
        //Task<PersonalInformationDetailViewModel> GetPersonalInformationDetailAsync(int id);

    }
}
