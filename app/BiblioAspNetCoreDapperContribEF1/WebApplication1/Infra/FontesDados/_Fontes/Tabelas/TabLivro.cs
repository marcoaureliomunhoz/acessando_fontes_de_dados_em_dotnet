using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Infra.FontesDados._Fontes.Tabelas
{
    [Table("dbo.Livro")]
    public class TabLivro
    {
        [Key]
        public int LivroId { get; set; } = 0;
        public string Titulo { get; set; } = "";

        [Computed]
        public TabEditora Editora { get; set; }
    }
}
