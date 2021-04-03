using Igreja.Domain.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Igreja.Application
{
    public interface IAplicationCategoriaIgrejaAppService
    {
        Task<IList<CategoriaViewModel>> ObterCategorias();
    }
}
