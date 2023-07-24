using PortalEquador.Constants;
using PortalEquador.Contracts;
using PortalEquador.Data.GroupTypes;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Domain.Repositories;
using System;

namespace PortalEquador.Domain.UseCases.DriversLicence
{
    public class GetDriversLicenceUseCase
    {
        private readonly DriversLicenceRepository _driversLicenceRepository;
        private readonly IDocumentRepository _documentRepository;

        public GetDriversLicenceUseCase(DriversLicenceRepository driversLicenceRepository, IDocumentRepository documentRepository)
        {
            _driversLicenceRepository = driversLicenceRepository;
            _documentRepository = documentRepository;
        }

        public async Task<DriversLicenceDetailViewModel?> Invoke(int curriculumId)
        {
            List<int> documentTypeIds = new List<int>();
            documentTypeIds.Add(ItemFromGroup.Documents.DRIVERS_LICENCE);
            // TODO: adicionar documentTypeIds.Add(ItemFromGroup.Documents.PROVISIONAL_LICENCE);

            var documents = await _documentRepository.GetDocumentsByTypeAsync(curriculumId, documentTypeIds);
            var model = await _driversLicenceRepository.GetDriversLicenceAsync(curriculumId);

            var document = documents.Find(item => item.GroupItemId == ItemFromGroup.Documents.DRIVERS_LICENCE);

            if (document != null)
            {
                document.Name = "Carta de condução";
            }

            if (model != null)
            {
                model.Documents = documents;
            }
            return model;
        }
    }
}