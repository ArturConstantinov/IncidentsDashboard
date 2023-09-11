namespace Incidents.Application.Incidents.Users.Commands.CreateUser
{
    public class CreateUserDto
    {
        public int CreatedBy { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<int> RolesId { get; set; }
    }
}
