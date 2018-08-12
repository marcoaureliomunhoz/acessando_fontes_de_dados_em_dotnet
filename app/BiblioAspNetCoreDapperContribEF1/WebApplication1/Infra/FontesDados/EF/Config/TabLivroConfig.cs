using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Infra.FontesDados._Fontes.Tabelas;

namespace WebApplication1.Infra.FontesDados.EF.Config
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
