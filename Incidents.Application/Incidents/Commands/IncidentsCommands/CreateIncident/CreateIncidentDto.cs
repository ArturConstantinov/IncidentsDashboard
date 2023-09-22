using MediatR;

namespace Incidents.Application.Incidents.Commands.IncidentsCommands.CreateIncident
{
    public class CreateIncidentDto : IRequest
    {
        public int CreatedBy { get; set; }
        public string RequestNr { get; set; }
        //public DateTime OpenDate { get => DateTime.Now; set => OpenDate = value; } // call error stack owerflow
        private DateTime openDate = DateTime.Now;
        public DateTime OpenDate { get => openDate; set => openDate = value; }
        public string Subsystem { get; set; }
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
        public string ThirdParty { get; set; }
        public int ScenaryId { get; set; }
        public int ThreatId { get; set; }
    }
}
