using DocumentFormat.OpenXml.Office2010.Excel;
using NuGet.Protocol.Core.Types;
using PortalEquador.Domain.Accident.Repository;
using PortalEquador.Domain.Accident.ViewModels;
using PortalEquador.Domain.Document.Repository;
using PortalEquador.Util.EnumTypes;
using static PortalEquador.Util.Constants.GroupTypesConstants.ItemFromGroup;
using static PortalEquador.Util.Constants.GroupTypesConstants;
using PortalEquador.Util.Files.models;

namespace PortalEquador.Domain.Accident.UseCases
{
    public class DeleteAccidentUseCase(
        IAccidentRepository accidentRepository,
        IDocumentRepository documentRepository
    )
    {

        public async Task Invoke(int accidentId)
        {
            await accidentRepository.DeleteAccident(accidentId);

            var document = await documentRepository.GetDocumentByParentId_v2(accidentId, ItemFromGroup.Documents.ACCIDENT);

            if (document != null)
            {
                var resource = new FileResource(
                    directory: Util.EnumTypes.FolderType.Accident,
                    folder: document.PersonaInformationId,
                    fileName: accidentId + "",
                    extension: document.Extension
                );

                await documentRepository.DeleteDocument(document.Id, resource);
            }
        }
    }
}
