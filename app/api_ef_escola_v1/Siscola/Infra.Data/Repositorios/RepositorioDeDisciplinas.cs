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
    public class RepositorioDeDisciplinas : Repositorio<Disciplina>, IRepositorioDeDisciplinas
    {
        public RepositorioDeDisciplinas(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public new List<Disciplina> Listar()
        {
            return this.Set()
                    .Include(disciplina => disciplina.Especialidade)
                    .ToList();
        }

        public override int Salvar(Disciplina entidade)
        {
            if (entidade.Id == 0)
            {
                this.Set().Add(entidade);
                return entidade.Id;
            }

            var cadastro = this.Retornar(entidade.Id);
            if (cadastro != null)
            {
                cadastro.AlterarNome(entidade.Nome);
                cadastro.AlterarDetalhes(entidade.Detalhes);
                cadastro.AlterarEspecialidade(entidade.Especialidade);
                return 1;
            }

            return 0;
        }
    }
}
