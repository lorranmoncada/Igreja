using Igreja.Application;
using Igreja.Core.Data;
using Igreja.Core.DomainObjects;
using Igreja.Domain;
using Igreja.Domain.Entity;
using Igreja.Domain.ViewModel;
using Igreja.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Igreja.Teste.Unidade
{
    public class CategoriaTeste
    {

        [Fact]
        public void RetornoIgrejaCategorias()
        {
            var listaCategoriasViewModel = new List<CategoriaViewModel>() { new CategoriaViewModel(Guid.NewGuid(), "Evangelico") };

            var listaCategoria = new List<CategoriaIgreja>() { new CategoriaIgreja(TipoCategoriaEnum.Evangelica) { Id = Guid.NewGuid() } };


            Moq.Mock<IAplicationCategoriaIgrejaAppService> mockAplication = new Moq.Mock<IAplicationCategoriaIgrejaAppService>();
            mockAplication.Setup(x => x.ObterCategorias()).Returns(Task.FromResult<IList<CategoriaViewModel>>(listaCategoriasViewModel));

            Moq.Mock<IUnitOfWork<CategoriaIgreja>> mockPattern = new Moq.Mock<IUnitOfWork<CategoriaIgreja>>();
            mockPattern.Setup(x => x.Repository.All()).Returns(Task.FromResult<IList<CategoriaIgreja>>(listaCategoria));

            var pattern = new AplicationCategoriaIgrejaAppService(mockPattern.Object);

            var result = pattern.ObterCategorias();

            Assert.Equal(result.Result.Any(), listaCategoriasViewModel.Any());
        }

        [Fact]
        public void ExecptionRetornoIgrejaCategorias()
        {
          
            var listaCategoria = new List<CategoriaIgreja>() { };

            Moq.Mock<IAplicationCategoriaIgrejaAppService> mockAplication = new Moq.Mock<IAplicationCategoriaIgrejaAppService>();    

            Moq.Mock<IUnitOfWork<CategoriaIgreja>> mockPattern = new Moq.Mock<IUnitOfWork<CategoriaIgreja>>();
            mockPattern.Setup(x => x.Repository.All()).Returns(Task.FromResult<IList<CategoriaIgreja>>(listaCategoria));

            var pattern = new AplicationCategoriaIgrejaAppService(mockPattern.Object);

            var result = pattern.ObterCategorias();

            Assert.ThrowsAny<DomainException>(() => throw new DomainException("Não foram encontradas categorias cadastradas"));
        }

        [Fact]
        public void VerificandoMensagemDeExessao()
        {

            var listaCategoria = new List<CategoriaIgreja>() { };

            Moq.Mock<IAplicationCategoriaIgrejaAppService> mockAplication = new Moq.Mock<IAplicationCategoriaIgrejaAppService>();

            Moq.Mock<IUnitOfWork<CategoriaIgreja>> mockPattern = new Moq.Mock<IUnitOfWork<CategoriaIgreja>>();
            mockPattern.Setup(x => x.Repository.All()).Returns(Task.FromResult<IList<CategoriaIgreja>>(listaCategoria));

            var pattern = new AplicationCategoriaIgrejaAppService(mockPattern.Object);

            var result = pattern.ObterCategorias().Exception.InnerException.Message;

            Assert.Equal("Não foram encontradas categorias cadastradas",result);
        }
    }
}
