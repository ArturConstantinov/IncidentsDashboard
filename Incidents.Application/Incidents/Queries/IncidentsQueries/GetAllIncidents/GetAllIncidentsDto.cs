using AutoMapper;
using Incidents.Application.Common.Mappings;
using Incidents.Domain.Entities;

namespace Incidents.Application.Incidents.Queries.IncidentsQueries.GetAllIncidents
{
    public class GetAllIncidentsDto : IMapWith<Incident>
    {
        public int Id { get; set; }
        public string RequestNr { get; set; }
        public string? Subsystem { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string Type { get; set; }
        public string Urgency { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Incident, GetAllIncidentsDto>()
                .ForMember(x => x.Id, option => option.MapFrom(x => x.Id))
                .ForMember(x => x.RequestNr, option => option.MapFrom(x => x.RequestNr))
                .ForMember(x => x.Subsystem, option => option.MapFrom(x => x.Subsystem))
                .ForMember(x => x.OpenDate, option => option.MapFrom(x => x.OpenDate))
                .ForMember(x => x.CloseDate, option => option.MapFrom(x => x.CloseDate))
                .ForMember(x => x.Type, option => option.MapFrom(x => x.Type))
                .ForMember(x => x.Urgency, option => option.MapFrom(x => x.Urgency));
        }
    }
}
