using Incidents.Application.Common.TableParameters;
using Incidents.Application.Incidents.Commands.IncidentsCommands.CreateIncident;
using Incidents.Application.Incidents.Commands.IncidentsCommands.DeleteIncident;
using Incidents.Application.Incidents.Queries.AmbitQueries.GetAllAmbits;
using Incidents.Application.Incidents.Queries.AmbitQueries.GetAmbitById;
using Incidents.Application.Incidents.Queries.IncidentsQueries.GetAllIncidents;
using Incidents.Application.Incidents.Queries.IncidentsQueries.GetIncidentById;
using Incidents.Application.Incidents.Queries.IncidentTypeQueries.GetAllIncedentTypes;
using Incidents.Application.Incidents.Queries.IncidentTypeQueries.GetIncidentTypeById;
using Incidents.Application.Incidents.Queries.OriginQueries.GetAllOrigins;
using Incidents.Application.Incidents.Queries.OriginQueries.GetOriginById;
using Incidents.Application.Incidents.Queries.ScenaryQueries.GetAllScenarios;
using Incidents.Application.Incidents.Queries.ScenaryQueries.GetScenaryById;
using Incidents.Application.Incidents.Queries.ThreatQueries.GetAllThreats;
using Incidents.Application.Incidents.Queries.ThreatQueries.GetThreatById;
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
            var incidentDetails = await Mediator.Send(new GetIncidentByIdQuery { Id = incidentId });
            

            ViewBag.IncidentDetails = incidentDetails;
            ViewBag.IncidentId = incidentId;

            if (incidentDetails.IncidentTypeId != null) 
            {
                var incidentType = await Mediator.Send(new GetIncidentTypeByIdQuery { Id = (int)incidentDetails.IncidentTypeId });
                ViewBag.IncidentType = incidentType;
            }

            if (incidentDetails.AmbitId != null)
            {
                var ambit = await Mediator.Send(new GetAmbitByIdQuery { Id = (int)incidentDetails.AmbitId });
                ViewBag.Ambit = ambit;
            }

            if (incidentDetails.OriginId != null)
            {
                var origin = await Mediator.Send(new GetOriginByIdQuery { Id = (int)incidentDetails.OriginId });
                ViewBag.Origin = origin;
            }

            if(incidentDetails.ScenaryId != null)
            {
                var scenary = await Mediator.Send(new GetScenaryByIdQuery { Id = (int)incidentDetails.ScenaryId });
                ViewBag.Scenary = scenary;
            }

            if (incidentDetails.ThreatId != null)
            {
                var threat = await Mediator.Send(new GetThreatByIdQuery { Id = (int)incidentDetails.ThreatId });
                ViewBag.Threat = threat;
            }

            return View("IncidentDetails");
        }

        [HttpPost]
        public async Task<IActionResult> GetAmbits(int originId)
        {
            var result = await Mediator.Send(new GetAllAmbitsQuery { OriginId = originId });

            return Json(result);
        }

        [HttpGet]
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

            return View("Create");
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
    }
}
