using AutoMapper;
using PortalEquador.Data.Contract.Entities;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Contract.Repository;
using PortalEquador.Domain.Contract.ViewModels;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util.Constants;
using PortalEquador.Util;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Domain.Curriculum.ViewModels;
using static PortalEquador.Util.Constants.GroupTypesConstants;
using PortalEquador.Data.Education.University.Entity;
using PortalEquador.Domain.GroupTypes.ViewModels;
using System.Diagnostics.Contracts;
using PortalEquador.Domain.Languages.ViewModels;
using PortalEquador.Data.Migrations;
using static PortalEquador.Util.Constants.GroupTypesConstants.ItemFromGroup;

namespace PortalEquador.Data.Contract.Repository
{
    public class ContractRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        IWebHostEnvironment hostEnvironment
        ) : GenericRepository<ContractEntity>(context, httpContextAccessor), IContractRepository
    {

        public async Task Contract(int id)
        {
            var contract = new ContractCreateViewModel
            {
                Id = 0,
                PersonaInformationId = id,
                ContractStateId = GroupTypesConstants.ItemFromGroup.ContractStates.CONTRACTED,
            };

            await Save(contract);
        }


        public async Task Save(ContractCreateViewModel model)
        {
            
            var entity = mapper.Map<ContractEntity>(model);
            entity.EditorId = GetCurrentUserId();

            await AddAsync(entity);
        }

        public async Task<ContractsViewModel> GetAll(int filter)
        {

            var contractStates = GroupItems(Groups.CONTRACT_STATE, OrderType.Alphabetic, -1, StringConstants.ContractStatus.UNASSIGNED);

            if (filter == -1) {
                var models = await NoFilter();
                models.ContractStates = contractStates;
                models.ContractStatesId = filter;
                return models;
            } else
            {
                var models = await Filter(filter);
                models.ContractStates = contractStates;
                models.ContractStatesId = filter;
                return models;
            }
        }

        private async Task<ContractsViewModel> NoFilter()
        {
            var query = from personal in context.PersonalInformationEntity

                        join ctc in
                            (from contract in context.ContractEntity
                             orderby contract.Id descending
                             select contract)
                            on personal.Id equals ctc.PersonalInformationId into resultCtc

                        from resultContract in resultCtc.DefaultIfEmpty()

                        where resultContract == null // ✅ This filters only the ones with NO contracts

                        select new CurrentContractViewModel
                        {
                            PersonalInformationId = personal.Id,
                            FullName = personal.FirstName + " " + personal.LastName,
                        };

            var result = await query.ToListAsync();

            return new ContractsViewModel
            {
                Contracts = result,
            };
        }

            private async Task<ContractsViewModel> Filter(int filter)
        {
            // Step 1: Get IDs of latest contracts per PersonalInformationId
            var latestContractIds = await context.ContractEntity
                .GroupBy(c => c.PersonalInformationId)
                .Select(g => g.OrderByDescending(c => c.Id)
                                        .Select(c => c.Id).FirstOrDefault())

                .ToListAsync();

            // Step 2: Load full contracts with related entities
            var latestContracts = await context.ContractEntity
                .Where(c => latestContractIds.Contains(c.Id))
                .Include(c => c.PersonalInformationEntity)
                .Include(c => c.ContractStateGroupItemEntity)
                .Include(c => c.ResignationReasonGroupItemEntity)
                .ToListAsync();

            var models = mapper.Map<List<CurrentContractViewModel>>(latestContracts);

            var updatedContracts = models
                .Select(contract =>
                {
                    // Modify fields (or even make a copy if needed)
                    contract.ProfileImagePath = ImagesUtil.GetProfileImagePath(hostEnvironment, contract.PersonalInformationId);
                    return contract;
                })
                .Where(c => c.ContractState.Id == filter)
                .ToList(); // This gives you the new list!

            return new ContractsViewModel
            {
                Contracts = updatedContracts,
            };
        }


        public async Task<ContractCreateViewModel> GetContract(int personalInformationId)
        {
            var result = await context.ContractEntity
                .Include(d => d.PersonalInformationEntity)
                .Include(d => d.ContractStateGroupItemEntity)
                .Include(d => d.ResignationReasonGroupItemEntity)
                .Where(item => item.PersonalInformationId == personalInformationId)
                .OrderByDescending(item => item.Id) 
                .FirstOrDefaultAsync();           

            var model = mapper.Map<ContractCreateViewModel>(result);

            var contractStates = GroupItems(Groups.CONTRACT_STATE, OrderType.Alphabetic, GroupTypesConstants.ItemFromGroup.ContractStates.CONTRACTED);
            var resignationReasons = GroupItems(Groups.RESIGNATION_REASONS, OrderType.Alphabetic);

            model.ContractStates = contractStates;
            model.ResignationReasons = resignationReasons;
            return model;
        }

        public async Task<List<ContractViewModel>> GetAllContracts(int personalInformationId)
        {
            var result = await context.ContractEntity
                .Include(d => d.PersonalInformationEntity)
                .Include(d => d.ContractStateGroupItemEntity)
                .Include(d => d.ResignationReasonGroupItemEntity)
                .Where(item => item.PersonalInformationId == personalInformationId)
                .OrderByDescending(item => item.Id)
                .ToListAsync();

            var model = mapper.Map<List<ContractViewModel>>(result);
            return model;
        }

        public async Task<ContractDashboardViewModel> GetDashboard(int id)
        {

            var query = from personal in context.PersonalInformationEntity

                        join ctc in
                            (from contract in context.ContractEntity
                             where contract.PersonalInformationId == id
                             orderby contract.Id descending
                             select contract).Take(1)
                            .Select(grouped => new
                            {
                                PersonalInformationId = grouped.PersonalInformationId,
                                ContractId = grouped.Id,
                                ContractStateId = grouped.ContractStateId
                            })
                        on personal.Id equals ctc.PersonalInformationId into resultCtc
                                                from resultContract in resultCtc.DefaultIfEmpty()


                        join contractCount in
                            (from contract in context.ContractEntity
                             where contract.PersonalInformationId == id
                             select contract).GroupBy(d => d.PersonalInformationId)
                            .Select(grouped => new
                            {
                                PersonalInformationId = grouped.Key,
                                ContractCount = grouped.Count()
                            })
                        on personal.Id equals contractCount.PersonalInformationId into resultCtcs
                        from resultContracts in resultCtcs.DefaultIfEmpty()

                        join medicalExamCount in
                            (from medicalExam in context.MedicalExamEntity
                             where medicalExam.PersonalInformationId == id
                             select medicalExam).GroupBy(d => d.PersonalInformationId)
                            .Select(grouped => new
                            {
                                PersonalInformationId = grouped.Key,
                                OrderDetailCount = grouped.Count()
                            })
                        on personal.Id equals medicalExamCount.PersonalInformationId into resultMd
                        from resultMedicalExams in resultMd.DefaultIfEmpty()

                        join trainningCount in
                            (from trainning in context.TrainningEntity
                             where trainning.PersonalInformationId == id
                             select trainning).GroupBy(d => d.PersonalInformationId)
                            .Select(grouped => new
                            {
                                PersonalInformationId = grouped.Key,
                                OrderDetailCount = grouped.Count()
                            })
                        on personal.Id equals trainningCount.PersonalInformationId into resultTrn
                        from resultTrainnings in resultTrn.DefaultIfEmpty()

                        join disciplinaryNotificationCount in
                            (from disciplinaryNotification in context.DisciplinaryNotificationEntity
                             where disciplinaryNotification.PersonalInformationId == id
                             select disciplinaryNotification).GroupBy(d => d.PersonalInformationId)
                            .Select(grouped => new
                            {
                                PersonalInformationId = grouped.Key,
                                OrderDetailCount = grouped.Count()
                            })
                        on personal.Id equals disciplinaryNotificationCount.PersonalInformationId into resultDN
                        from resultDisciplinaryNotifications in resultDN.DefaultIfEmpty()


                        where personal.Id == id

                        select new  ContractDashboardViewModel
                        {
                            Id = 1,
                            PersonaInformationId = personal.Id,
                            FullName = personal.FirstName + " " + personal.LastName,
                            ProfileImagePath = ImagesUtil.GetProfileImagePath(hostEnvironment, id),
                            TotalExams = resultMedicalExams.OrderDetailCount == null ? 0 : resultMedicalExams.OrderDetailCount,
                            TotalDisciplinaryNotification = resultDisciplinaryNotifications.OrderDetailCount == null ? 0 : resultDisciplinaryNotifications.OrderDetailCount,
                            TotalTrainning = resultTrainnings.OrderDetailCount == null ? 0 : resultTrainnings.OrderDetailCount,
                            ContractId = resultContract.ContractStateId == null ? 0 : resultContract.ContractStateId,
                            TotalContracts = resultContracts.ContractCount == null ? 0 : resultContracts.ContractCount,
                        };

            var result = await query.FirstOrDefaultAsync();

            var contractModel = await GroupItem(result.ContractId);
            if (contractModel != null)
            {
                result.Contract = mapper.Map<GroupItemViewModel>(contractModel);
            }
            return result;
        }


    }
}
