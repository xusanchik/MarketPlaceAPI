using AutoMapper;
using MarketPlace.Dto_s;
using MarketPlace.Entityes;

namespace MarketPlace.AutoMapperConfguration
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap(); 
        }
    }
}
