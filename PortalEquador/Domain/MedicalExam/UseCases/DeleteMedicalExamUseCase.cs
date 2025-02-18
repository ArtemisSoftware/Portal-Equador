using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.MedicalExam.Repository;
using PortalEquador.Util.EnumTypes;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.MedicalExam.UseCases
{
    public class DeleteMedicalExamUseCase(
         IMedicalExamRepository medicalExamRepository,
        IDocumentRepository documentRepository)
    {

        public async Task Invoke(int medicalExamId)
        {
            await medicalExamRepository.DeleteAsync(medicalExamId);
            var document = await documentRepository.GetDocumentByParentId(medicalExamId, ItemFromGroup.Documents.MEDICAL_EXAM);

            if (document != null)
            {
                await documentRepository.DeleteDocument(FolderType.MedicalExam, document.PersonaInformationId, medicalExamId, document);
            }
        }
    }
}