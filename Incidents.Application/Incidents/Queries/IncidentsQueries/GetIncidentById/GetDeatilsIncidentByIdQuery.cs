using AutoMapper;
using Incidents.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Queries.IncidentsQueries.GetIncidentById
{
    public class GetDeatilsIncidentByIdQuery : IRequest<GetDetailsIncidentByIdVm>
    {
        public int Id { get; set; }
    }

    public class GetIncidentByIdQueryHandler : IRequestHandler<GetDeatilsIncidentByIdQuery, GetDetailsIncidentByIdVm>
    {
        private readonly IIncidentsDbContext _context;
        private readonly IMapper _mapper;

        public GetIncidentByIdQueryHandler(IIncidentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetDetailsIncidentByIdVm> Handle(GetDeatilsIncidentByIdQuery request, CancellationToken cancellationToken)
        {
            var incidentVm = await _context.Incidents
                .Where(x => x.Id == request.Id)
                .Select(x => new GetDetailsIncidentByIdVm
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
                    IncidentType = x.IncidentType.Name,
                    Ambit = x.Ambit.Name,
                    Origin = x.Origin.Name,
                    ThirdParty = x.ThirdParty,
                    Scenary = x.Scenary.Name,
                    Threat = x.Threat.Name,

                })
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<GetDetailsIncidentByIdVm>(incidentVm);
        }
    }
}
