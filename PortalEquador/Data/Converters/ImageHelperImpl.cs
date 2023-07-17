using AutoMapper;
using Microsoft.Extensions.Hosting;
using PortalEquador.Contracts;
using PortalEquador.Data;
using PortalEquador.Domain.Converters;
using PortalEquador.Models.Documents;

namespace PortalEquador.Data.Converters
{
    public class ImageHelperImpl : ImageHelper
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImageHelperImpl(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        
        public async void CreateImage(IFormFile imageFile, int curriculumId, int itemId)
        {
            string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string extension = Path.GetExtension(imageFile.FileName);
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string root = wwwRootPath + "/images/" + curriculumId + "/";
            fileName = itemId + extension;

            if (!Directory.Exists(root))
            {
                //--Directory.CreateDirectory(root);
            }

            string path = Path.Combine(root, fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                //--await imageFile.CopyToAsync(fileStream);
            }
        }
    }
}
