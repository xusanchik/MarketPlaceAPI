using FluentValidation;
using MarketPlace.Dto_s;
using MarketPlace.Entityes;
using MarketPlace.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IValidator<UserDto> _validator;
    public AuthController(IValidator<UserDto > validator,IAuthService authService)
    {
        _validator = validator;
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(UserDto request)
    {
        var validation = await _validator.ValidateAsync(request);
        if (validation.IsValid)
        {
            return BadRequest(validation.Errors);
        }
        return Ok(await _authService.Register(request));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserDto request)
    {
        var validation = await _validator.ValidateAsync(request);
        if (validation.IsValid)
        {
            return BadRequest(validation.Errors);
        }
        return Ok(await _authService.Login(request));
    }
}

