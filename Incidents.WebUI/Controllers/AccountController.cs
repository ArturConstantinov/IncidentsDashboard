using Incidents.Application.Incidents.Users.Queries.GetUserByUserName;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Incidents.WebUI.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string userName, string password)
        {
            try
            {
                var userVm = await Mediator.Send(new GetUserByUserNameQuery
                {
                    UserName = userName,
                    Password = password
                });

                if (userVm == null || !userVm.IsEnabled) 
                {
                    ModelState.TryAddModelError("IncorrectLogin", "Non existen or delited user");
                    return View("Login");
                }
                else
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userVm.Id.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Name, userVm.UserName));
                    identity.AddClaim(new Claim("FullName", userVm.FullName));
                    identity.AddClaim(new Claim(ClaimTypes.Email, userVm.Email));

                    foreach(var role in userVm.UserRoles)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, role));
                    }

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return LocalRedirect("/Home");
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.StackTrace);
                return View("Login");
            }
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
