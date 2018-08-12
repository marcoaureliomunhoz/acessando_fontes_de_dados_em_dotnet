using AgendaAspNetCoreEF1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaAspNetCoreEF1.Data
{
    public class ContextoGeral : DbContext
    {
        public ContextoGeral(DbContextOptions<ContextoGeral> options) : base(options)
        {
            
        }

        public DbSet<Estado> Estados { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configura o nome das tabelas
            modelBuilder.Entity<Estado>().ToTable("Estado");
            modelBuilder.Entity<Contato>().ToTable("Contato");
        }
    }
}
