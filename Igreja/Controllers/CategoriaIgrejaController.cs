using Igreja.Application;
using Igreja.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Igreja.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class CategoriaIgrejaController : Controller
    {
        private readonly IAplicationCategoriaIgrejaAppService _aplicationCategoriaIgrejaAp;

        public CategoriaIgrejaController(IAplicationCategoriaIgrejaAppService aplicationCategoriaIgrejaAp)
        {
            _aplicationCategoriaIgrejaAp = aplicationCategoriaIgrejaAp;
        }

        [HttpGet]
        [Route("categoria")]
        public async Task<IList<CategoriaViewModel>> GetAll()
        {
            return await _aplicationCategoriaIgrejaAp.ObterCategorias();
        }
    }
}
