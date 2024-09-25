using static PortalEquador.Util.Constants.FoldersConstants;

namespace PortalEquador.Util.EnumTypes
{
    public enum FolderType
    {
        Curriculum,
        DriversLicence,
        Placeholder
    }

    public static class FolderTypeExtensions
    {
        public static string GetPath(this FolderType folderType)
        {
            switch (folderType)
            {
                case FolderType.Curriculum:
                    return  " / curriculum";

                case FolderType.DriversLicence:
                    return "/driverslicence";

                case FolderType.Placeholder:
                    return "/placeholder";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string GetFullPath(this FolderType folderType)
        {
            return Folder.IMAGES_DIR + GetPath(folderType);
        }
    }
}
