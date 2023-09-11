using AutoMapper;
using Incidents.Application.Common.Mappings;
using Incidents.Domain.Entities;

namespace Incidents.Application.Incidents.DTO
{
    public class RoleDto : IMapWith<Role>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Role, RoleDto>()
                .ForMember(x => x.Id, option => option.MapFrom(x => x.Id))
                .ForMember(x => x.Name, option => option.MapFrom(x => x.Name))
                .ForMember(x => x.Description, option => option.MapFrom(x => x.Description));
        }
    }
}
