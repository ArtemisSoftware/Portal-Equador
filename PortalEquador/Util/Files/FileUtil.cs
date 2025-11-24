using PortalEquador.Util.Files.models;
using File = System.IO.File;

namespace PortalEquador.Util.Files
{
    public static class FileUtil
    {
      
        private static string GetAbsoluteFullPath(IWebHostEnvironment hostEnvironment, FileResource file)
        {
            string root = hostEnvironment.WebRootPath + file.GetFullPath();
            return root;
        }

        private static string GetAbsoluteFilePath(IWebHostEnvironment hostEnvironment, FileResource file)
        {
            string root = GetAbsoluteFullPath(hostEnvironment, file);
            return Path.Combine(root, file.GetFullFileName());
        }


        public static void DeleteFile(IWebHostEnvironment hostEnvironment, FileResource file)
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
                    .Where(filePath => Path.GetFileName(filePath).Equals(file.GetFullFileName(), StringComparison.OrdinalIgnoreCase))
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

        public static async Task SaveFile(IWebHostEnvironment hostEnvironment, FileResource file)
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



        public static string GetFileAbsoluteLink(IWebHostEnvironment hostEnvironment, FileResource file)
        {
            return GetAbsoluteFilePath(hostEnvironment, file) + CacheBustingValue();
        }

        public static string GetFileAbsoluteLink(IHttpContextAccessor http, FileResource file)
        {
            var request = http.HttpContext.Request;

            var baseUrl = $"{request.Scheme}://{request.Host}";
            var urlPath = $"/{file.GetFullPath().TrimStart('/')}{file.GetFullFileName()}";
            return baseUrl + urlPath + CacheBustingValue();
        }


        public static string GetFileLink(FileResource file)
        {
            return "~" + file.GetFullFilePath() + CacheBustingValue();
        }

        private static string CacheBustingValue()
        {
            return $"?v={DateTime.UtcNow.Ticks}";
        }
    }
}
