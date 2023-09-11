using AutoMapper;
using Incidents.Application.Common.Interfaces;
using Incidents.Application.Common.TableParameters;
using Incidents.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Incidents.Application.Incidents.Users.Queries.GetAllUsers
{
    //public class GetAllUsersQuery : IRequest<List<GetAllUsersVm>>
    public class GetAllUsersQuery : IRequest<GetAllUsersVm>
    {
        public DataTablesParameters Parameters { get; set; }
        public GetAllUsersQuery(DataTablesParameters parameters)
        {
            Parameters = parameters;
        }

    }

    //public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<GetAllUsersVm>>
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersVm>
    {
        private readonly IIncidentsDbContext _context;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IIncidentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public async Task<List<GetAllUsersVm>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        public async Task<GetAllUsersVm> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            string orderColumn = request.Parameters.Columns[request.Parameters.Order[0].Column].Name;
            string search = request.Parameters.Search.Value ?? "";

            IQueryable<User> usersQuery = _context.Users;

            Expression<Func<User, object>> orderKey = request.Parameters.Columns[request.Parameters.Order[0].Column].Data switch
            {
                "userName" => user => user.UserName,
                "fullName" => user => user.FullName,
                "email" => user => user.Email,
                "isEnabled" => user => user.IsEnabled,
                _ => user => user.Id
            };

            if (request.Parameters.Order[0].Dir == "desc")
            {
                usersQuery = usersQuery.OrderByDescending(orderKey);
            }
            else
            {
                usersQuery = usersQuery.OrderBy(orderKey);
            }

            var users = await usersQuery
                .Include(x => x.UserRoles)
                .Where(x => x.UserName.ToLower().Contains(search)
                || x.FullName.ToLower().Contains(search)
                || x.Email.ToLower().Contains(search)
                || x.IsEnabled.ToString().ToLower().Contains(search)
                || x.UserRoles.Any(ur => ur.Role.Name.ToLower().Contains(search)))
                .Skip(request.Parameters.Start)
                .Take(request.Parameters.Length)
                //.ProjectTo<GetAllUsersDto>(_mapper.ConfigurationProvider)
                .Select(x => new GetAllUsersDto
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    FullName = x.FullName,
                    Email = x.Email,
                    IsEnabled = x.IsEnabled,
                    UserRoles = x.UserRoles.Where(u => u.UserId == x.Id)
                    .Select(ur => ur.Role.Name)
                    .ToList()
                })
                .ToListAsync();


            return new GetAllUsersVm { Users = users };
        }
    }
}
