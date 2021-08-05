using AutoMapper;
using Igreja.Core.Communication;
using Igreja.Core.Data;
using Igreja.Core.NotificationMessage;
using Igreja.Domain.Entity;
using Igreja.Domain.Interface;
using Igreja.Domain.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Igreja.Application.AppplicationService.ProprietarioAppService
{
    public class ProprietarioAppService : IProprietarioAppService
    {

        private readonly IUnitOfWork<LoginProprietario> _proprietarioIunitOfWork;

        private readonly ICadastroProprietarioServiceFacade _cadastroProprietarioServiceFacade;

        private readonly IMapper _mapper;
        public ProprietarioAppService(IMapper mapper,
            IUnitOfWork<LoginProprietario> proprietarioIunitOfWork,
            ICadastroProprietarioServiceFacade cadastroProprietarioServiceFacade)
        {
            _mapper = mapper;
            _proprietarioIunitOfWork = proprietarioIunitOfWork;
            _cadastroProprietarioServiceFacade = cadastroProprietarioServiceFacade;
        }

        public async Task CadastroUsuario(CadastroProprietarioViewModel cadastroProprietarioViewModel)
        {
            if (cadastroProprietarioViewModel.EhValido())
            {
                var viewModel = _mapper.Map<CadastroProprietarioIgrejaViewModel>(cadastroProprietarioViewModel);
                await _cadastroProprietarioServiceFacade.CadastratUsuarioProprietario(viewModel);

                await _proprietarioIunitOfWork.Commit();
            }

            foreach (var erro in cadastroProprietarioViewModel.Erros())
            {
                DomainNotificationHandler.AddNotification(new DomainNotification(erro.PropertyName, erro.ErrorMessage));
            }

        }

        public async Task<IEnumerable<LoginProprietario>> Proprietarios()
        {
           return await _proprietarioIunitOfWork.Repository.All();
        }


        public void Dispose()
        {
            _proprietarioIunitOfWork?.Dispose();
        }

    }
}
