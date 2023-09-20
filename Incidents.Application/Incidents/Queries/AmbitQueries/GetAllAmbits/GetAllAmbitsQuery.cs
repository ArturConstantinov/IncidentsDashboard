using AutoMapper;
using AutoMapper.QueryableExtensions;
using Incidents.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Queries.AmbitQueries.GetAllAmbits
{
    public class GetAllAmbitsQuery : IRequest<List<GetAllAmbitsVm>>
    {
        public int OriginId { get; set; }
    }

    public class GetAllAmbitsQueryHandler : IRequestHandler<GetAllAmbitsQuery, List<GetAllAmbitsVm>>
    {
        private readonly IIncidentsDbContext _context;
        private readonly IMapper _mapper;

        public GetAllAmbitsQueryHandler(IIncidentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetAllAmbitsVm>> Handle(GetAllAmbitsQuery request, CancellationToken cancellationToken)
        {
            var ambits = await _context.Ambits
                .Include(x => x.OriginsToAmbits)
                .Where(x => x.OriginsToAmbits.Any(a => a.AmbitId == x.Id && a.OriginId == request.OriginId))
                .Select(x => new GetAllAmbitsVm
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToListAsync(cancellationToken);

            return ambits;
        }
    }
}
