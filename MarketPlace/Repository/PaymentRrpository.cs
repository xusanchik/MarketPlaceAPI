using MarketPlace.Data;
using MarketPlace.Entityes;
using MarketPlace.Generic;

namespace MarketPlace.Repository;
public class PaymentRrpository:GenericRepository<Payment ,AppDbcontext>
{
    public PaymentRrpository(AppDbcontext appDbcontext): base(appDbcontext) { }
}
