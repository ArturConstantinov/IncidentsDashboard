using Incidents.Application.Common.TableParameters;
using Incidents.Application.Incidents.Queries.RoleQueries.GetAllRoles;
using Incidents.Application.Incidents.Users.Commands.CreateUser;
using Incidents.Application.Incidents.Users.Commands.UpdateUser;
using Incidents.Application.Incidents.Users.Commands.UpdateUser.GetUpdateUserById;
using Incidents.Application.Incidents.Users.Queries.GetAllUsers;
using Incidents.Application.Incidents.Users.Queries.GetUserById;
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
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetAllUsers(DataTablesParameters parameters = null!)
        {
            var result = await Mediator.Send(new GetAllUsersQuery(parameters));

            return Ok(new
            {
                draw = parameters.Draw,
                recordsFiltered = parameters.TotalCount,
                recordsTotal = parameters.TotalCount,
                data = result
            });
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetCreateUser(List<string> errors = null!)
        {
            ViewBag.Erroe = errors;
            var roles = await Mediator.Send(new GetAllRolesQuery());
            ViewBag.Roles = roles;

            var createUserDro = new CreateUserDto();
            return View("Create", createUserDro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUsers(CreateUserDto userDto)
        {
            userDto.CreatedBy = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var validator = new CreateUserDtoValidator();
            var validationResult = validator.Validate(userDto);

            if (!validationResult.IsValid)
            {
                var errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }

                return await GetCreateUser(errors);
            }

            await Mediator.Send(new CreateUserCommand { UserDto = userDto });
            return View("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetEditUser(int userId, List<string> errors = null!)
        {
            ViewBag.Error = errors;
            var userDetails = await Mediator.Send(new GetUpdateUserByIdQuery { UserId = userId });
            var roles = await Mediator.Send(new GetAllRolesQuery());
            ViewBag.Roles = roles;

            return View("EditUser", userDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(int userId, [FromForm] UpdateUserDto userDto)
        {
            userDto.Id = userId;
            userDto.LastModifiedBy = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var validator = new UpdateUserDtoValidator();
            var validationResult = validator.Validate(userDto);

            if (!validationResult.IsValid)
            {
                var errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }

                return await GetEditUser(userId ,errors);
            }

            await Mediator.Send(new UpdateUserCommand { UserDto = userDto });

            return View("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UserDetails(int userId)
        {
            var userDetails = await Mediator.Send(new GetDetailsUserByIdQuery { UserId = userId });
            return View("UserDetails", userDetails);
        }
    }
}
