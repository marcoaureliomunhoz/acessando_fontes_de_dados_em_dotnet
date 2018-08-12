using BiblioAspNetCoreEF1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioAspNetCoreEF1.Data.Configurations
{
    public class AutorConfig : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autor");

            builder.HasKey(x => x.AutorId);

            builder.Property(x => x.Nome).HasMaxLength(Autor.NomeMaxLength);
        }
    }
}
