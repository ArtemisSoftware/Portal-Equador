using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Curriculum.Entities;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Curriculum.Repository;
using PortalEquador.Domain.Curriculum.ViewModels;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Util;
using PortalEquador.Util.Constants;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PortalEquador.Data.Curriculum.Repository
{
    public class CurriculumRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment hostEnvironment) : GenericRepository<CurriculumEntity>(context, httpContextAccessor), CurriculumRepository
    {
        public async Task<CurriculumDashboardViewModel> GetCurriculumDashboard(int id)
        {

            var query = from personal in context.PersonalInformationEntity

                        join docCount in
                            (from document in context.DocumentEntity
                             where document.PersonalInformationId == id
                             select document).GroupBy(d => d.PersonalInformationId)
                            .Select(grouped => new
                            {
                                PersonalInformationId = grouped.Key,
                                OrderDetailCount = grouped.Count()
                            })
                        on personal.Id equals docCount.PersonalInformationId into resultDocs
                        from resultDocuments in resultDocs.DefaultIfEmpty()

                        join languageCount in
                            (from language in context.LanguageEntity
                             where language.PersonalInformationId == id
                             select language).GroupBy(d => d.PersonalInformationId)
                            .Select(grouped => new
                            {
                                PersonalInformationId = grouped.Key,
                                LanguageCount = grouped.Count()
                            })
                        on personal.Id equals languageCount.PersonalInformationId into resultLanguage
                        from resultLanguages in resultLanguage.DefaultIfEmpty()


                        where personal.Id == id

                        select new CurriculumDashboardViewModel
                        {
                            Id = id,
                            FullName = personal.FirstName + " " + personal.LastName,
                            IsPersonalInformationComplete = (personal.Id != 0),
                            TotalLanguages = resultLanguages.LanguageCount == null ? 0 : resultLanguages.LanguageCount,
                            TotalDocuments = resultDocuments.OrderDetailCount == null ? 0 : resultDocuments.OrderDetailCount,
                            ProfileImagePath = ImagesUtil.GetProfileImagePath(hostEnvironment, id)
                        };
            return await query.FirstOrDefaultAsync();
        }
    }
}
