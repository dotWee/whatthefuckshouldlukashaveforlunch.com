using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using whatthefuckshouldlukashaveforlunch.com.Models;
using whatthefuckshouldlukashaveforlunch.com.Models.Exceptions;
using whatthefuckshouldlukashaveforlunch.com.Models.Helper;

namespace whatthefuckshouldlukashaveforlunch.com.Models
{
    public class Meal
    {
        private int Weeknumber { get; set; }

        private List<Food> _foods = new List<Food>();
        private string _rawFoods = string.Empty;

        public Meal(int weeknumber)
        {
            Weeknumber = weeknumber;

            FetchRaw();
            SplitRaw();
        }

        private void FetchRaw()
        {
            // Create new request
			var request = (HttpWebRequest) WebRequest.Create(Endpoint);
			
            // Catch response
            var response = (HttpWebResponse) request.GetResponse();

            // Read response into string
			var reader = new StreamReader(response.GetResponseStream());
			_rawFoods = reader.ReadToEnd();
			reader.Close();
        }

        private void SplitRaw()
        {
            // Split raw string into an array of lines
            var lines = _rawFoods.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            // For each line in the raw string
            var firstLine = true;
			foreach (var line in lines)
			{
                // Skip CSV header line
                if (firstLine)
                {
                    firstLine = false;
                    continue;
                }

                // Parse CSV line
                var foodValues = line.Split(";", StringSplitOptions.RemoveEmptyEntries);

				var foodName = foodValues[3];
				var foodDate = foodValues[0];

                // Both name and date have to be not empty or null
                if (string.IsNullOrEmpty(foodName) && string.IsNullOrEmpty(foodDate))
                {
                    throw new MensaClosedException("yea");
                }


                // If date of current lines matches today, add to list
                var parsedFoodDate = DateHelper.ParseDate(foodDate);
                if (DateHelper.IsSameDay(DateTime.Today, parsedFoodDate))
                {
                    _foods.Add(new Food(foodName, parsedFoodDate));
				}
			}

		}

        private string Endpoint => $"http://www.stwno.de/infomax/daten-extern/csv/UNI-R/{Weeknumber}.csv";

        public Food RandomItem => _foods[new Random().Next(0, _foods.Count)];

        public bool IsEmpty => _foods.Count == 0;

    }
}