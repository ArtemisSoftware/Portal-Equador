using AutoMapper;
using PortalEquador.Data.Contract.Entities;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Contract.Repository;
using PortalEquador.Domain.Contract.ViewModels;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util.Constants;
using PortalEquador.Util;

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
            /*
            var query = from contract in context.ContractEntity
                        join profileDoc in
                            (from document in context.DocumentEntity
                             where document.DocumentTypeId == GroupTypesConstants.ItemFromGroup.Documents.PROFILE_PICTURE
                             select document)
                        on contract.PersonalInformationId equals profileDoc.PersonalInformationId into resultProfileDocs
                        from resultProfileDocument in resultProfileDocs.DefaultIfEmpty()
                        orderby contract.FirstName
                        select new ContractViewModel
                        {
                            Id = contract.Id,
                            FullName = contract.FirstName,
                            LastName = contract.LastName,

                            ProfileImagePath = ImagesUtil.GetProfileImagePath(hostEnvironment, contract.Id)
                        };
            return await query.ToListAsync();
            */
            var list = new List<ContractViewModel>();
            list.Add(
                    new ContractViewModel {
                        Id = 1,
                        FullName = "Name",
                        StartDate = DateTime.Now,
                    }
                );
            return list;
        }

        public async Task<ContractDashboardViewModel> GetDashboard(int id)
        {
            var lolo = new ContractDashboardViewModel
            {
                Id = 1,
                FullName = "Name",
                ProfileImagePath = "",
                TotalExams = 1
            };

           return lolo;
        }
    }
}
