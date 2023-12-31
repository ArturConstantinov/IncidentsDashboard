﻿using Incidents.Application.Common.TableParameters;
using Incidents.Application.Incidents.Queries.RoleQueries.GetAllRoles;
using Incidents.Application.Incidents.Users.Commands.CreateUser;
using Incidents.Application.Incidents.Users.Commands.UpdateUser;
using Incidents.Application.Incidents.Users.Commands.UpdateUser.GetUpdateUserById;
using Incidents.Application.Incidents.Users.Queries.GetAllUsers;
using Incidents.Application.Incidents.Users.Queries.GetUserById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        private async Task<IEnumerable<SelectListItem>> GetRolesSelectListAsync()
        {
            var rolesListVm = await Mediator.Send(new GetAllRolesQuery());

            return rolesListVm.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = false,
            });
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetCreateUser(List<string> errors = null!)
        {
            ViewBag.Erroe = errors;
            ViewBag.Roles = await GetRolesSelectListAsync();



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

            var result = await Mediator.Send(new CreateUserCommand { UserDto = userDto });

            if (result == 0)
            {
                ModelState.AddModelError("", "User Name or Email alredy exist");
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetEditUser(int userId, List<string> errors = null!)
        {
            ViewBag.Error = errors;
            var userDetails = await Mediator.Send(new GetUpdateUserByIdQuery { UserId = userId });
            ViewBag.Roles = await GetRolesSelectListAsync();

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

            var result = await Mediator.Send(new UpdateUserCommand { UserDto = userDto });

            if (result != -1)
            {
                return Ok();
            }

            ModelState.AddModelError("", "User Name or Email alredy exist");
            return BadRequest(ModelState);
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
