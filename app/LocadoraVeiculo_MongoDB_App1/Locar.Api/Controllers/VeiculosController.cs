using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locar.Domain.Entities;
using Locar.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Locar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly ILogger<VeiculosController> _logger;
        private readonly IVeiculoRepository _repository;

        public VeiculosController(
            ILogger<VeiculosController> logger,
            IVeiculoRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Veiculo>> Get()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Veiculo> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpPost]
        public async Task Post(Veiculo veiculo)
        {
            await _repository.Insert(veiculo);
        }

        [HttpPut("{id}")]
        public async Task Put(Guid id, Veiculo novoVeiculo)
        {
            await _repository.Update(id, novoVeiculo);
        }

        [HttpPut("set-modelo/{id}")]
        public async Task SetModelo(Guid id, string modelo)
        {
            await _repository.SetModelo(id, modelo);
        }
    }
}
