using BiblioAspNetCoreEF1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioAspNetCoreEF1.Data.Configurations
{
    public class LivroConfig : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");

            builder.HasKey(x => x.LivroId);

            builder.HasOne(x => x.Editora).WithMany(x => x.Livros);
        }
    }
}
