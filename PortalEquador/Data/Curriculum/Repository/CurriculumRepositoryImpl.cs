using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Curriculum.Entities;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Contract;
using PortalEquador.Domain.Curriculum.Repository;
using PortalEquador.Domain.Curriculum.ViewModels;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Constants;
using System.Diagnostics.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PortalEquador.Data.Curriculum.Repository
{
    public class CurriculumRepositoryImpl(
        ApplicationDbContext context, 
        IMapper mapper, 
        IHttpContextAccessor httpContextAccessor, 
        IWebHostEnvironment hostEnvironment
        ) : GenericRepository<CurriculumEntity>(context, httpContextAccessor), CurriculumRepository
    {
        public async Task<CurriculumDashboardViewModel> GetCurriculumDashboard(int id)
        {
            var query = from personal in context.PersonalInformationEntity

                        join ctc in
                            (from contract in context.ContractEntity
                             where contract.PersonalInformationId == id
                             orderby contract.DateOfContract descending
                             select contract).Take(1)
                            .Select(grouped => new
                            {
                                PersonalInformationId = grouped.PersonalInformationId,
                                ContractId = grouped.Id,
                                ContractStateId = grouped.ContractStateId
                            })
                        on personal.Id equals ctc.PersonalInformationId into resultCtc
                        from resultContract in resultCtc.DefaultIfEmpty()


                        join contractCount in
                            (from contract in context.ContractEntity
                             where contract.PersonalInformationId == id
                             select contract).GroupBy(d => d.PersonalInformationId)
                            .Select(grouped => new
                            {
                                PersonalInformationId = grouped.Key,
                                ContractCount = grouped.Count()
                            })
                        on personal.Id equals contractCount.PersonalInformationId into resultCtcs
                        from resultContracts in resultCtcs.DefaultIfEmpty()


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

                        join driversLicenceCount in
                            (from driversLicence in context.DriversLicenceEntity
                             where driversLicence.PersonalInformationId == id
                             select driversLicence).GroupBy(d => d.PersonalInformationId)
                            .Select(grouped => new
                            {
                                PersonalInformationId = grouped.Key,
                                DriversLicenceCount = grouped.Count()
                            })
                        on personal.Id equals driversLicenceCount.PersonalInformationId into resultDriversLicence
                        from resultDriversLicences in resultDriversLicence.DefaultIfEmpty()

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

                        join professionalCompetenceCount in
                            (from professionalCompetence in context.ProfessionalCompetenceEntity
                             where professionalCompetence.PersonalInformationId == id
                             select professionalCompetence).GroupBy(d => d.PersonalInformationId)
                            .Select(grouped => new
                            {
                                PersonalInformationId = grouped.Key,
                                ProfessionalCompetenceCount = grouped.Count()
                            })
                        on personal.Id equals professionalCompetenceCount.PersonalInformationId into resultProfessionalCompetence
                        from resultProfessionalCompetences in resultProfessionalCompetence.DefaultIfEmpty()

                        join professionalExperienceCount in
                            (from professionalExperience in context.ProfessionalExperienceEntity
                             where professionalExperience.PersonalInformationId == id
                             select professionalExperience).GroupBy(d => d.PersonalInformationId)
                            .Select(grouped => new
                            {
                                PersonalInformationId = grouped.Key,
                                Count = grouped.Count()
                            })
                        on personal.Id equals professionalExperienceCount.PersonalInformationId into resultProfessionalExperience
                        from resultProfessionalExperiences in resultProfessionalExperience.DefaultIfEmpty()

                        join schoolCount in
                            (from school in context.SchoolEntity
                             where school.PersonalInformationId == id
                             select school).GroupBy(d => d.PersonalInformationId)
                            .Select(grouped => new
                            {
                                PersonalInformationId = grouped.Key,
                                Count = grouped.Count()
                            })
                        on personal.Id equals schoolCount.PersonalInformationId into resultSchool
                        from resultSchools in resultSchool.DefaultIfEmpty()

                        join universityCount in
                            (from school in context.UniversityEntity
                             where school.PersonalInformationId == id
                             select school).GroupBy(d => d.PersonalInformationId)
                            .Select(grouped => new
                            {
                                PersonalInformationId = grouped.Key,
                                Count = grouped.Count()
                            })
                        on personal.Id equals universityCount.PersonalInformationId into resultUniversity
                        from resultUniversities in resultUniversity.DefaultIfEmpty()

                        where personal.Id == id

                        select new CurriculumDashboardViewModel
                        {
                            Id = id,
                            FullName = personal.FirstName + " " + personal.LastName,
                            IsPersonalInformationComplete = (personal.Id != 0),
                            TotalLanguages = resultLanguages.LanguageCount == null ? 0 : resultLanguages.LanguageCount,
                            TotalDocuments = resultDocuments.OrderDetailCount == null ? 0 : resultDocuments.OrderDetailCount,
                            TotalProfessionalCompetences = resultProfessionalCompetences.ProfessionalCompetenceCount == null ? 0 : resultProfessionalCompetences.ProfessionalCompetenceCount,
                            TotalProfessionalExperiences = resultProfessionalExperiences.Count == null ? 0 : resultProfessionalExperiences.Count,
                            TotalSchoolEducation = resultSchools.Count == null ? 0 : resultSchools.Count,
                            TotalUniversityEducation = resultUniversities.Count == null ? 0 : resultUniversities.Count,
                            TotalDriversLicence = resultDriversLicences.DriversLicenceCount == null ? 0 : resultDriversLicences.DriversLicenceCount,
                            ContractId = resultContract.ContractStateId == null ? 0 : resultContract.ContractStateId,
                            TotalContracts = resultContracts.ContractCount == null ? 0 : resultContracts.ContractCount,
                            ProfileImagePath = ImagesUtil.GetProfileImagePath(hostEnvironment, id)
                        };

            var result = await query.FirstOrDefaultAsync();
            var contractModel = await GroupItem(result.ContractId);
            if (contractModel != null)
            {
                result.Contract = mapper.Map<GroupItemViewModel>(contractModel);
            }

            return result;
        }

        public async Task<List<CurriculumViewModel>> GetCurriculums()
        {
            var query = from personal in context.PersonalInformationEntity

                        join contract in (
                            from c in context.ContractEntity
                            orderby c.DateOfContract descending
                            select new
                            {
                                c.Id,
                                c.PersonalInformationId,
                                c.ContractStateId
                            }
                        ) on personal.Id equals contract.PersonalInformationId into contractJoin
                        from contract in contractJoin.Take(1).DefaultIfEmpty()

                        join groupItem in context.GroupItemEntity
                                           on contract.ContractStateId equals groupItem.Id into groupItemGroup
                        from groupItem in groupItemGroup.DefaultIfEmpty()


                        select new CurriculumViewModel
                        {
                            Id = personal.Id,
                            FullName = personal.FirstName + " " + personal.LastName,
                            ProfileImagePath = ImagesUtil.GetProfileImagePath(hostEnvironment, personal.Id),
                            ContractDescription = groupItem != null ? groupItem.Description : "",
                            ContractId = groupItem != null ? groupItem.Id : null,
                        };

            var result = await query.ToListAsync();
            return result;
        }
    }
}
