using MarketPlace.Data;
using MarketPlace.Entityes;
using MarketPlace.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Repository;

public sealed partial class FoodMarketRepository : IFoodMarketRepository
{
    private readonly AppDbcontext _context;
    public async Task<List<FoodMarket>> GetAsyncByIncludes() => await _context.FoodMarkets.Include(x => x.Food).ToListAsync();
}