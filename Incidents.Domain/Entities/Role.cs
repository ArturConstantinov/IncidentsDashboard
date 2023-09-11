using Incidents.Domain.Common;

namespace Incidents.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
