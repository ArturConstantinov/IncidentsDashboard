using Incidents.Application.Common.Extensions;
using Incidents.Application.Common.Interfaces;
using Incidents.Application.Common.TableParameters;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Queries.IncidentsQueries.GetAllIncidents
{
    public class GetAllIncidentsQuery : IRequest<List<GetAllIncidentsVm>>
    {
        public DataTablesParameters Parameters { get; set; }

        public GetAllIncidentsQuery(DataTablesParameters parameters)
        {
            Parameters = parameters;
        }
    }

    public class GetAllIncidentsQueryHandler : IRequestHandler<GetAllIncidentsQuery, List<GetAllIncidentsVm>>
    {
        private readonly IIncidentsDbContext _context;

        public GetAllIncidentsQueryHandler(IIncidentsDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetAllIncidentsVm>> Handle(GetAllIncidentsQuery request, CancellationToken cancellationToken)
        {
            var incidentList = await _context.Incidents
                .Where(x => !x.IsDeleted)
                .Select(x => new GetAllIncidentsVm
                {
                    Id = x.Id,
                    RequestNr = x.RequestNr,
                    Subsystem = x.Subsystem,
                    OpenDate = x.OpenDate,
                    CloseDate = x.CloseDate,
                    Type = x.Type,
                    Urgency = x.Urgency
                })
                .Search(request.Parameters)
                .OrderBy(request.Parameters)
                .Page(request.Parameters)
                .ToListAsync(cancellationToken);

            return incidentList;
        }
    }
}
