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
    public class DisciplinaCursoMapping : IEntityTypeConfiguration<DisciplinaCurso>
    {
        public void Configure(EntityTypeBuilder<DisciplinaCurso> builder)
        {
            builder.HasKey(x => new { x.DisciplinaId, x.CursoId });

            builder.HasOne<Disciplina>(d => d.Disciplina)
                .WithMany(c => c.Cursos)
                .HasForeignKey(fk => fk.DisciplinaId);

            builder.HasOne<Curso>(c => c.Curso)
                .WithMany(d => d.Disciplinas)
                .HasForeignKey(fk => fk.CursoId);

            builder.ToTable(nameof(DisciplinaCurso));
        }
    }
}
