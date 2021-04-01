﻿using Igreja.Application.AppplicationService.CadastroProprietarioAppService;
using Igreja.Core.Comunication;
using Igreja.Core.DomainObjects;
using Igreja.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Igreja.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class CadastroProprietariocontroller : Controller
    {
        private readonly ICadastroProprietarioAppService _cadastroProprietarioAppService;
        private readonly DomainNotificationHandler _domainNotificationHandler;
        public CadastroProprietariocontroller(ICadastroProprietarioAppService cadastroProprietarioAppService,
            DomainNotificationHandler domainNotificationHandler)
        {
            _cadastroProprietarioAppService = cadastroProprietarioAppService;
            _domainNotificationHandler = domainNotificationHandler;
        }

        [HttpPost]
        [Route("cadastro/proprietario")]
        public async Task<IActionResult> CadastroProprietario([FromBody] CadastroProprietarioViewModel cadastroProprietarioViewModel)
        {
            await _cadastroProprietarioAppService.CadastroUsuario(cadastroProprietarioViewModel);

            
            if (_domainNotificationHandler.TemNotificacao())
            {
                var erros = _domainNotificationHandler.ListaErros();
                _domainNotificationHandler.LimparNotification();
               return BadRequest(erros);
            }

            return CreatedAtAction(nameof(CadastroProprietario), new { Login = cadastroProprietarioViewModel.Login });
        }
    }
}