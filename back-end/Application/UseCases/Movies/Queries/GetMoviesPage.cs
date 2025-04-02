using Application.Contract;
using Application.Contract.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.UseCases.Movies.Queries
{
    public class GetMoviesPageHandler : IRequestHandler<GetMoviesPageQuery, PageResult<MovieDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMoviesPageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PageResult<MovieDTO>> Handle(
            GetMoviesPageQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _unitOfWork.Movies.GetMoviesPageAsync(request);
        }
    }
}
