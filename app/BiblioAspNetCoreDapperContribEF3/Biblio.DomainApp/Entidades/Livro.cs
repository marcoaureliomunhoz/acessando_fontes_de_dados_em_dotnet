using System;
using System.Collections.Generic;
using System.Text;

namespace Biblio.DomainApp.Entidades
{
    public class Livro
    {
        public int LivroId { get; private set; } = 0;
        public string Titulo { get; private set; } = "";

        public Editora Editora { get; private set; } //1 Livro possui 1 Editora
        public List<Autor> Autores { get; private set; } = new List<Autor>(); //1 Livro possui N Autores

        private Livro()
        {
        }

        public Livro(string titulo, Editora editora)
        {
            Titulo = titulo;
            Editora = editora;
        }

        public void Alterar(string titulo, Editora editora)
        {
            Titulo = titulo;
            Editora = editora;
        }

        public void AdicAutores(List<Autor> autores)
        {
            if (autores != null)
                Autores.AddRange(autores);
        }

        public void AdicAutor(Autor autor)
        {
            if (autor != null)
                Autores.Add(autor);
        }
    }
}
