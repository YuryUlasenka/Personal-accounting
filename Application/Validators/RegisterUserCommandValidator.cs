using Application.Commands;
using FluentValidation;

namespace Application.Validators
{
    public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.UserForRegistration.FirstName).NotEmpty();

            RuleFor(x => x.UserForRegistration.LastName).NotEmpty();

            RuleFor(x => x.UserForRegistration.UserName)
                .NotEmpty()
                .MaximumLength(256);

            RuleFor(x => x.UserForRegistration.Password).NotEmpty();

            RuleFor(x => x.UserForRegistration.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(256);
        }
    }
}