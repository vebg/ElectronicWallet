using System;
using System.Collections.Generic;
namespace ElectronicWallet.Repositories.Model
{
    public class PagedResult<T> where T : class
    {
        public int Count { get; }
        public int Page { get; }
        public int Size { get; }
        public IEnumerable<T> Items { get; set; }

        public PagedResult(int count, int? page, int? size)
        {
            Count = Math.Max(0, count);
            Page = Math.Max(1, page ?? 1);
            Size = Math.Max(1, size ?? count);
        }
    }
}
