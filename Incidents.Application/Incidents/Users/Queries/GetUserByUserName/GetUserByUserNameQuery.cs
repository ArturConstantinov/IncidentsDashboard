using AutoMapper;
using Incidents.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Incidents.Application.Incidents.Users.Queries.GetUserByUserName
{
    public class GetUserByUserNameQuery : IRequest<GetUserByUserNameVm>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, GetUserByUserNameVm>
    {
        private readonly IIncidentsDbContext _context;
        private readonly IMapper _mapper;

        public GetUserByUserNameQueryHandler(IIncidentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetUserByUserNameVm> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            if (request.UserName == null || request.UserName == string.Empty || request.Password == null || request.Password == string.Empty)
            {
                throw new Exception();
            }

            string encrypted = "";
            using (SHA256 hash = SHA256.Create())
            {
                encrypted = string.Concat(hash
                    .ComputeHash(Encoding.UTF8.GetBytes(request.Password))
                    .Select(item => item.ToString("x2")));
            }

            var userVm = await _context.Users
                .Where(x => x.UserName.ToLower() == request.UserName
                .ToLower() && x.IsEnabled && x.Password == encrypted)
                .Select(x => new GetUserByUserNameVm
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Email = x.Email,
                    FullName = x.FullName,
                    IsEnabled = x.IsEnabled,
                    UserRoles = x.UserRoles.Where(u => u.UserId == x.Id).Select(ur => ur.Role.Name).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<GetUserByUserNameVm>(userVm);
        }
    }
}
