using Incidents.Domain.Common;

namespace Incidents.Domain.Entities
{
    public class Threat : BaseEntity
    {
        public string Name { get; set; }
        public List<Incident> Incidents { get; set; }

    }
}
