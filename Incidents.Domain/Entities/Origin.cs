using Incidents.Domain.Common;

namespace Incidents.Domain.Entities
{
    public class Origin : BaseEntity
    {
        public string Name { get; set; }

        public List<Incident> Incidents { get; set; }
        public List<OriginsToAmbit> OriginsToAmbits { get; set; }
    }
}
