using DataApp.Dapper;
using DataApp.EF;
using DataApp.Repositorios;
using DomainApp.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlApp
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton(new ContextoGeralEF());
            services.AddSingleton(new ContextoGeralDapper());
            services.AddScoped<IEditorasRep, EditorasRep>();
            services.AddScoped<IAutoresRep, AutoresRep>();
            services.AddScoped<ILivrosRep, LivrosRep>();
        }
    }
}
