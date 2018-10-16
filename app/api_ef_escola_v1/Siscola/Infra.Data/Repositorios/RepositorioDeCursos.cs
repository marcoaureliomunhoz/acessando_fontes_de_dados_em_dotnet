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
    public class RepositorioDeCursos : Repositorio<Curso>, IRepositorioDeCursos
    {
        public RepositorioDeCursos(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        //public new List<Curso> Listar()
        //{
        //    return this.Set()
        //            .Include(curso => curso.Disciplinas)
        //                .ThenInclude(disciplinaCurso => disciplinaCurso.Disciplina)
        //                    .ThenInclude(disciplina => disciplina.Especialidade)                        
        //            .ToList();
        //}

        public override int Salvar(Curso entidade)
        {
            if (entidade.Id == 0)
            {
                this.Set().Add(entidade);
                return entidade.Id;
            }

            var cadastro = this.Retornar(entidade.Id);
            if (cadastro != null)
            {
                cadastro.AlterarTitulo(entidade.Titulo);
                cadastro.AlterarDetalhes(entidade.Detalhes);
                return 1;
            }

            return 0;
        }
    }
}
