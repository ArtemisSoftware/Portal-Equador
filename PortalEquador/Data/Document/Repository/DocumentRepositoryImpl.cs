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
        public async Task<List<DocumentDetailViewModel>> GetAllDocuments(int PersonalInformationId)
        {
            var result = await context.DocumentEntity
                .Include(d => d.DocumentTypeGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .Where(item => item.PersonalInformationId == PersonalInformationId)
                .ToListAsync();

            return mapper.Map<List<DocumentDetailViewModel>>(result);
        }

        public async Task<DocumentViewModel> GetCreateModel(DocumentViewModel model)
        {
            var documentsTypes = GroupItems(Groups.DOCUMENTS);
            model.DocumentTypes = documentsTypes;
            return model;
        }

        public async Task<DocumentViewModel> GetCreateModel(int personaInformationId, string fullName)
        {
            var documentsTypes = GroupItems(Groups.DOCUMENTS);
            
            var model = new DocumentViewModel
            {
                DocumentTypes = documentsTypes,
                PersonaInformationId = personaInformationId,
                FullName = fullName,
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

        private async Task<DocumentViewModel> GetDocument(int id)
        {
            var result = await context.DocumentEntity
               .Include(d => d.DocumentTypeGroupItemEntity)
               .Where(item => item.Id == id)
               .FirstAsync();

            return mapper.Map<DocumentViewModel>(result);

        }

        private async Task<DocumentViewModel?> GetDocumentByType(int personaInformationId, int documentTypeId)
        {
            var result = await context.DocumentEntity
               .Include(d => d.DocumentTypeGroupItemEntity)
               .Where(item => item.PersonalInformationId == personaInformationId & item.DocumentTypeId == documentTypeId)
               .FirstAsync();

            if(result == null)
            {
                return null;
            }

            return mapper.Map<DocumentViewModel>(result);

        }

        public async Task DeleteDocument(int personaInformationId, int documentId)
        {
            var model = await GetDocument(documentId);
            ImagesUtil.DeleteImage(hostEnvironment, model);
            await DeleteAsync(documentId);
        }

        public async Task DeleteDocumentByType(int personaInformationId, int documentTypeId)
        {
            var model = await GetDocumentByType(personaInformationId, documentTypeId);
            if(model == null)
            {
                return;
            } else
            {
                ImagesUtil.DeleteImage(hostEnvironment, model);
                await DeleteAsync(model.Id);
            }
          
        }
    }
}
