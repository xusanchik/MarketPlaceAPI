using MarketPlace.Data;
using MarketPlace.Entityes;
using MarketPlace.Generic;

namespace MarketPlace.Repository;
public class FoodMarketRpository : GenericRepository<FoodMarket, AppDbcontext>
{
    public FoodMarketRpository(AppDbcontext appDbcontext) : base(appDbcontext) { }

}
