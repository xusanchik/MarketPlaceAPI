using MarketPlace.Data;
using MarketPlace.Entityes;
using MarketPlace.Generic;

namespace MarketPlace.Repository;
public class AdressRepository :GenericRepository<Adress, AppDbcontext>
{
    public AdressRepository(AppDbcontext appDbcontext) : base(appDbcontext) { }
}
