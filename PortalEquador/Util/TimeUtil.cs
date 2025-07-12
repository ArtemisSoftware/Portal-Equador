using Microsoft.AspNetCore.Http;

namespace PortalEquador.Util
{
    public static class TimeUtil
    {
        public static DateTime ToDateTime(DateOnly dateOnly)
        {
            TimeOnly customTime = new TimeOnly(0, 0, 0); 
            return dateOnly.ToDateTime(customTime);
        }

        public static DateOnly ToDateOnly(string date)
        {
            try { 
                return DateOnly.Parse(date);
            } catch(FormatException ex)
            {
                return DateOnly.FromDateTime(DateTime.Parse(date));
            }
        }

        public static DateOnly ToDateOnly(DateTime date)
        {
            return DateOnly.FromDateTime(date);
        }

        public static DateOnly DateOnlyCurrent()
        {
            return DateOnly.FromDateTime(DateTime.Now);
        }

        public static int GetAge(DateTime birthDate, DateTime? referenceDate = null)
        {
            var today = referenceDate ?? DateTime.Today;
            int age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
