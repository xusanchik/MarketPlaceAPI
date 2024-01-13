using MarketPlace.Entityes;

namespace MarketPlace.Interfaces;

public interface IFoodMarketRepository
{
    Task<List<FoodMarket>> GetAsyncByIncludes();
}
