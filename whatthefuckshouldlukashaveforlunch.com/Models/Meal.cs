using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using whatthefuckshouldlukashaveforlunch.com.Models.Helper;

namespace whatthefuckshouldlukashaveforlunch.com.Models
{
    public class Meal
    {

        int Weeknumber;
        List<Food> Foods = new List<Food>();
        string RawFoods = string.Empty;
        bool isExecuting = false;

        public Meal(int weeknumber)
        {
            Weeknumber = weeknumber;

            FetchRaw();
            SplitRaw();
        }

        void FetchRaw()
        {
            // Create new request
			HttpWebRequest request = (HttpWebRequest) WebRequest.Create(Endpoint);
			
            // Catch response
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();

            // Read response into string
			StreamReader sr = new StreamReader(response.GetResponseStream());
			RawFoods = sr.ReadToEnd();
			sr.Close();
        }

        void SplitRaw()
        {
            // Split raw string into an array of lines
            string[] lines = RawFoods.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            // For each line in the raw string
            bool firstLine = true;
			foreach (string line in lines)
			{
                // Skip CSV header line
                if (firstLine)
                {
                    firstLine = false;
                    continue;
                }

                // Parse CSV line
                string[] FoodValues = line.Split(";", StringSplitOptions.RemoveEmptyEntries);

                DateTime FoodDate = DateHelper.ParseDate(FoodValues[0]);
                string FoodName = FoodValues[3];

                // If date of current lines matches today, add to list
                if (DateHelper.IsSameDay(DateTime.Today, FoodDate))
                {
                    Foods.Add(new Food(FoodName, FoodDate));
				}
			}

		}

        private string Endpoint => $"http://www.stwno.de/infomax/daten-extern/csv/UNI-R/{Weeknumber}.csv";

        public Food GetRandom() 
        {
            int RandomPosition = new Random().Next(0, Foods.Count);
            return Foods[RandomPosition];
        }
    }
}