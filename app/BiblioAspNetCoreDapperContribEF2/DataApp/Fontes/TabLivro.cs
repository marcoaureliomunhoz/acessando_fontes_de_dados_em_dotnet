using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.Fontes
{
    [Table("Livro")]
    public class TabLivro
    {
        [Key]
        public int LivroId { get; set; } = 0;
        public string Titulo { get; set; } = "";

        [Computed]
        public TabEditora Editora { get; set; }
    }
}
