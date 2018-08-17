using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WhatTheFuckShouldLukasHaveForLunch.Models
{
    [DataContract]
    public class Item
    {
        public static readonly Dictionary<DayOfWeek, string> WeekdayValuesMap;
        private static string[] WeekdayValues;

        static Item()
        {
            WeekdayValues = new string[5] { "mo", "di", "mi", "do", "fr" };

            WeekdayValuesMap = new Dictionary<DayOfWeek, string>
            {
                {DayOfWeek.Monday, WeekdayValues[0]},
                {DayOfWeek.Tuesday, WeekdayValues[1]},
                {DayOfWeek.Wednesday, WeekdayValues[2]},
                {DayOfWeek.Thursday, WeekdayValues[3]},
                {DayOfWeek.Friday, WeekdayValues[4]}
            };
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
}