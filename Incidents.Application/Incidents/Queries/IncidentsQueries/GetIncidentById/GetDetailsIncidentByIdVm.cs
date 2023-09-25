using AutoMapper;
using Incidents.Application.Common.Mappings;
using Incidents.Domain.Entities;

namespace Incidents.Application.Incidents.Queries.IncidentsQueries.GetIncidentById
{
    public class GetDetailsIncidentByIdVm : IMapWith<Incident>
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
        public string? IncidentType { get; set; }
        public string? Ambit { get; set; }
        public string? Origin { get; set; }
        public string ThirdParty { get; set; }
        public string Scenary { get; set; }
        public string Threat { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Incident, GetDetailsIncidentByIdVm>();
        }
    }
}
