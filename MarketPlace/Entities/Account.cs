namespace MarketPlace.Entityes;

public class Account: IEntity
{
    public int Id { get; set; }
    public string EditProfile { get; set; }
    public string HomeAddres { get; set; }
    public string Secirity { get; set;}
    public Payment Payment {  get; set; }
}
