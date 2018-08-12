using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioAspNetCoreEF1.Models
{
    public class Editora
    {
        public int EditoraId { get; set; } = 0;

        public const int NomeMaxLength = 100;
        public string Nome { get; set; } = "";

        public ICollection<Livro> Livros { get; set; }
    }
}
