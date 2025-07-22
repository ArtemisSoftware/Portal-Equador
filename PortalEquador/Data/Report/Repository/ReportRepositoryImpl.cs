using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Math;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.Profession.Experience.Entity;
using PortalEquador.Domain.Education.University.ViewModels;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Domain.Report.ViewModels.AlchoolTest;
using PortalEquador.Util.Constants;
using System.Globalization;
using static PortalEquador.Util.Constants.GroupTypesConstants;
using static PortalEquador.Util.Constants.StringConstants;

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


        /*..............ALCHOOL....................*/

        public async Task<AlchoolTestViewModel> GetAlchoolTestForm()
        {
           
            var contracts = GroupItems(Groups.MECHANICAL_SHOP_CONTRACTS, OrderType.Alphabetic, -1, "Todos os contractos", true);

            var monthlyDates = context.DisciplinaryNotificationEntity
                .GroupBy(d => new { d.Date.Year, d.Date.Month })
                .Select(g => g.OrderBy(x => x.Date).First().Date)
                .ToList();


            var dates = new SelectList(
                monthlyDates.Select(d => new {
                    Value = d.ToString("yyyy-MM-dd"), // or just d if you're binding to a DateTime
                    Text = d.ToString("MMMM yyyy", new CultureInfo("pt-PT")) // e.g., "julho 2025"
                }),
                "Value",
                "Text"
            );

            var model = new AlchoolTestViewModel
            {
                Dates = dates,
                Contracts = contracts,
            };

            return model;
        }

        public async Task<AlchoolTestReportViewModel> GetAlchoolTestReport(DateTime date, int contractId)
        {

            var contractDescription = "";

            if (contractId != -1)
            {
                contractDescription = (await GroupItem(contractId))?.Description;
            }

            var startOfMonth = new DateTime(date.Year, date.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            var latestContractIds = GetLatestContracts();

            var query = from contract in context.ContractEntity
                        where latestContractIds.Contains(contract.Id)
                        where contract.ContractStateId == ItemFromGroup.ContractStates.CONTRACTED && (contractId == -1 || contract.ContractId == contractId)

                        let personal = contract.PersonalInformationEntity

                        select new AlchoolTestReportItemViewModel
                        {
                            FullName = personal.FirstName + " " + personal.LastName,
                            AlcoholTests = context.DisciplinaryNotificationEntity
                                .Where(d =>
                                        d.PersonalInformationId == personal.Id &&
                                        d.NotificationId == ItemFromGroup.DisciplinaryNotification.ALCOOL &&
                                        d.Date >= startOfMonth && d.Date <= endOfMonth
                                 )
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
                ReferenceDate = date,
                report = result,
                WorkStation = contractDescription
            };
        }
    }
}
