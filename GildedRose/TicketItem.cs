public class TicketItem : Item
{
    public override void UpdateQuality()
    {
        if (Quality < 50)
        {
            Quality += 1;
            if (SellIn < 11)
            {
                Quality += 1;
            }
            if (SellIn < 6)
            {
                Quality += 1;
            }
            if (SellIn <= 0)
            {
                Quality = 0;
            }
        }
    }
}
