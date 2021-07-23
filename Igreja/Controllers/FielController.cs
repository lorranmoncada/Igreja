using Igreja.Application.AppplicationService.CadastroFielAppService;
using Igreja.Application.ViewModel;
using Igreja.Core.NotificationMessage;
using Igreja.Domain.Entity;
using Igreja.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Igreja.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class FielController : Controller
    {
        private readonly IFielAppService _fielAppService;
        private readonly DomainNotificationHandler _domainNotificationHandler;
        public FielController(IFielAppService fielAppService,
            DomainNotificationHandler domainNotificationHandler)
        {
            _fielAppService = fielAppService;
            _domainNotificationHandler = domainNotificationHandler;
        }

        [HttpPost]
        [Route("cadastro/fiel")]
        public async Task<IActionResult> Cadastro([FromBody] CadastroFielViewModel cadastroFielViewModel)
        {
            await _fielAppService.CadastroFiel(cadastroFielViewModel);

            if (_domainNotificationHandler.TemNotificacao())
            {
                var erros = _domainNotificationHandler.ListaErros();
                _domainNotificationHandler.LimparNotification();
                return BadRequest(erros);
            }

            return CreatedAtAction(nameof(Cadastro), new { Login = cadastroFielViewModel.Login });
        }

        [HttpGet]
        [Route("fieis")]
        public async Task<IEnumerable<CristaoViewModel>> Fieis()
        {
            return await _fielAppService.AllFieis();
        }

    }
}
