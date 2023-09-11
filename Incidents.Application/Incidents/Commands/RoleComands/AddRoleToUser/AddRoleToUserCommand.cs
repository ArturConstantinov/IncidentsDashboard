using Incidents.Application.Common.Interfaces;
using Incidents.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Commands.RoleComands.AddRoleToUser
{
    public class AddRoleToUserCommand : IRequest<int>
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }

    public class AddRoleToUserCommandHandler : IRequestHandler<AddRoleToUserCommand, int>
    {
        private readonly IIncidentsDbContext _context;

        public AddRoleToUserCommandHandler(IIncidentsDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return 0;
            }

            if (await _context.Users.Where(x => x.Id == request.UserId).Include(x => x.UserRoles)
                .Where(x => x.UserRoles
                .Any(x => x.RoleId == request.RoleId))
                .AnyAsync(cancellationToken))
            {
                return -1;
            }

            var userRole = new UserRole
            {
                Role = await _context.Roles.Where(x => x.Id == request.RoleId).FirstOrDefaultAsync(cancellationToken),
                User = await _context.Users.Where(x => x.Id == request.UserId).FirstOrDefaultAsync(cancellationToken)
            };

            await _context.UserRoles.AddAsync(userRole, cancellationToken);

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
