using FluentValidation;

namespace Incidents.Application.Incidents.Queries.UserQueries.GetAllUsers
{
    public class GetAllUsersQueryValidator : AbstractValidator<GetAllUsersQuery>
    {
        public GetAllUsersQueryValidator()
        {
            //RuleFor(x => x.Id)
            //    .NotEmpty()
            //    .GreaterThan(0);
        }
    }
}
