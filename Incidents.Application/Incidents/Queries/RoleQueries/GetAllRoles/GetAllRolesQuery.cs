using Incidents.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Queries.RoleQueries.GetAllRoles
{
    public class GetAllRolesQuery : IRequest<List<RoleVm>>
    {
    }

    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<RoleVm>>
    {
        private readonly IIncidentsDbContext _context;

        public GetAllRolesQueryHandler(IIncidentsDbContext context)
        {
            _context = context;
        }

        public Task<List<RoleVm>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var result = _context.Roles
                .Select(x => new RoleVm
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                })
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
