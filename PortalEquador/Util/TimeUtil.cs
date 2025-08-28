using System.Globalization;

namespace PortalEquador.Util
{
    public static class TimeUtil
    {
        public const string dd_MMMM_yy = "dd-MMMM-yy";
        public const string dd_MM_yyyy__HH_mm_ss = "dd-MM-yyyy HH:mm:ss";
        public const string yyyy_MM_dd = "yyyy-MM-dd";
        public const string MMMM_yyyy = "MMMM yyyy";
        public const string dd_MM_yyyy = "dd-MM-yyyy";
        public const string dd_MMM_yyyy = "dd-MMM-yyyy";
        public const string yyyy = "yyyy";


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


        public static string GetFirstLetterOfWeekdayInPortuguese(DateTime date)
        {
            var culture = new CultureInfo("pt-PT");
            string dayName = culture.DateTimeFormat.GetDayName(date.DayOfWeek); // e.g., "segunda-feira"
            return dayName.Substring(0, 1).ToUpper(); // "S"
        }

        public static string GetYearsAndMonthsFromMonths(int months)
        {
                int years = months / 12;
                int remainingMonths = months % 12;
                var result = "";

                if (years == 1)
                {
                    result = $"{years} ano ";
                }
                else if (years > 1)
                {
                    result = $"{years} anos ";
                }
                else { }

                if (remainingMonths == 1 && years == 0)
                {
                    result += $" {remainingMonths} mes";
                }
                else if (remainingMonths > 1 && years == 0)
                {
                    result += $"{remainingMonths} meses ";
                }
                else if (remainingMonths == 1)
                {
                    result += $" e {remainingMonths} mes";
                }
                else if (remainingMonths > 1)
                {
                    result += $" e {remainingMonths} meses ";
                }
                return result;
        }
    }
}
