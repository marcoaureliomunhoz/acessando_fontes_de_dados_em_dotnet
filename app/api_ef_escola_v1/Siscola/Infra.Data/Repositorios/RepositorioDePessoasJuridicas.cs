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
    public class RepositorioDePessoasJuridicas : Repositorio<PessoaJuridica>, IRepositorioDePessoasJuridicas
    {
        public RepositorioDePessoasJuridicas(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
