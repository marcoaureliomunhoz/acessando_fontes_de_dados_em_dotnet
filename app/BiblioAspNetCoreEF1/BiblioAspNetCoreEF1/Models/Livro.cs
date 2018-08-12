using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioAspNetCoreEF1.Models
{
    public class Livro
    {
        public int LivroId { get; set; } = 0;
        public string Titulo { get; set; } = "";

        public Editora Editora { get; set; }
        //public List<Autor> Autores { get; set; }

        public Livro()
        {
        }

        public Livro(int id, string titulo, Editora editora)
        {
            this.LivroId = id;
            this.Titulo = titulo;
            this.Editora = editora;
        }
    }
}
