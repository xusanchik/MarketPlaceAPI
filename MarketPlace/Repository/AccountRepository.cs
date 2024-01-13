using MarketPlace.Data;
using MarketPlace.Entityes;
using MarketPlace.Generic;

namespace MarketPlace.Repository;

public class AccountRepository:GenericRepository<Account , AppDbcontext>
{
    public AccountRepository(AppDbcontext appDbcontext) : base(appDbcontext) { }
}
