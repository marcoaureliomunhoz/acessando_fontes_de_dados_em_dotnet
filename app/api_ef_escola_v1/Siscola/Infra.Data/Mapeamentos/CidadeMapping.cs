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
    public class CidadeMapping : EntityTypeConfiguration<Cidade>
    {
        public override void Map(EntityTypeBuilder<Cidade> builder)
        {
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(Constantes.TamMaxNomeComum);

            builder.Property(x => x.UF)
                .IsRequired();

            builder.ToTable(nameof(Cidade));
        }
    }
}
