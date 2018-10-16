using Siscola.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Dominio
{
    public class Curso : Entidade
    {
        public string Titulo { get; private set; }
        public string Detalhes { get; private set; }

        public virtual IList<DisciplinaCurso> Disciplinas { get; private set; } = new List<DisciplinaCurso>();
        public virtual IList<Matricula> Matriculas { get; private set; } = new List<Matricula>();

        protected Curso()
        {
        }

        public Curso(string titulo, string detalhes)
        {
            Titulo = titulo;
            Detalhes = detalhes;
        }

        public void AlterarTitulo(string titulo)
        {
            Titulo = titulo;
        }

        public void AlterarDetalhes(string detalhes)
        {
            Detalhes = detalhes;
        }

        public void AdicionarDisciplina(DisciplinaCurso disciplina)
        {
            Disciplinas.Add(disciplina);
        }

        public void RemoverDisciplina(DisciplinaCurso disciplina)
        {
            var item = Disciplinas.FirstOrDefault(x => x.DisciplinaId == disciplina.DisciplinaId && x.CursoId == disciplina.CursoId);
            if (item != null)
                Disciplinas.Remove(item);
        }
    }
}
