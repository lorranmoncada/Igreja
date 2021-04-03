using AutoMapper;
using Igreja.Core.Communication;
using Igreja.Core.Comunication;
using Igreja.Core.Data;
using Igreja.Domain.Entity;
using Igreja.Domain.ViewModel;
using Igreja.Service.Abstract;
using Igreja.Service.Abstract.ViewModel;
using System.Threading.Tasks;

namespace Igreja.Application.AppplicationService.CadastroFielAppService
{
    public class CadastroFielAppService : ICadastrofielAppService
    {
        private readonly IUnitOfWork<Fiel> _fielIunitOfWork;

        private readonly ICadastroFielService _cadastroService;

        private readonly IMapper _mapper;
        public CadastroFielAppService(IMapper mapper,IUnitOfWork<Fiel> fielIunitOfWork, ICadastroFielService cadastroService)
        {
            _fielIunitOfWork = fielIunitOfWork;
            _cadastroService = cadastroService;
            _mapper = mapper;


        }
        public  async Task CadastroFiel(CadastroFielViewModel cadastroFielViewModel)
        {
            if (cadastroFielViewModel.EhValido())
            {
                var fiel = _mapper.Map<FielViewModel>(cadastroFielViewModel);

                await _cadastroService.CadastroFiel(fiel);

                await _fielIunitOfWork.Commit();
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
