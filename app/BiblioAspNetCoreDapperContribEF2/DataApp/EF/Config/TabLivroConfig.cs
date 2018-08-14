using DataApp.Fontes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.EF.Config
{
    public class TabLivroConfig : IEntityTypeConfiguration<TabLivro>
    {
        public void Configure(EntityTypeBuilder<TabLivro> builder)
        {
            builder.ToTable("Livro");

            builder.HasKey(x => x.LivroId);
        }
    }
}
