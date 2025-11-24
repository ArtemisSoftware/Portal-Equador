using PortalEquador.Domain.Accident.Repository;
using PortalEquador.Domain.Accident.ViewModels;
using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Util.Files.models;
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

            if (model.FormFile != null)
            {
                var document = await documentRepository.GetDocumentByParentId_v2(accidentId, Documents.ACCIDENT);
                await SaveDocument(model, accidentId, document);
            }
        }

        private async Task SaveDocument(AccidentViewModel model, int accidentId, DocumentViewModel? document)
        {
            var resource = FileResource.AccidentResource(model, accidentId);

            if (document == null)
            {
                document = new DocumentViewModel
                {
                    PersonaInformationId = model.PersonaInformationId,
                    FullName = model.FullName,
                    ImageFile = model.FormFile,
                    DocumentTypeId = Documents.ACCIDENT,
                    ParentId = accidentId,
                    Extension = resource.GetExtension()
                };
            }
            else
            {
                document.ImageFile = model.FormFile;
                document.Extension = resource.GetExtension();
            }

            await documentRepository.Save(document, resource);
        }
    }
}