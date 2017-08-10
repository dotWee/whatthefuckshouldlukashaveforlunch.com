using System;
using System.Globalization;

namespace whatthefuckshouldlukashaveforlunch.com.Models.Helper
{
    public class DateHelper
    {
        private static string Format = "dd.MM.yyyy";

        public static int TodaysDayOfYear = DateTime.Today.DayOfYear;

        public static DateTime ParseDate(string Value) => DateTime.ParseExact(Value, Format, null);

		public static int CurrentWeeknumber = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

        public static bool IsSameDay(DateTime date1, DateTime date2) => date1.DayOfYear == date2.DayOfYear;
    }
}
