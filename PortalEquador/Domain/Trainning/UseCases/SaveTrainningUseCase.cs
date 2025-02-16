using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.MedicalExam.Repository;
using PortalEquador.Domain.MedicalExam.ViewModels;
using PortalEquador.Domain.Trainning.Repository;
using PortalEquador.Domain.Trainning.ViewModels;
using PortalEquador.Util;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.Trainning.UseCases
{
    public class SaveTrainningUseCase(
        ITrainningRepository trainningRepository,
        IDocumentRepository documentRepository
        )
    {

        public async Task Invoke(TrainningCreateViewModel model)
        {
            var trainningId = await trainningRepository.Save(model);
            var document = await documentRepository.GetDocumentByParentId(trainningId, ItemFromGroup.Documents.TRAINNIG);

            await SaveDocument(model, trainningId, document);
        }


        private async Task SaveDocument(TrainningCreateViewModel model, int trainningId, DocumentViewModel? document)
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
                        DocumentTypeId = ItemFromGroup.Documents.TRAINNIG,
                        SubTypeId = model.TrainningId,
                        ParentId = trainningId,
                        Extension = ImagesUtil.GetImageExtension(model.ImageFile)
                    };
                }
                else
                {
                    document.ImageFile = model.ImageFile;
                    document.Extension = ImagesUtil.GetImageExtension(model.ImageFile);
                }

                await documentRepository.Save(document, Util.EnumTypes.FolderType.Trainning);
            }
        }

    }
}
