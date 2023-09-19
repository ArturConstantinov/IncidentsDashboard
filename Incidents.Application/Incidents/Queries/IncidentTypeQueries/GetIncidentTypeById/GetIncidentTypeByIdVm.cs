using AutoMapper;
using Incidents.Application.Common.Mappings;
using Incidents.Domain.Entities;

namespace Incidents.Application.Incidents.Queries.IncidentTypeQueries.GetIncidentTypeById
{
    public class GetIncidentTypeByIdVm : IMapWith<IncidentType>
    {
        public string Name { get; set; }
        public int AmbitId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<IncidentType, GetIncidentTypeByIdVm>()
                .ForMember(x => x.Name, option => option.MapFrom(x => x.Name));
                //.ForMember(x => x.AmbitId, option => option.MapFrom(x => x.AmbitId));
        }
    }
}
