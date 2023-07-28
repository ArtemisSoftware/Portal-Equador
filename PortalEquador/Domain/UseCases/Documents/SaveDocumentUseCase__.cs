using AutoMapper;
using PortalEquador.Constants;
using PortalEquador.Contracts;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Domain.Models.Document;
using PortalEquador.Domain.Repositories;
using PortalEquador.Models.Documents;
using PortalEquador.Repositories;

namespace PortalEquador.Domain.UseCases.Documents
{
    public class SaveDocumentUseCase__
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IDocumentRepository _documentRepository;

        public SaveDocumentUseCase__(IWebHostEnvironment hostEnvironment,  IDocumentRepository documentRepository)
        {
            _hostEnvironment = hostEnvironment;
            _documentRepository = documentRepository;
        }

        public async Task Invoke(DocumentViewModel document)
        {
            /*
            string fileName = Path.GetFileNameWithoutExtension(document.ImageFile.FileName);
            string extension = Path.GetExtension(document.ImageFile.FileName);
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string root = wwwRootPath + "/" + FoldersConstants.IMAGES + "/" + document.CurriculumId + "/";
            fileName = document.GroupItemId + extension;

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            string path = Path.Combine(root, fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await document.ImageFile.CopyToAsync(fileStream);
            }
            
            document.FileExtension = extension;
           await _documentRepository.AddAsync(document);
            */
        }
    }
}
