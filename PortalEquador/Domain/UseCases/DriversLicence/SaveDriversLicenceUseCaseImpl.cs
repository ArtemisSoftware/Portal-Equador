using PortalEquador.Contracts;
using PortalEquador.Domain.Repositories;
using PortalEquador.Repositories;

namespace PortalEquador.Domain.UseCases.DriversLicence
{
    public class SaveDriversLicenceUseCaseImpl
    {

        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly DriversLicenceRepository _driversLicenceRepository;
        private readonly IDocumentRepository _documentRepository;

        public SaveDriversLicenceUseCaseImpl(IWebHostEnvironment hostEnvironment, DriversLicenceRepository driversLicenceRepository, IDocumentRepository documentRepository)
        {
            
            _hostEnvironment = hostEnvironment;
            _driversLicenceRepository = driversLicenceRepository;
            _documentRepository = documentRepository;
        }
        public void Invoke(IFormFile imageFile, int curriculumId, int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
