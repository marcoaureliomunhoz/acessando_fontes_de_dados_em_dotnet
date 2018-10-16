using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Siscola.Dominio;
using Siscola.Infra.Data.Mapeamentos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Infra.Data
{
    public class SiscolaDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("SiscolaDbContext"));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Cidade>(new CidadeMapping());
            modelBuilder.ApplyConfiguration<Endereco>(new EnderecoMapping());
            modelBuilder.ApplyConfiguration<Disciplina>(new DisciplinaMapping());
            modelBuilder.ApplyConfiguration<Curso>(new CursoMapping());
            modelBuilder.ApplyConfiguration<DisciplinaCurso>(new DisciplinaCursoMapping());
            modelBuilder.ApplyConfiguration<PessoaFisica>(new PessoaFisicaMapping());
            modelBuilder.ApplyConfiguration<PessoaJuridica>(new PessoaJuridicaMapping());
            modelBuilder.ApplyConfiguration<Matricula>(new MatriculaMapping());
            modelBuilder.ApplyConfiguration<Turma>(new TurmaMapping());
            modelBuilder.ApplyConfiguration<Especialidade>(new EspecialidadeMapping());
            modelBuilder.ApplyConfiguration<Professor>(new ProfessorMapping());
        }
    }
}
