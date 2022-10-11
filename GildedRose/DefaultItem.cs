public class DefaultItem : Item
{
    public override void UpdateQuality()
    {
        if (Quality < 50)
        {
            if (SellIn < 0 && Quality > 0)
            {
                Quality -= 2;
            }
            else if (Quality > 0)
            {
                Quality -= 1;
            }
        }
    }
}