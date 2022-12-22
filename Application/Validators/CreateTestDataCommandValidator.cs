using Application.Commands;
using FluentValidation;

namespace Application.Validators
{
    public sealed class CreateTestDataCommandValidator : AbstractValidator<CreateTestDataNotification>
    {
        public CreateTestDataCommandValidator()
        {
            RuleFor(c => c.dataDto.Id)
                .Must(id => id > 0 && id < 10);
            RuleFor(c => c.dataDto.Data)
                .NotEmpty()
                .MaximumLength(10);
        }
    }
}