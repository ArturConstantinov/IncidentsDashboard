using AutoMapper;
using Incidents.Application.Common.Mappings;
using Incidents.Domain.Entities;

namespace Incidents.Application.Incidents.Queries.OriginQueries.GetOriginById
{
    public class GetOriginByIdVm : IMapWith<Origin>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Origin, GetOriginByIdVm>()
                .ForMember(x => x.Name, option => option.MapFrom(x => x.Name));
        }
    }
}
