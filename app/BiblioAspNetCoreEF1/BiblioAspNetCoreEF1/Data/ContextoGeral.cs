using BiblioAspNetCoreEF1.Data.Configurations;
using BiblioAspNetCoreEF1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioAspNetCoreEF1.Data
{
    public class ContextoGeral : DbContext
    {
        public ContextoGeral(DbContextOptions<ContextoGeral> options) : base(options)
        {
        }

        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<LivroAutor> LivroAutor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Editora>(new EditoraConfig());
            modelBuilder.ApplyConfiguration<Autor>(new AutorConfig());
            modelBuilder.ApplyConfiguration<Livro>(new LivroConfig());
            modelBuilder.ApplyConfiguration<LivroAutor>(new LivroAutorConfig());
        }
    }
}
