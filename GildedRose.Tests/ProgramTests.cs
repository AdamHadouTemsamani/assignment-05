namespace GildedRose.Tests;

public class ProgramTests
{
    //make Program accessible to tests
    private Program program;
    public ProgramTests()
    {
        program = new Program();
    }


    [Fact]
    public void Once_Sell_Date_Passes_Quality_Changes_Correctly()
    {
        //Arrange
        program.Items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 },
            new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 },
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 },
        };

        //Act
        program.UpdateQuality();

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
            new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 },
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 0 },
            new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 0 },
        };

        //Act
        program.UpdateQuality();

        //Assert
        program.Items.Should().NotContain(i => i.Quality < 0);
    }


    [Fact]
    public void Quality_Of_An_Item_Is_Never_More_Than_50_except_sulfuras()
    {
        //Arrange
        program.Items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 },
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 },
            new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 50 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
        };

        //Act
        program.UpdateQuality();

        //Assert 
        program.Items.Should().NotContain(i => i.Quality > 50 && i.Name != "Sulfuras, Hand of Ragnaros");
    }


    [Fact]
    public void Legendary_Items_Quality_Should_Never_Change()
    {
        //Arrange
        program.Items = new List<Item>
        {
             new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
        };
        var answer = 80;

        //Act
        program.UpdateQuality();

        //Assert
        program.Items[0].Quality.Should().Be(answer);
    }

    [Fact]
    public void Backstage_Pass_Quality_Changes_Correctly()
    {
        //Arrange
        program.Items = new List<Item>
        {
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10},
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10},
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10}
        };

        //Act
        program.UpdateQuality();


        //Assert
        program.Items[0].Quality.Should().Be(12);
        program.Items[1].Quality.Should().Be(13);
        program.Items[2].Quality.Should().Be(0);
    }





}

