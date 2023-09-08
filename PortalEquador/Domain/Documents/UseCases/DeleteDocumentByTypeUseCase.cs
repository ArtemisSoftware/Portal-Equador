using Microsoft.Extensions.Hosting;
using PortalEquador.Domain.Documents.Repository;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Util;

namespace PortalEquador.Domain.Documents.UseCases
{
    public class DeleteDocumentByTypeUseCase
    {
        private readonly DocumentRepository documentRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public DeleteDocumentByTypeUseCase(
                        IWebHostEnvironment hostEnvironment,
                        DocumentRepository documentRepository
            )
        {
            _hostEnvironment = hostEnvironment;
            this.documentRepository = documentRepository;
        }

        public async Task Invoke(int curriculumId, int documentTypeId)
        {
            //--var document = await documentRepository.GetDocumentAsync(documentId);
            //--ImagesUtil.DeleteImage(_hostEnvironment, document);
            //--await documentRepository.DeleteAsync(document.Id);
        }
    }
}