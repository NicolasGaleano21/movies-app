using System.Linq.Expressions;
using Application.Contract;
using Application.Contract.DTOs;
using Application.Helpers;
using Application.Interfaces.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class MoviesRepository : IMovies
    {
        private readonly MoviesDbContext _context;
        private readonly IMapper _mapper;

        public MoviesRepository(MoviesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PageResult<MovieDTO>> GetMoviesPageAsync(MovieSearchFilter filter)
        {
            var query = _context
                .Movies.Include(m => m.MovieActors)
                .ThenInclude(ma => ma.Actor)
                .Include(m => m.MovieGenres)
                .ThenInclude(mg => mg.Genre)
                .AsQueryable();

            // Apply search filter if provided
            if (
                !string.IsNullOrEmpty(filter.SearchValue)
                && !string.IsNullOrEmpty(filter.SearchType.ToString())
            )
            {
                query = query.Where(SearchByFilterType(filter));
            }

            var pageRequest = new PageRequest
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
            };
            var mappedQuery = query.ProjectTo<MovieDTO>(_mapper.ConfigurationProvider);
            return await PaginationHelper.GetPageAsync(pageRequest, mappedQuery);
        }

        // Filter expression based on the search type
        private static Expression<Func<Movie, bool>> SearchByFilterType(MovieSearchFilter filter)
        {
            return filter.SearchType switch
            {
                MovieSearchType.Genre => m =>
                    m.MovieGenres.Any(mg => mg.Genre!.Description.Contains(filter.SearchValue!)),

                MovieSearchType.Actor => m =>
                    m.MovieActors.Any(ma => ma.Actor!.Name.Contains(filter.SearchValue!)),

                _ => m => m.Title.Contains(filter.SearchValue!),
            };
        }
    }
}
