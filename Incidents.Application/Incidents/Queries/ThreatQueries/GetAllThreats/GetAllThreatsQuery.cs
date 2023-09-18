using AutoMapper;
using AutoMapper.QueryableExtensions;
using Incidents.Application.Common.Interfaces;
using Incidents.Application.Incidents.Queries.OriginQueries.GetAllOrigins;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Queries.ThreatQueries.GetAllThreats
{
    public class GetAllThreatsQuery : IRequest<List<GetAllThreatsVm>>
    {

    }

    public class GetAllThreatsQueryHandler : IRequestHandler<GetAllThreatsQuery, List<GetAllThreatsVm>>
    {
        private readonly IIncidentsDbContext _context;
        private readonly IMapper _mapper;

        public GetAllThreatsQueryHandler(IIncidentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetAllThreatsVm>> Handle(GetAllThreatsQuery request, CancellationToken cancellationToken)
        {
            var threats = await _context.Threats
                .Select(x => new GetAllThreatsVm
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToListAsync(cancellationToken);

            return threats;
        }
    }
}
