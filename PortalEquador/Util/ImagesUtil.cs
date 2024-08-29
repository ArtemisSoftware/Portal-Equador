using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Util.Constants;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Util
{
    public static class ImagesUtil
    {
        /*
        public static string GetProfilePicturePath(int curriculumId, string extension)
        {
            return "~/" + FoldersConstants.IMAGES + "/" + curriculumId + "/" + ItemFromGroup.Documents.PROFILE_PICTURE + extension;
        }

        public static string GetFilePath(int curriculumId, int documentTypeId, string extension)
        {
            return "~/" + FoldersConstants.IMAGES + "/" + curriculumId + "/" + documentTypeId + extension;
        }


        public static string GetFilePath(int curriculumId, int imageName)
        {
            string wwwRootPath = "";//hostEnvironment.WebRootPath;
            string folderPath = wwwRootPath + "/" + FoldersConstants.IMAGES + "/" + curriculumId + "/";


            // Get all image files from the folder
            string[] imageFiles = Directory.GetFiles(folderPath)
                .Where(file => IsImageFile(file))
                .ToArray();


            // Search for the image by name
            string matchingImagePath = imageFiles.FirstOrDefault(
                imagePath => Path.GetFileNameWithoutExtension(imagePath).Equals(imageName.ToString(), StringComparison.OrdinalIgnoreCase));

            if (matchingImagePath != null)
            {
                return matchingImagePath;
            }
            else
            {
                return "";
                //Console.WriteLine($"Image '{imageNameToSearch}' not found in the folder.");
            }
        }

        static bool IsImageFile(string filePath)
        {
            // Check if the file has an image extension (you can customize this check)
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            string fileExtension = Path.GetExtension(filePath);
            return imageExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase);
        }







        */
        private static string GetImagePath(IWebHostEnvironment hostEnvironment, DocumentViewModel document)
        {
            string wwwRootPath = hostEnvironment.WebRootPath;

            string fileName = "";
            string extension = "";

            if (document.ImageFile == null)
            {
                fileName = document.DocumentTypeId.ToString();
                extension = document.Extension;
            }
            else
            {
                fileName = Path.GetFileNameWithoutExtension(document.ImageFile.FileName);
                extension = Path.GetExtension(document.ImageFile.FileName);
            }

            string root = wwwRootPath + "/" + FoldersConstants.Folder.CURRICULUM + "/" + document.PersonaInformationId + "/";
            fileName = document.DocumentTypeId + extension;
            string path = Path.Combine(root, fileName);

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            return path;
        }
        
        public static async Task<OperationType> SaveImage(IWebHostEnvironment hostEnvironment, DocumentViewModel document)
        {
            var operationType = OperationType.Create;

            string path = GetImagePath(hostEnvironment, document);

            if (File.Exists(path))
            {
                operationType = OperationType.Update;
                File.Delete(path);
            }

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await document.ImageFile.CopyToAsync(fileStream);
            }

            return operationType;
        }

        /*
        public static void DeleteImage(IWebHostEnvironment hostEnvironment, DocumentViewModel document)
        {
            string path = GetImagePath(hostEnvironment, document);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        */
    }
}