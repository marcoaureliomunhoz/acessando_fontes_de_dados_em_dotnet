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
    public class PessoaFisicaMapping : EntityTypeConfiguration<PessoaFisica>
    {
        public override void Map(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder.Property(x => x.NomeCivil)
                .IsRequired()
                .HasMaxLength(Constantes.TamMaxNomeComum);

            builder.Property(x => x.NomeSocial)
                .HasMaxLength(Constantes.TamMaxNomeComum);

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasMaxLength(Constantes.TamMaxCPF);

            builder.Property(x => x.RG)
                .HasMaxLength(Constantes.TamMaxRG);

            builder
                .HasMany(e => e.Enderecos)
                .WithOne(p => p.PessoaFisica)
                .HasPrincipalKey(pk => pk.Id)
                .HasForeignKey(fk => fk.PessoaFisicaId);

            builder.ToTable(nameof(PessoaFisica));
        }
    }
}
