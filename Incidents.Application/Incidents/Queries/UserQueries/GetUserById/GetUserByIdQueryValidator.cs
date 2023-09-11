using FluentValidation;

namespace Incidents.Application.Incidents.Queries.UserQueries.GetUserById
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
