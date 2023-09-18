using AutoMapper;
using Incidents.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Queries.IncidentsQueries.GetIncidentById
{
    public class GetIncidentByIdQuery : IRequest<GetIncidentByIdVm>
    {
        public int Id { get; set; }
    }

    public class GetIncidentByIdQueryHandler : IRequestHandler<GetIncidentByIdQuery, GetIncidentByIdVm>
    {
        private readonly IIncidentsDbContext _context;
        private readonly IMapper _mapper;

        public GetIncidentByIdQueryHandler(IIncidentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetIncidentByIdVm> Handle(GetIncidentByIdQuery request, CancellationToken cancellationToken)
        {
            var incidentVm = await _context.Incidents
                .Where(x => x.Id == request.Id)
                .Select(x => new GetIncidentByIdVm
                {
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
                    ScenaryId = x.ScenaryId,
                    ThreatId = x.ThreatId,

                })
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<GetIncidentByIdVm>(incidentVm);
        }
    }
}
