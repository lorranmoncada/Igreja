using Igreja.Application.AppplicationService.CadastroProprietarioAppService;
using Igreja.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Igreja.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class CadastroProprietariocontroller : Controller
    {
        private readonly ICadastroProprietarioAppService _cadastroProprietarioAppService;
        public CadastroProprietariocontroller(ICadastroProprietarioAppService cadastroProprietarioAppService)
        {
            _cadastroProprietarioAppService = cadastroProprietarioAppService;
        }

        [HttpPost]
        [Route("cadastro/proprietario")]
        public Task<bool> CadastroProprietario([FromBody] CadastroProprietarioViewModel cadastroProprietarioViewModel)
        {
            return _cadastroProprietarioAppService.CadastroUsuario(cadastroProprietarioViewModel);
        }
    }
}
