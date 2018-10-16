using Siscola.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Dominio
{
    public class Matricula : Entidade
    {
        public DateTime DataDaMatricula { get; private set; }
        public string RA { get; private set; }

        public int AlunoId { get; private set; }
        public virtual PessoaFisica Aluno { get; private set; }

        public int CursoId { get; private set; }
        public virtual Curso Curso { get; private set; }

        public int TurmaId { get; private set; }
        public virtual Turma Turma { get; private set; }

        protected Matricula()
        {
        }

        public Matricula(Curso curso, PessoaFisica aluno, Turma turma)
        {
            Curso = curso;
            Aluno = aluno;
            Turma = turma;
            DataDaMatricula = DateTime.Now;
            RA = "";
        }

        public void DefinirRA()
        {
            RA = Turma.Id.ToString() + "." + Curso.Id.ToString() + "." + Aluno.Id.ToString();
        }
    }
}
