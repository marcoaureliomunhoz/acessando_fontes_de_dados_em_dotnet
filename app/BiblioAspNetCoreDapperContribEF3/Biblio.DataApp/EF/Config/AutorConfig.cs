using Biblio.DomainApp.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblio.DataApp.EF.Config
{
    public class AutorConfig : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autor");

            builder.HasKey(x => x.AutorId);

            //ignore
            //builder.Ignore(x => x.Problemas);
        }
    }
}
