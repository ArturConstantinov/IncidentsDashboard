using FluentValidation;

namespace Incidents.Application.Incidents.Commands.UserComands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.LastModifiedBy)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
