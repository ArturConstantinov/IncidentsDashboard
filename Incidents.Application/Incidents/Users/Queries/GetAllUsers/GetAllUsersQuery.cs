using AutoMapper;
using Incidents.Application.Common.Extensions;
using Incidents.Application.Common.Interfaces;
using Incidents.Application.Common.TableParameters;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<GetAllUsersVm>>
    {
        public DataTablesParameters Parameters { get; set; }
        public GetAllUsersQuery(DataTablesParameters parameters)
        {
            Parameters = parameters;
        }

    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<GetAllUsersVm>>
    {
        private readonly IIncidentsDbContext _context;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IIncidentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetAllUsersVm>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var usersList = await _context.Users
                .Include(x => x.UserRoles)
                .Select(x => new GetAllUsersVm
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    FullName = x.FullName,
                    Email = x.Email,
                    IsEnabled = x.IsEnabled,
                    UserRoles = x.UserRoles.Where(u => u.UserId == x.Id)
                            .Select(ur => ur.Role.Name)
                            .ToList()
                })
                .Search(request.Parameters)
                .OrderBy(request.Parameters)
                .Page(request.Parameters)
                .ToListAsync(cancellationToken);

            return usersList;
        }
    }
}
