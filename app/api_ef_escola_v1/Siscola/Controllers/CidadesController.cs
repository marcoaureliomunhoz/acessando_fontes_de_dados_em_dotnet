using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Siscola.Dominio;
using Siscola.Dominio.Filtros;
using Siscola.Dominio.Repositorios;
using Siscola.Dominio.Repositorios._Base;

namespace Siscola.Controllers
{
    [Produces("application/json")]
    [Route("api/Cidades")]
    public class CidadesController : Controller
    {
        private readonly IRepositorioDeCidades _cidadesRepositorio;

        public CidadesController(
            IRepositorioDeCidades cidadesRepositorio)
        {
            _cidadesRepositorio = cidadesRepositorio;
        }

        public List<Cidade> Get()
        {
            return _cidadesRepositorio.Listar();
        }

        [HttpGet("{id}")]
        public Cidade Get(int id)
        {
            return _cidadesRepositorio.Retornar(id);
        }

        [HttpPost("Onde")]
        public List<Cidade> Onde([FromBody] FiltroCidade filtro)
        {
            return _cidadesRepositorio.Filtrar(
                new List<ExpressaoDeConsulta<Cidade>>
                {
                    new ExpressaoDeConsulta<Cidade>(filtro.Id > 0, x => x.Id == filtro.Id),
                    new ExpressaoDeConsulta<Cidade>(filtro.Nome.Length > 0, x => x.Nome.Contains(filtro.Nome))
                },
                null,
                new List<ExpressaoDeOrdenacao<Cidade>>
                {
                    new ExpressaoDeOrdenacao<Cidade>(
                        filtro.Ordenador.ToLower() == "nome", 
                        new List<Expression<Func<Cidade, object>>>
                        {
                            x => x.Nome
                        }
                    ),
                    new ExpressaoDeOrdenacao<Cidade>(
                        filtro.Ordenador.ToLower() == "uf,nome",
                        new List<Expression<Func<Cidade, object>>>
                        {
                            x => x.UF,
                            x => x.Nome
                        }
                    )
                },
                "",
                filtro.OrdenarDecrescente ? TipoOrdem.Decrescente : TipoOrdem.Crescente,
                filtro.Pagina,
                filtro.ItensPorPagina
            );
        }
    }
}