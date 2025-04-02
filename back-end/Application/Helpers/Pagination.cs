using Application.Contract;
using Microsoft.EntityFrameworkCore;

namespace Application.Helpers
{
    public static class PaginationHelper
    {
        public static async Task<PageResult<T>> GetPageAsync<T>(PageRequest pageRequest, IQueryable<T> query) where T : class
        {
            int totalRows = await query.CountAsync().ConfigureAwait(false);

            var items = await query
                .Skip((pageRequest.PageNumber - 1) * pageRequest.PageSize)
                .Take(pageRequest.PageSize)
                .ToListAsync()
                .ConfigureAwait(false);

            return new PageResult<T>(items, totalRows);
        }
    }
}
