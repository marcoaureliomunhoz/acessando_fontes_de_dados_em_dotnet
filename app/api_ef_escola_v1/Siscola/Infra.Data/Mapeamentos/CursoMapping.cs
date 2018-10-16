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
    public class CursoMapping : EntityTypeConfiguration<Curso>
    {
        public override void Map(EntityTypeBuilder<Curso> builder)
        {
            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(Constantes.TamMaxNomeComum);

            builder.Property(x => x.Detalhes)
                .HasMaxLength(Constantes.TamMaxDescricaoDetalhada);

            builder.ToTable(nameof(Curso));
        }
    }
}
