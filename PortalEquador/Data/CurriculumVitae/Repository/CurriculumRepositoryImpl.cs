using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.CurriculumVitae.Entities;
using PortalEquador.Domain.CurriculumVitae.Repository;
using PortalEquador.Domain.CurriculumVitae.ViewModels;
using PortalEquador.Repositories;

namespace PortalEquador.Data.CurriculumVitae.Repository
{
    public class CurriculumRepositoryImpl : GenericRepository<CurriculumEntity>, CurriculumRepository
    {
        public CurriculumRepositoryImpl(ApplicationDbContext context) : base(context){ }


        public async Task<CurriculumDashboardViewModel> GetCurriculumDashboard(int id)
        {
            //return new CurriculumDashboardViewModel();

            var query = from personal in context.PersonalInformationEntity
                            /*
                                        join diverlicences in
                                           (from diverlicences in context.DriversLicenceEntity
                                            group diverlicences by diverlicences.PersonalInformationId into grouped
                                            select new
                                            {
                                                PersonalInformationId = grouped.Key,
                                                HasDriverLicence = true//grouped.Count() > 0
                                            })
                                            on personal.Id equals diverlicences.PersonalInformationId into resultDL
                                            from resultDriversLicence in resultDL.DefaultIfEmpty()
                            */
                                        join documents in
                                            (from documents in context.DocumentEntity
                                             group documents by documents.PersonalInformationId into grouped
                                             select new
                                             {
                                                 PersonalInformationId = grouped.Key,
                                                 OrderDetailCount = grouped.Count()
                                             })
                                        on personal.Id equals documents.PersonalInformationId into resultDocs
                                        from resultDocuments in resultDocs.DefaultIfEmpty()
                        where personal.Id == id

                        select new CurriculumDashboardViewModel
                        {
                            Id = id,
                            FullName = personal.FirstName + " " + personal.LastName,
                            IsPersonalInformationComplete = (personal.Id != 0),
                            TotalDocuments = resultDocuments.OrderDetailCount == null ? 0 : resultDocuments.OrderDetailCount,
                            IsDriversLicenceComplete = true//resultDriversLicence.HasDriverLicence
                        };

            return await query.FirstOrDefaultAsync();
            
        }
    }
}
