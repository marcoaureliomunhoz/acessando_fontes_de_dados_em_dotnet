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
    public class TurmaMapping : EntityTypeConfiguration<Turma>
    {
        public override void Map(EntityTypeBuilder<Turma> builder)
        {
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(Constantes.TamMaxNomeComum);

            builder.Property(x => x.Ano)
                .IsRequired();

            builder.ToTable(nameof(Turma));
        }
    }
}
