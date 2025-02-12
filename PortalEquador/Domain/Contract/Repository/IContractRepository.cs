using PortalEquador.Data.Contract.Entities;
using PortalEquador.Domain.Contract.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.PersonalInformation.ViewModels;

namespace PortalEquador.Domain.Contract.Repository
{
    public interface IContractRepository : IGenericRepository<ContractEntity>
    {
        Task<List<ContractViewModel>> GetAll();
        Task<ContractDashboardViewModel> GetDashboard(int id);
    }
}
