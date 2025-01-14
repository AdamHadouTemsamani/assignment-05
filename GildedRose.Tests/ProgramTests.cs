namespace GildedRose.Tests;

public class ProgramTests
{
    //make Program accessible to tests
    private Program program;
    public ProgramTests()
    {
        program = new Program();
    }

    public void FastFoward(int numberOfDays)
    {
        for(int i = 0; i < numberOfDays; i++)
        {
            program.UpdateQuality();
        }
    }

    [Fact]
    public void Once_Sell_Date_Passes_Quality_Changes_Correctly()
    {
        //Arrange
        program.Items = new List<Item>
        {
            new CheeseItem { Name = "Aged Brie", SellIn = 0, Quality = 10 },
            new CheeseItem { Name = "Aged Brie", SellIn = 0, Quality = 50 },
            new TicketItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 },
        };

        //Act
        FastFoward(1);

        //Assert
        program.Items[0].Quality.Should().Be(12);
        program.Items[1].Quality.Should().Be(50);
        program.Items[2].Quality.Should().Be(0);
    }




    [Fact]
    public void Quality_Of_An_Item_Is_Never_Negative()
    {
        //Arrange
        program.Items = new List<Item>
        {
            new CheeseItem { Name = "Aged Brie", SellIn = 0, Quality = 0 },
            new TicketItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 0 },
            new DefaultItem { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 0 },
        };

        //Act
        FastFoward(1);

        //Assert
        program.Items.Should().NotContain(i => i.Quality < 0);
    }


    [Fact]   
    public void Quality_Of_An_Item_Is_Never_More_Than_50_except_sulfuras()
    {
        //Arrange
        program.Items = new List<Item>
        {
            new CheeseItem { Name = "Aged Brie", SellIn = 0, Quality = 10 },
            new TicketItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 },
            new DefaultItem { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 50 },
            new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
        };

        //Act
        FastFoward(1);

        //Assert 
        program.Items.Should().NotContain(i => i.Quality > 50 && i.Name != "Sulfuras, Hand of Ragnaros");
    }


    [Fact]
    public void Legendary_Items_Quality_Should_Never_Change()
    {
        //Arrange
        program.Items = new List<Item>
        {
             new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
        };
        var answer = 80;

        //Act
        FastFoward(1);

        //Assert
        program.Items[0].Quality.Should().Be(answer);
    }

    [Fact]
    public void Backstage_Pass_Quality_Changes_Correctly()
    {
        //Arrange
        program.Items = new List<Item>
        {
            new TicketItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 10 },
            new TicketItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10},
            new TicketItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10},
            new TicketItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10}
        };

        //Act
        FastFoward(1);


        //Assert
        program.Items[0].Quality.Should().Be(11);
        program.Items[1].Quality.Should().Be(12);
        program.Items[2].Quality.Should().Be(13);
        program.Items[3].Quality.Should().Be(0);
    }

    [Fact]
    public void Aged_Brie_Quality_Increases()
    {
        //Arrange
        program.Items = new List<Item>
        {
            new CheeseItem { Name = "Aged Brie", SellIn = 10, Quality = 10},
            new CheeseItem { Name = "Aged Brie", SellIn = 0, Quality = 10},
        };

        //Act
        FastFoward(1);

        //Assert
        program.Items[0].Quality.Should().Be(11);
        program.Items[1].Quality.Should().Be(12);
    }

    [Fact]
    public void Conjured_Items_Decrease_Twice_As_Fast()
    {
        //Arrange
        program.Items = new List<Item>
        {
            new ConjuredItem { Name = "Conjured Mana Food", SellIn = 10, Quality = 10},
            new ConjuredItem { Name = "Mana Food that has been Conjured",  SellIn = 10, Quality = 10}
        };

        //Act
        FastFoward(1);
        
        //Assert
        program.Items[0].Quality.Should().Be(8);
        program.Items[1].Quality.Should().Be(8);
    }

    [Fact]
    public void DefaultItem_Quality_Returns_7_After_12_Days()
    {
        //Arrange
        program.Items = new List<Item>
        {
            new DefaultItem { Name = "Totally Ordinary Item", SellIn = 10, Quality = 20}
        };

        //Act
        FastFoward(12);

        //Assert
        program.Items[0].Quality.Should().Be(7);
    }


    [Fact]
    public void When_Conjured_Hits_Zero_It_Updates_Quality_Correctly()
    {
        //Arrange 
        program.Items = new List<Item>
        {
            new ConjuredItem { Name = "Conjured +10 Potion", SellIn = 10, Quality = 10}
        };

        //Act
        FastFoward(12);

        //Assert
        program.Items[0].Quality.Should().Be(0);
        program.Items[0].SellIn.Should().Be(-2);
    }

    [Fact]
    public void When_AgedBrie_Hits_Fifty_It_Updates_Quality_Correctly()
    {
        //Arrange 
        program.Items = new List<Item>
        {
            new CheeseItem { Name = "Nasty Looking Cheese", SellIn = 5, Quality = 40}
        };

        //Act
        FastFoward(12);

        //Assert
        program.Items[0].Quality.Should().Be(50);
        program.Items[0].SellIn.Should().Be(-7);
        
    }

}



