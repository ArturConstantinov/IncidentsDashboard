using FluentValidation;

namespace Incidents.Application.Incidents.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.LastModifiedBy)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username cannot be empty")
                .Length(7).WithMessage("Username must have 7 characters")
                .Must(a => a.ToLower()
                    .StartsWith("cr") == true).WithMessage("Username must start with 'cr'");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Name cannot be empty");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Not an email address");



            var roleNames = new List<string>() { "Administrator", "User", "Operator" };

            RuleFor(x => x.RoleName)
                .NotEmpty()
                .NotNull()
                .Must(x => roleNames.Contains(x)).WithMessage("Role can only be: " + string.Join(",", roleNames));
        }
    }
}
