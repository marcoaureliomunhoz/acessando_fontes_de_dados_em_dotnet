using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Dominio.Entidades
{
    public class Editora : _Base.Entidade, _Base.IEntidade
    {
        private int _editoraId { get; set; } = 0;
        public int EditoraId { get => _editoraId; }

        public const int NomeMax = 100;
        public const int NomeMin = 3;
        private string _nome { get; set; } = "";
        public string Nome { get => _nome; }

        private IList<Livro> _livros;
        public IReadOnlyCollection<Livro> Livros
        {
            get { return _livros.ToArray(); }
        }

        public Editora(int editoraId, string nome, List<Livro> livros)
        {
            _editoraId = editoraId;
            _nome = nome;

            _livros = new List<Livro>();
            if (livros != null)
                livros.ForEach(x => _livros.Add(
                    new Livro(x.LivroId, x.Titulo, null)));

            Validar();
        }

        private void Validar()
        {
            Init();
            ValidarTamanhoMin(_nome, NomeMin, $"O nome deve ter no mínimo {NomeMin} caracteres.");
            ValidarTamanhoMax(_nome, NomeMax, $"O nome deve ter no máximo {NomeMax} caracteres.");
        }
    }
}
