using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Domain.Abstract.Service
{
    public interface ICategoriaService
    {
        Task<IList<CategoriaViewModel>> ObterCategorias();
    }
}
