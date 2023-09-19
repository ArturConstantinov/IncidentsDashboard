using Incidents.Domain.Common;

namespace Incidents.Domain.Entities
{
    public class Ambit : BaseEntity
    {
        public string Name { get; set; }
        public List<OriginsToAmbit> OriginsToAmbits { get; set; }
        public List<Incident> Incidents { get; set; }
        public List<AmbitsToTypes> AmbitsToTypes { get; set; }
    }
}
