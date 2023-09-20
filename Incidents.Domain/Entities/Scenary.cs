using Incidents.Domain.Common;

namespace Incidents.Domain.Entities
{
    public class Scenary : BaseEntity
    {
        public string Name { get; set; }
        public List<Incident> Incidents { get; set; }

    }
}
