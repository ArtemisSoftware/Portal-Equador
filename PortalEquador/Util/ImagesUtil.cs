using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using NuGet.Packaging.Signing;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Util.Constants;
using PortalEquador.Util.EnumTypes;
using System.Xml.XPath;
using static PortalEquador.Util.Constants.FoldersConstants;
using static PortalEquador.Util.Constants.GroupTypesConstants;
using static PortalEquador.Util.Constants.GroupTypesConstants.ItemFromGroup;

namespace PortalEquador.Util
{
    public static class ImagesUtil
    {

        public static async Task SaveImage(IWebHostEnvironment hostEnvironment, DocumentViewModel document, FolderType folder)
        {
            FolderType _folder = GetFolder(document);
            string fileName = GetFileName(document, _folder);
            var lolo = GetFileToDelete(hostEnvironment, _folder, document.PersonaInformationId,  GetImageId(document));

            foreach(string filePath in lolo)
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            //------


            string path = GetImagePath(hostEnvironment, document, folder);


            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await document.ImageFile.CopyToAsync(fileStream);
            }
        }

        private static List<string> GetFileToDelete(IWebHostEnvironment hostEnvironment, FolderType folder, int personalInformationId, string imageName)
        {
            string wwwRootPath = hostEnvironment.WebRootPath;
            string folderPath = wwwRootPath + folder.GetFullPath() + "/" + personalInformationId + "/";
            List<string> matchingImagePath = new List<string>();

            try
            {
                // Get all image files from the folder
                string[] imageFiles = Directory.GetFiles(folderPath)
                    .Where(file => IsImageAllFile(file))
                    .ToArray();


                // Search for the image by name
                matchingImagePath = imageFiles
                    .Where(imagePath => Path.GetFileNameWithoutExtension(imagePath).Equals(imageName.ToString(), StringComparison.OrdinalIgnoreCase))
                    .ToList();

                
            } catch(DirectoryNotFoundException ex)
            {

            }

            return matchingImagePath;
        }

        private static string GetImagePath(IWebHostEnvironment hostEnvironment, DocumentViewModel document, FolderType folder)
        {
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
            document.Extension = extension;
            string root = GetRootDirectory(hostEnvironment, document, folder);
            fileName = GetFileName(document,folder);
            string path = Path.Combine(root, fileName);

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            return path;
        }

        public static string GetImageExtension(IFormFile imageFile)
        {
            return Path.GetExtension(imageFile.FileName);
        }

        private static string GetRootDirectory(IWebHostEnvironment hostEnvironment, DocumentViewModel document, FolderType folder)
        {
            string wwwRootPath = hostEnvironment.WebRootPath;
            string root = wwwRootPath +  folder.GetFullPath() + "/" + document.PersonaInformationId + "/";
            return root;
        }

        private static string GetFileName(DocumentViewModel document, FolderType folder)
        {
            switch (folder)
            {
                case FolderType.Curriculum:
                    return GetImageId(document) + document.Extension; 

                case FolderType.DriversLicence:
                    return GetImageId(document) + document.Extension; ;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string GetFilePath(FolderType folder, int personalInformationId, int imageId, string extension)
        {
            return "~" + folder.GetFullPath() + "/" + personalInformationId + "/" + imageId + extension + "?v=123456";
        }

        private static string GetFilePath(DocumentViewModel model)
        {
            return GetFolder(model).GetFullPath() + "/" + model.PersonaInformationId + "/" + GetImageId(model) + model.Extension;
        }
        
        public static string GetFileFullPath(DocumentViewModel model)
        {
            var path = "~" + GetFolder(model).GetFullPath() + "/" + model.PersonaInformationId + "/" + GetImageId(model) + model.Extension;
            return path + "?v=123456";
        }

        public static DocumentViewModel ValidateDocument(IWebHostEnvironment hostEnvironment, DocumentViewModel model)
        {
            var folder = GetFolder(model);
            var imageId = GetImageId(model);
            //string imagePath = Path.Combine(hostEnvironment.WebRootPath, GetFilePath(model));
            string imagePath = hostEnvironment.WebRootPath + "/" + GetFilePath(model);

            if (File.Exists(imagePath))
            {
                model.PicturePath = GetFileFullPath(model);
            }
            else if (folder == FolderType.Curriculum && imageId == ItemFromGroup.Documents.PROFILE_PICTURE.ToString())
            {
                model.PicturePath = "~" + FolderType.Placeholder.GetFullPath() + ImageConstants.Placeholder.AVATAR;
            }
            else
            {
                model.PicturePath = "~" + FolderType.Placeholder.GetFullPath() + ImageConstants.Placeholder.NO_IMAGE;
            }

            return model;
        }

        private static FolderType GetFolder(DocumentViewModel model)
        {
            if (Documents.GetDriversLicenceDocuments().Contains(model.DocumentTypeId))
            {
                return FolderType.DriversLicence;
            }
            else
            {
                return FolderType.Curriculum;
            }
        }

        private static string GetImageId(DocumentViewModel model)
        {
            if (model.DocumentTypeId == ItemFromGroup.Documents.DRIVERS_LICENCE)
            {
                return ((int)model.SubTypeId).ToString();
            }
            else if (model.DocumentTypeId == ItemFromGroup.Documents.DRIVERS_LICENCE_PROVISIONAL)
            {
                return model.SubTypeId.ToString() + ImageConstants.NameSuffix.DRIVERS_LICENCE_PROVISIONAL;
            }
            else
            {
                return model.DocumentTypeId.ToString();
            }
        }

        public static void DeleteImage_(IWebHostEnvironment hostEnvironment, DocumentViewModel document)
        {
            FolderType folder = GetFolder(document);
            string path = GetImagePath(hostEnvironment, document, folder);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public static string GetProfileImagePath(IWebHostEnvironment hostEnvironment, int personaInformationId)
        {
            string folderPath = Path.Combine(hostEnvironment.WebRootPath, FoldersConstants.Folder.CURRICULUM + "/" + personaInformationId);
            string imagePath = "";

            try
            {
                var images = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly)
                      .Where(s => ImageConstants.Extensions.IsValidImageExtension(s) && s.Contains(GroupTypesConstants.ItemFromGroup.Documents.PROFILE_PICTURE.ToString()))
                      .ToList();

                if (images.Count > 0)
                {
                    imagePath = "~/" + FoldersConstants.Folder.CURRICULUM + "/" + personaInformationId + "/" + GroupTypesConstants.ItemFromGroup.Documents.PROFILE_PICTURE + "." + images[0].Split(".")[1];
                }
                else
                {
                    imagePath = "~/" + FoldersConstants.Folder.PLACEHOLDER + ImageConstants.Placeholder.AVATAR;
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                imagePath = "~/" + FoldersConstants.Folder.PLACEHOLDER + ImageConstants.Placeholder.AVATAR;
            }

            return imagePath + "?v=123456";
        }

        public static bool isValidImageExtension(IFormFile image)
        {
            string fileExtension = GetImageExtension(image);
            return ImageConstants.Extensions.IMAGE_EXTENSIONS.Contains(fileExtension, StringComparer.OrdinalIgnoreCase);
        }

        public static bool IsImageFile(string filePath)
        {
            string fileExtension = Path.GetExtension(filePath);
            return ImageConstants.Extensions.IMAGE_EXTENSIONS.Contains(fileExtension, StringComparer.OrdinalIgnoreCase);
        }






























        /*
        public static string GetProfilePicturePath(int curriculumId, string extension)
        {
            return "~/" + FoldersConstants.IMAGES + "/" + curriculumId + "/" + ItemFromGroup.Documents.PROFILE_PICTURE + extension;
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

        public static string GetFilePath(int curriculumId, int documentTypeId, string extension)
        {
            return "~/" + FoldersConstants.Folder.CURRICULUM + "/" + curriculumId + "/" + documentTypeId + extension;
        }



        public static string GetFilePath(int curriculumId, int imageName)
        {
            string wwwRootPath = "";//hostEnvironment.WebRootPath;
            string folderPath = wwwRootPath + "/" + FoldersConstants.Folder.CURRICULUM + "/" + curriculumId + "/";


            // Get all image files from the folder
            string[] imageFiles = Directory.GetFiles(folderPath)
                .Where(file => IsImageFile(file))
                .ToArray();


            // Search for the image by name
            string? matchingImagePath = imageFiles.FirstOrDefault(
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



        static bool IsImageAllFile(string filePath)
        {
            // Check if the file has an image extension (you can customize this check)
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", "" };
            string fileExtension = Path.GetExtension(filePath);
            return imageExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase);
        }


        public static void DeleteImage(IWebHostEnvironment hostEnvironment, DocumentViewModel document)
        {
            string path = GetImagePath(hostEnvironment, document);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public static void DeleteImage(IWebHostEnvironment hostEnvironment, int personaInformationId, int documentTypeId, string extension)
        {
            string wwwRootPath = hostEnvironment.WebRootPath;

            string root = wwwRootPath + "/" + FoldersConstants.Folder.CURRICULUM + "/" + personaInformationId + "/";
            string fileName = documentTypeId + extension;
            string path = Path.Combine(root, fileName);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }




    }
}