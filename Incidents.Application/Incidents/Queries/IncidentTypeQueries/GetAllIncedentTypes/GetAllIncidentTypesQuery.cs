using AutoMapper;
using AutoMapper.QueryableExtensions;
using Incidents.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Queries.IncidentTypeQueries.GetAllIncedentTypes
{
    public class GetAllIncidentTypesQuery : IRequest<List<GetAllIncidentTypesVm>>
    {
        public int AmbitId { get; set; }
    }

    public class GetAllIncidentTypesQueryHandler : IRequestHandler<GetAllIncidentTypesQuery, List<GetAllIncidentTypesVm>>
    {
        private readonly IIncidentsDbContext _context;
        private readonly IMapper _mapper;

        public GetAllIncidentTypesQueryHandler(IIncidentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetAllIncidentTypesVm>> Handle(GetAllIncidentTypesQuery request, CancellationToken cancellationToken)
        {
            var incidentTypes = await _context.IncidentTypes
                //.Where(x => x.AmbitId == request.AmbitId)
                .Select(x => new GetAllIncidentTypesVm
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToListAsync(cancellationToken);

            return incidentTypes;
        }
    }
}
