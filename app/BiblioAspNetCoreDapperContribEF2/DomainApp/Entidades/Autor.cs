namespace DomainApp.Entidades
{
    public class Autor : _Base.Entidade
    {
        private int _autorId { get; set; } = 0;
        public int AutorId { get => _autorId; }

        public const int NomeMax = 100;
        public const int NomeMin = 3;
        private string _nome { get; set; } = "";
        public string Nome { get => _nome; }

        public Autor(int autorId, string nome)
        {
            _autorId = autorId;
            _nome = nome;
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
