using Incidents.Domain.Common;

namespace Incidents.Domain.Entities
{
    public class IncidentType : BaseEntity
    {
        public string Name { get; set; }
        public List<Incident> Incidents { get; set; }
        public List<AmbitsToTypes> AmbitsToTypes { get; set; }

    }
}
