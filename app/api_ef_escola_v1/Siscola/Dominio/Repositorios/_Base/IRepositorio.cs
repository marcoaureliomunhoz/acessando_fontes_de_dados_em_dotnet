using Microsoft.EntityFrameworkCore.Query;
using Siscola.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Siscola.Dominio.Repositorios._Base
{
    public class ExpressaoDeOrdenacao<TEntidade> where TEntidade : Entidade
    {
        public bool Ordenar { get; private set; } = false;
        public List<Expression<Func<TEntidade, object>>> Expressoes { get; private set; } = null;

        public ExpressaoDeOrdenacao(bool ordenar, List<Expression<Func<TEntidade, object>>> expressoes)
        {
            Ordenar = ordenar;
            Expressoes = expressoes;
        }
    }

    public class ExpressaoDeConsulta<TEntidade> where TEntidade : Entidade
    {
        public bool Consultar { get; private set; } = false;
        public Expression<Func<TEntidade, bool>> Expressao { get; private set; } = null;

        public ExpressaoDeConsulta(bool consultar, Expression<Func<TEntidade, bool>> expressao)
        {
            Consultar = consultar;
            Expressao = expressao;
        }
    }

    public interface IRepositorio<TEntidade> where TEntidade : Entidade
    {
        TEntidade Retornar(int id);
        List<TEntidade> Listar();
        List<TEntidade> Filtrar(
            List<ExpressaoDeConsulta<TEntidade>> expressoesDeConsulta,
            Func<IQueryable<TEntidade>, IIncludableQueryable<TEntidade, object>> expressaoDeInclusao,
            List<ExpressaoDeOrdenacao<TEntidade>> expressoesDeOrdenacao,
            string propriedadeDeOrdenacao,
            TipoOrdem ordem,
            int pagina,
            int itensPorPagina);
        int Salvar(TEntidade entidade);
        void RemoverTodos();
        void Remover(int id);
    }
}
