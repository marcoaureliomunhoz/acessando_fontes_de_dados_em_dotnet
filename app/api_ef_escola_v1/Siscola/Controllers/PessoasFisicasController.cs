using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siscola.Dominio;
using Siscola.Dominio.Repositorios;

namespace Siscola.Controllers
{
    [Produces("application/json")]
    [Route("api/PessoasFisicas")]
    public class PessoasFisicasController : Controller
    {
        private readonly IRepositorioDePessoasFisicas _pessoasFisicasRepositorio;

        public PessoasFisicasController(
            IRepositorioDePessoasFisicas pessoasFisicasRepositorio)
        {
            _pessoasFisicasRepositorio = pessoasFisicasRepositorio;
        }

        public List<PessoaFisica> Get()
        {
            return _pessoasFisicasRepositorio.Listar();
        }
    }
}