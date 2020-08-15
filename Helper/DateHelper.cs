using System;
using System.Globalization;

namespace WhatTheFuckShouldLukasHaveForLunch.Helper
{
    public class DateHelper
    {
        public const string Format = "dd.MM.yyyy";

        public static int TodaysDayOfYear = DateTime.Today.DayOfYear;

        public static DateTime ParseDate(string value) => DateTime.ParseExact(value, Format, null);

        public static int CurrentWeeknumber = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

        public static bool IsSameDay(DateTime date1, DateTime date2) => date1.DayOfYear == date2.DayOfYear;
    }
}
