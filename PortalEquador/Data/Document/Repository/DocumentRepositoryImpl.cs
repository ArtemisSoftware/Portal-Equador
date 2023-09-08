using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.Document.Entities;
using PortalEquador.Domain.Documents.Repository;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.UseCases;
using PortalEquador.Repositories;
using PortalEquador.Util;
using System.Xml.Linq;

namespace PortalEquador.Data.Document.Repository
{
    public class DocumentRepositoryImpl : GenericRepository<DocumentEntity>, DocumentRepository
    {

        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public DocumentRepositoryImpl(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment) : base(context)
        {
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

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

        public async Task<bool> DocumentExists(int curriculumId, int documentTypeId)
        {
            //return await context.DocumentEntity.AnyAsync(item => item.CurriculumId == curriculumId & item.GroupItemId == documentTypeId);
            return false;
        }

        public async Task SaveDocument(DocumentViewModel document)
        {
            var extension = Path.GetExtension(document.ImageFile.FileName);
            var operationType = await ImagesUtil.CreateImage(_hostEnvironment, document);

            var entity = _mapper.Map<DocumentEntity>(document);
            entity.Extension = extension;

            switch (operationType)
            {
                case OperationType.Create:

                    await AddAsync(entity);
                    break;
                case OperationType.Update:

                    entity.DateModified = DateTime.UtcNow;
                    await UpdateAsync(entity);
                    break;
            }
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
    }
}
