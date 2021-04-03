using Igreja.Application;
using Igreja.Core.Data;
using Igreja.Infraestructure;
using Igreja.Repositorie.Abastract;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Igreja
{
    public class StartupApiTests
    {
        public StartupApiTests(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
            services.AddScoped<IAplicationCategoriaIgrejaAppService, AplicationCategoriaIgrejaAppService>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app)
        {
            //app.UseMvc();
        }
    }
}
