using Incidents.Domain.Common;

namespace Incidents.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
