using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Dominio
{
    public class DisciplinaCurso
    {
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
