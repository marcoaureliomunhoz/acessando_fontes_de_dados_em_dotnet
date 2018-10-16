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
    public class PessoaJuridicaMapping : EntityTypeConfiguration<PessoaJuridica>
    {
        public override void Map(EntityTypeBuilder<PessoaJuridica> builder)
        {
            builder.Property(x => x.RazaoSocial)
                .IsRequired()
                .HasMaxLength(Constantes.TamMaxNomeComum);

            builder.Property(x => x.NomeFantasia)
                .HasMaxLength(Constantes.TamMaxNomeComum);

            builder.Property(x => x.CNPJ)
                .IsRequired()
                .HasMaxLength(Constantes.TamMaxCNPJ);

            builder.ToTable(nameof(PessoaJuridica));
        }
    }
}
