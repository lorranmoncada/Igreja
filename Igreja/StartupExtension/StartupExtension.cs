using Igreja.Application;
using Igreja.Application.AppplicationService.CadastroFielAppService;
using Igreja.Application.AppplicationService.CadastroProprietarioAppService;
using Igreja.Core.Comunication;
using Igreja.Core.Data;
using Igreja.Domain.Services;
using Igreja.Fieis.Domain.Services;
using Igreja.Infraestructure;
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
            // context
            service.AddDbContext<IgrejaContext>();

            service.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
            service.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            //Application
            service.AddScoped<IAplicationCategoriaIgrejaAppService, AplicationCategoriaIgrejaAppService>();
            service.AddScoped<ICadastroProprietarioAppService, CadastroProprietarioAppService>();
            service.AddScoped<ICadastrofielAppService, CadastroFielAppService>();

            //Catagoria
            service.AddScoped<ICategoriaRepository, CategoriaRepository>();
            service.AddScoped<ICategoriaService, CategoriaService>();

            //Cadastro Login Proprietario
            service.AddScoped<ILoginProprietarioRepository, LoginProprietarioRepository>();
            service.AddScoped<ICadastroProprietarioServiceFacade, CadastroProprietarioServiceFacade>();

            //Fiel
            service.AddScoped<ICadastroFielService, CadastroFielService>();

            //DomainNotification
            service.AddSingleton<DomainNotificationHandler>();
        }
    }
}
