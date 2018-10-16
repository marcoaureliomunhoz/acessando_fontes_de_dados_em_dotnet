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
    public class EnderecoMapping : EntityTypeConfiguration<Endereco>
    {
        public override void Map(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(x => x.Logradouro)
                .IsRequired()
                .HasMaxLength(Constantes.TamMaxNomeRua);

            builder.Property(x => x.Bairro)
                .IsRequired()
                .HasMaxLength(Constantes.TamMaxNomeBairro);

            builder.Property(x => x.Numero)
                .HasMaxLength(Constantes.TamMaxNumero);

            builder.Property(x => x.Tipo)
                .IsRequired();

            builder.HasOne(c => c.Cidade)
                .WithMany(e => e.Enderecos)
                .HasPrincipalKey(pk => pk.Id) //lá em cidade
                .HasForeignKey(fk => fk.CidadeId); //aqui em endereço

            builder.ToTable(nameof(Endereco));
        }
    }
}
