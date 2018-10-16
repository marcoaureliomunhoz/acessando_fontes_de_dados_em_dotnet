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
    [Route("api/Especialidades")]
    public class EspecialidadesController : Controller
    {
        private readonly IRepositorioDeEspecialidades _especialidadesRepositorio;

        public EspecialidadesController(
            IRepositorioDeEspecialidades especialidadesRepositorio)
        {
            _especialidadesRepositorio = especialidadesRepositorio;
        }

        public List<Especialidade> Get()
        {
            return _especialidadesRepositorio.Listar();
        }
    }
}