using Siscola.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Siscola.Dominio.Repositorios._Base
{
    public class FiltroBuilder<TEntidade> where TEntidade : Entidade
    {


        public static FiltroBuilder<TEntidade> Novo()
        {
            return new FiltroBuilder<TEntidade>();
        }

        public FiltroBuilder<TEntidade> Filtro(Expression<Func<TEntidade, bool>> predicado)
        {
            return this;
        }
    }
}
