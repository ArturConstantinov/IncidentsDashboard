using FluentValidation;

namespace Incidents.Application.Incidents.Queries.UserQueries.GetAllUsers
{
    public class GetAllUsersDtoValidator : AbstractValidator<GetAllUsersDto>
    {
        public GetAllUsersDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username cannot be empty") // CRXXXXX
                .Length(7).WithMessage("Username must have 7 characters")
                .Must(a => a.ToLower()
                    .StartsWith("cr") == true).WithMessage("Username must start with 'cr'");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Name cannot be empty");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Not an email address");
        }
    }
}
