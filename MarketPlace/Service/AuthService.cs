using MarketPlace.Data;
using MarketPlace.Dto_s;
using MarketPlace.Entityes;
using MarketPlace.Extensions;
using MarketPlace.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MarketPlace.Service;
public class AuthService : IAuthService
{
    private readonly AppDbcontext _appDbcontext;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public AuthService(AppDbcontext appContext ,UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
    {
        _appDbcontext = appContext;
        _userManager = userManager;
        _roleManager = roleManager;
        
    }

    public async Task<List<Food>> FoodsList()
    {
        return await _appDbcontext.Foodss.ToListAsync();
    }

    public async Task<string> Login(UserDto userDto)
    {
        var use = await _appDbcontext.Users.FirstOrDefaultAsync(e => e.Email == userDto.Email);
        if(use !=  null) 
        {
            var roles = await _userManager.GetRolesAsync(use);
            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();
            roleClaims.Add(new Claim(ClaimTypes.Name,userDto.Name));
            var token = CreateTokenInJwtAuthorizationFromUsers.CreateToken(use, roleClaims);
            return token;
        }
        throw new BadHttpRequestException("User not found.");

    }

    public async Task<User> Register(UserDto userDto)
    {
        var user = new User
        {
            UserName = userDto.Name,
            Email = userDto.Email
        };

        var result = await _userManager.CreateAsync(user, userDto.Password);
        if (!result.Succeeded)
        {
            throw new Exception("Password isn't hashed");
        }
        await _userManager.AddToRoleAsync(user, Enum.GetName(userDto.Role).ToUpper());
        await _appDbcontext.SaveChangesAsync();
        return user;
    }

    public async Task<List<User>> UsersList()
    {
        return await _appDbcontext.Users.ToListAsync();
    }
}
