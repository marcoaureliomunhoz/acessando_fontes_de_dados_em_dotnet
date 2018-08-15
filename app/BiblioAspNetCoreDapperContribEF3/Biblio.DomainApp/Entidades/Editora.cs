using System.Collections.Generic;

namespace Biblio.DomainApp.Entidades
{
    public class Editora : _Base.Entidade
    {
        public int EditoraId { get; private set; } = 0;

        public const int NOME_TAM_MAX = 100;
        public const int NOME_TAM_MIN = 3;
        public string Nome { get; private set; } = "";

        public List<Livro> Livros { get; private set; } //1 Editora possui N Livros        

        private Editora()
        {
        }

        private void Validar()
        {
            ValidarTamanhoMin(Nome, NOME_TAM_MIN, $"O nome de ter no mínimo {NOME_TAM_MIN} caracteres.");
            ValidarTamanhoMax(Nome, NOME_TAM_MAX, $"O nome de ter no máximo {NOME_TAM_MAX} caracteres.");
        }

        public Editora(string nome)
        {
            Nome = nome;
            Validar();
        }

        public void Alterar(string nome)
        {
            Nome = nome;
            Validar();
        }

        public void Alterar(Editora editora)
        {
            Alterar(editora.Nome);
        }
    }
}
