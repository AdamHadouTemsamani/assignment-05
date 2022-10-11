using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");
            var app = new Program()
            {
                Items = new List<Item>
                                          {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                                          }
            };
            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < app.Items.Count; j++)
                {
                    Console.WriteLine(app.Items[j].Name + ", " + app.Items[j].SellIn + ", " + app.Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
        

        public void SulfurasLegendaryItem(Item item)
        {
            item.Quality = 80;
        }

        public void AgedBrieItem(Item item) {
            if (item.Quality < 50)
            {
                if (item.SellIn > 0) item.Quality += 1;
                if (item.SellIn <= 0) item.Quality += 2;
            }
        }
        

        public void ConjuredItem(Item item)
        {  
            if(item.Quality < 50 && item.Quality > 0)
            {
                if(item.SellIn > 0)
                {
                    item.Quality -= 2;
                } 
                else
                {
                    item.Quality = 0;
                }
            }
            
        }

        public void BackstagePassesItem(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
                if (item.SellIn < 11)
                {
                    item.Quality += 1;
                }
                if (item.SellIn < 6)
                {
                    item.Quality += 1;
                }
                if (item.SellIn <= 0)
                {
                    item.Quality = 0;
                }
            }
        }
        
        public void DefaultItem(Item item) {
            if(item.Quality < 50) 
            {
                if (item.SellIn < 0 && item.Quality > 0)
                {
                    item.Quality -= 2;
                }
                else if (item.Quality > 0)
                {
                    item.Quality -= 1;
                }
            }
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                switch(item.Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                        SulfurasLegendaryItem(item);
                        break;
                        
                    case "Aged Brie":
                        AgedBrieItem(item);
                        break;
                    
                    case var backstage when item.Name.Contains("Backstage") && item.Name.Contains("passes"):
                        BackstagePassesItem(item);

                        break;
                    
                    case var conjured when item.Name.Contains("Conjured"):
                        ConjuredItem(item);
                        break;
                
                    default:
                        DefaultItem(item);
                        break;
                } 
            }
        }
    }
}

//     {for (var i = 0; i < Items.Count; i++)
        //     {
        //         if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
        //         {
        //             if (Items[i].Quality > 0)
        //             {
        //                 if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //                 {
        //                     Items[i].Quality = Items[i].Quality - 1;
        //                 }
        //             }
        //         }
        //         else
        //         {
        //             if (Items[i].Quality < 50)
        //             {
        //                 Items[i].Quality = Items[i].Quality + 1;

        //                 if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
        //                 {
        //                     if (Items[i].SellIn < 11)
        //                     {
        //                         if (Items[i].Quality < 50)
        //                         {
        //                             Items[i].Quality = Items[i].Quality + 1;
        //                         }
        //                     }

        //                     if (Items[i].SellIn < 6)
        //                     {
        //                         if (Items[i].Quality < 50)
        //                         {
        //                             Items[i].Quality = Items[i].Quality + 1;
        //                         }
        //                     }
        //                 }
        //             }
        //         }

        //         if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //         {
        //             Items[i].SellIn = Items[i].SellIn - 1;
        //         }

        //         if (Items[i].SellIn < 0)
        //         {
        //             if (Items[i].Name != "Aged Brie")
        //             {
        //                 if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
        //                 {
        //                     if (Items[i].Quality > 0)
        //                     {
        //                         if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //                         {
        //                             Items[i].Quality = Items[i].Quality - 1;
        //                         }
        //                     }
        //                 }
        //                 else
        //                 {
        //                     Items[i].Quality = Items[i].Quality - Items[i].Quality;
        //                 }
        //             }
        //             else
        //             {
        //                 if (Items[i].Quality < 50)
        //                 {
        //                     Items[i].Quality = Items[i].Quality + 1;
        //                 }
        //             }
        //         }
        //     }
        // }}