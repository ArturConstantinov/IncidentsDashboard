using Incidents.Application.Common.TableParameters;
using Incidents.Application.Incidents.Commands.IncidentsCommands.CreateIncident;
using Incidents.Application.Incidents.Commands.IncidentsCommands.DeleteIncident;
using Incidents.Application.Incidents.Commands.IncidentsCommands.UpdateIncident;
using Incidents.Application.Incidents.Commands.IncidentsCommands.UpdateIncident.GetUpdateIncidentById;
using Incidents.Application.Incidents.Queries.AmbitQueries.GetAllAmbits;
using Incidents.Application.Incidents.Queries.AmbitQueries.GetAmbitById;
using Incidents.Application.Incidents.Queries.IncidentsQueries.GetAllIncidents;
using Incidents.Application.Incidents.Queries.IncidentsQueries.GetIncidentById;
using Incidents.Application.Incidents.Queries.IncidentTypeQueries.GetAllIncedentTypes;
using Incidents.Application.Incidents.Queries.IncidentTypeQueries.GetIncidentTypeById;
using Incidents.Application.Incidents.Queries.OriginQueries.GetAllOrigins;
using Incidents.Application.Incidents.Queries.OriginQueries.GetOriginById;
using Incidents.Application.Incidents.Queries.RoleQueries.GetAllRoles;
using Incidents.Application.Incidents.Queries.ScenaryQueries.GetAllScenarios;
using Incidents.Application.Incidents.Queries.ScenaryQueries.GetScenaryById;
using Incidents.Application.Incidents.Queries.ThreatQueries.GetAllThreats;
using Incidents.Application.Incidents.Queries.ThreatQueries.GetThreatById;
using Incidents.Application.Incidents.Users.Commands.UpdateUser;
using Incidents.Application.Incidents.Users.Queries.GetUserById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Incidents.WebUI.Controllers
{
    public class IncidentController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetAllIncidents(DataTablesParameters parameters = null!)
        {
            var result = await Mediator.Send(new GetAllIncidentsQuery(parameters));

            return Ok(new
            {
                draw = parameters.Draw,
                recordsFiltered = parameters.TotalCount,
                recordsTotal = parameters.TotalCount,
                data = result
            });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> IncidentDetails(int incidentId)
        {
            var incidentDetails = await Mediator.Send(new GetDeatilsIncidentByIdQuery { Id = incidentId });

            return View("IncidentDetails", incidentDetails);
        }

        [HttpPost]
        public async Task<IActionResult> GetAmbits(int originId)
        {
            var result = await Mediator.Send(new GetAllAmbitsQuery { OriginId = originId });

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetIncidentTypes(int ambitId)
        {
            var result = await Mediator.Send(new GetAllIncidentTypesQuery { AmbitId = ambitId });

            return Json(result);
        }

        [HttpGet]
        [Authorize(Roles = "Operator")]
        public async Task<IActionResult> GetCreateIncident(List<string> errors = null!)
        {
            ViewBag.Erroe = errors;

            var origins = await Mediator.Send(new GetAllOriginsQuery { });

            var scenarios = await Mediator.Send(new GetAllScenariosQuery { });
            var threats = await Mediator.Send(new GetAllThreatsQuery { });
            
            ViewBag.Origins = origins;
            ViewBag.Scenarios = scenarios;
            ViewBag.Threats = threats;

            var createIncidentDto = new CreateIncidentDto();

            return View("Create", createIncidentDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateIncident(CreateIncidentDto incidentDto)
        {
            incidentDto.CreatedBy = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var validator = new CreateIncidentDtoValidator();
            var validationResult = validator.Validate(incidentDto);

            if (!validationResult.IsValid)
            {
                var errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }

                return await GetCreateIncident(errors);
            }

            var result = await Mediator.Send(new CreateIncidentCommand { Dto = incidentDto });
            return View("Index");

        }

        [HttpPost]
        public async Task<IActionResult> DeleteIncident(int incidentId)
        {
            await Mediator.Send(new DeleteIncidentCommand { Id = incidentId });

            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Operator")]
        public async Task<IActionResult> GetEditIncident(int incidentId, List<string> errors = null!)
        {
            ViewBag.Error = errors;

            var incidentDetails = await Mediator.Send(new GetUpdateIncidentByIdQuery { Id = incidentId });

            var scenarios = await Mediator.Send(new GetAllScenariosQuery { });
            var threats = await Mediator.Send(new GetAllThreatsQuery { });
            var origins = await Mediator.Send(new GetAllOriginsQuery { });

            if(incidentDetails is null)
            {
                throw new Exception("Incident is Null");
            }
            //ViewBag.IncidentDetails = incidentDetails;
            //ViewBag.IncidentId = incidentId;

            if (incidentDetails.OriginId != null)
            {
                var ambits = await Mediator.Send(new GetAllAmbitsQuery { OriginId = (int)incidentDetails.OriginId });
                ViewBag.Ambits = ambits;

            }

            if (incidentDetails.AmbitId != null)
            {
                var incidentTypes = await Mediator.Send(new GetAllIncidentTypesQuery { AmbitId = (int)incidentDetails.AmbitId });
                ViewBag.IncidentTypes = incidentTypes;

            }

            ViewBag.Origins = origins;

            ViewBag.Scenarios = scenarios;
            ViewBag.Threats = threats;


            return View("EditIncident", incidentDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditIncident(int incidentId, [FromForm] UpdateIncidentDto incidentDto)
        {
            incidentDto.Id = incidentId;
            incidentDto.LastModifiedBy = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var validator = new UpdateIncidentDtoValidator();
            var validationResult = validator.Validate(incidentDto);

            if (!validationResult.IsValid)
            {
                var errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }

                return await GetEditIncident(incidentId, errors);
            }

            await Mediator.Send(new UpdateIncidentCommand { Dto = incidentDto });

            return View("Index");
        }
    }
}
