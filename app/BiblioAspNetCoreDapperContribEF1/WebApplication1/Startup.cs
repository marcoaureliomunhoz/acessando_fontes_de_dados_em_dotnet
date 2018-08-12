using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Dominio.Repositorios;
using WebApplication1.Infra.FontesDados.Dapper;
using WebApplication1.Infra.FontesDados.EF;
using WebApplication1.Infra.FontesDados.Repositorios;

namespace WebApplication1
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
            var stringConexao = Configuration.GetConnectionString("ContextoGeral");
            services.AddDbContext<ContextoGeralEF>(options => options.UseSqlServer(stringConexao));

            var contextoGeralDapper = new ContextoGeralDapper(stringConexao);
            services.AddSingleton(contextoGeralDapper);

            //EF
            services.AddScoped<IEditorasRep, EditorasRep>();
            services.AddScoped<IAutoresRep, AutoresRep>();

            //Dapper
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
