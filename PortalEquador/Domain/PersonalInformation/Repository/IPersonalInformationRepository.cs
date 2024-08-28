using PortalEquador.Data.PersonalInformation.Entity;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.PersonalInformation.ViewModels;

namespace PortalEquador.Domain.PersonalInformation.Repository
{
    public interface IPersonalInformationRepository : IGenericRepository<PersonalInformationEntity>
    {
        Task<PersonalInformationViewModel> GetCreateModel(PersonalInformationViewModel? model);
        Task<bool> ValidateIdentityCardNumber(string identityCardNumber);
        Task Save(PersonalInformationViewModel model);
        Task<PersonalInformationViewModel> GetPersonalInformation(int id);
        Task<PersonalInformationDetailViewModel> GetPersonalInformationDetail(int id);
        Task<List<PersonalInformationViewModel>> GetAll();

    }
}
