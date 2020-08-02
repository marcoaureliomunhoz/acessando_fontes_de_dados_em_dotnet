using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Locar.Domain.Entities;

namespace Locar.Domain.Repositories
{
    public interface IVeiculoRepository
    {
         Task<IEnumerable<Veiculo>> GetAll();
         Task<Veiculo> Get(Guid id);
         Task Insert(Veiculo veiculo);
         Task Update(Guid id, Veiculo veiculoAlterado);

         Task InsertPrecoPorVeiculo(Guid veiculoId, Preco preco);
         Task InsertPrecoSemVeiculo(Guid id, Preco preco);
         Task UpdateUltimoPrecoPorVeiculo(Guid id, Preco preco);
         Task SetUltimoPrecoSemVeiculo(Guid id, Preco preco);
         Task SetModelo(Guid id, string modelo);
    }
}