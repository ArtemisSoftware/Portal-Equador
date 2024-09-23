using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.DriversLicence.Entity;
using PortalEquador.Data.Education.School.Entity;
using PortalEquador.Data.Education.University.Entity;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.Education.School.ViewModels;
using PortalEquador.Domain.Education.University.Repository;
using PortalEquador.Domain.Education.University.ViewModels;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Data.Education.University.Repository
{
    public class UniversityRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<UniversityEntity>(context, httpContextAccessor), IUniversityRepository
    {
        public async Task<List<UniversityDetailViewModel>> GetAll(int personalInformationId)
        {
            var result = await context.UniversityEntity
                .Include(d => d.InstitutionGroupItemEntity)
                .Include(d => d.MajorGroupItemEntity)
                .Include(d => d.DegreeGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .Where(item => item.PersonalInformationId == personalInformationId)
                .ToListAsync();

            return mapper.Map<List<UniversityDetailViewModel>>(result);
        }

        public async Task<UniversityViewModel> GetCreateModel(int personalInformationId, string fullName)
        {
            var institutions = GroupItems(Groups.UNIVERSITY);
            var courses = GroupItems(Groups.UNIVERSITY_COURSES);
            var degrees = GroupItems(Groups.UNIVERSITY_DEGREES);

            var model = new UniversityViewModel
            {
                PersonaInformationId = personalInformationId,
                FullName = fullName,
                Institutions = institutions,
                Majors = courses,
                Degrees = degrees,
            };

            return model;
        }

        public async Task<UniversityViewModel> GetCreateModel(UniversityViewModel model)
        {
            var institutions = GroupItems(Groups.UNIVERSITY);
            var courses = GroupItems(Groups.UNIVERSITY_COURSES);
            var degrees = GroupItems(Groups.UNIVERSITY_DEGREES);

            model.Institutions = institutions;
            model.Majors = courses;
            model.Degrees = degrees;

            return model;
        }

        public async Task<UniversityViewModel> GetUniversity(int id)
        {
            var result = await context.UniversityEntity
                            .Include(d => d.InstitutionGroupItemEntity)
                            .Include(d => d.MajorGroupItemEntity)
                            .Include(d => d.DegreeGroupItemEntity)
                            .Include(d => d.PersonalInformationEntity)
                            .Where(item => item.Id == id)
                            .FirstOrDefaultAsync();

            return mapper.Map<UniversityViewModel>(result);
        }

        public async Task Save(UniversityViewModel model)
        {
            var entity = mapper.Map<UniversityEntity>(model);
            entity.EditorId = GetCurrentUserId();

            if (model.Id == 0)
            {
                await AddAsync(entity);
            }
            else
            {
                entity.DateModified = DateTime.UtcNow;
                await UpdateAsync(entity);
            }
        }

        public async Task<bool> UniversityExists(int personalInformationId, int institutionId, int majorId)
        {
            return await context.UniversityEntity.AnyAsync(
                item => item.PersonalInformationId == personalInformationId
                & item.InstitutionId == institutionId
                 & item.MajorId == majorId
                );
        }
    }
}
