using Siscola.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Dominio
{
    public class Especialidade : Entidade
    {
        public string Nome { get; private set; }
        public virtual IList<Disciplina> Disciplinas { get; private set; } = new List<Disciplina>();

        protected Especialidade()
        {
        }

        public Especialidade(string nome)
        {
            Nome = nome;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
    }
}
