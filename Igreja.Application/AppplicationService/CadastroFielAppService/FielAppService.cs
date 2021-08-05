using AutoMapper;
using Igreja.Application.ViewModel;
using Igreja.Core.Communication;
using Igreja.Core.Communication.MediaTR;
using Igreja.Core.Data;
using Igreja.Core.NotificationMessage;
using Igreja.Domain.Entity;
using Igreja.Domain.Events.FielEvents.CadastroEvent;
using Igreja.Domain.Interface;
using Igreja.Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Igreja.Application.AppplicationService.CadastroFielAppService
{
    public class FielAppService : IFielAppService
    {
        private readonly IUnitOfWork<Fiel> _fielIunitOfWork;
        private readonly ICadastroFielService _cadastroService;
        private readonly IMediatrHandler _mediatrHandler;

        private readonly IMapper _mapper;
        public FielAppService(IMapper mapper,
            IUnitOfWork<Fiel> fielIunitOfWork,
            ICadastroFielService cadastroService,
            IMediatrHandler mediatrHandler)
        {
            _fielIunitOfWork = fielIunitOfWork;
            _cadastroService = cadastroService;
            _mapper = mapper;
            _mediatrHandler = mediatrHandler;


        }

        public async Task<IEnumerable<CristaoViewModel>> AllFieis()
        {
            var fieis = await _fielIunitOfWork.Repository.All();
            return fieis.Select(x => _mapper.Map<CristaoViewModel>(x));
        }

        public async Task CadastroFiel(CadastroFielViewModel cadastroFielViewModel)
        {
            if (cadastroFielViewModel.EhValido())
            {
                var fiel = _mapper.Map<FielViewModel>(cadastroFielViewModel);

                await _cadastroService.CadastroFiel(fiel);

                if (await _fielIunitOfWork.Commit())
                {
                   var cadastroEvent = new FielCadastradoEvent(cadastroFielViewModel.Email, cadastroFielViewModel.Telefone, cadastroFielViewModel.NomeFiel);
                   await  _mediatrHandler.PublicarEvento<FielCadastradoEvent>(cadastroEvent);
                }
            }

            foreach (var erro in cadastroFielViewModel.Erros())
            {
                DomainNotificationHandler.AddNotification(new DomainNotification(erro.PropertyName, erro.ErrorMessage));
            }



        }

        public void Dispose()
        {
            _fielIunitOfWork?.Dispose();
        }
    }
}
