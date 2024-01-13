using MarketPlace.Entityes;
using MarketPlace.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = " ADMIN,USER")]

    public class AdressController : MoldController<Adress ,AdressRepository>
    {
        public AdressController(AdressRepository adressRepository):base(adressRepository) { }
    }
}
