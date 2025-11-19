using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Util.Constants;
using PortalEquador.Util.EnumTypes;
using PortalEquador.Util.Files.models;
using static PortalEquador.Util.Constants.GroupTypesConstants;
using static PortalEquador.Util.Constants.GroupTypesConstants.ItemFromGroup;

namespace PortalEquador.Util.Files
{
    public class FileUtil
    {
      
        private string GetAbsoluteFullPath(IWebHostEnvironment hostEnvironment, FileResource file)
        {
            string root = hostEnvironment.WebRootPath + file.GetFullPath();
            return root;
        }

        private string GetAbsoluteFilePath(IWebHostEnvironment hostEnvironment, FileResource file)
        {
            string root = GetAbsoluteFullPath(hostEnvironment, file);
            return Path.Combine(root, file.GetFullFileName());
        }


        private void DeleteFile(IWebHostEnvironment hostEnvironment, FileResource file)
        {
            List<string> matchingFilesPath = new List<string>();
            var fullPath = GetAbsoluteFullPath(hostEnvironment, file);

            try
            {
                // Get all image files from the folder
                string[] files = Directory.GetFiles(fullPath)
                    //.Where(file => IsValidFileExtension(file))
                    .ToArray();

                // Search for the image by name
                matchingFilesPath = files
                    .Where(filePath => Path.GetFileNameWithoutExtension(filePath).Equals(file.GetFullFileName(), StringComparison.OrdinalIgnoreCase))
                    .ToList();

                foreach (string filePath in matchingFilesPath)
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
            }
            catch (DirectoryNotFoundException ex) { }
        }

        public async Task SaveFile(IWebHostEnvironment hostEnvironment, FileResource file)
        {
            DeleteFile(hostEnvironment, file);

            var fullPath = GetAbsoluteFullPath(hostEnvironment, file);
            var fullFilePath = GetAbsoluteFilePath(hostEnvironment, file);

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            using (var fileStream = new FileStream(fullFilePath, FileMode.Create))
            {
                await file.FormFile.CopyToAsync(fileStream);
            }
        }


        public string GetFileLink(FileResource file)
        {
            return "~" + file.GetFullFilePath() + CacheBustingValue();
        }

        private string CacheBustingValue()
        {
            return $"?v={DateTime.UtcNow.Ticks}";
        }


        //protected abstract string[] GetExtensions();

    }
}
