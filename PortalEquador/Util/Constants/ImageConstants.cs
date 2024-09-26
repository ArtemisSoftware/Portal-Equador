namespace PortalEquador.Util.Constants
{
    public static class ImageConstants
    {
        public static class Extensions
        {
            public static string[] IMAGE_EXTENSIONS = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

            public static bool IsValidImageExtension(string path)
            {
                foreach (var extension in IMAGE_EXTENSIONS)
                {

                    if (path.EndsWith(extension))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public static class Placeholder
        {
            public const string AVATAR = "/avatar.png";
        }

        public static class NameSuffix
        {
            public const string DRIVERS_LICENCE_PROVISIONAL = "-provisional";
        }
    }
}
