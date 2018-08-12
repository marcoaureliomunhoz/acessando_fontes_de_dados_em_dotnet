using BiblioAspNetCoreEF1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioAspNetCoreEF1.Data.Configurations
{
    public class EditoraConfig : IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {
            builder.ToTable("Editora");

            builder.HasKey(x => x.EditoraId);

            builder.Property(x => x.Nome).HasMaxLength(Editora.NomeMaxLength);
        }
    }
}
