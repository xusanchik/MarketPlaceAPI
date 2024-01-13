using FluentValidation;
using MarketPlace.Data;
using MarketPlace.Dto_s;
using MarketPlace.Entityes;
using MarketPlace.FilterAtribute;
using MarketPlace.Repository;
using MarketPlace.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "CUSTOMER, ADMIN,USER")]
    public class FoodController: ControllerBase
    {
        private readonly IFoodService _foodService;
        private readonly IValidator<FoodDto> _validator;
        private IFoodService foodService;
        private AppDbcontext appDbcontext;
        private FoodRepository foodRepository;

        public FoodController(IFoodService foodService, Data.AppDbcontext _appDbcontext, IValidator<FoodDto> validator)
        {
            _foodService = foodService;
            _validator = validator;
        }

        public FoodController(IFoodService foodService, AppDbcontext appDbcontext, FoodRepository foodRepository, IValidator<FoodDto> _validator)
        {
            this.foodService = foodService;
            this.appDbcontext = appDbcontext;
            this.foodRepository = foodRepository;
        }

        [HttpGet("Get/Food")]
        public async Task<IActionResult> GetALlFood() => Ok(await _foodService.GetAllfood());
        [TypeFilter(typeof(CHeckFilterAtribute))]
        [HttpGet("id")]
        public async Task<IActionResult> GetFoodById(int id) => Ok(await _foodService.GetFoodById(id));

        [HttpPost]
        public async Task<IActionResult> CreateFood(FoodDto foodDto)
        {
            var validetion = await _validator.ValidateAsync(foodDto);
            if (!validetion.IsValid)
            {
                return BadRequest(validetion.Errors);
            }
                return Ok(await _foodService.Create(foodDto));

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFood(int id)
        {
            await _foodService.Deletee(id);
            return Ok("Deleted Teacher");
        }

    }
}
