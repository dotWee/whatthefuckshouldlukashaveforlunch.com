using System;
using System.Text;

namespace whatthefuckshouldlukashaveforlunch.com.Models
{
    public class Food
    {
        public Food(string name, DateTime date)
        {
            Name = ConvertToUtf8(name);
            Date = date;
        }

        private string ConvertToUtf8(string unformated)
        {
			Encoding iso = Encoding.GetEncoding("ISO-8859-1");
			Encoding utf8 = Encoding.UTF8;

			byte[] utfBytes = utf8.GetBytes(Name);
			byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
			return iso.GetString(isoBytes);
        }

        public string Name { get; }
        public DateTime Date { get; }
    }
}
