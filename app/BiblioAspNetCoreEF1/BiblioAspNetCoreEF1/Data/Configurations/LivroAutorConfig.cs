using BiblioAspNetCoreEF1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioAspNetCoreEF1.Data.Configurations
{
    public class LivroAutorConfig : IEntityTypeConfiguration<LivroAutor>
    {
        public void Configure(EntityTypeBuilder<LivroAutor> builder)
        {
            builder.ToTable("Livro_Autor");

            builder.HasKey(x => new { x.LivroId, x.AutorId });
        }
    }
}
