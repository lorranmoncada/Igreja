using Igreja.Application;
using Igreja.Core.Data;
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


            Moq.Mock<IAplicationCategoriaIgrejaApp> mockAplication = new Moq.Mock<IAplicationCategoriaIgrejaApp>();
            mockAplication.Setup(x => x.ObterCategorias()).Returns(Task.FromResult<IList<CategoriaViewModel>>(listaCategoriasViewModel));

            Moq.Mock<IUnitOfWork<CategoriaIgreja>> mockPattern = new Moq.Mock<IUnitOfWork<CategoriaIgreja>>();
            mockPattern.Setup(x => x.Repository.All()).Returns(Task.FromResult<IList<CategoriaIgreja>>(listaCategoria));

            var pattern = new AplicationCategoriaIgrejaApp(mockPattern.Object);

            var result = pattern.ObterCategorias();

            Assert.Equal(result.Result.Any(), listaCategoriasViewModel.Any());
        }
    }
}
