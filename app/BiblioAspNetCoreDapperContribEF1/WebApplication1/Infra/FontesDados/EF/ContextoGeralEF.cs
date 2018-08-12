using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Infra.FontesDados._Fontes.Tabelas;

namespace WebApplication1.Infra.FontesDados.EF
{
    public class ContextoGeralEF : DbContext
    {
        public ContextoGeralEF(DbContextOptions<ContextoGeralEF> options) : base(options)
        {
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
