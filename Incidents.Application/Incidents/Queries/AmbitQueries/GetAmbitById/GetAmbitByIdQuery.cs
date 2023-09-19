using AutoMapper;
using Incidents.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Queries.AmbitQueries.GetAmbitById
{
    public class GetAmbitByIdQuery :IRequest<GetAmbitByIdVm>
    {
        public int Id { get; set; }
    }

    public class GetAmbitByIdQueryHandler : IRequestHandler<GetAmbitByIdQuery, GetAmbitByIdVm>
    {
        private readonly IIncidentsDbContext _context;
        private readonly IMapper _mapper;

        public GetAmbitByIdQueryHandler(IIncidentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetAmbitByIdVm> Handle(GetAmbitByIdQuery request, CancellationToken cancellationToken)
        {
            var ambitVm = await _context.Ambits
                .Where(x => x.Id == request.Id)
                .Select(x => new GetAmbitByIdVm
                {
                    Name = x.Name,
                    //OriginId = x.OriginId
                })
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<GetAmbitByIdVm>(ambitVm);
        }
    }
}
