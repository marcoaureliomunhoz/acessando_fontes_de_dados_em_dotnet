using Microsoft.EntityFrameworkCore;
using Siscola.Dominio;
using Siscola.Dominio.Repositorios;
using Siscola.Dominio.Repositorios._Base;
using Siscola.Infra.Data.Repositorios._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Infra.Data.Repositorios
{
    public class RepositorioDeMatriculas : Repositorio<Matricula>, IRepositorioDeMatriculas
    {
        public RepositorioDeMatriculas(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public new List<Matricula> Listar()
        {
            return this.Set()
                    .Include(matricula => matricula.Aluno)
                    .Include(matricula => matricula.Curso)
                    .Include(matricula => matricula.Turma)
                    .ToList();
        }

        public override int Salvar(Matricula entidade)
        {
            if (entidade.Id == 0)
            {
                this.Set().Add(entidade);
                return entidade.Id;
            }

            var cadastro = this.Retornar(entidade.Id);
            if (cadastro != null)
            {
                cadastro.DefinirRA();
                //cadastro.AlterarDetalhes(entidade.Detalhes);
                return 1;
            }

            return 0;
        }
    }
}
