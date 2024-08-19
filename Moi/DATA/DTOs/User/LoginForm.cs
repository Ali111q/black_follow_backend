using GaragesStructure.DATA.DTOs.User;
using FluentValidation;

namespace GaragesStructure.DATA.DTOs.User
{
    public class LoginForm
    {
        
        public String Username { get; set; }
        public String Password { get; set; }
    }
}

public class LoginFormValidator : AbstractValidator<LoginForm>
{
    public LoginFormValidator()
    {
        RuleFor(x => x.Username).NotNull().NotEmpty();
        RuleFor(x => x.Password).NotNull().NotEmpty();
    }
}