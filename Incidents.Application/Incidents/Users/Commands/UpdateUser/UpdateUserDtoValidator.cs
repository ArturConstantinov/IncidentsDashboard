using FluentValidation;

namespace Incidents.Application.Incidents.Users.Commands.UpdateUser
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username cannot be empty")
                .Length(7).WithMessage("Username must have 7 characters")
                .Must(a => a.ToLower()
                    .StartsWith("cr") == true).WithMessage("Username must start with 'cr'");

            RuleFor(x => x.Password)
                .MinimumLength(5).WithMessage("Password should be more then 5 characters")
                .MaximumLength(30).WithMessage("Username should be less then 30 characters");

            RuleFor(x => x.ConfirmPassword)
                .Equal(p => p.Password).WithMessage("Passwords do not match");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Name cannot be empty");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Not an email address");

            RuleFor(x => x.RolesId)
                .NotEmpty().WithMessage("Need to select role");
        }
    }
}
