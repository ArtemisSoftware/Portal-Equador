namespace PortalEquador.Domain.UseCases.DriversLicence
{
    public interface SaveDriversLicenceUseCase
    {
        public void Invoke(IFormFile imageFile, int curriculumId, int itemId);
    }
}
