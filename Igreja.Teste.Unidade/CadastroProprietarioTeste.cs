using AutoMapper;
using Igreja.Core.Data;
using Igreja.Domain.Entity;
using Igreja.Domain.Services;
using Igreja.Domain.ViewModel;
using Igreja.Service.Abstract;
using Igreja.Service.Abstract.ViewModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Igreja.Teste.Unidade
{  
    public class CadastroProprietarioTeste
    {
        [Fact]
        public async Task Testar_Cadastro_Proprietario()
        {
            var proprietario = new CadastroProprietarioViewModel()
            {
                Login = "lorran.mendes",
                Senha = "123456789",
                NomeProprietario = "Lorran Mendes",
                CpfProrpietario = "10791471446",
                IdTipoCategoria = Guid.Parse("2a1db0da-2132-4fbd-8df4-5da88c56249a"),
                NomeIgreja = "igreja do Amor",
                CepIgreja = "53437040",
                CnpjIgreja = "59.291.534/0001-67"
            };

            Moq.Mock<IMapper> mocokMapper = new Moq.Mock<IMapper>();
            Moq.Mock<IUnitOfWork<Proprietario>> mockIof = new Moq.Mock<IUnitOfWork<Proprietario>>();
            Moq.Mock<ICadastroProprietarioServiceFacade> mockFacade = new Moq.Mock<ICadastroProprietarioServiceFacade>();

            var cadastroProprietarioService = new CadastroProprietarioAppService(mocokMapper.Object,mockIof.Object,mockFacade.Object);
            await cadastroProprietarioService.CadastroUsuario(proprietario);

            Moq.Mock<ICadastroProprietarioAppService> mocokApp = new Moq.Mock<ICadastroProprietarioAppService>();
            
            mockIof.Verify(c => c.Commit(), Times.Once);

        }

        [Fact]
        public async Task Testar_Cadastro_Sem_Nome()
        {
            var proprietario = new CadastroProprietarioViewModel()
            {
                Login = "",
                Senha = "123456789",
                NomeProprietario = "Lorran Mendes",
                CpfProrpietario = "10791471446",
                IdTipoCategoria = Guid.Parse("2a1db0da-2132-4fbd-8df4-5da88c56249a"),
                NomeIgreja = "igreja do Amor",
                CepIgreja = "53437040",
                CnpjIgreja = "59.291.534/0001-67"
            };

            Moq.Mock<IMapper> mocokMapper = new Moq.Mock<IMapper>();
            Moq.Mock<IUnitOfWork<Proprietario>> mockIof = new Moq.Mock<IUnitOfWork<Proprietario>>();
            Moq.Mock<ICadastroProprietarioServiceFacade> mockFacade = new Moq.Mock<ICadastroProprietarioServiceFacade>();

            Moq.Mock<ICadastroProprietarioAppService> mockAppService = new Moq.Mock<ICadastroProprietarioAppService>();

            var cadastroProprietarioService = new CadastroProprietarioAppService(mocokMapper.Object, mockIof.Object, mockFacade.Object);
            await cadastroProprietarioService.CadastroUsuario(proprietario);

            mockIof.Verify(c => c.Commit(), Times.Never);
            Assert.False(proprietario.EhValido());

        }
    }
}
