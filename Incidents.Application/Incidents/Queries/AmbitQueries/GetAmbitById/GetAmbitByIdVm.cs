using AutoMapper;
using Incidents.Application.Common.Mappings;
using Incidents.Domain.Entities;

namespace Incidents.Application.Incidents.Queries.AmbitQueries.GetAmbitById
{
    public class GetAmbitByIdVm : IMapWith<Ambit>
    {
        public string Name { get; set; }
        public int OriginId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Ambit, GetAmbitByIdVm>()
                .ForMember(x => x.Name, option => option.MapFrom(x => x.Name))
                .ForMember(x => x.OriginId, option => option.MapFrom(x => x.OriginId));
        }
    }
}
