using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.Profession.Experience.Entity;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Util.Constants;

namespace PortalEquador.Data.Report.Repository
{
    public class ReportRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor
        ) : GenericRepository<ProfessionalExperienceEntity>(context, httpContextAccessor), IReportRepository
    {
        public async Task<AgeReportViewModel> GetAgeReport()
        {

            var latestContractIds = context.ContractEntity
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
    }
}
