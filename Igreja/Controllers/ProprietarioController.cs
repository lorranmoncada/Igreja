using Igreja.Application.AppplicationService.ProprietarioAppService;
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
    public class ProprietarioController : Controller
    {
        private readonly IProprietarioAppService _proprietarioAppService;
        private readonly DomainNotificationHandler _domainNotificationHandler;
        public ProprietarioController(IProprietarioAppService proprietarioAppService,
            DomainNotificationHandler domainNotificationHandler)
        {
            _proprietarioAppService = proprietarioAppService;
            _domainNotificationHandler = domainNotificationHandler;
        }

        [HttpPost]
        [Route("cadastro/proprietario")]
        public async Task<IActionResult> CadastroProprietario([FromBody] CadastroProprietarioViewModel cadastroProprietarioViewModel)
        {
            await _proprietarioAppService.CadastroUsuario(cadastroProprietarioViewModel);

            
            if (_domainNotificationHandler.TemNotificacao())
            {
                var erros = _domainNotificationHandler.ListaErros();
                _domainNotificationHandler.LimparNotification();
               return BadRequest(erros);
            }

            return NoContent();
        }

        [HttpGet]
        [Route("proprietarios")]
        public async Task<IEnumerable<LoginProprietario>> AllProprietarios()
        {
            return await _proprietarioAppService.Proprietarios();
        }
    }
}