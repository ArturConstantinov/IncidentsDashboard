using Incidents.Application.Common.Interfaces;
using Incidents.Application.Incidents.DTO;
using Incidents.Domain.Entities;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace Incidents.Application.Incidents.Commands.UserComands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public CreateUserDto UserDto { get; set; }
        //public int CreatedBy { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
        //public string FullName { get; set; }
        //public string Email { get; set; }
        //public List<int> RolesId { get; set; }

        //public List<RoleDto> AllRoles { get; set; }
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
            if (request == null || request.UserDto == null)
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
                Password = encrypted,
                Email = request.UserDto.Email,
                IsEnabled = false,
                IsDeleted = false,
                UserRoles = request.UserDto.RolesId.Select(id => new UserRole { RoleId = id }).ToList()
            };

            await _context.Users.AddAsync(user, cancellationToken);

            //var userRole = new UserRole
            //{
            //    UserId = user.Id,
            //    RoleId = await _context.Roles
            //        .Where(x => x.Name.ToLower() == "user")
            //        .Select(x => x.Id)
            //        .FirstOrDefaultAsync()
            //};

            //await _context.UserRoles.AddAsync(userRole, cancellationToken);

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
