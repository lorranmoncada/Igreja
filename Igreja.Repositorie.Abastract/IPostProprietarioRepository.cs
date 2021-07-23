using Igreja.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Repositorie.Abastract
{
    public interface IPostProprietarioRepository<T> where T : BaseEntity 
    {
        IQueryable<T> PostsByUser(Guid Id);
    }
}
