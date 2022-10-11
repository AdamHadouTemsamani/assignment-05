public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }

    public virtual void UpdateQuality() { } //Pray to allah that Goblin doesn't kill me
}
