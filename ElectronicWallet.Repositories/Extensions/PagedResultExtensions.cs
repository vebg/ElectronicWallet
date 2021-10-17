using ElectronicWallet.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicWallet.Repositories.Extensions
{
    public static class PagedResultExtensions
    {
        public static PagedResult<T> ToPagedResult<T>(this IQueryable<T> query, int? page = null, int? size = null) where T : class
        {
            var result = new PagedResult<T>(query.Count(), page, size);

            result.Items = query.Skip((result.Page - 1) * result.Size).Take(result.Size).ToList();

            return result;
        }

        public static async Task<PagedResult<T>> ToPagedResultAsync<T>(this IQueryable<T> query, int? page = null, int? size = null) where T : class
        {
            var result = new PagedResult<T>(await query.CountAsync(), page, size);

            result.Items = await query.Skip((result.Page - 1) * result.Size).Take(result.Size).ToListAsync();

            return result;
        }
    }
}
