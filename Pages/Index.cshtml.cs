using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.Serialization;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Json;

namespace WhatTheFuckShouldLukasHaveForLunch.Pages
{
    public class IndexModel : PageModel
    {
        public string ItemName { get; set; }

        public bool ShowClosedMessage { get; set; } = false;

        public void OnGet()
        {
            DayOfWeek today = DateTime.Now.DayOfWeek;
            if (today == DayOfWeek.Saturday || today == DayOfWeek.Sunday) {
                ShowClosedMessage = true;
            }

            else {
                Menu menu = MensaProxy.GetMenu(today);
                Item randomItem = menu.GetRandomItem();

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

    static class MensaProxy
    {

        internal static DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Item>));

        internal static string GetEndpoint(DayOfWeek weekday) => "http://132.199.139.24:9001/mensa/uni/" + Item.WeekdayValuesMap[weekday];

        internal static string DownloadJson(DayOfWeek weekday)
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

        internal static List<Item> ReadItemsFromJson(string json)
        {
            List<Item> items;
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(json)))
            {
                items = (List<Item>)serializer.ReadObject(stream);
            }

            return items;
        }

        public static Menu GetMenu(DayOfWeek weekday)
        {
            string json = DownloadJson(weekday);

            List<Item> items = ReadItemsFromJson(json);

            Debug.WriteLine($"Menu for day={weekday} has item count={items.Count}");
            return new Menu(weekday, items);
        }
    }

    [DataContract]
    public class Menu
    {
        public Menu(DayOfWeek weekday, List<Item> items)
        {
            this.weekday = weekday;
            this.items = items;
        }
        public DayOfWeek weekday { get; }
        
        [DataMember]
        public List<Item> items { get; }

        public Item GetRandomItem()
        {
            try
            {
                return items[new Random().Next(0, items.Count)];
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                return null;
            }
        }
    }

    [DataContract]
    public class Item
    {
        public static Dictionary<DayOfWeek, string> WeekdayValuesMap;
        public static string[] WeekdayValues;

        static Item()
        {
            WeekdayValues = new string[5] { "mo", "di", "mi", "do", "fr" };

            WeekdayValuesMap = new Dictionary<DayOfWeek, string>();
            WeekdayValuesMap.Add(DayOfWeek.Monday, WeekdayValues[0]);
            WeekdayValuesMap.Add(DayOfWeek.Tuesday, WeekdayValues[1]);
            WeekdayValuesMap.Add(DayOfWeek.Wednesday, WeekdayValues[2]);
            WeekdayValuesMap.Add(DayOfWeek.Thursday, WeekdayValues[3]);
            WeekdayValuesMap.Add(DayOfWeek.Friday, WeekdayValues[4]);
        }

        public Item()
        {

        }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string day { get; set; }

        [DataMember]
        public string category { get; set; }

        [DataMember]
        public string labels { get; set; }

        [DataMember]
        public Cost cost { get; set; }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int upvotes { get; set; }

        [DataMember]
        public int downvotes { get; set; }
    }

    [DataContract]
    public class Cost
    {
        [DataMember]
        public string students { get; set; }

        [DataMember]
        public string employees { get; set; }

        [DataMember]
        public string guests { get; set; }
    }
}
