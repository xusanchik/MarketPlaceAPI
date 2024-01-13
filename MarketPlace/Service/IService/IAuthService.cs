using MarketPlace.Dto_s;
using MarketPlace.Entityes;

namespace MarketPlace.Service.IService;
public interface IAuthService
{
    public Task<User> Register(UserDto userDto);
    public Task<string> Login(UserDto userDto);
    public Task<List<User>> UsersList();
    public Task<List<Food>> FoodsList();

}
