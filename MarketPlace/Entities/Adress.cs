namespace MarketPlace.Entityes;
public class Adress : IEntity
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string HouseNumber { get; set; }
    public string City { get; set; }
}
