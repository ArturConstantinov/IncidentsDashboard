using AutoMapper;
using Incidents.Application.Common.Interfaces;
using Incidents.Application.Incidents.Queries.UserQueries.GetUserById;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Users.Queries.GetUserById
{
    public class GetDetailsUserByIdQuery : IRequest<GetDetailsUserByIdVm>
    {
        public int UserId { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetDetailsUserByIdQuery, GetDetailsUserByIdVm>
    {
        private readonly IIncidentsDbContext _context;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IIncidentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetDetailsUserByIdVm> Handle(GetDetailsUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userVm = await _context.Users
                .Where(x => x.Id == request.UserId)
                .Select(x => new GetDetailsUserByIdVm
                {
                    UserName = x.UserName,
                    FullName = x.FullName,
                    Email = x.Email,
                    IsEnabled = x.IsEnabled,
                    UserRoles = x.UserRoles.Where(u => u.UserId == x.Id)
                            .Select(ur => ur.Role.Name)
                            .ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<GetDetailsUserByIdVm>(userVm);
        }
    }
}
