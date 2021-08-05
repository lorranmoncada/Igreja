using AutoMapper;
using Igreja.Core.Data;
using Igreja.Core.DomainObjects;
using Igreja.Domain.Entity;
using Igreja.Domain.Interface;
using Igreja.Domain.ViewModel;
using System.Threading.Tasks;

namespace Igreja.Domain.Services
{
    public class CadastroProprietarioServiceFacade : ICadastroProprietarioServiceFacade
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<LoginProprietario> _loginRepository;
        private readonly IUnitOfWork<Proprietario> _proprietarioRepository;
        private readonly IUnitOfWork<Endereco> _enderecoRepository;
        private readonly IUnitOfWork<CategoriaIgreja> _categoriaRepository;
        private readonly IUnitOfWork<IgrejaEntity> _igrejaRepository;
        public CadastroProprietarioServiceFacade(
        IMapper mapper,
        IUnitOfWork<Proprietario> proprietarioIunitOfWork,
        IUnitOfWork<LoginProprietario> loginProprietarioIunitOfWork,
        IUnitOfWork<Endereco> enderecoRepository,
        IUnitOfWork<CategoriaIgreja> categoriaRepository,
        IUnitOfWork<IgrejaEntity> igrejaRepository)
        {
            _mapper = mapper;
            _proprietarioRepository = proprietarioIunitOfWork;
            _loginRepository = loginProprietarioIunitOfWork;
            _enderecoRepository = enderecoRepository;
            _categoriaRepository = categoriaRepository;
            _igrejaRepository = igrejaRepository;
        }

        public async Task CadastratUsuarioProprietario(CadastroProprietarioIgrejaViewModel cadastroProprietarioIgrejaViewModel)
        {
            //Login
            var loginProprietario = _mapper.Map<LoginProprietario>(cadastroProprietarioIgrejaViewModel);
            await _loginRepository.Repository.Add(loginProprietario);

            //Proprietario
            var proprietario = _mapper.Map<Proprietario>(cadastroProprietarioIgrejaViewModel);
            proprietario.AtribuirIdLoginProprietario(loginProprietario.Id);
            await _proprietarioRepository.Repository.Add(proprietario);

            //Endereco
            var endereco = _mapper.Map<Endereco>(cadastroProprietarioIgrejaViewModel);
            await _enderecoRepository.Repository.Add(endereco);

            var categoriaExistente = await _categoriaRepository.Repository.GetById(cadastroProprietarioIgrejaViewModel.IdTipoCategoria);

            if (categoriaExistente == null) throw new DomainException("Categoria de igreja inexistente");

            var igreja = _mapper.Map<IgrejaEntity>(cadastroProprietarioIgrejaViewModel);

            igreja.AtribuirCategoria(categoriaExistente.Id);
            igreja.AtribuirEndereco(endereco.Id);
            igreja.AtribuirProprietario(proprietario.Id);

            await _igrejaRepository.Repository.Add(igreja);
        }

        public void Dispose()
        {
            _loginRepository?.Dispose();
            _proprietarioRepository?.Dispose();
            _enderecoRepository?.Dispose();
            _categoriaRepository?.Dispose();
            _igrejaRepository?.Dispose();
        }
    }
}
