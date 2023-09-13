using FluentValidation;

namespace Incidents.Application.Incidents.Queries.IncidentsQueries.GetAllIncidents
{
    public class GetAllIncidentsDtoValidator : AbstractValidator<GetAllIncidentsDto>
    {
        public GetAllIncidentsDtoValidator()
        {
            RuleFor(x => x.RequestNr)
                .NotEmpty().WithMessage("RequestNr cannot be empty")
                .Length(17).WithMessage("RequestNr must heve 17 characters");

            RuleFor(x => x.Subsystem)
                .NotEmpty().WithMessage("Subsystem cannot be empty")
                .Length(2).WithMessage("Subsystem must heve 2 characters");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type cannot be empty");

            RuleFor(x => x.Urgency)
                .NotEmpty().WithMessage("Urgency cannot be empty");
        }
    }
}
