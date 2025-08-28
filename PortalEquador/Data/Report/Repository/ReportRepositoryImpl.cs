using AutoMapper;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MechanicalWorkshop;
using PortalEquador.Data.Profession.Experience.Entity;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Domain.Report.ViewModels.Age;
using PortalEquador.Domain.Report.ViewModels.AlchoolTest;
using PortalEquador.Domain.Report.ViewModels.DriversLicence;
using PortalEquador.Domain.Report.ViewModels.MedicalExam;
using PortalEquador.Domain.Report.ViewModels.Profession.Competence;
using PortalEquador.Domain.Report.ViewModels.Trainning;
using PortalEquador.Util;
using PortalEquador.Util.Constants;
using System.Globalization;
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


        /*..............AGE....................*/

        public async Task<AgeReportFormViewModel> GetAgeForm()
        {
            var userId = GetCurrentUserId();
            var hasFullAccess = MechanicalWorkshopUtil.HasFullAccess(GetCurrentUserRole());

            SelectList? contracts;

            if (hasFullAccess)
            {
                contracts = GroupItems(
                    Groups.MECHANICAL_SHOP_CONTRACTS,
                    OrderType.Alphabetic,
                    StringConstants.Report.ALL_CONTRACTS_ID,
                    StringConstants.Report.ALL_CONTRACTS,
                    true
                 );
            }
            else
            {
                var result =
                   from item in context.GroupItemEntity
                   join contract in context.AdminMechanicalWorkShopContractEntity on item.Id equals contract.ContractId
                   where item.Active &&
                                   contract.UserId == userId
                   orderby item.Description
                   select item;

                contracts = GroupItems(result, OrderType.Alphabetic, StringConstants.Report.ALL_CONTRACTS, true);
            }

            var model = new AgeReportFormViewModel
            {
                Contracts = contracts,
            };

            return model;
        }

        public async Task<AgeReportViewModel> GetAgeReport(List<int> accessibleContracts)
        {
            var latestContractIds = GetLatestContracts();

            var query = from contract in context.ContractEntity
                        where latestContractIds.Contains(contract.Id)
                        where contract.ContractStateId == ItemFromGroup.ContractStates.CONTRACTED && accessibleContracts.Contains((int)contract.ContractId)

                        let personal = contract.PersonalInformationEntity
                        orderby personal.FirstName

                        join workStationItem in context.GroupItemEntity
                        on contract.ContractId equals workStationItem.Id into workStationItemGroup
                        from workStationItem in workStationItemGroup.DefaultIfEmpty()

                        join agencyItem in context.GroupItemEntity
                        on personal.AgencyId equals agencyItem.Id into agencyItemGroup
                        from agencyItem in agencyItemGroup.DefaultIfEmpty()

                        select new AgeReportItemViewModel
                        {
                            FullName = personal.FirstName + " " + personal.LastName,
                            DateOfBirth = personal.DateOfBirth,
                            WorkStation = workStationItem.Description,
                            Agency = agencyItem.Description,
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

            var userId = GetCurrentUserId();
            var hasFullAccess = MechanicalWorkshopUtil.HasFullAccess(GetCurrentUserRole());

            var monthlyDates = context.DisciplinaryNotificationEntity
                .GroupBy(d => new { d.Date.Year, d.Date.Month })
                .Select(g => g.OrderBy(x => x.Date).First().Date)
                .ToList();


            var dates = new SelectList(
                monthlyDates.Select(
                    d => new {
                                            Value = d.ToString(TimeUtil.yyyy_MM_dd), // or just d if you're binding to a DateTime
                                            Text = d.ToString(TimeUtil.MMMM_yyyy, new CultureInfo("pt-PT")) // e.g., "julho 2025"
                                        }
                  ), "Value",  "Text"
            );

            SelectList? contracts;

            if (hasFullAccess)
            {
                contracts = GroupItems(
                    Groups.MECHANICAL_SHOP_CONTRACTS,
                    OrderType.Alphabetic, 
                    StringConstants.Report.ALL_CONTRACTS_ID, 
                    StringConstants.Report.ALL_CONTRACTS, 
                    true
                 );
            }
            else
            {
                var result =
                   from item in context.GroupItemEntity 
                   join contract in context.AdminMechanicalWorkShopContractEntity on item.Id equals contract.ContractId
                   where item.Active &&
                                   contract.UserId == userId 
                   orderby item.Description
                   select item;

                contracts = GroupItems(result, OrderType.Alphabetic, StringConstants.Report.ALL_CONTRACTS, true);
            }

            var model = new AlchoolTestViewModel
            {
                Dates = dates,
                Contracts = contracts,
            };

            return model;
        }

        public async Task<AlchoolTestReportViewModel> GetAlchoolTestReport(string contractDescription, DateTime date, List<int> accessibleContracts)
        {
            var startOfMonth = new DateTime(date.Year, date.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            var latestContractIds = GetLatestContracts();

                var query = from contract in context.ContractEntity
                            where latestContractIds.Contains(contract.Id)
                            where contract.ContractStateId == ItemFromGroup.ContractStates.CONTRACTED && accessibleContracts.Contains((int)contract.ContractId)

                            let personal = contract.PersonalInformationEntity
                            orderby personal.FirstName

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


        /*..............DRIVERS LICENCE....................*/

        public async Task<DriversLicenceReportFormViewModel> GetDriversLicenceForm()
        {
            var userId = GetCurrentUserId();
            var hasFullAccess = MechanicalWorkshopUtil.HasFullAccess(GetCurrentUserRole());

            SelectList? contracts;

            if (hasFullAccess)
            {
                contracts = GroupItems(
                    Groups.MECHANICAL_SHOP_CONTRACTS,
                    OrderType.Alphabetic,
                    StringConstants.Report.ALL_CONTRACTS_ID,
                    StringConstants.Report.ALL_CONTRACTS,
                    true
                 );
            }
            else
            {
                var result =
                   from item in context.GroupItemEntity
                   join contract in context.AdminMechanicalWorkShopContractEntity on item.Id equals contract.ContractId
                   where item.Active &&
                                   contract.UserId == userId
                   orderby item.Description
                   select item;

                contracts = GroupItems(result, OrderType.Alphabetic, StringConstants.Report.ALL_CONTRACTS, true);
            }

            var model = new DriversLicenceReportFormViewModel
            {
                Contracts = contracts,
            };

            return model;
        }

        public async Task<DriversLicenceReportViewModel> GetDriversLicenceReport(List<int> accessibleContracts)
        {
            var latestContractIds = GetLatestContracts();

            var query = from contract in context.ContractEntity
                        where latestContractIds.Contains(contract.Id)
                        where contract.ContractStateId == ItemFromGroup.ContractStates.CONTRACTED && accessibleContracts.Contains((int)contract.ContractId)

                        let personal = contract.PersonalInformationEntity
                        orderby personal.FirstName

                        join licence in (
                            from licenceInfo in context.DriversLicenceEntity
                            select new
                            {
                                licenceInfo.PersonalInformationId,
                                licenceInfo.ProvisionalExpirationDate,
                                licenceInfo.ExpirationDate,
                                licenceInfo.LicenceTypeId,
                            }
                        )
                        on contract.PersonalInformationEntity.Id equals licence.PersonalInformationId into contractJoin
                        from contractResult in contractJoin/*.Take(1)*/.DefaultIfEmpty()
                        where contractResult.PersonalInformationId != null

                        join workStationItem in context.GroupItemEntity
                        on contract.ContractId equals workStationItem.Id into workStationItemGroup
                        from workStationItem in workStationItemGroup.DefaultIfEmpty()

                        join licenceTypeItem in context.GroupItemEntity
                        on contractResult.LicenceTypeId equals licenceTypeItem.Id into licenceTypeItemGroup
                        from licenceTypeItem in licenceTypeItemGroup.DefaultIfEmpty()


                        select new DriversLicenceReportItemViewModel
                        {
                            FullName = personal.FirstName + " " + personal.LastName,
                            LicenceExpirationDate = contractResult.ExpirationDate,
                            ProvisionalExpirationDate = contractResult.ProvisionalExpirationDate,
                            WorkStation = workStationItem.Description,
                            Licence = licenceTypeItem.Description
                        };

            var result = await query.ToListAsync();

            return new DriversLicenceReportViewModel
            {
                report = result,
            };
        }

        /*..............MEDICAL EXAM....................*/

        public async Task<MedicalExamReportFormViewModel> GetMedicalExamForm()
        {
            var userId = GetCurrentUserId();
            var hasFullAccess = MechanicalWorkshopUtil.HasFullAccess(GetCurrentUserRole());

            var yearDates = context.MedicalExamEntity
                .GroupBy(d => new { d.Date.Year })
                .Select(g => g.OrderBy(x => x.Date).First().Date)
                .ToList();

            var dates = new SelectList(
                yearDates.Select(
                    d => new {
                        Value = d.ToString(TimeUtil.yyyy), // or just d if you're binding to a DateTime
                        Text = d.ToString(TimeUtil.yyyy, new CultureInfo("pt-PT")) // e.g., "julho 2025"
                    }
                  ), "Value", "Text"
            );

            SelectList? contracts;

            if (hasFullAccess)
            {
                contracts = GroupItems(
                    Groups.MECHANICAL_SHOP_CONTRACTS,
                    OrderType.Alphabetic,
                    StringConstants.Report.ALL_CONTRACTS_ID,
                    StringConstants.Report.ALL_CONTRACTS,
                    true
                 );
            }
            else
            {
                var result =
                   from item in context.GroupItemEntity
                   join contract in context.AdminMechanicalWorkShopContractEntity on item.Id equals contract.ContractId
                   where item.Active &&
                                   contract.UserId == userId
                   orderby item.Description
                   select item;

                contracts = GroupItems(result, OrderType.Alphabetic, StringConstants.Report.ALL_CONTRACTS, true);
            }

            var model = new MedicalExamReportFormViewModel
            {
                Dates = dates,
                Contracts = contracts,
            };

            return model;
        }
        public async Task<MedicalExamReportViewModel> GetMedicalExamReport(int year, List<int> accessibleContracts)
        {
            var latestContractIds = GetLatestContracts();

            var query = from contract in context.ContractEntity
                        where latestContractIds.Contains(contract.Id)
                        where contract.ContractStateId == ItemFromGroup.ContractStates.CONTRACTED && accessibleContracts.Contains((int)contract.ContractId)

                        let personal = contract.PersonalInformationEntity
                        orderby personal.FirstName

                        join medical in (
                            from medicalInfo in context.MedicalExamEntity
                            where medicalInfo.Date.Year == year
                            select new
                            {
                                medicalInfo.PersonalInformationId,
                                medicalInfo.ExamId,
                                medicalInfo.Date,
                                medicalInfo.ResultId,
                            }
                        )
                        on contract.PersonalInformationEntity.Id equals medical.PersonalInformationId into contractJoin
                        from contractResult in contractJoin/*.Take(1)*/.DefaultIfEmpty()
                        where contractResult.PersonalInformationId != null

                        join workStationItem in context.GroupItemEntity
                        on contract.ContractId equals workStationItem.Id into workStationItemGroup
                        from workStationItem in workStationItemGroup.DefaultIfEmpty()

                        join examItem in context.GroupItemEntity
                        on contractResult.ExamId equals examItem.Id into examItemGroup
                        from examItem in examItemGroup.DefaultIfEmpty()

                        join examResultItem in context.GroupItemEntity
                        on contractResult.ResultId equals examResultItem.Id into examResultItemGroup
                        from examResultItem in examResultItemGroup.DefaultIfEmpty()

                        select new MedicalExamReportItemViewModel
                        {
                            FullName = personal.FirstName + " " + personal.LastName,
                            Date = contractResult.Date,
                            WorkStation = workStationItem.Description,
                            Exam = examItem.Description,
                            Situation = examResultItem.Description
                        };

            var result = await query.ToListAsync();

            return new MedicalExamReportViewModel
            {
                report = result,
                Date = year
            };
        }


        /*..............PROFESSION + EXPERIENCE....................*/

        public async Task<ProfessionalExperienceReportFormViewModel> GetProfessionalExperienceForm()
        {
            var userId = GetCurrentUserId();
            var hasFullAccess = MechanicalWorkshopUtil.HasFullAccess(GetCurrentUserRole());

            SelectList? contracts;
            SelectList? professions;

            if (hasFullAccess)
            {
                contracts = GroupItems(
                    Groups.MECHANICAL_SHOP_CONTRACTS,
                    OrderType.Alphabetic,
                    StringConstants.Report.ALL_CONTRACTS_ID,
                    StringConstants.Report.ALL_CONTRACTS,
                    true
                 );
            }
            else
            {
                var result =
                   from item in context.GroupItemEntity
                   join contract in context.AdminMechanicalWorkShopContractEntity on item.Id equals contract.ContractId
                   where item.Active &&
                                   contract.UserId == userId
                   orderby item.Description
                   select item;

                contracts = GroupItems(result, OrderType.Alphabetic, StringConstants.Report.ALL_CONTRACTS, true);
            }

            var experience = GroupItems(Groups.WORKSTATIONS, OrderType.Alphabetic, -1, StringConstants.Report.ALL_WORK_EXPERIENCE, true);

            var model = new ProfessionalExperienceReportFormViewModel
            {
                Experiences = experience,
                Contracts = contracts,
            };

            return model;
        }

        public async Task<ProfessionalExperienceReportViewModel> GetProfessionalExperienceReport(int experienceId, List<int> accessibleContracts)
        {
            var latestContractIds = GetLatestContracts();

            var query = from contract in context.ContractEntity
                        where latestContractIds.Contains(contract.Id)
                        where contract.ContractStateId == ItemFromGroup.ContractStates.CONTRACTED && accessibleContracts.Contains((int)contract.ContractId)

                        let personal = contract.PersonalInformationEntity
                        orderby personal.FirstName

                        join experience in (
                            from experienceInfo in context.ProfessionalExperienceEntity
                            where experienceId == StringConstants.Report.ALL_WORK_EXPERIENCE_ID || experienceInfo.WorkstationId == experienceId
                            select new
                            {
                                experienceInfo.PersonalInformationId,
                                experienceInfo.CompanyId,
                                experienceInfo.Months,
                                experienceInfo.WorkstationId,
                            }
                        )
                        on contract.PersonalInformationEntity.Id equals experience.PersonalInformationId into contractJoin
                        from contractResult in contractJoin.DefaultIfEmpty()
                        where contractResult.PersonalInformationId != null

                        join companyItem in context.GroupItemEntity
                        on contractResult.CompanyId equals companyItem.Id into companyItemGroup
                        from companyItem in companyItemGroup.DefaultIfEmpty()

                        join experienceItem in context.GroupItemEntity
                        on contractResult.WorkstationId equals experienceItem.Id into experienceItemGroup
                        from experienceItem in experienceItemGroup.DefaultIfEmpty()

                        select new ProfessionalExperienceReportItemViewModel
                        {
                            FullName = personal.FirstName + " " + personal.LastName,
                            Company = companyItem.Description,
                            Experience = experienceItem.Description,
                            Months = contractResult.Months,
                        };

            var result = await query.ToListAsync();

            return new ProfessionalExperienceReportViewModel
            {
                report = result,
            };
        }

        /*..............MEDICAL EXAM....................*/

        public async Task<TrainningReportFormViewModel> GetTrainningForm(int trainningId)
        {
            var userId = GetCurrentUserId();
            var hasFullAccess = MechanicalWorkshopUtil.HasFullAccess(GetCurrentUserRole());

            var yearDates = context.TrainningEntity
                .Where(item => item.TrainningId == trainningId)
                .GroupBy(d => new { d.Date.Year })
                .Select(g => g.OrderBy(x => x.Date).First().Date)
                .OrderBy(x => x.Date)
                .ToList();

            var dates = new SelectList(
                yearDates.Select(
                    d => new {
                        Value = d.ToString(TimeUtil.yyyy), // or just d if you're binding to a DateTime
                        Text = d.ToString(TimeUtil.yyyy, new CultureInfo("pt-PT")) // e.g., "julho 2025"
                    }
                  ), "Value", "Text"
            );

            SelectList? contracts;

            if (hasFullAccess)
            {
                contracts = GroupItems(
                    Groups.MECHANICAL_SHOP_CONTRACTS,
                    OrderType.Alphabetic,
                    StringConstants.Report.ALL_CONTRACTS_ID,
                    StringConstants.Report.ALL_CONTRACTS,
                    true
                 );
            }
            else
            {
                var result =
                   from item in context.GroupItemEntity
                   join contract in context.AdminMechanicalWorkShopContractEntity on item.Id equals contract.ContractId
                   where item.Active &&
                                   contract.UserId == userId
                   orderby item.Description
                   select item;

                contracts = GroupItems(result, OrderType.Alphabetic, StringConstants.Report.ALL_CONTRACTS, true);
            }

            var model = new TrainningReportFormViewModel
            {
                Dates = dates,
                Contracts = contracts,
            };

            return model;
        }
        public async Task<TrainningReportViewModel> GetTrainningReport(int year, List<int> accessibleContracts, int trainningId)
        {
            var latestContractIds = GetLatestContracts();

            var query = from contract in context.ContractEntity
                        where latestContractIds.Contains(contract.Id)
                        where contract.ContractStateId == ItemFromGroup.ContractStates.CONTRACTED && accessibleContracts.Contains((int)contract.ContractId)

                        let personal = contract.PersonalInformationEntity
                        orderby personal.FirstName

                        join trainning in (
                            from trainningInfo in context.TrainningEntity
                            where trainningInfo.Date.Year == year && trainningInfo.TrainningId == trainningId
                            select new
                            {
                                trainningInfo.PersonalInformationId,
                                trainningInfo.TrainningId,
                                trainningInfo.Date,
                            }
                        )
                        on contract.PersonalInformationEntity.Id equals trainning.PersonalInformationId into contractJoin
                        from contractResult in contractJoin/*.Take(1)*/.DefaultIfEmpty()

                        join workStationItem in context.GroupItemEntity
                        on contract.ContractId equals workStationItem.Id into workStationItemGroup
                        from workStationItem in workStationItemGroup.DefaultIfEmpty()

                        join trainningItem in context.GroupItemEntity
                        on contractResult.TrainningId equals trainningItem.Id into trainningItemGroup
                        from trainningItem in trainningItemGroup.DefaultIfEmpty()

                        select new TrainningReportItemViewModel
                        {
                            FullName = personal.FirstName + " " + personal.LastName,
                            Date = contractResult.Date,
                            WorkStation = workStationItem.Description,
                            Trainning = trainningItem.Description,
                        };

            var result = await query.ToListAsync();

            return new TrainningReportViewModel
            {
                report = result,
                Date = year
            };
        }

    }
}
