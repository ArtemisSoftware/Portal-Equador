using PortalEquador.Domain.Accident.Repository;
using PortalEquador.Domain.Document.Repository;
using PortalEquador.Util.EnumTypes;
using PortalEquador.Util.Files.models;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.Document
{
    public class DeleteDocumentUseCase(
         IDocumentRepository documentRepository
        )
    {
        public async Task Invoke(int itemId, FolderType folder)
        {
            var document = await documentRepository.GetDocumentByParentId_v2(itemId, ItemFromGroup.Documents.ACCIDENT);

            if (document != null)
            {
                var resource = new FileResource(
                    directory: folder,
                    folder: document.PersonaInformationId,
                    fileName: itemId + "",
                    extension: document.Extension
                );

                await documentRepository.DeleteDocument(document.Id, resource);
            }
        }
    }
}
