using Incidents.Application.Common.Interfaces;
using Incidents.Application.Incidents.Queries.IncidentsQueries.GetIncidentById;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Commands.IncidentsCommands.UpdateIncident.GetUpdateIncidentById
{
    public class GetUpdateIncidentByIdQuery : IRequest<UpdateIncidentDto>
    {
        public int Id { get; set; }
    }

    public class GetUpdateIncidentByIdQueryHandler : IRequestHandler<GetUpdateIncidentByIdQuery, UpdateIncidentDto>
    {
        private readonly IIncidentsDbContext _context;

        public GetUpdateIncidentByIdQueryHandler(IIncidentsDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateIncidentDto> Handle(GetUpdateIncidentByIdQuery request, CancellationToken cancellationToken)
        {
            var incident = await _context.Incidents
                .Where(x => x.Id == request.Id)
                .Select(x => new UpdateIncidentDto
                {
                    Id = x.Id,
                    RequestNr = x.RequestNr,
                    Subsystem = x.Subsystem,
                    OpenDate = x.OpenDate,
                    CloseDate = x.CloseDate,
                    Type = x.Type,
                    ApplicationType = x.ApplicationType,
                    Urgency = x.Urgency,
                    SubCause = x.SubCause,
                    ProblemSummery = x.ProblemSummery,
                    ProblemDescription = x.ProblemDescription,
                    Solution = x.Solution,
                    IncidentTypeId = x.IncidentTypeId,
                    AmbitId = x.AmbitId,
                    OriginId = x.OriginId,
                    ThirdParty = x.ThirdParty,
                    ScenaryId = x.ScenaryId,
                    ThreatId = x.ThreatId,

                })
                .FirstOrDefaultAsync(cancellationToken);

            return incident;
        }
    }
}
