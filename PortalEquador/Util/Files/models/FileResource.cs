using PortalEquador.Data.Migrations;
using PortalEquador.Domain.Accident.ViewModels;
using PortalEquador.Domain.Report.ViewModels.Accident;
using PortalEquador.Util.Constants;
using PortalEquador.Util.EnumTypes;

namespace PortalEquador.Util.Files.models
{
    public class FileResource
    {
        public string FileName { get; }
        public IFormFile? FormFile { get; }
        public FolderType Directory { get; }
        public int Folder { get; }

        private string? Extension { get; }

        public FileResource(
            string fileName,
            IFormFile formFile,
            FolderType directory,
            int folder
            )
        {
            FileName = fileName;
            FormFile = formFile;
            Directory = directory;
            Folder = folder;
        }

        public FileResource(
            string fileName,
            string extension,
            FolderType directory,
            int folder
        )
        {
            FileName = fileName;
            Extension = extension;
            Directory = directory;
            Folder = folder;
        }

        public string GetExtension()
        {
            if (FormFile != null)
            {
                return Path.GetExtension(FormFile.FileName);
            }
            else
            {
                return Extension;
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>Ex:Filename + extension</returns>
        public string GetFullFileName() {
            return GetFileId() + GetExtension();
        }

        /// <summary>
        ///  Folder/FolderType/PersonalInformationId/
        /// </summary>
        /// <returns>Ex:images/accident/1/</returns>
        public string GetFullPath()
        {
            var result = string.Empty;

            switch (Directory)
            {
                case FolderType.Accident:
                    result = FoldersConstants.Folder.REPORT_DIR;
                    break;
              
                default:
                    result = FoldersConstants.Folder.IMAGES_DIR;
                    break;
            }

            return result + FolderTypeExtensions.GetPath(Directory) + "/" + Folder + "/";
        }

        /// <summary>
        /// Folder/FolderType/PersonalInformationId/Filename.extension
        /// </summary>
        /// <returns>Ex:images/accident/1/sample.pdf</returns>
        public string GetFullFilePath()
        {
            return Path.Combine(GetFullPath(), GetFullFileName());
        }


        private string GetFileId()
        {
            var result = string.Empty;
            switch (Directory)
            {
                case FolderType.DriversLicence:
                    break;
                case FolderType.DriversLicenceProvisional:
                    break;
                default:
                    result = FileName;
                    break;
            }

            return result;
        }


        //---------------------
        //---------------------

        public static FileResource AccidentResource(AccidentViewModel model, int fileName)
        {
            return  new FileResource(
                directory: FolderType.Accident,
                folder: model.PersonaInformationId,
                fileName: fileName + "",
                formFile: model.FormFile
            );
        }

        public static FileResource AccidentResource(AccidentResultViewModel model)
        {
            return new FileResource(
                directory: FolderType.Accident,
                folder: model.PersonalInformationId,
                fileName: model.Id.ToString(),
                extension: model.FileExtension
            );
        }
    }
}
