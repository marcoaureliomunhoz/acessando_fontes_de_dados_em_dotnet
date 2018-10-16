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
    [Route("api/Disciplinas")]
    public class DisciplinasController : Controller
    {
        private readonly IRepositorioDeDisciplinas _disciplinasRepositorio;

        public DisciplinasController(
            IRepositorioDeDisciplinas disciplinasRepositorio)
        {
            _disciplinasRepositorio = disciplinasRepositorio;
        }

        public List<Disciplina> Get()
        {
            return _disciplinasRepositorio.Listar();
        }
    }
}