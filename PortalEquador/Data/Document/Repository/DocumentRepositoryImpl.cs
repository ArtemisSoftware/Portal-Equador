using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PortalEquador.Data.Document.Entity;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Util;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Data.Document.Repository
{
    public class DocumentRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment hostEnvironment) : GenericRepository<DocumentEntity>(context, httpContextAccessor), IDocumentRepository
    {
        public async Task<DocumentViewModel> GetCreateModel(int personaInformationId, string fullName)
        {

            var documentsTypes = GroupItems(Groups.DOCUMENTS);
            
            var model = new DocumentViewModel
            {
                DocumentTypes = documentsTypes,
                PersonaInformationId = personaInformationId,
                FullName = fullName
            };

            return model;
        }

        public async Task<bool> DocumentExists(int personaInformationId, int documentTypeId)
        {
            return await context.DocumentEntity.AnyAsync(item => item.PersonalInformationId == personaInformationId & item.DocumentTypeId == documentTypeId);
        }

        public async Task Save(DocumentViewModel model)
        {
            var extension = Path.GetExtension(model.ImageFile.FileName);
            var operationType = await ImagesUtil.SaveImage(hostEnvironment, model);

            var entity = mapper.Map<DocumentEntity>(model);
            entity.Extension = extension;
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

        /*
        public async Task<List<DocumentDetailViewModel>> GetAllDocumentsAsync(int PersonalInformationId)
        {
            var result = await context.DocumentEntity
                .Include(d => d.DocumentTypeGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .Where(item => item.PersonalInformationId == PersonalInformationId)
                .ToListAsync();

            return _mapper.Map<List<DocumentDetailViewModel>>(result);

            //return new List<DocumentDetailViewModel>();
        }

        public async Task<DocumentViewModel> GetDocumentAsync(int id)
        {
            var result = await context.DocumentEntity
               .Include(d => d.DocumentTypeGroupItemEntity)
               .Where(item => item.Id == id).FirstAsync();

            return _mapper.Map<DocumentViewModel>(result);

            //return new DocumentViewModel();
        }







        public async Task<List<DocumentDetailViewModel>> GetDocumentsDetails(int personalInformationId, int GroupItemId)
        {

            var result = await context.DocumentEntity
                .Include(d => d.DocumentTypeGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .Where(item => item.PersonalInformationId == personalInformationId && item.DocumentTypeId == GroupItemId)
                .ToListAsync();

            return _mapper.Map<List<DocumentDetailViewModel>>(result);

            //return new List<DocumentDetailViewModel>();
        }

        public async Task<List<DocumentDetailViewModel>> GetDocumentsDetails(int personalInformationId, List<int> DocumentsGroupIds)
        {
            var result = await context.DocumentEntity
               .Include(d => d.DocumentTypeGroupItemEntity)
               .Include(d => d.PersonalInformationEntity)
               .Where(item => item.PersonalInformationId == personalInformationId && DocumentsGroupIds.Contains(item.DocumentTypeId) == true)
               .ToListAsync();

            return _mapper.Map<List<DocumentDetailViewModel>>(result);
        }
        */

    }
}
