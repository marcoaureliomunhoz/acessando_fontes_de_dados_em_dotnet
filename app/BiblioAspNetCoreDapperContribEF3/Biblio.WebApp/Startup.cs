using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblio.DataApp.EF;
using Biblio.DataApp.EF.Repositorios;
using Biblio.DomainApp.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Biblio.WebApp
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
            //EF
            //services.AddSingleton(new ContextoGeralEF());
            services.AddDbContext<ContextoGeralEF>(ServiceLifetime.Scoped);
            services.AddScoped<IEditorasRep, EditorasRep>();
            services.AddScoped<IAutoresRep, AutoresRep>();
            services.AddScoped<ILivrosRep, LivrosRep>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
