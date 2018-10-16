using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Siscola.Dominio.Repositorios;
using Siscola.Dominio.Repositorios._Base;
using Siscola.Infra.Data;
using Siscola.Infra.Data.Repositorios;

namespace Siscola
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
            services.AddDbContext<SiscolaDbContext>(ServiceLifetime.Scoped);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            AdicionarRepositorios(services);

            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        public void AdicionarRepositorios(IServiceCollection services)
        {
            var namespaceRepositorios = typeof(Siscola.Dominio.Repositorios.IRepositorioDeCidades).Namespace;
            var irepositoriosType = GetType().Assembly.GetTypes().Where(x => x.IsInterface && x.Namespace == namespaceRepositorios);

            foreach (var irep in irepositoriosType)
            {
                var repositoriosType = GetType().Assembly.GetTypes().Where(x => irep.IsAssignableFrom(x) && !x.IsInterface);
                foreach (var rep in repositoriosType)
                {
                    services.AddScoped(irep, rep);
                }
            }

            //services.AddScoped<IRepositorioDeCidades, RepositorioDeCidades>();
            //services.AddScoped<IRepositorioDeCursos, RepositorioDeCursos>();
        }
    }
}
