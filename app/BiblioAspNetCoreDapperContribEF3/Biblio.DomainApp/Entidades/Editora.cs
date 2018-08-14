using System.Collections.Generic;

namespace Biblio.DomainApp.Entidades
{
    public class Editora
    {
        public int EditoraId { get; private set; } = 0;
        public string Nome { get; private set; } = "";

        public List<Livro> Livros { get; private set; } //1 Editora possui N Livros

        private Editora()
        {
        }

        public Editora(string nome)
        {
            Nome = nome;
        }

        public void Alterar(string nome)
        {
            Nome = nome;
        }

        public void Alterar(Editora editora)
        {
            Alterar(editora.Nome);
        }
    }
}
