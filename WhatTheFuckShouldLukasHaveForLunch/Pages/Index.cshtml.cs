using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Json;
using WhatTheFuckShouldLukasHaveForLunch.Models;

namespace WhatTheFuckShouldLukasHaveForLunch.Pages
{
    public class IndexModel : PageModel
    {
        public string ItemName { get; private set; }

        public bool ShowClosedMessage { get; private set; } = false;

        public void OnGet()
        {
            var today = DateTime.Now.DayOfWeek;
            if (today == DayOfWeek.Saturday || today == DayOfWeek.Sunday) {
                ShowClosedMessage = true;
            }

            else {
                var menu = MensaProxy.GetMenu(today);
                var randomItem = menu.GetRandomItem();

                if (randomItem == null)
                {
                    ShowClosedMessage = true;
                }

                else
                {
                    ItemName = randomItem.name;
                }
            }
        }
    }

    internal static class MensaProxy
    {
        private static readonly DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Item>));

        private static string GetEndpoint(DayOfWeek weekday) => "http://132.199.139.24:9001/mensa/uni/" + Item.WeekdayValuesMap[weekday];

        private static string DownloadJson(DayOfWeek weekday)
        {
            string json;
            using (var webClient = new System.Net.WebClient())
            {
                json = webClient.DownloadString(GetEndpoint(weekday));
            }

            // TODO: validate json
            Debug.WriteLine($"Downloaded menu for day={weekday}");
            return json;
        }

        private static List<Item> ReadItemsFromJson(string json)
        {
            List<Item> items;
            using (var stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(json)))
            {
                items = (List<Item>)serializer.ReadObject(stream);
            }

            return items;
        }

        public static Menu GetMenu(DayOfWeek weekday)
        {
            var json = DownloadJson(weekday);

            var items = ReadItemsFromJson(json);

            Debug.WriteLine($"Menu for day={weekday} has item count={items.Count}");
            return new Menu(weekday, items);
        }
    }
}
