using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlApp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp
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
            services.AddMvc();
            services.RegisterServices();
        }

        string listRoutingConstraint(string sufixo) => "^(get|list|listar)-"+sufixo+"$";
        string cadRoutingConstraint(string sufixo, string key) => "^(cad|cadastro|cadastrar)-"+sufixo+ @"(|\?"+key+"=[0-9]*)$";

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
                    name: "list-editoras",
                    template: "{*list}",
                    constraints: new { list = listRoutingConstraint("editoras") },
                    defaults: new { controller = "Editoras", action = "Index"});

                routes.MapRoute(
                    name: "cad-editora",
                    template: "{*cad}",
                    constraints: new { cad = cadRoutingConstraint("editora","id") },
                    defaults: new { controller = "Editoras", action = "Cadastro" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
