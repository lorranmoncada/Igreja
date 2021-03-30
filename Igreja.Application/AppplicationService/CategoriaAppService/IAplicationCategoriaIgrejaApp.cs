using Igreja.Domain.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Igreja.Application
{
    public interface IAplicationCategoriaIgrejaApp
    {
        Task<IList<CategoriaViewModel>> ObterCategorias();
    }
}
