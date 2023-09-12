using Incidents.Application.Common.Interfaces;
using Incidents.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Incidents.Application.Incidents.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<int>
    {
        public UpdateUserDto UserDto { get; set; }

        //public List<string> UserRoles { get; set; } = new List<string>();
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IIncidentsDbContext _context;

        public UpdateUserCommandHandler(IIncidentsDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserDto.Id, cancellationToken);

            if (user == null)
            {
                return 0;
            }

            string encrypted = "";
            using (SHA256 hash = SHA256.Create())
            {
                encrypted = string.Concat(hash
                    .ComputeHash(Encoding.UTF8.GetBytes(request.UserDto.Password))
                    .Select(item => item.ToString("x2")));
            }

            user.UserName = request.UserDto.UserName;
            user.Password = encrypted;
            user.FullName = request.UserDto.FullName;
            user.Email = request.UserDto.Email;
            user.IsEnabled = request.UserDto.IsEnabled;
            user.LastModified = DateTime.UtcNow;
            user.LastModifiedBy = request.UserDto.LastModifiedBy;
            user.UserRoles = request.UserDto.RolesId.Select(id => new UserRole { RoleId = id }).ToList();

            await _context.SaveChangesAsync(cancellationToken);

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
