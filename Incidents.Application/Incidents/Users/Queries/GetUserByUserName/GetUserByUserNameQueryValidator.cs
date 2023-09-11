using FluentValidation;

namespace Incidents.Application.Incidents.Users.Queries.GetUserByUserName
{
    public class GetUserByUserNameQueryValidator : AbstractValidator<GetUserByUserNameQuery>
    {
        public GetUserByUserNameQueryValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username cannot be empty")
                .Length(7).WithMessage("Username must have 7 characters")
                .Must(a => a.ToLower()
                    .StartsWith("cr") == true).WithMessage("Username must start with 'cr'");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(5).WithMessage("Password should be more then 5 characters")
                .MaximumLength(30).WithMessage("Username should be less then 30 characters");
        }
    }
}
