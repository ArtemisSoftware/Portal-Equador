using PortalEquador.Data.Languages.entity;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Languages.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;

namespace PortalEquador.Domain.Languages.Repository
{
    public interface ILanguageRepository : IGenericRepository<LanguageEntity>
    {
        Task<List<LanguageDetailViewModel>> GetAll(int personalInformationId);

        Task<LanguageViewModel> GetCreateModel(int personalInformationId, string fullName);
        Task<LanguageViewModel> GetCreateModel(LanguageViewModel model);
        Task Save(LanguageViewModel model);

        Task<bool> LanguageExists(int personalInformationId, int languageId);

        Task<LanguageViewModel> GetLanguage(int id);
    }
}
