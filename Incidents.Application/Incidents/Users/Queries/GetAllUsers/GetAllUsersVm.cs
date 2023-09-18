namespace Incidents.Application.Incidents.Users.Queries.GetAllUsers
{
    public class GetAllUsersVm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> UserRoles { get; set; }
    }
}
