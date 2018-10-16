using Siscola.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Dominio
{
    public class Turma : Entidade
    {
        public string Nome { get; private set; }
        public int Ano { get; private set; }

        public virtual IList<Matricula> Matriculas { get; private set; } = new List<Matricula>();

        protected Turma()
        {
        }

        public Turma(string nome, int ano)
        {
            Nome = nome;
            Ano = ano;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarAno(int ano)
        {
            Ano = ano;
        }
    }
}
