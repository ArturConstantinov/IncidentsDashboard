using AutoMapper;
using AutoMapper.QueryableExtensions;
using Incidents.Application.Common.Interfaces;
using Incidents.Application.Incidents.Queries.OriginQueries.GetAllOrigins;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Queries.ScenaryQueries.GetAllScenarios
{
    public class GetAllScenariosQuery : IRequest<List<GetAllScenariosVm>>
    {

    }

    public class GetAllScenariosQueryHandler : IRequestHandler<GetAllScenariosQuery, List<GetAllScenariosVm>>
    {
        private readonly IIncidentsDbContext _context;
        private readonly IMapper _mapper;

        public GetAllScenariosQueryHandler(IIncidentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetAllScenariosVm>> Handle(GetAllScenariosQuery request, CancellationToken cancellationToken)
        {
            var scenarios = await _context.Scenarios
                .Select(x => new GetAllScenariosVm
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToListAsync(cancellationToken);

            return scenarios;
        }
    }
}
