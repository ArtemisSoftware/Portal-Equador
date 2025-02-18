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

namespace PortalEquador.Data.Contract.Repository
{
    public class ContractRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        IWebHostEnvironment hostEnvironment
        ) : GenericRepository<ContractEntity>(context, httpContextAccessor), IContractRepository
    {
        public async Task<List<ContractViewModel>> GetAll()
        {
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
                            Id = personal.Id,
                            PersonaInformationId = personal.Id,
                            FullName = personal.FirstName + " " + personal.LastName,   
                            ProfileImagePath = ImagesUtil.GetProfileImagePath(hostEnvironment, personal.Id)
                        };
            return await query.ToListAsync();
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
                            (from disciplinaryNotification in context.TrainningEntity
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
