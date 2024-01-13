using MarketPlace.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class AdminController : ControllerBase
    {
        private readonly AppDbcontext _context;
        public AdminController(AppDbcontext context) => _context = context;
        [HttpGet("User")]
        public async Task<IActionResult> GetAll() => Ok(await _context.Users.ToListAsync());
        [HttpGet("Food")]
        public async Task<IActionResult> GetAl() => Ok(await _context.Foodss.ToListAsync());
    }
}
