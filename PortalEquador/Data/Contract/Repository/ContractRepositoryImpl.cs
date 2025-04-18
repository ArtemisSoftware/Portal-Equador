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

        public async Task<ContractsViewModel> GetAll()
        {

            var contractStates = await GroupItemsList(Groups.CONTRACT_STATE, OrderType.Alphabetic);
            var states = mapper.Map<List<GroupItemViewModel>>(contractStates);

            var query = from personal in context.PersonalInformationEntity
                        join profileDoc in
                            (from document in context.DocumentEntity
                             where document.DocumentTypeId == GroupTypesConstants.ItemFromGroup.Documents.PROFILE_PICTURE
                             select document)
                        on personal.Id equals profileDoc.PersonalInformationId into resultProfileDocs
                        from resultProfileDocument in resultProfileDocs.DefaultIfEmpty()
                        orderby personal.FirstName
                        select new ContractViewModel
                        {
                            //Id = personal.Id,
                            //PersonalInformationId = personal.Id,
                            //--FullName = personal.FirstName + " " + personal.LastName,   
                            //--ProfileImagePath = ImagesUtil.GetProfileImagePath(hostEnvironment, personal.Id)
                        };

                var models = await query.ToListAsync();

                return new ContractsViewModel
                {
                    Contracts = models,
                    States = states
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
                        };

            var result = await query.FirstOrDefaultAsync();
            return result;
        }


    }
}
