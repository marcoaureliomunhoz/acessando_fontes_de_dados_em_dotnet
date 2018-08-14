using DataApp.Fontes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataApp.EF
{
    public class ContextoGeralEF : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("ContextoGeral"));
        }

        public DbSet<TabEditora> Editoras { get; set; }
        public DbSet<TabAutor> Autores { get; set; }
        public DbSet<TabLivro> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<TabEditora>(new Config.TabEditoraConfig());
            modelBuilder.ApplyConfiguration<TabAutor>(new Config.TabAutorConfig());
            modelBuilder.ApplyConfiguration<TabLivro>(new Config.TabLivroConfig());
        }
    }
}
