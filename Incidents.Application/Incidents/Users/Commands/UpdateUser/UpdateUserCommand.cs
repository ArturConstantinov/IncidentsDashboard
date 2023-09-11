using Incidents.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Incidents.Application.Incidents.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int LastModifiedBy { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsEnabled { get; set; }
        public string RoleName { get; set; }

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
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (user == null)
            {
                return 0;
            }

            string encrypted = "";
            using (SHA256 hash = SHA256.Create())
            {
                encrypted = string.Concat(hash
                    .ComputeHash(Encoding.UTF8.GetBytes(request.Password))
                    .Select(item => item.ToString("x2")));
            }

            user.UserName = request.UserName;
            user.Password = encrypted; // update password
            user.FullName = request.FullName;
            user.Email = request.Email;
            user.IsEnabled = request.IsEnabled;
            user.LastModified = DateTime.UtcNow;
            user.LastModifiedBy = request.LastModifiedBy;

            await _context.SaveChangesAsync(cancellationToken);

            // updateUserRole   need to correct!!!!!!!!!!!
            //var userRole = await _context.UserRoles
            //    .Where(x => x.UserId == request.Id)
            //    .ToListAsync(cancellationToken);

            //if (userRole == null)
            //{
            //    return 0;
            //}

            //userRole.RoleId = await _context.Roles
            //        .Where(x => x.Name.ToLower() == request.RoleName.ToLower())
            //        .Select(x => x.Id)
            //        .FirstOrDefaultAsync();

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
