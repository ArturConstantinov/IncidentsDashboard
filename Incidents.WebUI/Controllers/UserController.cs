using FluentValidation;
using Incidents.Application.Common.TableParameters;
using Incidents.Application.Incidents.Queries.RoleQueries.GetAllRoles;
using Incidents.Application.Incidents.Users.Commands.CreateUser;
using Incidents.Application.Incidents.Users.Commands.UpdateUser;
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
        [Authorize(Roles = "Administrator")]//????????
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

            var result = await Mediator.Send(new CreateUserCommand { UserDto = userDto });
            return View("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetEditUser(int userId, List<string> errors = null!)
        {
            ViewBag.Error = errors;
            var userDetails = await Mediator.Send(new GetUserByIdQuery { UserId = userId });

            ViewBag.UserDetails = userDetails;
            ViewBag.UserId = userId;

            var roles = await Mediator.Send(new GetAllRolesQuery());
            ViewBag.Roles = roles;

            return View("EditUser");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(int userId, [FromBody] UpdateUserDto userDto)
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

            return await GetEditUser(userId);
        }

    }
}
