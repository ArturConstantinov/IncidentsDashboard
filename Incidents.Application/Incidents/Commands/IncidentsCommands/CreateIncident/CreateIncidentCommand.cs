using Incidents.Application.Common.Interfaces;
using Incidents.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Commands.IncidentsCommands.CreateIncident
{
    public class CreateIncidentCommand : IRequest<int>
    {
        public CreateIncidentDto Dto { get; set; }
    }

    public class CreateIncidentCommandHandler : IRequestHandler<CreateIncidentCommand, int>
    {
        private readonly IIncidentsDbContext _context;

        public CreateIncidentCommandHandler(IIncidentsDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateIncidentCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.Dto == null)
            {
                return 0;
            }

            var existing = await _context.Incidents.AnyAsync(x => x.RequestNr == request.Dto.RequestNr);

            if (existing == true)
            {
                return 0;
            }

            var incident = new Incident
            {
                CreatedBy = request.Dto.CreatedBy,
                RequestNr = request.Dto.RequestNr,
                Subsystem = request.Dto.Subsystem,
                OpenDate = request.Dto.OpenDate,
                Type = request.Dto.Type,
                ApplicationType = request.Dto.ApplicationType,
                Urgency = request.Dto.Urgency,
                SubCause = request.Dto.SubCause,
                ProblemSummery = request.Dto.ProblemSummery,
                ProblemDescription = request.Dto.ProblemDescription,
                Solution = request.Dto.Solution,
                IncidentTypeId = request.Dto.IncidentTypeId,
                AmbitId = request.Dto.AmbitId,
                OriginId = request.Dto.OriginId,
                ThirdParty = request.Dto.ThirdParty,
                ScenaryId = request.Dto.ScenaryId,
                ThreatId = request.Dto.ThreatId,
            };

            await _context.Incidents.AddAsync(incident);

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
