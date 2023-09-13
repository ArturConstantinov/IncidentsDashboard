using Incidents.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Incidents.WebUI.Controllers
{
    
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var userName = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var fullName = HttpContext.User.FindFirstValue("FullName");
            var roles = HttpContext.User.FindFirstValue(ClaimTypes.Role);

            ViewBag.UserName = userName;
            ViewBag.Roles = roles;
            ViewBag.FullName = fullName;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}