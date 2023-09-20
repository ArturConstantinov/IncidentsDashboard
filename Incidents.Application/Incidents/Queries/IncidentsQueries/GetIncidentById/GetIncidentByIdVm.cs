using AutoMapper;
using Incidents.Application.Common.Mappings;
using Incidents.Domain.Entities;

namespace Incidents.Application.Incidents.Queries.IncidentsQueries.GetIncidentById
{
    public class GetIncidentByIdVm : IMapWith<Incident>
    {
        public string RequestNr { get; set; }
        public string Subsystem { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string Type { get; set; }
        public string ApplicationType { get; set; }
        public string Urgency { get; set; }
        public string SubCause { get; set; }
        public string ProblemSummery { get; set; }
        public string ProblemDescription { get; set; }
        public string Solution { get; set; }
        public int? IncidentTypeId { get; set; }
        public int? AmbitId { get; set; }
        public int? OriginId { get; set; }
        public int ScenaryId { get; set; }
        public int ThreatId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Incident, GetIncidentByIdVm>()
                .ForMember(x => x.RequestNr, option => option.MapFrom(x => x.RequestNr))
                .ForMember(x => x.Subsystem, option => option.MapFrom(x => x.Subsystem))
                .ForMember(x => x.OpenDate, option => option.MapFrom(x => x.OpenDate))
                .ForMember(x => x.CloseDate, option => option.MapFrom(x => x.CloseDate))
                .ForMember(x => x.Type, option => option.MapFrom(x => x.Type))
                .ForMember(x => x.ApplicationType, option => option.MapFrom(x => x.ApplicationType))
                .ForMember(x => x.Urgency, option => option.MapFrom(x => x.Urgency))
                .ForMember(x => x.SubCause, option => option.MapFrom(x => x.SubCause))
                .ForMember(x => x.ProblemSummery, option => option.MapFrom(x => x.ProblemSummery))
                .ForMember(x => x.ProblemDescription, option => option.MapFrom(x => x.ProblemDescription))
                .ForMember(x => x.Solution, option => option.MapFrom(x => x.Solution))
                .ForMember(x => x.IncidentTypeId, option => option.MapFrom(x => x.IncidentTypeId))
                .ForMember(x => x.AmbitId, option => option.MapFrom(x => x.AmbitId))
                .ForMember(x => x.OriginId, option => option.MapFrom(x => x.OriginId))
                .ForMember(x => x.ScenaryId, option => option.MapFrom(x => x.ScenaryId))
                .ForMember(x => x.ThreatId, option => option.MapFrom(x => x.ThreatId));


        }
    }
}
