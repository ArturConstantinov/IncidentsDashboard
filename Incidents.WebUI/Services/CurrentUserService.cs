using Incidents.Application.Common.Interfaces;
using System.Security.Claims;

namespace Incidents.WebUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            if (int.TryParse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                UserId = userId;
            }

            UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            FullName = httpContextAccessor.HttpContext?.User?.FindFirstValue("FullName");
            Email = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
        }
        public int UserId { get; }
        public bool IsAuthenticated { get; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
