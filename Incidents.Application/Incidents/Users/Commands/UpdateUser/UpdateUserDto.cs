using MediatR;

namespace Incidents.Application.Incidents.Users.Commands.UpdateUser
{
    public class UpdateUserDto : IRequest
    {
        public int Id { get; set; }
        public int LastModifiedBy { get; set; }
        public string UserName { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsEnabled { get; set; }
        public List<int> UserRoles { get; set; }
    }
}
