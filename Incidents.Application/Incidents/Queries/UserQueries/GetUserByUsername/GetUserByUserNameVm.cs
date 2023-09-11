using AutoMapper;
using Incidents.Application.Common.Mappings;
using Incidents.Application.Incidents.Queries.UserQueries.GetUserById;
using Incidents.Domain.Entities;

namespace Incidents.Application.Incidents.Queries.UserQueries.GetUserByUsername
{
    public class GetUserByUserNameVm : IMapWith<User>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public List<string> UserRoles { get; set; } = new List<string>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetUserByUserNameVm>()
                .ForMember(x => x.Id, option => option.MapFrom(x => x.Id))
                .ForMember(x => x.UserName, option => option.MapFrom(x => x.UserName))
                .ForMember(x => x.Password, option => option.MapFrom(x => x.Password))
                .ForMember(x => x.FullName, option => option.MapFrom(x => x.FullName))
                .ForMember(x => x.Email, option => option.MapFrom(x => x.Email))
                .ForMember(x => x.IsEnabled, option => option.MapFrom(x => x.IsEnabled))
                .ForMember(x => x.IsDeleted, option => option.MapFrom(x => x.IsDeleted));
        }
    }
}
