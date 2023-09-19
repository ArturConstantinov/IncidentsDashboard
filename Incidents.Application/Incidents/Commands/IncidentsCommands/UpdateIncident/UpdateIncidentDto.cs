using MediatR;

namespace Incidents.Application.Incidents.Commands.IncidentsCommands.UpdateIncident
{
    public class UpdateIncidentDto : IRequest
    {
        public int Id { get; set; }
        public int LastModifiedBy { get; set; }
        public string RequestNr { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string Subsystem { get; set; }
        public string Type { get; set; }
        public string ApplicationType { get; set; }
        public string Urgency { get; set; }
        public string SubCause { get; set; }
        public string ProblemSummery { get; set; }
        public string ProblemDescription { get; set; }
        public string Solution { get; set; }

        public int IncidentTypeId { get; set; }
        public int AmbitId { get; set; }
        public int OriginId { get; set; }
        public string ThirdParty { get; set; }
        public int ScenaryId { get; set; }
        public int ThreatId { get; set; }
    }
}
