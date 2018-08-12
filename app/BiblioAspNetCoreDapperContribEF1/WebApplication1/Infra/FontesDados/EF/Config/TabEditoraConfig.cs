using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Infra.FontesDados._Fontes.Tabelas;

namespace WebApplication1.Infra.FontesDados.EF.Config
{
    public class TabEditoraConfig : IEntityTypeConfiguration<TabEditora>
    {
        public void Configure(EntityTypeBuilder<TabEditora> builder)
        {
            builder.ToTable("Editora");

            builder.HasKey(x => x.EditoraId);

            builder.HasMany(x => x.Livros).WithOne(x => x.Editora);
        }
    }
}
