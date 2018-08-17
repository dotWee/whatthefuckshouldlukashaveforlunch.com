using WhatTheFuckShouldLukasHaveForLunch.Networks;
using Xunit;
using System.Linq;

namespace WhatTheFuckShouldLukasHaveForLunch.Test
{
    
    public class MensaProxyTest
    {
        [Fact]
        public void ReadItemsFromJsonTest()
        {
            var TestJson =
                "[{\"name\":\"Karotten-Ingwer-Suppe\",\"day\":\"Mo\",\"category\":\"Suppe\",\"labels\":\"V\",\"cost\":{\"students\":\"0,70\",\"employees\":\"0,90\",\"guests\":\"1,40\"},\"id\":433,\"upvotes\":441852,\"downvotes\":8011},{\"name\":\"Spaghetti Carbonara\",\"day\":\"Mo\",\"category\":\"HG1\",\"labels\":\"S\",\"cost\":{\"students\":\"2,00\",\"employees\":\"2,80\",\"guests\":\"3,60\"},\"id\":434,\"upvotes\":5,\"downvotes\":4},{\"name\":\"Putenschnitzel paniert mit Kartoffelsalat\",\"day\":\"Mo\",\"category\":\"HG2\",\"labels\":\"G\",\"cost\":{\"students\":\"3,10\",\"employees\":\"3,90\",\"guests\":\"4,60\"},\"id\":744,\"upvotes\":0,\"downvotes\":0}]";
            var Items = MensaProxy.ReadItemsFromJson(TestJson);

            // Validate item day
            foreach (var item in Items) Assert.Equal("Mo", item.day);
            
            // Validate item count
            Assert.Equal(3, Items.Count());
        }
    }
}