using Microsoft.AspNetCore.Identity;

namespace MarketPlace.Entityes
{
    public class User:IdentityUser
    {
        public int Age { get; set; }
    }
}
