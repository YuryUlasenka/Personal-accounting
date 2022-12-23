using Application.Commands;
using FluentValidation;

namespace Application.Validators
{
    public sealed class AuthenticateUserValidator : AbstractValidator<AuthenticateUserCommand>
    {
        public AuthenticateUserValidator()
        {
            RuleFor(_ => _.UserLogin.UserName).NotEmpty();
            RuleFor(_=> _.UserLogin.Password).NotEmpty();
        }
    }
}
