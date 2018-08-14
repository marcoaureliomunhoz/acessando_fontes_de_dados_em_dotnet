using DataApp.Fontes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.EF.Config
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
