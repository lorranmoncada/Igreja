using Igreja.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Igreja.Mapper
{
    public static class AutoMapperExtension
    {
        public static void StartupAutoMapperExtension(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(ViewModelToProprietario));
            service.AddAutoMapper(typeof(ViewModelToLoginProprietario));
            service.AddAutoMapper(typeof(ViewModelIgrejaToDomain));
            service.AddAutoMapper(typeof(ViewModelToEnderecoDomain));
            service.AddAutoMapper(typeof(CadastroFielViewmodelMap));
            service.AddAutoMapper(typeof(ViewModelPostProprietarioToDomain));
            service.AddAutoMapper(typeof(ComentarioViewModelToComentarioDomain));
            service.AddAutoMapper(typeof(FielDomainToFielViewModelMap));
        }
    }
}
