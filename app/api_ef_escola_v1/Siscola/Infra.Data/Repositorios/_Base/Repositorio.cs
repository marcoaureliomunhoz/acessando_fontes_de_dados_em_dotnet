using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Siscola.Dominio._Base;
using Siscola.Dominio.Repositorios._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Siscola.Infra.Data.Repositorios._Base
{
    public abstract class Repositorio<TEntidade> : IRepositorio<TEntidade> where TEntidade : Entidade
    {
        private readonly IUnitOfWork _unitOfWork;

        public Repositorio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DbSet<TEntidade> Set()
        {
            return _unitOfWork.Set<TEntidade>();
        }

        public DbContext Ctx()
        {
            return (_unitOfWork as UnitOfWork).Ctx();
        }

        public TEntidade Retornar(int id)
        {
            return Set().FirstOrDefault(x => x.Id == id);
        }

        public List<TEntidade> Listar()
        {
            return Set().ToList();
        }

        private readonly MethodInfo OrderByMethod = typeof(Queryable).GetMethods().Single(method => method.Name == "OrderBy" && method.GetParameters().Length == 2);
        private readonly MethodInfo OrderByDescendingMethod = typeof(Queryable).GetMethods().Single(method => method.Name == "OrderByDescending" && method.GetParameters().Length == 2);

        public List<TEntidade> Filtrar(
            List<ExpressaoDeConsulta<TEntidade>> expressoesDeConsulta,
            Func<IQueryable<TEntidade>, IIncludableQueryable<TEntidade, object>> expressaoDeInclusao,
            List<ExpressaoDeOrdenacao<TEntidade>> expressoesDeOrdenacao,
            string propriedadeDeOrdenacao,
            TipoOrdem ordem,
            int pagina,
            int itensPorPagina)
        {
            var retorno = Set().AsQueryable();

            if (expressoesDeConsulta != null && expressoesDeConsulta.Count > 0 && expressoesDeConsulta.Count(x => x.Consultar == true) > 0)
            {
                foreach (var expressaoDeConsulta in expressoesDeConsulta.Where(x => x.Consultar == true))
                {
                    retorno = retorno.Where(expressaoDeConsulta.Expressao);
                }
            }

            if (expressaoDeInclusao != null)
                retorno = expressaoDeInclusao(retorno);

            if (expressoesDeOrdenacao != null && expressoesDeOrdenacao.Count > 0 && expressoesDeOrdenacao.Count(x => x.Ordenar == true) > 0)
            {
                var primeiraExpressaoDeOrdenacaoValida = expressoesDeOrdenacao.First(x => x.Ordenar == true).Expressoes;
                retorno = ordem == TipoOrdem.Decrescente
                    ? retorno.OrderByDescending(primeiraExpressaoDeOrdenacaoValida[0])
                    : retorno.OrderBy(primeiraExpressaoDeOrdenacaoValida[0]);
                if (primeiraExpressaoDeOrdenacaoValida.Count > 1)
                {
                    for (int i = 1; i < primeiraExpressaoDeOrdenacaoValida.Count; i++)
                    {
                        retorno = ordem == TipoOrdem.Decrescente
                            ? (retorno as IOrderedQueryable<TEntidade>).ThenByDescending(primeiraExpressaoDeOrdenacaoValida[i])
                            : (retorno as IOrderedQueryable<TEntidade>).ThenBy(primeiraExpressaoDeOrdenacaoValida[i]);
                    }
                }
            }
            else if (!string.IsNullOrEmpty(propriedadeDeOrdenacao))
            {
                ParameterExpression paramterExpression = Expression.Parameter(typeof(TEntidade));
                Expression orderByProperty = Expression.Property(paramterExpression, propriedadeDeOrdenacao);
                LambdaExpression lambda = Expression.Lambda(orderByProperty, paramterExpression);
                MethodInfo genericMethod = ordem == TipoOrdem.Decrescente
                    ? OrderByDescendingMethod.MakeGenericMethod(typeof(TEntidade), orderByProperty.Type)
                    : OrderByMethod.MakeGenericMethod(typeof(TEntidade), orderByProperty.Type);
                object retornoOrdenado = genericMethod.Invoke(null, new object[] { retorno, lambda });
                retorno = (IQueryable<TEntidade>)retornoOrdenado;
            }

            if (pagina > 0 && itensPorPagina > 0)
            {
                var skip = (pagina - 1) * itensPorPagina;
                retorno = retorno.Skip(skip).Take(itensPorPagina);
            }

            return retorno.ToList();
        }

        public virtual int Salvar(TEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            var cadastro = Retornar(id);
            if (cadastro != null)
            {
                Set().Remove(cadastro);
            }
        }

        public void RemoverTodos()
        {
            foreach (var cadastro in Listar())
            {
                Set().Remove(cadastro);
            }
        }

        public void Commit()
        {
            this.Commit();
        }

        public void Rollback()
        {
            this.Rollback();
        }

    }
}
