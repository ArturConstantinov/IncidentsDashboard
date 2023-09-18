using AutoMapper;
using Incidents.Application.Common.Interfaces;
using Incidents.Application.Incidents.Queries.ScenaryQueries.GetScenaryById;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Queries.ThreatQueries.GetThreatById
{
    public class GetThreatByIdQuery : IRequest<GetThreatByIdVm>
    {
        public int Id { get; set; }
    }

    public class GetThreatByIdQueryHandler : IRequestHandler<GetThreatByIdQuery, GetThreatByIdVm>
    {
        private readonly IIncidentsDbContext _context;
        private readonly IMapper _mapper;

        public GetThreatByIdQueryHandler(IIncidentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetThreatByIdVm> Handle(GetThreatByIdQuery request, CancellationToken cancellationToken)
        {
            var threatVm = await _context.Threats
               .Where(x => x.Id == request.Id)
               .Select(x => new GetThreatByIdVm
               {
                   Name = x.Name,
               })
               .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<GetThreatByIdVm>(threatVm);
        }
    }
}
