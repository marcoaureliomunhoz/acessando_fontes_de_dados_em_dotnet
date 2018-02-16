using System.Collections.Generic;

namespace WindowsFormsApp1.Entidades
{
    public class Autor
    {
        public int AutorId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }

        public Autor()
        {
            Livros = new List<Livro>();
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
