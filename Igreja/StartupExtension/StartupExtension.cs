using Igreja.Application;
using Igreja.Application.AppplicationService.CadastroFielAppService;
using Igreja.Application.AppplicationService.Comentario;
using Igreja.Application.AppplicationService.PostProprietario;
using Igreja.Application.AppplicationService.ProprietarioAppService;
using Igreja.Application.AutoMapper;
using Igreja.Core.Communication.MediaTR;
using Igreja.Core.Data;
using Igreja.Core.NotificationMessage;
using Igreja.Core.Util;
using Igreja.Domain.Dtos;
using Igreja.Domain.Entities;
using Igreja.Domain.Entity;
using Igreja.Domain.Events.FielEvents.CadastroEvent;
using Igreja.Domain.Services;
using Igreja.Fieis.Domain.Services;
using Igreja.Infraestructure;
using Igreja.Infraestructure.Repository;
using Igreja.Repositorie.Abastract;
using Igreja.Service.Abstract;
using MediatR;
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
            service.AddScoped<IProprietarioAppService, ProprietarioAppService>();
            service.AddScoped<IFielAppService, FielAppService>();
            service.AddScoped<IPostProprietarioAppService, PostProprietarioAppService>(); 
            service.AddScoped<IComentarioAppService, ComentarioAppService>();

            //Catagoria
            service.AddScoped<ICategoriaRepository, CategoriaRepository>();
            service.AddScoped<ICategoriaService, CategoriaService>();

            //Cadastro Login Proprietario
            service.AddScoped<ILoginProprietarioRepository, LoginProprietarioRepository>();
            service.AddScoped<ICadastroProprietarioServiceFacade, CadastroProprietarioServiceFacade>();

            //Fiel
            service.AddScoped<ICadastroFielService, CadastroFielService>();

            //Post Proprietario
            service.AddScoped<IPostProprietarioRepository<ProprietarioPost>, PostProprietarioRepository>();

            //Comentario
            service.AddScoped<IComentarioRepository<DtoComentario>, ComentarioRepository>();

            //DomainNotification
            service.AddSingleton<DomainNotificationHandler>();

            //MediaTR
            service.AddScoped<IMediatrHandler, MediaTrHandler>();
             
            service.AddScoped<INotificationHandler<FielCadastradoEvent>, FielEventHandler>();
        }     
    }
}
