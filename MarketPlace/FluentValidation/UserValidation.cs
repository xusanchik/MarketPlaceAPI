using FluentValidation;
using MarketPlace.Dto_s;
using MarketPlace.Entityes;

namespace MarketPlace.FluentValidation;
public class UserValidation:AbstractValidator<UserDto>
{
    public UserValidation()
    {
        RuleFor(x=> x.Email).NotEmpty().MinimumLength(6).MaximumLength(13).WithMessage("Erroor Gmail");
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6).MaximumLength(15).WithMessage("not Faund");
        RuleFor(x => x.Name).NotEmpty().MinimumLength(6).MaximumLength(13).Equal("Equel name");


    }
}
