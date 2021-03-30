using Igreja.Application;
using Igreja.Application.AppplicationService.CadastroProprietarioAppService;
using Igreja.Core;
using Igreja.Domain.Services;
using Igreja.Infraestructure;
using Igreja.Infraestructure.Interface;
using Igreja.Infraestructure.Repository;
using Igreja.Repositorie.Abastract;
using Igreja.Service.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace Igreja.StartupExtension
{
    public static class StartupExtension
    {
        public static void StartupResolveDependencyInject(this IServiceCollection service)
        {
            service.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
            service.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            //Application
            service.AddScoped<IAplicationCategoriaIgrejaApp, AplicationCategoriaIgrejaApp>();
            service.AddScoped<ICadastroProprietarioAppService, CadastroProprietarioAppService>(); 

            //Catagoria
            service.AddScoped<ICategoriaRepository, CategoriaRepository>();
            service.AddScoped<ICategoriaService, CategoriaService>();

            //Cadastro Login Proprietario
            service.AddScoped<ILoginProprietarioRepository, LoginProprietarioRepository>();

        }
    }
}
