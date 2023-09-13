using Incidents.Application.Common.TableParameters;
using Incidents.Application.Incidents.Queries.IncidentsQueries.GetAllIncidents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                data = result.Incidents
            });
        }
    }
}
