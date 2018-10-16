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
    public class ProfessorMapping : EntityTypeConfiguration<Professor>
    {
        public override void Map(EntityTypeBuilder<Professor> builder)
        {
            builder.Property(x => x.Usuario)
                .IsRequired()
                .HasMaxLength(Constantes.TamMaxUsuario);

            builder.Property(x => x.Senha)
                .IsRequired()
                .HasMaxLength(Constantes.TamMaxSenha);

            builder.ToTable(nameof(Professor));
        }
    }
}
