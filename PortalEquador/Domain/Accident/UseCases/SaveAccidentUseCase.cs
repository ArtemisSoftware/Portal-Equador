using Microsoft.AspNetCore.Http;
using PortalEquador.Domain.Accident.Repository;
using PortalEquador.Domain.Accident.ViewModels;
using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Files;
using PortalEquador.Util.Files.models;
using System.IO;
using static PortalEquador.Util.Constants.FoldersConstants;
using static PortalEquador.Util.Constants.GroupTypesConstants;
using static PortalEquador.Util.Constants.GroupTypesConstants.ItemFromGroup;

namespace PortalEquador.Domain.Accident.UseCases
{
    public class SaveAccidentUseCase(
        IAccidentCauseRepository accidentCauseRepository,
        IAccidentRepository accidentRepository,
        IDocumentRepository documentRepository
        )
    {

        public async Task Invoke(AccidentViewModel model)
        {
            await accidentCauseRepository.DeleteCauses(model.Id);
            var accidentId = await accidentRepository.Save(model);

            var document = await documentRepository.GetDocumentByParentId(accidentId, ItemFromGroup.Documents.ACCIDENT);

            await SaveDocument(model, accidentId, document);
        }

        private async Task SaveDocument(AccidentViewModel model, int accidentId, DocumentViewModel? document)
        {
            var resource = new FileResource(
                directory: Util.EnumTypes.FolderType.Accident,
                folder: model.PersonaInformationId,
                fileName: accidentId + "",
                formFile:  model.PdfFile
            );


            if (document == null)
            {
                document = new DocumentViewModel
                {
                    PersonaInformationId = model.PersonaInformationId,
                    FullName = model.FullName,
                    ImageFile = model.PdfFile,
                    DocumentTypeId = Documents.ACCIDENT,
                    ParentId = accidentId,
                    Extension = resource.GetExtension()
                };
            }
            else
            {
                document.ImageFile = model.PdfFile;
                document.Extension = resource.GetExtension();
            }

            await documentRepository.Save(document, resource);
        }
    }
}