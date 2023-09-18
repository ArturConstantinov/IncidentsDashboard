using FluentValidation;

namespace Incidents.Application.Incidents.Commands.IncidentsCommands.CreateIncident
{
    public class CreateIncidentDtoValidator : AbstractValidator<CreateIncidentDto>
    {
        public CreateIncidentDtoValidator()
        {
            RuleFor(x => x.RequestNr)
                .NotEmpty().WithMessage("RequestNr cannot be empty")
                .Length(17).WithMessage("RequestNr must heve 17 characters");

            RuleFor(x => x.Subsystem)
                //.NotEmpty().WithMessage("Subsystem cannot be empty")
                .Length(2).WithMessage("Subsystem must heve 2 characters");

            RuleFor(x => x.OpenDate)
                .NotEmpty().WithMessage("Date cannot be empty");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type cannot be empty")
                .MaximumLength(50).WithMessage("Type should be less then 50 characters");

            RuleFor(x => x.ApplicationType)
                .NotEmpty().WithMessage("Application Type cannot be empty")
                .MaximumLength(50).WithMessage("Application Type should be less then 50 characters");

            RuleFor(x => x.Urgency)
                .NotEmpty().WithMessage("Urgency cannot be empty");

            RuleFor(x => x.SubCause)
                .NotEmpty().WithMessage("Subcause cannot be empty")
                .MaximumLength(50).WithMessage("Subcause should be less then 50 characters");

            RuleFor(x => x.ProblemSummery)
                .NotEmpty().WithMessage("Problem Summery cannot be empty")
                .MaximumLength(250).WithMessage("Problem Summery should be less then 250 characters");

            RuleFor(x => x.ProblemDescription)
                .NotEmpty().WithMessage("Problem Description cannot be empty")
                .MaximumLength(350).WithMessage("Problem Description should be less then 350 characters");

            RuleFor(x => x.Solution)
                .NotEmpty().WithMessage("Solution cannot be empty")
                .MaximumLength(350).WithMessage("Solution should be less then 350 characters");

            RuleFor(x => x.ThirdParty)
                .MaximumLength(50).WithMessage("Third Party name should be less then 50 characters");

        }
    }
}
