using Siscola.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Dominio
{
    public class Disciplina : Entidade
    {
        public string Nome { get; private set; }
        public string Detalhes { get; private set; }

        public virtual IList<DisciplinaCurso> Cursos { get; private set; } = new List<DisciplinaCurso>();

        public int EspecialidadeId { get; private set; }
        public virtual Especialidade Especialidade { get; private set; }

        protected Disciplina()
        {
        }

        public Disciplina(string nome, string detalhes, Especialidade especialidade)
        {
            Nome = nome;
            Detalhes = detalhes;
            Especialidade = especialidade;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarDetalhes(string detalhes)
        {
            Detalhes = detalhes;
        }

        public void AlterarEspecialidade(Especialidade especialidade)
        {
            EspecialidadeId = especialidade.Id;
            Especialidade = especialidade;
        }
    }
}
