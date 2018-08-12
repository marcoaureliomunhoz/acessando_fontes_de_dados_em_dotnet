using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Infra.FontesDados._Fontes.Tabelas
{
    public class TabEditora
    {
        public int EditoraId { get; set; } = 0;
        public string Nome { get; set; } = "";

        [Computed]
        public List<TabLivro> Livros { get; set; }
    }
}
