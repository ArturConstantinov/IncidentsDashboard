using AutoMapper;
using Incidents.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Queries.IncidentTypeQueries.GetIncidentTypeById
{
    public class GetIncidentTypeByIdQuery : IRequest<GetIncidentTypeByIdVm>
    {
        public int TypeId { get; set; }
    }

    public class GetIncidentTypeByIdQueryHandler : IRequestHandler<GetIncidentTypeByIdQuery, GetIncidentTypeByIdVm>
    {
        private readonly IIncidentsDbContext _context;
        private readonly IMapper _mapper;

        public GetIncidentTypeByIdQueryHandler(IIncidentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetIncidentTypeByIdVm> Handle(GetIncidentTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var incidentTypeVm = await _context.IncidentTypes
                .Where(x => x.Id == request.TypeId)
                .Select(x => new GetIncidentTypeByIdVm
                {
                    Name = x.Name,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<GetIncidentTypeByIdVm>(incidentTypeVm);
        }
    }
}
