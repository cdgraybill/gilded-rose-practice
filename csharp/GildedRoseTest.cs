using NUnit.Framework;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void UpdateItems_LowerSellInByOne_WhenGenericItem()
        {
            var any = new Any();

            var items = any.GenerateGenericItem();
            var sellIn = items[0].SellIn;

            GildedRose app = new GildedRose(items);
            app.UpdateItems();

            Assert.AreEqual("Sword", items[0].Name);
            Assert.AreEqual(sellIn - 1, items[0].SellIn);
        }

        [Test]
        public void UpdateItems_LowerQualityByOne_WhenGenericItem()
        {
            var any = new Any();

            var items = any.GenerateGenericItem();
            var quality = items[0].Quality;

            GildedRose app = new GildedRose(items);
            app.UpdateItems();

            Assert.AreEqual("Sword", items[0].Name);
            Assert.AreEqual(quality - 1, items[0].Quality);
        }

        [Test]
        public void UpdateItems_LowerQualityByTwo_WhenGenericItem_SellInDatePassed()
        {
            var any = new Any();

            var items = any.GenerateGenericItem();
            var quality = items[0].Quality;
            items[0].SellIn = 0;

            GildedRose app = new GildedRose(items);
            app.UpdateItems();

            Assert.AreEqual("Sword", items[0].Name);
            Assert.AreEqual(quality - 2, items[0].Quality);
        }

        [Test]
        public void UpdateItems_LowerSellInByOne_WhenAgedBrie()
        {
            var any = new Any();

            var items = any.GenerateAgedBrie();
            var sellIn = items[0].SellIn;

            GildedRose app = new GildedRose(items);
            app.UpdateItems();

            Assert.AreEqual("Aged Brie", items[0].Name);
            Assert.AreEqual(sellIn - 1, items[0].SellIn);
        }

        [Test]
        public void UpdateItems_IncreaseQualityByOne_WhenAgedBrie()
        {
            var any = new Any();

            var items = any.GenerateAgedBrie();
            var quality = items[0].Quality;

            GildedRose app = new GildedRose(items);
            app.UpdateItems();

            Assert.AreEqual("Aged Brie", items[0].Name);
            Assert.AreEqual(quality + 1, items[0].Quality);
        }

        [Test]
        public void UpdateItems_IncreaseQualityByTwo_WhenAgedBrie_SellInDatePassed()
        {
            var any = new Any();

            var items = any.GenerateAgedBrie();
            var quality = items[0].Quality;
            items[0].SellIn = 0;

            GildedRose app = new GildedRose(items);
            app.UpdateItems();

            Assert.AreEqual("Aged Brie", items[0].Name);
            Assert.AreEqual(quality + 2, items[0].Quality);
        }

        [Test]
        public void UpdateItems_SellInDoesNotChange_WhenSulfuras()
        {
            var any = new Any();

            var items = any.GenerateSulfuras();
            var sellIn = items[0].SellIn;

            GildedRose app = new GildedRose(items);
            app.UpdateItems();

            Assert.AreEqual("Sulfuras, Hand of Ragnaros", items[0].Name);
            Assert.AreEqual(sellIn, items[0].SellIn);
        }

        [Test]
        public void UpdateItems_QualityDoesNotChange_WhenSulfuras()
        {
            var any = new Any();

            var items = any.GenerateSulfuras();
            var quality = items[0].Quality;

            GildedRose app = new GildedRose(items);
            app.UpdateItems();

            Assert.AreEqual("Sulfuras, Hand of Ragnaros", items[0].Name);
            Assert.AreEqual(quality, items[0].Quality);
        }

        [Test]
        public void UpdateItems_QualityIncreasesByOne_WhenBackstagePass()
        {
            var any = new Any();

            var items = any.GenerateBackstagePass();
            var quality = items[0].Quality;

            GildedRose app = new GildedRose(items);
            app.UpdateItems();

            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", items[0].Name);
            Assert.AreEqual(quality + 1, items[0].Quality);
        }

        [Test]
        public void UpdateItems_QualityIncreasesByTwo_WhenBackstagePass_TenToSixDaysLeft()
        {
            var any = new Any();

            var items = any.GenerateBackstagePass(6, 11);
            var quality = items[0].Quality;

            GildedRose app = new GildedRose(items);
            app.UpdateItems();

            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", items[0].Name);
            Assert.AreEqual(quality + 2, items[0].Quality);
        }

        [Test]
        public void UpdateItems_QualityIncreasesByThree_WhenBackstagePass_FiveToTwoDaysLeft()
        {
            var any = new Any();

            var items = any.GenerateBackstagePass(2, 5);
            var quality = items[0].Quality;

            GildedRose app = new GildedRose(items);
            app.UpdateItems();

            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", items[0].Name);
            Assert.AreEqual(quality + 3, items[0].Quality);
        }

        [Test]
        public void UpdateItems_QualityIsZero_WhenBackstagePass_AfterConcert()
        {
            var any = new Any();

            var items = any.GenerateBackstagePass(0, 1);
            var quality = items[0].Quality;

            GildedRose app = new GildedRose(items);
            app.UpdateItems();

            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", items[0].Name);
            Assert.AreEqual(quality - quality, items[0].Quality);
        }
    }
}
