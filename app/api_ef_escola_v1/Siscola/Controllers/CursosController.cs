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
    [Route("api/Cursos")]
    public class CursosController : Controller
    {
        private readonly IRepositorioDeCursos _cursosRepositorio;

        public CursosController(
            IRepositorioDeCursos cursosRepositorio)
        {
            _cursosRepositorio = cursosRepositorio;
        }

        public List<Curso> Get()
        {
            return _cursosRepositorio.Listar();
        }
    }
}