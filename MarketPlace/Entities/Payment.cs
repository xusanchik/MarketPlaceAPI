namespace MarketPlace.Entityes;

public class Payment:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TotalPrice { get; set; }
}
