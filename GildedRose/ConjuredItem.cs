public class ConjuredItem : Item
{
    public override void UpdateQuality()
    {
        if (Quality < 50 && Quality > 0)
        {
            if (SellIn > 0)
            {
                Quality -= 2;
            }
            else
            {
                Quality -= 4;
            }
        }
        SellIn--;
    }
}