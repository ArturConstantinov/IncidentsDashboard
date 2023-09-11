using FluentValidation;

namespace Incidents.Application.Incidents.Commands.UserComands.CreateUser
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.CreatedBy)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username cannot be empty") // to create validation with rexex (CRXXXXX)
                .Length(7).WithMessage("Username must have 7 characters")
                .Must(a => a.ToLower()
                    .StartsWith("cr") == true).WithMessage("Username must start with 'cr'");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(5).WithMessage("Password should be more then 5 characters")
                .MaximumLength(30).WithMessage("Username should be less then 30 characters");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Name cannot be empty");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Not an email address");
        }
    }
}
