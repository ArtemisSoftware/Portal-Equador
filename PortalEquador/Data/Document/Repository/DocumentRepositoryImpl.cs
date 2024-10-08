using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PortalEquador.Data.Document.Entity;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Util;
using PortalEquador.Util.EnumTypes;
using static PortalEquador.Util.Constants.GroupTypesConstants;
using static PortalEquador.Util.Constants.GroupTypesConstants.ItemFromGroup;

namespace PortalEquador.Data.Document.Repository
{
    public class DocumentRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment hostEnvironment)
        : GenericRepository<DocumentEntity>(context, httpContextAccessor), IDocumentRepository
    {
        public async Task<List<DocumentViewModel>> GetAllDocuments(int PersonalInformationId)
        {
            var result = await context.DocumentEntity
                .Include(d => d.DocumentTypeGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
               .Include(d => d.SubTypeGroupItemEntity)
                .Where(item => item.PersonalInformationId == PersonalInformationId)
                .ToListAsync();

            var models = new List<DocumentViewModel>();
            mapper.Map<List<DocumentViewModel>>(result).ForEach(document => models.Add(ImagesUtil.ValidateDocument(hostEnvironment, document)));
            return models;
        }


        private async Task<DocumentViewModel> GetDocument(int id)
        {
            var result = await context.DocumentEntity
               .Include(d => d.DocumentTypeGroupItemEntity)
               .Where(item => item.Id == id)
               .FirstAsync();

            var model = mapper.Map<DocumentViewModel>(result);
            model = ImagesUtil.ValidateDocument(hostEnvironment, model);    
            return model;
        }

        private async Task<DocumentViewModel?> GetDocumentByType(int personaInformationId, int documentTypeId)
        {
            var result = await context.DocumentEntity
               .Include(d => d.DocumentTypeGroupItemEntity)
               .Where(item => item.PersonalInformationId == personaInformationId & item.DocumentTypeId == documentTypeId)
               .FirstAsync();

            if (result == null)
            {
                return null;
            }

            var model = mapper.Map<DocumentViewModel>(result);
            model = ImagesUtil.ValidateDocument(hostEnvironment, model);
            return model;
        }


        public async Task<List<DocumentViewModel>> GetDocumentByParentId(int id, List<int> documentTypeIds)
        {
            var result = await context.DocumentEntity
               .Include(d => d.DocumentTypeGroupItemEntity)
               .Include(d => d.SubTypeGroupItemEntity)
               .Where(item => item.ParentId == id &&  documentTypeIds.Contains(item.DocumentTypeId))
               .ToListAsync();

            var models = new List<DocumentViewModel>();
            mapper.Map<List<DocumentViewModel>>(result).ForEach(document => models.Add(ImagesUtil.ValidateDocument(hostEnvironment, document)));
            return models;
        }

        public async Task<DocumentViewModel?> GetDocumentByParentId(int id, int documentTypeId)
        {
            var result = await context.DocumentEntity
               .Include(d => d.DocumentTypeGroupItemEntity)
               .Include(d => d.SubTypeGroupItemEntity)
               .Where(item => item.ParentId == id && item.DocumentTypeId == documentTypeId)
               .FirstOrDefaultAsync();

            if(result == null)
            {
                return null;
            } else
            {
                var model = mapper.Map<DocumentViewModel>(result);
                model = ImagesUtil.ValidateDocument(hostEnvironment, model);
                return model;
            }
        }

        public async Task<DocumentViewModel> GetCreateModel(DocumentViewModel model)
        {
            var documentsTypes = GroupItemsForDocuments(OrderType.Alphabetic);
            model.DocumentTypes = documentsTypes;
            return model;
        }

        public async Task<DocumentViewModel> GetCreateModel(int personaInformationId, string fullName)
        {
            var documentsTypes = GroupItemsForDocuments(OrderType.Alphabetic);
            
            var model = new DocumentViewModel
            {
                DocumentTypes = documentsTypes,
                PersonaInformationId = personaInformationId,
                FullName = fullName,
            };

            return model;
        }


        private SelectList GroupItemsForDocuments(OrderType orderType = OrderType.No_order)
        {
            var result = context.GroupItemEntity
                .Where(x => x.GroupEntityId == Groups.DOCUMENTS & x.Active == true & Documents.GetDriversLicenceDocuments().Contains(x.Id) == false);

            switch (orderType)
            {
                case OrderType.No_order:
                    break;

                case OrderType.Alphabetic:
                    result = result.OrderBy(x => x.Description);
                    break;

                default:
                    break;
            }

            return new SelectList(result, "Id", "Description");
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

        public async Task Save(DocumentViewModel model, FolderType folder)
        {

            var extension = Path.GetExtension(model.ImageFile.FileName);
            await ImagesUtil.SaveImage(hostEnvironment, model, folder);

            var entity = mapper.Map<DocumentEntity>(model);
            entity.Extension = extension;
            entity.EditorId = GetCurrentUserId();

            // set Modified flag in your entry
            var local = context.Set<DocumentEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(model.Id));

            // check if local is not null 
            if (local != null)
            {
                // detach
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(entity).State = EntityState.Modified;

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

        public async Task DeleteDocument(int personaInformationId, DocumentViewModel model)
        {
            ImagesUtil.DeleteImage_(hostEnvironment, model);
            await DeleteAsync(model.Id);
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
