using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Infra.FontesDados._Fontes.Tabelas;

namespace WebApplication1.Infra.FontesDados.EF.Config
{
    public class TabAutorConfig : IEntityTypeConfiguration<TabAutor>
    {
        public void Configure(EntityTypeBuilder<TabAutor> builder)
        {
            builder.ToTable("Autor");

            builder.HasKey(x => x.AutorId);
        }
    }
}
