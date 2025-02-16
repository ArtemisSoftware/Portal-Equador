using PortalEquador.Domain.DisciplinaryNotification.Repository;
using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.MedicalExam.Repository;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.DisciplinaryNotification.UseCases
{
    public class DeleteDisciplinaryNotificationUseCase(
         IDisciplinaryNotificationRepository disciplinaryNotificationRepository,
        IDocumentRepository documentRepository)
    {

        public async Task Invoke(int disciplinaryNotificationRepositoryId)
        {
            await disciplinaryNotificationRepository.DeleteAsync(disciplinaryNotificationRepositoryId);
            var document = await documentRepository.GetDocumentByParentId(disciplinaryNotificationRepositoryId, ItemFromGroup.Documents.DISCIPLINARY_NOTIFICATION);

            if (document != null)
            {
                await documentRepository.DeleteDocument(document.PersonaInformationId, document);
            }
        }
    }
}