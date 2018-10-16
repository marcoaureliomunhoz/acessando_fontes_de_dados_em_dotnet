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
    public class DisciplinaMapping : EntityTypeConfiguration<Disciplina>
    {
        public override void Map(EntityTypeBuilder<Disciplina> builder)
        {
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(Constantes.TamMaxNomeComum);

            builder.Property(x => x.Detalhes)
                .HasMaxLength(Constantes.TamMaxDescricaoDetalhada);

            //builder.HasOne(e => e.Especialidade)
            //    .WithMany(d => d.Disciplinas)
            //    .HasPrincipalKey(pk => pk.Id)
            //    .HasForeignKey(fk => fk.EspecialidadeId);

            builder.ToTable(nameof(Disciplina));
        }
    }
}
