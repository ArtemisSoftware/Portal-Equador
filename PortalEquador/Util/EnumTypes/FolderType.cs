using static PortalEquador.Util.Constants.FoldersConstants;

namespace PortalEquador.Util.EnumTypes
{
    public enum FolderType
    {
        Curriculum,
        DriversLicence,
        DriversLicenceProvisional,
        Placeholder,
        MedicalExam,
        Trainning,
        DisciplinaryNotification,
        Accident
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

                case FolderType.Accident:
                    return "/accident";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string GetFullPath(this FolderType folderType)
        {
            return Folder.IMAGES_DIR + GetPath(folderType);
        }


        /*
        public class FolderType
{
    public string Code { get; }
    public string Description { get; }

    private FolderType(string code, string description)
    {
        Code = code;
        Description = description;
    }

    public static readonly FolderType Curriculum = 
        new FolderType("CUR", "Curriculum");

    public static readonly FolderType DriversLicence = 
        new FolderType("DL", "Driver's Licence");

    public static readonly FolderType DriversLicenceProvisional = 
        new FolderType("DLP", "Provisional Driver's Licence");

    public static readonly FolderType Placeholder = 
        new FolderType("PH", "Placeholder");

    public static readonly FolderType MedicalExam = 
        new FolderType("ME", "Medical Exam");

    public static readonly FolderType Training = 
        new FolderType("TR", "Training");

    public static readonly FolderType DisciplinaryNotification = 
        new FolderType("DN", "Disciplinary Notification");

    public static readonly FolderType Accident = 
        new FolderType("AC", "Accident");

    public override string ToString() => Description;
}

        var type = FolderType.DriversLicence;
Console.WriteLine(type.Code);        // "DL"
Console.WriteLine(type.Description); // "Driver's Licence"

        */
    }
}
