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
    public class EspecialidadeMapping : EntityTypeConfiguration<Especialidade>
    {
        public override void Map(EntityTypeBuilder<Especialidade> builder)
        {
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(Constantes.TamMaxNomeComum);

            builder.HasMany(d => d.Disciplinas)
                .WithOne(e => e.Especialidade)
                .HasPrincipalKey(pk => pk.Id)
                .HasForeignKey(fk => fk.EspecialidadeId);

            builder.ToTable(nameof(Especialidade));
        }
    }
}
