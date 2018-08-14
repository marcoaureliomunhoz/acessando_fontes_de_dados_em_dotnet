using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.Fontes
{
    [Table("Editora")]
    public class TabEditora
    {
        public int EditoraId { get; set; } = 0;
        public string Nome { get; set; } = "";

        [Computed]
        public List<TabLivro> Livros { get; set; }
    }
}
