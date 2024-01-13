namespace MarketPlace.Entityes;
public class FoodMarket:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Food Food { get; set; }
}
