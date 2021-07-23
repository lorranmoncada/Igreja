using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Core.Util
{

    public class PagedInfo
    {
        public Guid Id { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
