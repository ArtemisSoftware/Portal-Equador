using PortalEquador.Data.Contract.Entities;
using PortalEquador.Domain.Contract.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.MechanicalWorkshop;
using PortalEquador.Domain.PersonalInformation.ViewModels;

namespace PortalEquador.Domain.Contract.Repository
{
    public interface IContractRepository : IGenericRepository<ContractEntity>
    {
        Task Contract(int id);
        Task<ContractsViewModel> GetAll();
        Task<ContractDashboardViewModel> GetDashboard(int id);
        Task<ContractCreateViewModel> GetContract(int personalInformationId);
        Task Save(ContractCreateViewModel model);
        Task<List<ContractViewModel>> GetAllContracts(int personalInformationId);
    }
}
