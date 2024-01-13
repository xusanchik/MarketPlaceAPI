using MarketPlace.Entityes;
using MarketPlace.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "MANAGER,ADMIN,USER")]
    public class PaymentController : MoldController<Payment ,PaymentRrpository>
    {
        public PaymentController(PaymentRrpository paymentRrpository) : base (paymentRrpository) { }
    }
}
