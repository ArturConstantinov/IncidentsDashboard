using Incidents.Domain.Common;

namespace Incidents.Domain.Entities
{
    public class Ambit : BaseEntity
    {
        public string Name { get; set; }
        public int OriginId { get; set; }
        public Origin Origin { get; set; }
    }
}
