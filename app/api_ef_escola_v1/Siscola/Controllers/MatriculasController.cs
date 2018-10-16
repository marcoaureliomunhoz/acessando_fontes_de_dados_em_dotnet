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
    [Route("api/Matriculas")]
    public class MatriculasController : Controller
    {
        private readonly IRepositorioDeMatriculas _matriculasRepositorio;

        public MatriculasController(
            IRepositorioDeMatriculas matriculasRepositorio)
        {
            _matriculasRepositorio = matriculasRepositorio;
        }

        public List<Matricula> Get()
        {
            return _matriculasRepositorio.Listar();
        }
    }
}