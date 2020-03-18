using AgendaSis.Application.Services.Agendas;
using AgendaSis.Application.Services.Generos;
using AgendaSis.Application.Services.Pessoas;
using AgendaSis.Application.Services.Salas;
using AgendaSis.Domain.Interfaces;
using AgendaSis.Infra.Contexto;
using AgendaSis.Infra.Filtros;
using AgendaSis.Infra.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AgendaSis.Web
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
            services
                .AddDbContext<MeuContexto>(
                    opt => opt.UseNpgsql(Configuration["ConnectionStrings:MinhaStringConexao"])
                );

            services.AddScoped<ISalaRepository, SalaRepository>();
            services.AddScoped<ISalaService, SalaService>();

            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<IGeneroService, GeneroService>();
            //services.AddScoped<IGeneroService, GeneroFakeService>();

            services.AddScoped<IPessoaFisicaRepository, PessoaFisicaRepository>();
            services.AddScoped<IPessoaFisicaService, PessoaFisicaService>();
            services.AddScoped<IPessoaJuridicaRepository, PessoaJuridicaRepository>();
            services.AddScoped<IPessoaJuridicaService, PessoaJuridicaService>();
            
            services.AddScoped<IAgendaRepository, AgendaRepository>();
            services.AddScoped<IAgendaService, AgendaService>();

            services.AddMvc(options => options.Filters.Add(typeof(JsonExceptionFilter)));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
