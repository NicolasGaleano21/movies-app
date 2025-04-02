using Application.Interfaces;
using Application.Interfaces.Services;

namespace Infrastructure.Persistence.Repositories
{
    // The Unit of Work serves as a centralized way to manage transactions and coordinate multiple repositories.
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly MoviesDbContext _context;

        public IMovies Movies { get; }

        public UnitOfWork(MoviesDbContext context, IMovies moviesRepository)
        {
            _context = context;
            Movies = moviesRepository;
        }

        public void Dispose() => _context.Dispose();
    }
}
