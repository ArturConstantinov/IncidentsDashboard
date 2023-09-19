using Incidents.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Commands.IncidentsCommands.UpdateIncident
{
    public class UpdateIncidentCommand : IRequest<int>
    {
        public UpdateIncidentDto Dto { get; set; }
    }

    public class UpdateIncidentCommandHandler : IRequestHandler<UpdateIncidentCommand, int>
    {
        private readonly IIncidentsDbContext _context;

        public UpdateIncidentCommandHandler(IIncidentsDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateIncidentCommand request, CancellationToken cancellationToken)
        {
            var incident = await _context.Incidents
                .FirstOrDefaultAsync(x => x.Id == request.Dto.Id, cancellationToken);

            if (incident == null)
            {
                return 0;
            }

            incident.RequestNr = request.Dto.RequestNr;
            incident.OpenDate = request.Dto.OpenDate;
            incident.CloseDate = request.Dto.CloseDate;
            incident.Subsystem = request.Dto.Subsystem;
            incident.Type = request.Dto.Type;
            incident.ApplicationType = request.Dto.ApplicationType;
            incident.Urgency = request.Dto.Urgency;
            incident.SubCause = request.Dto.SubCause;
            incident.ProblemSummery = request.Dto.ProblemSummery;
            incident.ProblemDescription = request.Dto.ProblemDescription;
            incident.Solution = request.Dto.Solution;
            incident.IncidentTypeId = request.Dto.IncidentTypeId;
            incident.AmbitId = request.Dto.AmbitId;
            incident.OriginId = request.Dto.OriginId;
            incident.ThirdParty = request.Dto.ThirdParty;
            incident.ScenaryId = request.Dto.ScenaryId;
            incident.ThreatId = request.Dto.ThreatId;

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
