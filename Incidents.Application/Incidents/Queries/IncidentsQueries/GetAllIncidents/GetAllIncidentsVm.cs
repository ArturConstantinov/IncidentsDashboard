namespace Incidents.Application.Incidents.Queries.IncidentsQueries.GetAllIncidents
{
    public class GetAllIncidentsVm
    {
        public int Id { get; set; }
        public string RequestNr { get; set; }
        public string? Subsystem { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string Type { get; set; }
        public string Urgency { get; set; }
    }
}
