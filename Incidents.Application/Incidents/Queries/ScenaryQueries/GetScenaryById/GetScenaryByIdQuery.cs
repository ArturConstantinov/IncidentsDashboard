using AutoMapper;
using Incidents.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Queries.ScenaryQueries.GetScenaryById
{
    public class GetScenaryByIdQuery : IRequest<GetScenaryByIdVm>
    {
        public int Id { get; set; }
    }

    public class GetScenaryByIdQueryHandler : IRequestHandler<GetScenaryByIdQuery, GetScenaryByIdVm>
    {
        private readonly IIncidentsDbContext _context;
        private readonly IMapper _mapper;

        public GetScenaryByIdQueryHandler(IIncidentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetScenaryByIdVm> Handle(GetScenaryByIdQuery request, CancellationToken cancellationToken)
        {
            var scenaryVm = await _context.Scenarios
               .Where(x => x.Id == request.Id)
               .Select(x => new GetScenaryByIdVm
               {
                   Name = x.Name,
               })
               .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<GetScenaryByIdVm>(scenaryVm);
        }
    }
}
