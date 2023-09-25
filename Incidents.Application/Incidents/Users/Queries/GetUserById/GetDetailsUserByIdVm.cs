using AutoMapper;
using Incidents.Application.Common.Mappings;
using Incidents.Domain.Entities;

namespace Incidents.Application.Incidents.Queries.UserQueries.GetUserById
{
    public class GetDetailsUserByIdVm : IMapWith<User>
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> UserRoles { get; set; } = new List<string>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetDetailsUserByIdVm>();
        }
    }
}
