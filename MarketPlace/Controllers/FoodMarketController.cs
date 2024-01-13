using MarketPlace.Entityes;
using MarketPlace.Interfaces;
using MarketPlace.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "MANAGER,ADMIN")]
public class FoodMarketController :MoldController<FoodMarket, FoodMarketRpository>
{
    private readonly IFoodMarketRepository _foodMarketRepository;
    public FoodMarketController(FoodMarketRepository foodMarketRpository, IFoodMarketRepository foodMarketRepositoryFromInterface) : base(foodMarketRpository) => _foodMarketRepository = foodMarketRepositoryFromInterface;

    [HttpGet("Include")]
    public async Task<IActionResult> GetAllFood() => Ok(await _foodMarketRepository.GetAsyncByIncludes());

}
