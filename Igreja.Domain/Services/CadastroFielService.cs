using AutoMapper;
using Igreja.Core.Data;
using Igreja.Domain.Entity;
using Igreja.Domain.Interface;
using Igreja.Domain.ViewModel;
using System.Threading.Tasks;

namespace Igreja.Fieis.Domain.Services
{
    public class CadastroFielService : ICadastroFielService
    {
        private readonly IUnitOfWork<LoginFiel> _loginFielIunitOfWork;
        private readonly IUnitOfWork<Fiel> _fielIunitOfWork;
        private readonly IMapper _mapper;

        public CadastroFielService(IMapper mapper,
            IUnitOfWork<LoginFiel> loginFielIunitOfWork,
            IUnitOfWork<Fiel> fielIunitOfWork)
        {
            _loginFielIunitOfWork = loginFielIunitOfWork;
            _mapper = mapper;
            _fielIunitOfWork = fielIunitOfWork;
        }
        public async Task CadastroFiel(FielViewModel cadastroFielViewModel)
        {
            //Login do fiel
            var loginFiel = _mapper.Map<LoginFiel>(cadastroFielViewModel);
            await _loginFielIunitOfWork.Repository.Add(loginFiel);

            //Dados do Fiel
            var fiel = _mapper.Map<Fiel>(cadastroFielViewModel);
            fiel.AtribuirIdIgreja(cadastroFielViewModel.IdIgreja);

            fiel.AtribuirLoginFiel(loginFiel.Id);
            await _fielIunitOfWork.Repository.Add(fiel);
        }

        public void Dispose()
        {
            _loginFielIunitOfWork?.Dispose();
            _fielIunitOfWork?.Dispose();
        }
    }
}
