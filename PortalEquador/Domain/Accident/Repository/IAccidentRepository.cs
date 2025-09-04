using PortalEquador.Data.Accident.Entities;
using PortalEquador.Data.Contract.Entities;
using PortalEquador.Domain.Accident.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.Languages.ViewModels;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.Accident.Repository
{
    public interface IAccidentRepository : IGenericRepository<AccidentEntity>
    {
        Task<List<AccidentDetailViewModel>> GetAll(int personalInformationId);

        Task<AccidentViewModel> GetCreateModel(int personalInformationId, string fullName);
        Task<AccidentViewModel> GetCreateModel(AccidentViewModel model);
        Task<int> Save(AccidentViewModel model);

        Task<bool> AccidentNumberExists(int numberId);

        Task<AccidentViewModel> GetAccident(int id);
    }
}
