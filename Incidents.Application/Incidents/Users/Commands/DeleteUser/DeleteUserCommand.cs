using Incidents.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int LastModifiedBy { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IIncidentsDbContext _context;

        public DeleteUserCommandHandler(IIncidentsDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (user == null)
            {
                return 0;
            }

            user.LastModifiedBy = request.LastModifiedBy;
            user.LastModified = DateTime.UtcNow;
            user.IsEnabled = false;

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
