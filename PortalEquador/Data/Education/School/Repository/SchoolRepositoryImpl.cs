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
            var institutions = GroupItems(Groups.SCHOOLS, OrderType.Alphabetic);
            var courses = GroupItems(Groups.SCHOOL_COURSES, OrderType.Alphabetic);
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
            var institutions = GroupItems(Groups.SCHOOLS, OrderType.Alphabetic);
            var courses = GroupItems(Groups.SCHOOL_COURSES, OrderType.Alphabetic);
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

            var resultMapped = mapper.Map<SchoolViewModel>(result);

            if(result.MajorId == null)
            {
                resultMapped.MajorNotDeclared = true;
            }

            return resultMapped;
        }

        public async Task Save(SchoolViewModel model)
        {
            var entity = mapper.Map<SchoolEntity>(model);
            entity.EditorId = GetCurrentUserId();

            if(model.MajorNotDeclared)
            {
                entity.MajorId = null;
                entity.MajorGroupItemEntity = null;
            }

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

        public async Task<bool> SchoolExists(int personalInformationId, int institutionId, int? majorId, int degreeId)
        {
            return await context.SchoolEntity.AnyAsync(
                item => item.PersonalInformationId == personalInformationId 
                & item.InstitutionId == institutionId
                & item.MajorId == majorId
                 & item.DegreeId == degreeId
                );
        }
    }
}
