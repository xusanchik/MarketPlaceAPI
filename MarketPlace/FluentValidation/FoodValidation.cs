using FluentValidation;
using MarketPlace.Dto_s;

namespace MarketPlace.FluentValidation;

public class FoodValidation: AbstractValidator<FoodDto>
{
    public FoodValidation()
    {
        RuleFor(x =>x.Name).NotEmpty().MinimumLength(4).MaximumLength(10).WithMessage("no exict name");
    }
}
