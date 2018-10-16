using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siscola.Dominio;
using Siscola.Dominio.Dtos;
using Siscola.Dominio.Repositorios;

namespace Siscola.Controllers
{
    [Produces("application/json")]
    [Route("api/Professores")]
    public class ProfessoresController : Controller
    {
        private readonly IRepositorioDeProfessores _professoresRepositorio;

        public ProfessoresController(
            IRepositorioDeProfessores professoresRepositorio)
        {
            _professoresRepositorio = professoresRepositorio;
        }

        public List<Professor> Get()
        {
            return _professoresRepositorio.Listar();
        }

        [HttpGet("itensDeLista")]
        public List<ItemListaDeProfessor> ItensDeLista()
        {
            return _professoresRepositorio.ListarItens();
        }
    }
}