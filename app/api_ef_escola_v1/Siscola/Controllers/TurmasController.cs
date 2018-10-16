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
    [Route("api/Turmas")]
    public class TurmasController : Controller
    {
        private readonly IRepositorioDeTurmas _turmasRepositorio;

        public TurmasController(
            IRepositorioDeTurmas turmasRepositorio)
        {
            _turmasRepositorio = turmasRepositorio;
        }

        public List<Turma> Get()
        {
            return _turmasRepositorio.Listar();
        }
    }
}