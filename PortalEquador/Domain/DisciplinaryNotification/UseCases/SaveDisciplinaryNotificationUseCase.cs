using PortalEquador.Domain.DisciplinaryNotification.Repository;
using PortalEquador.Domain.DisciplinaryNotification.ViewModels;
using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.MedicalExam.Repository;
using PortalEquador.Domain.MedicalExam.ViewModels;
using PortalEquador.Util;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.DisciplinaryNotification.UseCases
{
    public class SaveDisciplinaryNotificationUseCase(
        IDisciplinaryNotificationRepository disciplinaryNotificationRepository,
        IDocumentRepository documentRepository
        )
    {

        public async Task Invoke(DisciplinaryNotificationCreateViewModel model)
        {
            var disciplinaryNotificationId = await disciplinaryNotificationRepository.Save(model);
            var document = await documentRepository.GetDocumentByParentId(disciplinaryNotificationId, ItemFromGroup.Documents.DISCIPLINARY_NOTIFICATION);

            await SaveDocument(model, disciplinaryNotificationId, document);
        }


        private async Task SaveDocument(DisciplinaryNotificationCreateViewModel model, int disciplinaryNotificationId, DocumentViewModel? document)
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
                        DocumentTypeId = ItemFromGroup.Documents.DISCIPLINARY_NOTIFICATION,
                        SubTypeId = model.NotificationId,
                        ParentId = disciplinaryNotificationId,
                        Extension = ImagesUtil.GetImageExtension(model.ImageFile)
                    };
                }
                else
                {
                    document.ImageFile = model.ImageFile;
                    document.Extension = ImagesUtil.GetImageExtension(model.ImageFile);
                }

                await documentRepository.Save(document, Util.EnumTypes.FolderType.DisciplinaryNotification);
            }
        }

    }
}
