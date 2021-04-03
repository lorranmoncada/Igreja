using Igreja.Application.AppplicationService.CadastroFielAppService;
using Igreja.Core.Comunication;
using Igreja.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Igreja.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class FielController : Controller
    {
        private readonly ICadastrofielAppService _cadastrofielAppService;
        private readonly DomainNotificationHandler _domainNotificationHandler;
        public FielController(ICadastrofielAppService cadastrofielAppService,
            DomainNotificationHandler domainNotificationHandler)
        {
            _cadastrofielAppService = cadastrofielAppService;
            _domainNotificationHandler = domainNotificationHandler;
        }

        [HttpPost]
        [Route("cadastro/fiel")]
        public async Task<IActionResult> CadastroFiel([FromBody] CadastroFielViewModel cadastroFielViewModel)
        {
            await _cadastrofielAppService.CadastroFiel(cadastroFielViewModel);

            if (_domainNotificationHandler.TemNotificacao())
            {
                var erros = _domainNotificationHandler.ListaErros();
                _domainNotificationHandler.LimparNotification();
                return BadRequest(erros);
            }

            return CreatedAtAction(nameof(CadastroFiel), new { Login = cadastroFielViewModel.Login });
        }
    }
}
