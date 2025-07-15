using AutoMapper;
using PortalEquador.Data.Contract.Entities;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Contract.Repository;
using PortalEquador.Domain.Contract.ViewModels;
using PortalEquador.Util.Constants;
using PortalEquador.Util;
using Microsoft.EntityFrameworkCore;
using static PortalEquador.Util.Constants.GroupTypesConstants;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Curriculum.ViewModels;

namespace PortalEquador.Data.Contract.Repository
{
    public class ContractRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        IWebHostEnvironment hostEnvironment
        ) : GenericRepository<ContractEntity>(context, httpContextAccessor), IContractRepository
    {



        public async Task Save(ContractCreate__ViewModel model)
        {
            var entity = mapper.Map<ContractEntity>(model);
            entity.ContractStateId = GroupTypesConstants.ItemFromGroup.ContractStates.CONTRACTED;
            entity.EditorId = GetCurrentUserId();

            await AddAsync(entity);
        }

        public async Task Save(ContractResignViewModel model)
        {
            var entity = mapper.Map<ContractEntity>(model);
            entity.EditorId = GetCurrentUserId();

            await AddAsync(entity);
        }



        private async Task<ContractsViewModel> NoFilter()
        {

            var query = from personal in context.PersonalInformationEntity

                        join contract in (
                            from c in context.ContractEntity
                            orderby c.DateOfContract descending
                            select new
                            {
                                c.Id,
                                c.PersonalInformationId,
                                c.ContractStateId
                            }
                        ) on personal.Id equals contract.PersonalInformationId into contractJoin
                        from contract in contractJoin.Take(1).DefaultIfEmpty()

                        join groupItem in context.GroupItemEntity
                                           on contract.ContractStateId equals groupItem.Id into groupItemGroup
                        from groupItem in groupItemGroup.DefaultIfEmpty()

                        where contract.ContractStateId == null

                        select new CurrentContractViewModel
                        {
                            PersonalInformationId = personal.Id,
                            FullName = personal.FirstName + " " + personal.LastName,
                            ProfileImagePath = ImagesUtil.GetProfileImagePath(hostEnvironment, personal.Id),
                            ContractDescription = groupItem != null ? groupItem.Description : "",
                            ContractId = groupItem != null ? groupItem.Id : null,
                        };

            var result = await query.ToListAsync();
            
            return new ContractsViewModel
            {
                Contracts = result,
            };
        }

      private async Task<ContractsViewModel> Filter(int filter)
        {

            var query = from personal in context.PersonalInformationEntity

                        join contract in (
                            from c in context.ContractEntity
                            orderby c.DateOfContract descending
                            select new
                            {
                                c.Id,
                                c.PersonalInformationId,
                                c.ContractStateId
                            }
                        ) on personal.Id equals contract.PersonalInformationId into contractJoin
                        from contract in contractJoin.Take(1).DefaultIfEmpty()

                        join groupItem in context.GroupItemEntity
                                           on contract.ContractStateId equals groupItem.Id into groupItemGroup
                        from groupItem in groupItemGroup.DefaultIfEmpty()

                        where contract.ContractStateId == filter

                        select new CurrentContractViewModel
                        {
                            PersonalInformationId = personal.Id,
                            FullName = personal.FirstName + " " + personal.LastName,
                            ProfileImagePath = ImagesUtil.GetProfileImagePath(hostEnvironment, personal.Id),
                            ContractDescription = groupItem != null ? groupItem.Description : "",
                            ContractId = groupItem != null ? groupItem.Id : null,
                        };

            var result = await query.ToListAsync();

            return new ContractsViewModel
            {
                Contracts = result,
            };
        }


        public async Task<ContractResignViewModel> GetResignationModel(int personalInformationId)
        {
            var result = await context.ContractEntity
                            .Include(d => d.PersonalInformationEntity)
                            .Include(d => d.ContractStateGroupItemEntity)
                            .Include(d => d.ResignationReasonGroupItemEntity)
                            .Include(d => d.ContractGroupItemEntity)
                            .Where(item => item.PersonalInformationId == personalInformationId)
                            .OrderByDescending(item => item.Id)
                            .FirstOrDefaultAsync();

            var model = mapper.Map<ContractResignViewModel>(result);

            var contractStates = GroupItems(Groups.CONTRACT_STATE, OrderType.Alphabetic, GroupTypesConstants.ItemFromGroup.ContractStates.CONTRACTED);
            var resignationReasons = GroupItems(Groups.RESIGNATION_REASONS, OrderType.Alphabetic);

            model.ContractStates = contractStates;
            model.ResignationReasons = resignationReasons;
            model.Id = 0;
            model.DateOfContract = null;
            model.Observation = "";
            return model;
        }

        public async Task<ContractResignViewModel> GetResignationModel(ContractResignViewModel model)
        {

            var result = await context.ContractEntity
                .Include(d => d.PersonalInformationEntity)
                .Include(d => d.ContractStateGroupItemEntity)
                .Include(d => d.ResignationReasonGroupItemEntity)
                .Include(d => d.ContractGroupItemEntity)
                .Where(item => item.PersonalInformationId == model.PersonaInformationId)
                .OrderByDescending(item => item.Id)
                .FirstOrDefaultAsync();

            var current = mapper.Map<ContractResignViewModel>(result);

            var contractStates = GroupItems(Groups.CONTRACT_STATE, OrderType.Alphabetic, GroupTypesConstants.ItemFromGroup.ContractStates.CONTRACTED);
            var resignationReasons = GroupItems(Groups.RESIGNATION_REASONS, OrderType.Alphabetic);

            current.ContractStates = contractStates;
            current.ResignationReasons = resignationReasons;
            current.Id = 0;
            current.DateOfContract = model.DateOfContract;
            current.Observation = model.Observation;
            current.ContractId = model.ContractId;
            current.ContractStateId = model.ContractStateId;
            current.ResignationReasonsId = model.ResignationReasonsId;
            return model;
        }

        public async Task<ContractHistoryViewModel> GetAllContracts(int personalInformationId)
        {
            
            var result = await context.ContractEntity
                            .Include(d => d.PersonalInformationEntity)
                            .Include(d => d.ContractStateGroupItemEntity)
                            .Include(d => d.ResignationReasonGroupItemEntity)
                            .Include(d => d.ContractGroupItemEntity)
                .Where(item => item.PersonalInformationId == personalInformationId)
                .OrderByDescending(item => item.DateOfContract)
                .ToListAsync();

            var model = mapper.Map<List<ContractViewModel>>(result);

            var current = new List<ContractViewModel>();
            current.Add(model.First());

            var history = new List<ContractViewModel>();

            if (model.Count - 1 > 0)
            {
                history = model.GetRange(1, model.Count - 1);
            }

            return new ContractHistoryViewModel
            {
                Current = current,
                History = history
            };

        }

        public async Task<ContractDashboardViewModel> GetDashboard(int id)
        {
            
            var query = from personal in context.PersonalInformationEntity

                        join ctc in
                            (from contract in context.ContractEntity
                             where contract.PersonalInformationId == id
                             orderby contract.DateOfContract descending
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

        public async Task<ContractCreate__ViewModel> GetCreateModel(int personalInformationId, string fullName)
        {
            var contracts = GroupItems(Groups.MECHANICAL_SHOP_CONTRACTS, OrderType.Alphabetic);


            return new ContractCreate__ViewModel
            {
                PersonaInformationId = personalInformationId,
                FullName = fullName,
                Contracts = contracts
            };
        }

        public async Task<ContractCreate__ViewModel> GetCreateModel(ContractCreate__ViewModel model)
        {
            var contracts = GroupItems(Groups.MECHANICAL_SHOP_CONTRACTS, OrderType.Alphabetic);

            model.Contracts = contracts;
            return model;
        }

        public async Task<ContractsViewModel> GetAll(int filter)
        {

            var contractStates = GroupItems(Groups.CONTRACT_STATE, OrderType.Alphabetic, -1, StringConstants.ContractStatus.UNASSIGNED);

            if (filter == -1)
            {
                var models = await NoFilter();
                models.ContractStates = contractStates;
                models.ContractStatesId = filter;
                return models;
            }
            else
            {
                var models = await Filter(filter);
                models.ContractStates = contractStates;
                models.ContractStatesId = filter;
                return models;
            }
        }






    }
}
