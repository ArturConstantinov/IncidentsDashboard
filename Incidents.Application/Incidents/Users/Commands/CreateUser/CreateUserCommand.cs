using Incidents.Application.Common.Interfaces;
using Incidents.Application.Incidents.DTO;
using Incidents.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Incidents.Application.Incidents.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public CreateUserDto UserDto { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IIncidentsDbContext _context;

        public CreateUserCommandHandler(IIncidentsDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existing = await _context.Users.AnyAsync(x => x.UserName == request.UserDto.UserName || x.Email == request.UserDto.Email);

            if (request == null || request.UserDto == null || existing == true)
            {
                return 0;
            }

            if (request.UserDto.Password != request.UserDto.ConfirmPassword)
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

            var user = new User
            {
                CreatedBy = request.UserDto.CreatedBy,
                Created = DateTime.UtcNow,
                UserName = request.UserDto.UserName,
                FullName = request.UserDto.FullName,
                Password = encrypted,
                Email = request.UserDto.Email,
                IsEnabled = false,
                UserRoles = request.UserDto.RolesId.Select(id => new UserRole { RoleId = id }).ToList()
            };

            await _context.Users.AddAsync(user, cancellationToken);

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
