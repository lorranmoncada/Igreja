using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Core.Util
{
   public class PagenateAux<T> where T : class
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public List<T> Itens { get; set; } = new List<T>();
        public int PageSize { get; set; }
        public bool HasPreviousPage{ get; set; }     
        public bool HasNextPage { get; set; }

        public PagenateAux(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;
            Itens.AddRange(items);
        }
    }
}
