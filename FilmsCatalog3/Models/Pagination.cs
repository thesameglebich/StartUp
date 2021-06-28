using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class Pagination<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public Pagination(List<T> items, int count, int pageIndex, int pagesize)
        {
            this.PageIndex = pageIndex;
            this.TotalPages = (int)Math.Ceiling(count / (double)pagesize);
            this.AddRange(items);
        }

        public bool PreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        
        public bool NextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        public static async Task<Pagination<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new Pagination<T>(items, count, pageIndex, pageSize);
        }
    }
}
