using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Education.School.Entity;
using PortalEquador.Data.Education.University.Entity;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Education.School.Repository;
using PortalEquador.Domain.Education.School.ViewModels;
using PortalEquador.Domain.Education.University.Repository;
using PortalEquador.Domain.Languages.ViewModels;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Data.Education.School.Repository
{
    public class SchoolRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<SchoolEntity>(context, httpContextAccessor), ISchoolRepository
    {
        public async Task<List<SchoolDetailViewModel>> GetAll(int personalInformationId)
        {
            var result = await context.SchoolEntity
                .Include(d => d.InstitutionGroupItemEntity)
                .Include(d => d.MajorGroupItemEntity)
                .Include(d => d.DegreeGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .Where(item => item.PersonalInformationId == personalInformationId)
                .ToListAsync();

            return mapper.Map<List<SchoolDetailViewModel>>(result);
        }

        public async Task<SchoolViewModel> GetCreateModel(int personalInformationId, string fullName)
        {
            var institutions = GroupItems(Groups.SCHOOLS);
            var courses = GroupItems(Groups.SCHOOL_COURSES);
            var degrees = GroupItems(Groups.SCHOOL_DEGREES);

            var model = new SchoolViewModel
            {
                PersonaInformationId = personalInformationId,
                FullName = fullName,
                Institutions = institutions,
                Majors = courses,
                Degrees = degrees,
            };

            return model;
        }

        public async Task<SchoolViewModel> GetCreateModel(SchoolViewModel model)
        {
            var institutions = GroupItems(Groups.SCHOOLS);
            var courses = GroupItems(Groups.SCHOOL_COURSES);
            var degrees = GroupItems(Groups.SCHOOL_DEGREES);

            model.Institutions = institutions;
            model.Majors = courses;
            model.Degrees = degrees;

            return model;
        }

        public async Task<SchoolViewModel> GetSchool(int id)
        {
            var result = await context.SchoolEntity
                            .Include(d => d.InstitutionGroupItemEntity)
                            .Include(d => d.MajorGroupItemEntity)
                            .Include(d => d.DegreeGroupItemEntity)
                            .Include(d => d.PersonalInformationEntity)
                            .Where(item => item.Id == id)
                            .FirstOrDefaultAsync();

            return mapper.Map<SchoolViewModel>(result);
        }

        public async Task Save(SchoolViewModel model)
        {
            var entity = mapper.Map<SchoolEntity>(model);
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

        public async Task<bool> SchoolExists(int personalInformationId, int institutionId, int courseId)
        {
            return await context.SchoolEntity.AnyAsync(
                item => item.PersonalInformationId == personalInformationId 
                & item.InstitutionId == institutionId
                 & item.MajorId == courseId
                );
        }
    }
}
