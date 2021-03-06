using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WhatTheFuckShouldLukasHaveForLunch.Exceptions;
using WhatTheFuckShouldLukasHaveForLunch.Helper;

namespace WhatTheFuckShouldLukasHaveForLunch.Models
{
    public class MealModel
    {
        private HttpClient client = new HttpClient();

        // private readonly IHttpClientFactory _clientFactory;

        private int Weeknumber
        {
            get; set;
        }

        private List<FoodModel> _foods = new List<FoodModel>();
        private string _rawFoods = string.Empty;

        public MealModel(int _weeknumber, HttpClient _httpClient)
        {
            Weeknumber = _weeknumber;
            client = _httpClient;
        }

        private async Task<string> FetchRaw()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync(Endpoint);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);

                _rawFoods = responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return _rawFoods;
        }

        private void SplitRaw()
        {
            // Split raw string into an array of lines
            var lines = _rawFoods.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            try
            {
                // Check lines against current date string
                var nowDate = DateTime.Now.ToString(DateHelper.Format);

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

                    // Stop processing the line if it doesn't start with the current date string
                    if (!line.StartsWith(nowDate, System.StringComparison.CurrentCultureIgnoreCase))
                    {
                        Console.WriteLine($"Line doesn't start with our date: ignoring. nowDate={nowDate} line={line}");
                        continue;
                    }

                    // Parse CSV line
                    var foodValues = line.Split(";", StringSplitOptions.RemoveEmptyEntries);

                    var foodName = foodValues[3];
                    var foodDate = foodValues[0];

                    // Both name and date have to be not empty or null
                    if (string.IsNullOrEmpty(foodName) && string.IsNullOrEmpty(foodDate))
                    {
                        throw new MensaClosedException("Invalid line (NullOrEmpty foodName & NullOrEmpty foodDate");
                    }


                    // If date of current lines matches today, add to list
                    var parsedFoodDate = DateHelper.ParseDate(foodDate);
                    if (DateHelper.IsSameDay(DateTime.Today, parsedFoodDate))
                    {
                        _foods.Add(new FoodModel(foodName, parsedFoodDate));
                    }
                }
            }
            catch (FormatException)
            {
                throw new MensaClosedException("Can't format the current moment into a short date string!");
            }

            Console.WriteLine($"Size of foodsArray={_foods.Count} after splitting up the lines");

            if (_foods.Count == 0)
            {
                throw new MensaClosedException($"After parsing {lines.Length} menu lines, not even one entry matches the current date string!");
            }
        }

        private string Endpoint => $"http://www.stwno.de/infomax/daten-extern/csv/UNI-R/{Weeknumber}.csv";

        public async Task<FoodModel> GetRandomFoodAsync()
        {
            try
            {
                await FetchRaw();
                SplitRaw();

                if (_foods.Count > 0)
                {
                    return _foods[new Random().Next(0, _foods.Count)];
                }
            }
            catch (MensaClosedException e)
            {
                Console.WriteLine("Error: {0}", e);
                throw;
            }

            return null;
        }

        public override string ToString()
        {
            string retVal = string.Empty;
            foreach (FoodModel item in _foods)
            {
                if (string.IsNullOrEmpty(retVal))
                    retVal += item.ToString();
                else
                    retVal += string.Format(", {0}", item);
            }

            return $"MealModel: Weeknumber={Weeknumber} Foods={retVal}";
        }
    }
}
