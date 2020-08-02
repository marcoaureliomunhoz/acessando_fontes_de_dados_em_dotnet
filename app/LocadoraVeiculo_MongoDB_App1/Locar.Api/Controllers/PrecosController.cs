using System;
using System.Threading.Tasks;
using Locar.Domain.Entities;
using Locar.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Locar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrecosController : ControllerBase
    {
        private readonly ILogger<PrecosController> _logger;
        private readonly IVeiculoRepository _repository;

        public PrecosController(
            ILogger<PrecosController> logger,
            IVeiculoRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("novo-por-veiculo/{veiculoId}")]
        public async Task NovoPorVeiculo(Guid veiculoId, Preco preco)
        {
            await _repository.InsertPrecoPorVeiculo(veiculoId, preco);
        }

        [HttpPost("novo-sem-veiculo/{veiculoId}")]
        public async Task NovoSemVeiculo(Guid veiculoId, Preco preco)
        {
            await _repository.InsertPrecoSemVeiculo(veiculoId, preco);
        }

        [HttpPut("update-ultimo-valor-por-veiculo/{veiculoId}")]
        public async Task AlteraUltimoValorPorVeiculo(Guid veiculoId, Preco preco)
        {
            await _repository.UpdateUltimoPrecoPorVeiculo(veiculoId, preco);
        }

        [HttpPut("set-ultimo-valor-sem-veiculo/{veiculoId}")]
        public async Task AlteraUltimoValorSemVeiculo(Guid veiculoId, Preco preco)
        {
            await _repository.SetUltimoPrecoSemVeiculo(veiculoId, preco);
        }
    }
}
