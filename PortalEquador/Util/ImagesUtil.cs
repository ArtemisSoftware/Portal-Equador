using PortalEquador.Constants;

namespace PortalEquador.Util
{
    public static class ImagesUtil
    {
        public static string GetProfilePicturePath(int curriculumId, string extension)
        {
            return "~/" + FoldersConstants.IMAGES + "/" + curriculumId + "/" + ItemFromGroup.Documents.PROFILE_PICTURE + extension; 
        }

        public static string GetFilePath(int curriculumId, int documentTypeId, string extension)
        {
            return "~/" + FoldersConstants.IMAGES + "/" + curriculumId + "/" + documentTypeId + extension;
        }

    }
}
