using MarketPlace.Data;
using MarketPlace.Entityes;
using MarketPlace.Generic;

namespace MarketPlace.Repository;
public class FoodRepository:GenericRepository<Food ,AppDbcontext>
{
    public FoodRepository(AppDbcontext appDbcontext) :  base(appDbcontext) { }
}
