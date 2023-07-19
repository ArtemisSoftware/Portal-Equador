using AutoMapper;
using PortalEquador.Contracts;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Domain.Repositories;
using PortalEquador.Models.Documents;
using PortalEquador.Repositories;

namespace PortalEquador.Domain.UseCases.Documents
{
    public class SaveDocumentUseCase
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IDocumentRepository _documentRepository;

        public SaveDocumentUseCase(IWebHostEnvironment hostEnvironment,  IDocumentRepository documentRepository)
        {
            _hostEnvironment = hostEnvironment;
            _documentRepository = documentRepository;
        }

        public async Task Invoke(Document document)
        {
            string fileName = Path.GetFileNameWithoutExtension(document.ImageFile.FileName);
            string extension = Path.GetExtension(document.ImageFile.FileName);
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string root = wwwRootPath + "/images/" + document.CurriculumId + "/";
            fileName = document.GroupItemId + extension;

            if (!Directory.Exists(root))
            {
                //--Directory.CreateDirectory(root);
            }

            string path = Path.Combine(root, fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                //--await imageFile.CopyToAsync(fileStream);
            }
            
            document.FileExtension = extension;
           //--await _documentRepository.AddAsync(document);
        }
    }
}
