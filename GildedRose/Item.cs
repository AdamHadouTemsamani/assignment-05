public abstract class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }

    public abstract void UpdateQuality(); /* Our explanation to the Goblin can be found in our README file */
}
