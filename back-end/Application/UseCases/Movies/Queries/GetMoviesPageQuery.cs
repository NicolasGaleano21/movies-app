using Application.Contract;
using Application.Contract.DTOs;
using MediatR;

namespace Application.UseCases.Movies.Queries
{
    public class GetMoviesPageQuery : MovieSearchFilter, IRequest<PageResult<MovieDTO>> { }
}
