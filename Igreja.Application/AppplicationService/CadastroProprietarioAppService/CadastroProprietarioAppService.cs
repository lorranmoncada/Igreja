using AutoMapper;
using Igreja.Core.Communication;
using Igreja.Core.Comunication;
using Igreja.Core.Data;
using Igreja.Domain.Entity;
using Igreja.Domain.ViewModel;
using Igreja.Service.Abstract;
using Igreja.Service.Abstract.ViewModel;
using System.Threading.Tasks;

namespace Igreja.Application.AppplicationService.CadastroProprietarioAppService
{
    public class CadastroProprietarioAppService : ICadastroProprietarioAppService
    {

        private readonly IUnitOfWork<Proprietario> _proprietarioIunitOfWork;

        private readonly ICadastroProprietarioServiceFacade _cadastroProprietarioServiceFacade;

        private readonly IMapper _mapper;
        public CadastroProprietarioAppService(IMapper mapper,
            IUnitOfWork<Proprietario> proprietarioIunitOfWork,
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

        public void Dispose()
        {
            _proprietarioIunitOfWork?.Dispose();
        }
    }
}
