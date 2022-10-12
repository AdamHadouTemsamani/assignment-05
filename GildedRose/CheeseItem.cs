public class CheeseItem : Item
{
    public override void UpdateQuality()
    {
        if (Quality < 50)
        {
            if (SellIn > 0) Quality += 1;
            if (SellIn <= 0) Quality += 2;
            if (Quality > 50) Quality = 50;
        }
        SellIn--;
    }


}