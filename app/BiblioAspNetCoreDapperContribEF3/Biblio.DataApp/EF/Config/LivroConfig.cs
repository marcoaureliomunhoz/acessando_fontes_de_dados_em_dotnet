using Biblio.DomainApp.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblio.DataApp.EF.Config
{
    public class LivroConfig : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");

            builder.HasKey(x => x.LivroId);

            builder.HasOne(x => x.Editora).WithMany(x => x.Livros);

            //ignore
            //builder.Ignore(x => x.Problemas);
            builder.Ignore(x => x.Autores);
        }
    }
}
