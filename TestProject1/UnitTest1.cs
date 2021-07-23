using FluentAssertions;
using Igreja.Domain.ViewModel;
using integracao.Fixtures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        private readonly Testecontext _texteContext;

        public UnitTest1()
        {
            _texteContext = new Testecontext();
        }

        [Fact]
        public async void TestarStatusDaRequisicao()
        {
            var response = await _texteContext.Client.GetAsync("api/categoria");
            response.EnsureSuccessStatusCode();

           response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async void VerificarRetorno()
        {
            var response = await _texteContext.Client.GetAsync("api/categoria");
            response.EnsureSuccessStatusCode();
            var retorno = await response.Content.ReadAsStringAsync();
            var categorias = JsonConvert.DeserializeObject<IList<CategoriaViewModel>>(retorno);
          

            Assert.Equal(2, categorias.Count);
        }
    }
}
