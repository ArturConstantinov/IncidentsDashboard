using FluentValidation;

namespace Incidents.Application.Incidents.Commands.RoleComands.AddRoleToUser
{
    public class AddRoleToUserCommandValidator : AbstractValidator<AddRoleToUserCommand>
    {
        public AddRoleToUserCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.RoleId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
