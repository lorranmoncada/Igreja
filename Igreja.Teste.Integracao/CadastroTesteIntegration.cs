using Igreja.Domain.ViewModel;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Igreja.Teste.Integracao
{
    [Collection(nameof(IntegrationApiTestFixtureCollection))]
    public class CadastroTesteIntegration
    {
        private readonly IntegrationTestFixture<StartupApiTests> _integrationTestFixture;
        public CadastroTesteIntegration(IntegrationTestFixture<StartupApiTests> integrationTestFixture)
        {
            _integrationTestFixture = integrationTestFixture;
        }

        [Fact(DisplayName = "pega as categorias")]
        public async Task Efetua_Saque_Via_Api()
        {
           //https://localhost:44329/
            var requisicao = await _integrationTestFixture.Client.GetFromJsonAsync<Task<IList<CategoriaViewModel>>>("/api/teste");
            var resposta = await requisicao;

            //Assert.True(requisicao.IsSuccessStatusCode);
            //Assert.Contains("Receba seu saque", resposta);
        }
    }

}
