using Incidents.Application.Common.TableParameters;
using Incidents.Application.Incidents.Queries.RoleQueries.GetAllRoles;
using Incidents.Application.Incidents.Users.Commands.CreateUser;
using Incidents.Application.Incidents.Users.Queries.GetAllUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Incidents.WebUI.Controllers
{
    public class UserController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAllUsers(DataTablesParameters parameters = null!)
        {
            var result = await Mediator.Send(new GetAllUsersQuery(parameters));

            return Json(new
            {
                draw = parameters.Draw,
                recordsFiltered = result.Users.Count(),
                recordsTotal = result.Users.Count(),
                data = result.Users
            });
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetCreateUser(List<string> errors = null!)
        {
            ViewBag.Erroe = errors;
            var roles = await Mediator.Send(new GetAllRolesQuery());
            ViewBag.Roles = roles;

            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserDto userDto)
        {
            userDto.CreatedBy = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var result = await Mediator.Send(new CreateUserCommand { UserDto = userDto });
            return Index();
        }
    }
}
