using Application.UseCases.Movies.Queries;
using ClearMechanicMovies.Api.Common;
using Microsoft.AspNetCore.Mvc;

namespace ClearMechanicMovies.Api.Controllers
{
    public class MoviesController : CmControllerBase
    {
        /// Retrieves a paginated list of movies based on the specified search criteria.
        /// The search can be performed by title, genre, or actor.
        [HttpGet]
        public async Task<IActionResult> GetPagedMovies([FromQuery] GetMoviesPageQuery pageCommand)
        {
            var result = await Mediator.Send(pageCommand);
            return Ok(result);
        }
    }
}
