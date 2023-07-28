using AutoMapper;
using NuGet.Packaging;
using PortalEquador.Constants;
using PortalEquador.Contracts;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Domain.Repositories;

namespace PortalEquador.Domain.UseCases.DriversLicence
{
    public class GetDriversLicenceUseCase__
    {
        private readonly DriversLicenceRepository _driversLicenceRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IPersonalInformationRepository personalInformationRepository;

        public GetDriversLicenceUseCase__(IPersonalInformationRepository personalInformationRepository, DriversLicenceRepository driversLicenceRepository, IDocumentRepository documentRepository)
        {
            _driversLicenceRepository = driversLicenceRepository;
            _documentRepository = documentRepository;
            this.personalInformationRepository = personalInformationRepository;
        }

        public async Task<DriversLicenceViewModel__?> Invoke(int curriculumId)
        {

           
/*
            var licenceTypes = personalInformationRepository.GroupItems(Groups.DRIVERS_LICENCE);
            var profile = await personalInformationRepository.GetProfileInformation(curriculumId);

            var documents = await _documentRepository.GetDocumentsByTypeAsync(curriculumId, documentTypeIds);
            var model = await _driversLicenceRepository.GetDriversLicenceAsync(curriculumId);

            var model = new DriversLicenceCreateViewModel
            {
                CurriculumId = curriculumId,
                Profile = profile,
                LicenceTypes = licenceTypes
            };
            */

            var model = await _driversLicenceRepository.GetDriversLicenceAsync__(curriculumId);
            var licenceTypes = _driversLicenceRepository.GroupItems(Groups.DRIVERS_LICENCE);
            
            if (model == null)
            {
                model = new DriversLicenceViewModel__
                {
                    CurriculumId = curriculumId,
                };
            }

            var expirationDateAvailable = true;

            if(model.ExpirationDate != null)
            {
                expirationDateAvailable = false;
            }

            model.LicenceTypes = licenceTypes;
            model.ExpirationDateAvailable = expirationDateAvailable;

            List<int> documentTypeIds = new List<int>();
            documentTypeIds.Add(ItemFromGroup.Documents.DRIVERS_LICENCE);
            documentTypeIds.Add(ItemFromGroup.Documents.PROVISIONAL_DRIVERS_LICENCE);

            var documents = await _documentRepository.GetDocumentsByTypeAsync(curriculumId, documentTypeIds);
            model.Documents = documents;
            model.ProvisionalDocument = documents.Find(item => item.GroupItemId == ItemFromGroup.Documents.PROVISIONAL_DRIVERS_LICENCE);
            return model;

            /*
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
            */
        }
    }
}

