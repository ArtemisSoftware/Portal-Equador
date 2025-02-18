using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.MedicalExam.Repository;
using PortalEquador.Domain.MedicalExam.ViewModels;
using PortalEquador.Util;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.MedicalExam.UseCases
{

    public class SaveMedicalExamUseCase(
        IMedicalExamRepository medicalExamRepository, 
        IDocumentRepository documentRepository
        )
    {
        
        public async Task Invoke(MedicalExamCreateViewModel model)
        {
            var medicalExamId = await medicalExamRepository.Save(model);

            if (model.ImageFile != null)
            {
                var document = await documentRepository.GetDocumentByParentId(medicalExamId, ItemFromGroup.Documents.MEDICAL_EXAM);
                await SaveDocument(model, medicalExamId, document);
            }
        }

 
        private async Task SaveDocument(MedicalExamCreateViewModel model, int medicalExamId, DocumentViewModel? document)
        {
            if (model.ImageFile != null)
            {
                if (document == null)
                {
                    document = new DocumentViewModel
                    {
                        PersonaInformationId = model.PersonaInformationId,
                        FullName = model.FullName,
                        ImageFile = model.ImageFile,
                        DocumentTypeId = ItemFromGroup.Documents.MEDICAL_EXAM,
                        SubTypeId = medicalExamId,
                        ParentId = medicalExamId,
                        Extension = ImagesUtil.GetImageExtension(model.ImageFile)
                    };
                }
                else
                {
                    document.ImageFile = model.ImageFile;
                    document.Extension = ImagesUtil.GetImageExtension(model.ImageFile);
                }

                await documentRepository.Save(document, Util.EnumTypes.FolderType.MedicalExam);
            }
        }

    }
}
