using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Siscola.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Infra.Data.Mapeamentos._Base
{
    public class EntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : Entidade
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            Map(builder);
        }

        public virtual void Map(EntityTypeBuilder<T> builder)
        {
        }
    }
}
