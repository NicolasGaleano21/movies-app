using Application.Interfaces.Services;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMovies Movies { get; }
    }
}
