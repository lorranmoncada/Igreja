using Igreja.Application.AutoMapper;
using Igreja.Infraestructure;
using Igreja.StartupExtension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Igreja
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //Contexto
            services.AddDbContext<IgrejaContext>(p => p.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            //AutoMapper
            services.AddAutoMapper(typeof(ViewModelToProprietario));
            services.AddAutoMapper(typeof(ViewModelToLoginProprietario));
            services.AddAutoMapper(typeof(ViewModelIgrejaToDomain));
            services.AddAutoMapper(typeof(ViewModelToEnderecoDomain));
            services.AddAutoMapper(typeof(CadastroFielViewmodelMap));

            // Inje��o de dependencias
            services.StartupResolveDependencyInject();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Igreja", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Igreja v1"));
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
