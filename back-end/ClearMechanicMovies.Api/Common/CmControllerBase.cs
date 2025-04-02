using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClearMechanicMovies.Api.Common
{
    // Base controller class that other controllers can inherit from.
    // It provides common functionality to avoid code duplication.
    // TODO: Implement authentication mechanism and user claiming
    [Route("api/[controller]")]
    [ApiController]
    public class CmControllerBase : ControllerBase
    {
        private ISender? _mediator;
        protected ISender Mediator =>
            _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
