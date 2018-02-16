using System.Collections.Generic;

namespace WindowsFormsApp1.Entidades
{
    public class Livro
    {
        public int LivroId { get; set; }
        public string Nome { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<Autor> Autores { get; set; }

        public Livro()
        {
            Autores = new List<Autor>();
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
