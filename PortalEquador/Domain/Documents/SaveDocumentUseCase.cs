﻿using AutoMapper;
using PortalEquador.Constants;
using PortalEquador.Data.Document.Entities;
using PortalEquador.Domain.Documents.Repository;

namespace PortalEquador.Domain.UseCases.Documents
{
    public class SaveDocumentUseCase
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly DocumentRepository _documentRepository;

        public SaveDocumentUseCase(IWebHostEnvironment hostEnvironment,  DocumentRepository documentRepository)
        {
            _hostEnvironment = hostEnvironment;
            _documentRepository = documentRepository;
        }

        public async Task Invoke(DocumentEntity document)
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
