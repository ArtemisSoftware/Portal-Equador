namespace PortalEquador.Domain.Converters
{
    public interface ImageHelper
    {
        public void CreateImage(IFormFile imageFile, int curriculumId, int itemId);
    }
}
