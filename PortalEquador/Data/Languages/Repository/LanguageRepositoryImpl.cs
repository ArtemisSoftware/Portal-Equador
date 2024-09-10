using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using PortalEquador.Data.Generic;
using PortalEquador.Data.Languages.entity;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Languages.Repository;
using PortalEquador.Domain.Languages.ViewModels;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Data.Languages.Repository
{
    public class LanguageRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<LanguageEntity>(context, httpContextAccessor), ILanguageRepository
    {
        public async Task<List<LanguageDetailViewModel>> GetAll(int personalInformationId)
        {
            var result = await context.LanguageEntity
                .Include(d => d.LanguageGroupItemEntity)
                .Include(d => d.OralLevelGroupItemEntity)
                .Include(d => d.WrittenLevelGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .Where(item => item.PersonalInformationId == personalInformationId)
                .ToListAsync();

            return mapper.Map<List<LanguageDetailViewModel>>(result);
        }

        public async Task<LanguageViewModel> GetCreateModel(int personalInformationId, string fullName)
        {
            var languages = GroupItems(Groups.LANGUAGES);
            var languageLevel = GroupItems(Groups.LANGUAGE_LEVEL);

            var model = new LanguageViewModel
            {
                PersonaInformationId = personalInformationId,
                FullName = fullName,
                Languages = languages,
                OralLevels = languageLevel,
                WrittenLevels = languageLevel,
            };

            return model;
        }

        public async Task<LanguageViewModel> GetCreateModel(LanguageViewModel model)
        {
            var languages = GroupItems(Groups.LANGUAGES);
            var languageLevel = GroupItems(Groups.LANGUAGE_LEVEL);

            model.OralLevels = languageLevel;
            model.WrittenLevels = languageLevel;
            model.Languages = languages;

            return model;
        }

        public async Task<LanguageViewModel> GetLanguage(int id)
        {
            var result = await context.LanguageEntity
                            .Include(item => item.OralLevelGroupItemEntity)
                            .Include(item => item.WrittenLevelGroupItemEntity)
                            .Include(item => item.LanguageGroupItemEntity)
                            .Where(item => item.Id == id)
                            .FirstOrDefaultAsync();

            return mapper.Map<LanguageViewModel>(result);
        }

        public async Task<bool> LanguageExists(int personalInformationId, int languageId)
        {
            return await context.LanguageEntity.AnyAsync(item => item.PersonalInformationId == personalInformationId & item.LanguageId == languageId);
        }

        public async Task Save(LanguageViewModel model)
        {
            var entity = mapper.Map<LanguageEntity>(model);
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
    }
}
