using AutoMapper;
using Incidents.Application.Common.Interfaces;
using Incidents.Application.Incidents.Queries.UserQueries.GetUserById;
using Incidents.Application.Incidents.Users.Queries.GetUserById;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Users.Commands.UpdateUser.GetUpdateUserById
{
    public class GetUpdateUserByIdQuery : IRequest<UpdateUserDto>
    {
        public int UserId { get; set; }
    }

    public class GetUpdateUserByIdQueryHandler : IRequestHandler<GetUpdateUserByIdQuery, UpdateUserDto>
    {
        private readonly IIncidentsDbContext _context;

        public GetUpdateUserByIdQueryHandler(IIncidentsDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateUserDto> Handle(GetUpdateUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userVm = await _context.Users
                .Where(x => x.Id == request.UserId)
                .Select(x => new UpdateUserDto
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    FullName = x.FullName,
                    Email = x.Email,
                    IsEnabled = x.IsEnabled,
                    UserRoles = x.UserRoles.Where(u => u.UserId == request.UserId).Select(ur => ur.Role.Id).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            return userVm;
        }
    }
}
