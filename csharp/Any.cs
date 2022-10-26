using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    internal class Any
    {
        private static readonly Random SellIn = new Random();
        private static readonly Random Quality = new Random();

        public List<Item> GenerateGenericItem()
        {
            Item item = GenerateItemTemplate("Sword");

            return new List<Item> { item };
        }

        public List<Item> GenerateAgedBrie()
        {
            Item item = GenerateItemTemplate("Aged Brie");

            return new List<Item> { item };
        }

        public List<Item> GenerateSulfuras()
        {
            Item item = GenerateItemTemplate("Sulfuras, Hand of Ragnaros");
            item.Quality = 80;

            return new List<Item> { item };
        }

        public List<Item> GenerateBackstagePass(int minDaysLeft = 12, int maxDaysLeft = 30)
        {
            Item item = GenerateItemTemplate("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = SellIn.Next(minDaysLeft, maxDaysLeft);

            return new List<Item> { item };
        }

        private static Item GenerateItemTemplate(string itemName)
        {
            var item = new Item()
            {
                Name = itemName,
                Quality = Quality.Next(2, 49),
                SellIn = SellIn.Next(2, 49)
            };

            return item;
        }
    }
}
