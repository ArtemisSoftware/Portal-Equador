using System.Text;
using System.Text.RegularExpressions;

namespace PortalEquador.Util
{
    public static class PasswordGenerator
    {
        private static readonly Random Random = new();

        public static string GeneratePassword(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                fullName = "User Default";

            // Split name into words
            var parts = Regex.Split(fullName.Trim(), @"\s+")
                             .Where(p => !string.IsNullOrWhiteSpace(p))
                             .ToArray();

            // Use first and last word
            string namePart = parts.Length == 1
                ? Capitalize(parts[0])
                : $"{Capitalize(parts[0])}{Capitalize(parts[^1])}";

            // Start with 2 random digits
            StringBuilder numberPart = new(Random.Next(10, 100).ToString());

            // Ensure total length >= 8
            while ((namePart.Length + 1 + numberPart.Length) < 8)
            {
                numberPart.Append(Random.Next(0, 10));
            }

            // Build password: Name + dot + numbers
            string password = $"{namePart}.{numberPart}";

            return password;
        }

        private static string Capitalize(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}
