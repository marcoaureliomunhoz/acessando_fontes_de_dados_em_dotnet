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
    public class RepositorioDeCidades : Repositorio<Cidade>, IRepositorioDeCidades
    {
        public RepositorioDeCidades(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override int Salvar(Cidade entidade)
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
                cadastro.AlterarUF(entidade.UF);
                return 1;
            }

            return 0;
        }
    }
}
