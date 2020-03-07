using System;
using System.Text;

namespace WhatTheFuckShouldLukasHaveForLunch.Models
{
    public class FoodModel
    {
        public FoodModel(string name, DateTime date)
        {
            Name = name;
            ConvertToUtf8();
            RemoveBrackets();

            Date = date;
        }

        public string Name { get; set; }
		public DateTime Date { get; }

        private void ConvertToUtf8()
        {
			Encoding iso = Encoding.GetEncoding("ISO-8859-1");
			Encoding utf8 = Encoding.UTF8;

			byte[] utfBytes = utf8.GetBytes(Name);
			byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
			Name = iso.GetString(isoBytes);
        }

        private void RemoveBrackets()
        {
            string Pattern = "(\\[.*\\])|(\".*\")|('.*')|(\\(.*\\))";
            Name = System.Text.RegularExpressions.Regex.Replace(Name, Pattern, "");
        }


    }
}
