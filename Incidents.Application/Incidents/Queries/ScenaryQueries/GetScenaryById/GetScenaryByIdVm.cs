using AutoMapper;
using Incidents.Application.Common.Mappings;
using Incidents.Domain.Entities;

namespace Incidents.Application.Incidents.Queries.ScenaryQueries.GetScenaryById
{
    public class GetScenaryByIdVm : IMapWith<Scenary>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Scenary, GetScenaryByIdVm>()
                .ForMember(x => x.Name, option => option.MapFrom(x => x.Name));
        }
    }
}
