using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.MedicalExam.Repository;
using PortalEquador.Domain.Trainning.Repository;
using PortalEquador.Util.EnumTypes;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.Trainning.UseCases
{
    public class DeleteTrainningUseCase(
         ITrainningRepository trainningRepository,
        IDocumentRepository documentRepository)
    {

        public async Task Invoke(int trainningId)
        {
            await trainningRepository.DeleteAsync(trainningId);
            var document = await documentRepository.GetDocumentByParentId(trainningId, ItemFromGroup.Documents.TRAINNIG);

            if (document != null)
            {
                await documentRepository.DeleteDocument(FolderType.Trainning, document.PersonaInformationId, trainningId, document);
            }
        }
    }
}