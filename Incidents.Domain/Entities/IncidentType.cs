using Incidents.Domain.Common;

namespace Incidents.Domain.Entities
{
    public class IncidentType : BaseEntity
    {
        public string Name { get; set; }
        public int AmbitId { get; set; }
        public Ambit Ambit { get; set; }
    }
}
