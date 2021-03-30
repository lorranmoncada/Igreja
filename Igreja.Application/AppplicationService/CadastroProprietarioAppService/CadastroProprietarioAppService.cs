using AutoMapper;
using Igreja.Domain.Entity;
using Igreja.Domain.ViewModel;
using Igreja.Infraestructure;
using System.Threading.Tasks;

namespace Igreja.Application.AppplicationService.CadastroProprietarioAppService
{
    public class CadastroProprietarioAppService : ICadastroProprietarioAppService
    {
        private readonly IUnitOfWork<LoginProprietario> _loginIunitOfWork;

        private readonly IUnitOfWork<Proprietario> _proprietarioIunitOfWork;

        private readonly IMapper _mapper;
        public CadastroProprietarioAppService(IUnitOfWork<LoginProprietario> loginIunitOfWork, IUnitOfWork<Proprietario> proprietarioIunitOfWork)
        {
            _loginIunitOfWork = loginIunitOfWork;
            _proprietarioIunitOfWork = proprietarioIunitOfWork;
        }
       

        public CadastroProprietarioAppService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public async Task<bool> CadastroUsuario(CadastroProprietarioViewModel cadastroProprietarioViewModel)
        {
            var loginProprietario = _mapper.Map<LoginProprietario>(cadastroProprietarioViewModel);
            await _loginIunitOfWork.Repository.Add(loginProprietario);

            var proprietario = _mapper.Map<Proprietario>(cadastroProprietarioViewModel);
            await _proprietarioIunitOfWork.Repository.Add(proprietario);

            return true;
        }
    }
}
