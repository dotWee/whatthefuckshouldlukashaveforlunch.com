using System;
namespace whatthefuckshouldlukashaveforlunch.com.Models
{
    public class Food
    {
        public Food(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }

        public string Name { get; }
        public DateTime Date { get; }
    }
}
