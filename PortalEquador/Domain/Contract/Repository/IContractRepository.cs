using PortalEquador.Data.Contract.Entities;
using PortalEquador.Domain.Contract.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.MechanicalWorkshop;
using PortalEquador.Domain.PersonalInformation.ViewModels;

namespace PortalEquador.Domain.Contract.Repository
{
    public interface IContractRepository : IGenericRepository<ContractEntity>
    {

        Task<ContractsViewModel> GetAll(int filter = -1);
        Task<ContractDashboardViewModel> GetDashboard(int id);
        Task<ContractHistoryViewModel> GetAllContracts(int personalInformationId);

        Task<ContractCreate__ViewModel> GetCreateModel(int personalInformationId, string fullName);
        Task<ContractCreate__ViewModel> GetCreateModel(ContractCreate__ViewModel model);
        Task Save(ContractCreate__ViewModel model);

        Task<ContractResignViewModel> GetResignationModel(int personalInformationId);
        Task<ContractResignViewModel> GetResignationModel(ContractResignViewModel model);
        Task Save(ContractResignViewModel model);
    }
}
