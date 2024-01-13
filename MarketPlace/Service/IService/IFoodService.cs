using MarketPlace.Dto_s;
using MarketPlace.Entityes;

namespace MarketPlace.Service.IService;
public interface IFoodService
{
    public Task<List<Food>> GetAllfood();
    public Task<Food> Create(FoodDto foodDto);
    public Task Deletee(int id);
    public Task<Food> GetFoodById(int id);
    public Task<Food> Update(int id,FoodDto foodDto);
}
