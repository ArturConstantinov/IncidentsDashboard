namespace Incidents.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        bool IsAuthenticated { get; }
        string UserName { get; set; }
        string FullName { get; set; }
        string Email { get; set; }
    }
}
