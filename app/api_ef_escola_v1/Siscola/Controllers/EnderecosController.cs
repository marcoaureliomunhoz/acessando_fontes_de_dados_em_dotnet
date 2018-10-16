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
    [Route("api/Enderecos")]
    public class EnderecosController : Controller
    {
        private readonly IRepositorioDeEnderecos _enderecosRepositorio;

        public EnderecosController(
            IRepositorioDeEnderecos enderecosRepositorio)
        {
            _enderecosRepositorio = enderecosRepositorio;
        }

        public List<Endereco> Get()
        {
            return _enderecosRepositorio.Listar();
        }
    }
}