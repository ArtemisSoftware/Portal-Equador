﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Curriculum.Entities;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Curriculum.Repository;
using PortalEquador.Domain.Curriculum.ViewModels;
using PortalEquador.Domain.GroupTypes.Repository;

namespace PortalEquador.Data.Curriculum.Repository
{
    public class CurriculumRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<CurriculumEntity>(context, httpContextAccessor), CurriculumRepository
    {
        public async Task<CurriculumDashboardViewModel> GetCurriculumDashboard(int id)
        {
            //return new CurriculumDashboardViewModel { FullName = "Lopes"};

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
                            /*
join competences in
    (from competences in context.ProfessionalCompetenceEntity
     group competences by competences.PersonalInformationId into groupedCompetences
     select new
     {
         PersonalInformationId = groupedCompetences.Key,
         CompetencesCount = groupedCompetences.Count()
     })
on personal.Id equals competences.PersonalInformationId into resultComp
from resultCompetences in resultComp.DefaultIfEmpty()

join expertises in
    (from expertises in context.ProfessionalExperienceEntity
     group expertises by expertises.PersonalInformationId into groupedExpertises
     select new
     {
         PersonalInformationId = groupedExpertises.Key,
         ExpertisesCount = groupedExpertises.Count()
     })
on personal.Id equals expertises.PersonalInformationId into resultExp
from resultExpertises in resultExp.DefaultIfEmpty()
    */
                        where personal.Id == id

                        select new CurriculumDashboardViewModel
                        {
                            Id = id,
                            FullName = personal.FirstName + " " + personal.LastName,
                            IsPersonalInformationComplete = (personal.Id != 0),
                            
                            TotalDocuments = resultDocuments.OrderDetailCount == null ? 0 : resultDocuments.OrderDetailCount,
                            /*TotalCompetences = resultCompetences.CompetencesCount == null ? 0 : resultCompetences.CompetencesCount,
                            TotalExpertises = resultExpertises.ExpertisesCount == null ? 0 : resultExpertises.ExpertisesCount,
                            IsDriversLicenceComplete = true//resultDriversLicence.HasDriverLicence
                            */
                        };

            return await query.FirstOrDefaultAsync();
        }
    }
}
