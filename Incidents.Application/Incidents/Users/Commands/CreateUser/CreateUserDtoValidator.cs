using FluentValidation;

namespace Incidents.Application.Incidents.Users.Commands.CreateUser
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {

            RuleFor(x => x.UserName)
              .NotEmpty().WithMessage("Username cannot be empty")
              .NotNull().WithMessage("Username cannot be null")
              .Length(7).WithMessage("Username must have 7 characters")
              .Must(a => a.ToLower()
                    .StartsWith("cr") == true).WithMessage("Username must start with 'cr'");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(5).WithMessage("Password should be more then 5 characters")
                .MaximumLength(30).WithMessage("Username should be less then 30 characters");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm password")
                .Equal(p => p.Password).WithMessage("Passwords do not match");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Name cannot be empty")
                .NotNull();

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty")
                .EmailAddress().WithMessage("Not an email address");

            RuleFor(x => x.RolesId)
                .NotEmpty().WithMessage("Need to select role");
        }
    }
}
