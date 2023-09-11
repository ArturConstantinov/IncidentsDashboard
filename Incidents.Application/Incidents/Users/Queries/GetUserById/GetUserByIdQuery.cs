using AutoMapper;
using Incidents.Application.Common.Interfaces;
using Incidents.Application.Incidents.Queries.UserQueries.GetUserById;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdVm>
    {
        public int UserId { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdVm>
    {
        private readonly IIncidentsDbContext _context;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IIncidentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetUserByIdVm> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userVm = await _context.Users
                .Where(x => x.Id == request.UserId)
                .Select(x => new GetUserByIdVm
                {
                    UserName = x.UserName,
                    FullName = x.FullName,
                    Email = x.Email,
                    IsEnabled = x.IsEnabled,
                    UserRoles = x.UserRoles.Where(u => u.UserId == request.UserId).Select(ur => ur.Role.Name).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<GetUserByIdVm>(userVm);
            //return userVm;
        }
    }
}
