using Igreja;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace integracao.Fixtures
{
    public class Testecontext
    {
        public HttpClient Client { get; set; }

        public TestServer _server;

        public Testecontext()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();

            // estamos subindo um server com as configurações d aminha startup
            // tambem posso criar um startup somente pros testes
            _server = new TestServer(new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseStartup<Startup>());

            Client = _server.CreateClient();
        }
    }
}
