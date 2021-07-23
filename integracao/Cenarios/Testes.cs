using integracao.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace integracao.Cenarios
{
    public class Testes
    {

        private readonly Testecontext _texteContext;

        public Testes()
        {
            _texteContext = new Testecontext();
        }

        [Fact]
        public async Task ObterCategorias()
        {
            var response = await _texteContext.Client.GetAsync("/api/categoria");
           var status = response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, status.StatusCode);
        }
    }
}
