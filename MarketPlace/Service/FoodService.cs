using Mapster;
using MarketPlace.Data;
using MarketPlace.Dto_s;
using MarketPlace.Entityes;
using MarketPlace.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Service;
public class FoodService : IFoodService
{
    private readonly AppDbcontext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public FoodService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, AppDbcontext context)
    {
        _roleManager = roleManager;
        _context = context;
        _userManager = userManager;
    }
    public async Task<Food> Create(FoodDto foodDto)
    {
        var food = foodDto.Adapt<Food>();
        _context.Foodss.Add(food);
        await _context.SaveChangesAsync();
        return food;
    }

    public async Task Deletee(int id)
    {
        var get = await _context.Foodss.FirstOrDefaultAsync(x => x.Id == id);
        _context.Foodss.Remove(get);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Food>> GetAllfood()
    {
        return await _context.Foodss.ToListAsync();
    }

    public async Task<Food> GetFoodById(int id)
    {
        return await _context.Foodss.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Food> Update(int id, FoodDto foodDto)
    {
        var get = await _context.Foodss.FirstOrDefaultAsync(x => x.Id == id);
        get.Name = foodDto.Name;
        get.Price = foodDto.Price;
        _context.Foodss.Update(get);
        await _context.SaveChangesAsync();
        return get;
        }
}
