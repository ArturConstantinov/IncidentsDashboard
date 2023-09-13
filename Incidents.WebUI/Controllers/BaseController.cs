using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Incidents.WebUI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        private IMediator _mediator = null!;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
