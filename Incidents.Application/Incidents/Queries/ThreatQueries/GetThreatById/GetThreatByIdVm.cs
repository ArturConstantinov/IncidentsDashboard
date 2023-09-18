using AutoMapper;
using Incidents.Application.Common.Mappings;
using Incidents.Domain.Entities;

namespace Incidents.Application.Incidents.Queries.ThreatQueries.GetThreatById
{
    public class GetThreatByIdVm : IMapWith<Threat>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Threat, GetThreatByIdVm>()
                .ForMember(x => x.Name, option => option.MapFrom(x => x.Name));
        }
    }
}
