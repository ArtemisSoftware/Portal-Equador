using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.Profession.Experience.Entity;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Util.Constants;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Data.Report.Repository
{
    public class ReportRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor
        ) : GenericRepository<ProfessionalExperienceEntity>(context, httpContextAccessor), IReportRepository
    {

        private IQueryable<int> GetLatestContracts()
        {
            return context.ContractEntity
                .Where(c => c.DateOfContract != null)
                .GroupBy(c => c.PersonalInformationId)
                .Select(g => g
                    .OrderByDescending(c => c.DateOfContract)
                    .Select(c => c.Id)
                    .FirstOrDefault()
                );
        }

        public async Task<AgeReportViewModel> GetAgeReport()
        {

            IQueryable<int> latestContractIds = context.ContractEntity
                .Where(c => c.DateOfContract != null)
                .GroupBy(c => c.PersonalInformationId)
                .Select(g => g
                    .OrderByDescending(c => c.DateOfContract)
                    .Select(c => c.Id)
                    .FirstOrDefault()
                );

            var query = from contract in context.ContractEntity
                        where latestContractIds.Contains(contract.Id)

                        join personal in (
                            from personalInfo in context.PersonalInformationEntity
                            select new
                            {
                                personalInfo.Id,
                                personalInfo.FirstName,
                                personalInfo.LastName ,
                                personalInfo.DateOfBirth
                            }
                        ) 
                        on contract.PersonalInformationEntity.Id equals personal.Id into contractJoin
                        from contractResult in contractJoin/*.Take(1)*/.DefaultIfEmpty()

                        join groupItem in context.GroupItemEntity
                            on contract.ContractId equals groupItem.Id into groupItemGroup
                        from groupItem in groupItemGroup.DefaultIfEmpty()

                        where contract.ContractStateId == GroupTypesConstants.ItemFromGroup.ContractStates.CONTRACTED
                        orderby contractResult.DateOfBirth

                        select new AgeReportItemViewModel
                        {
                            FullName = contractResult.FirstName + " " + contractResult.LastName,
                            DateOfBirth = contractResult.DateOfBirth,
                            WorkStation = groupItem.Description,
                        };

            var result = await query.ToListAsync();

            return new AgeReportViewModel
            {
                report = result,
            };
        }

        public async Task<AlchoolTestReportViewModel> GetAlchoolTestReport()
        {
            var latestContractIds = GetLatestContracts();

            var query = from contract in context.ContractEntity
                        where latestContractIds.Contains(contract.Id)
                        where contract.ContractStateId == ItemFromGroup.ContractStates.CONTRACTED

                        let personal = contract.PersonalInformationEntity

                        select new AlchoolTestReportItemViewModel
                        {
                            FullName = personal.FirstName + " " + personal.LastName,
                            AlcoholTests = context.DisciplinaryNotificationEntity
                                .Where(d => d.PersonalInformationId == personal.Id && d.NotificationId == ItemFromGroup.DisciplinaryNotification.ALCOOL)
                                .Select(d => new AlcoholTestResultViewModel
                                {
                                        Date = d.Date,
                                        Result = d.AlcoolTestResultGroupItemEntity.Id,
                                    }
                                )
                                .ToList()
                        };

            var result = await query.ToListAsync();

            return new AlchoolTestReportViewModel
            {
                report = result,
            };
        }
    }
}
