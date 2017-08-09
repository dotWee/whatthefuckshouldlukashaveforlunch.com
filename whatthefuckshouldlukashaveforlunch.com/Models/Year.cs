using System;
namespace whatthefuckshouldlukashaveforlunch.com.Models
{
    public static class Year
    {
        public static string Value 
        {
            get => DateTime.Today.Year.ToString();
        }
    }
}
