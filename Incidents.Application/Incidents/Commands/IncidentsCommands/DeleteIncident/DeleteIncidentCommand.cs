using Incidents.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Commands.IncidentsCommands.DeleteIncident
{
    public class DeleteIncidentCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteIncidentCommandHandler : IRequestHandler<DeleteIncidentCommand, int>
    {
        private readonly IIncidentsDbContext _context;

        public DeleteIncidentCommandHandler(IIncidentsDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteIncidentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Incidents.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity != null)
            {
                entity.IsDeleted = true;
            }

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
