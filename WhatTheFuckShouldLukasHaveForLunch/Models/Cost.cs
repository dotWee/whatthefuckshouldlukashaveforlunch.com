using System.Runtime.Serialization;

namespace WhatTheFuckShouldLukasHaveForLunch.Models
{
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