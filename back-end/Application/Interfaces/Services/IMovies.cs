using Application.Contract;
using Application.Contract.DTOs;

namespace Application.Interfaces.Services
{
    public interface IMovies
    {
        Task<PageResult<MovieDTO>> GetMoviesPageAsync(MovieSearchFilter filter);
    }
}
