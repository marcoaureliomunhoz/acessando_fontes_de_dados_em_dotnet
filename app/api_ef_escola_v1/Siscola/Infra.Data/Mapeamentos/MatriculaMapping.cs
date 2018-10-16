using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Siscola.Dominio;
using Siscola.Dominio._Base;
using Siscola.Infra.Data.Mapeamentos._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Infra.Data.Mapeamentos
{
    public class MatriculaMapping : EntityTypeConfiguration<Matricula>
    {
        public override void Map(EntityTypeBuilder<Matricula> builder)
        {
            builder.Property(x => x.RA)
                .IsRequired()
                .HasMaxLength(Constantes.TamMaxRA);

            builder.HasOne(a => a.Aluno)
                .WithMany(m => m.Matriculas)
                .HasPrincipalKey(pk => pk.Id)
                .HasForeignKey(fk => fk.AlunoId);

            builder.HasOne(c => c.Curso)
                .WithMany(m => m.Matriculas)
                .HasPrincipalKey(pk => pk.Id)
                .HasForeignKey(fk => fk.CursoId);

            builder.HasOne(t => t.Turma)
                .WithMany(m => m.Matriculas)
                .HasPrincipalKey(pk => pk.Id)
                .HasForeignKey(fk => fk.TurmaId);

            builder.ToTable(nameof(Matricula));
        }
    }
}
