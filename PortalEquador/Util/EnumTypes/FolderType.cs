using static PortalEquador.Util.Constants.FoldersConstants;

namespace PortalEquador.Util.EnumTypes
{
    public enum FolderType
    {
        Curriculum,
        DriversLicence,
        Placeholder,
        MedicalExam,
        Trainning,
        DisciplinaryNotification
    }

    public static class FolderTypeExtensions
    {
        public static string GetPath(this FolderType folderType)
        {
            switch (folderType)
            {
                case FolderType.Curriculum:
                    return  "/curriculum";

                case FolderType.DriversLicence:
                    return "/driverslicence";

                case FolderType.Placeholder:
                    return "/placeholder";

                case FolderType.MedicalExam:
                    return "/medicalexam";

                case FolderType.Trainning:
                    return "/trainning";

                case FolderType.DisciplinaryNotification:
                    return "/disciplinarynotification";

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
