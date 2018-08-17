using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WhatTheFuckShouldLukasHaveForLunch.Models
{
    [DataContract]
    public class Menu
    {
        public Menu(DayOfWeek weekday, List<Item> items)
        {
            this.weekday = weekday;
            this.items = items;
        }

        private DayOfWeek weekday { get; }
        
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
}