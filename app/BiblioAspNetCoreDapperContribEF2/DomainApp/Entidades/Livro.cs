using System.Collections.Generic;
using System.Linq;

namespace DomainApp.Entidades
{
    public class Livro : _Base.Entidade
    {
        private int _livroId { get; set; } = 0;
        public int LivroId { get => _livroId; }

        public const int TituloMax = 100;
        public const int TituloMin = 3;
        private string _titulo { get; set; } = "";
        public string Titulo { get => _titulo; }

        private IList<Autor> _autores;
        public IReadOnlyCollection<Autor> Autores
        {
            get { return _autores.ToArray(); }
        }

        public Livro(int livroId, string titulo, List<Autor> autores)
        {
            _livroId = livroId;
            _titulo = titulo;

            _autores = new List<Autor>();
            if (autores != null)
                autores.ForEach(x => _autores.Add(
                    new Autor(x.AutorId, x.Nome)));

            Validar();
        }

        private void Validar()
        {
            Init();
            ValidarTamanhoMin(_titulo, TituloMin, $"O título deve ter no mínimo {TituloMin} caracteres.");
            ValidarTamanhoMax(_titulo, TituloMax, $"O título deve ter no máximo {TituloMax} caracteres.");
        }
    }
}
