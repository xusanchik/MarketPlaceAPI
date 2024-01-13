using MarketPlace.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.FilterAtribute
{
    public class CHeckFilterAtribute: ActionFilterAttribute
    {
        private readonly AppDbcontext _appDbcontext;
        public CHeckFilterAtribute(AppDbcontext appDbcontext) => _appDbcontext = appDbcontext;
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate actionExecutionDelegate)
        {
            if (!context.ActionArguments.ContainsKey("id"))
            {
                await actionExecutionDelegate();
                return;
            }
            var get = (int )context.ActionArguments["id"];
            if (!await _appDbcontext.Foodss.AnyAsync(x => x.Id == get))
            {
                await actionExecutionDelegate();
                return;
            }
            await actionExecutionDelegate();


        }




    }
}
