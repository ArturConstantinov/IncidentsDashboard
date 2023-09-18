using AutoMapper;
using Incidents.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Queries.OriginQueries.GetOriginById
{
    public class GetOriginByIdQuery : IRequest<GetOriginByIdVm>
    {
        public int Id { get; set; }
    }

    public class GetOriginByIdQueryHandler : IRequestHandler<GetOriginByIdQuery, GetOriginByIdVm>
    {
        private readonly IIncidentsDbContext _context;
        private readonly IMapper _mapper;

        public GetOriginByIdQueryHandler(IIncidentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetOriginByIdVm> Handle(GetOriginByIdQuery request, CancellationToken cancellationToken)
        {
            var originVm = await _context.Origins
                .Where(x => x.Id == request.Id)
                .Select(x => new GetOriginByIdVm
                {
                    Name = x.Name,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<GetOriginByIdVm>(originVm);
        }
    }
}
