using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locar.Domain.Entities;
using Locar.Domain.Repositories;
using Locar.Infra.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Locar.Infra.Data.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly ILocarMongoContext _context;

        public VeiculoRepository(ILocarMongoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Veiculo>> GetAll()
        {
            return await _context.Veiculos.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Veiculo> Get(Guid id)
        {
            return await _context.Veiculos.Find(v => v.Id == id).FirstOrDefaultAsync();
        }

        public async Task Insert(Veiculo veiculo)
        {
            await _context.Veiculos.InsertOneAsync(veiculo);
        }

        public async Task Update(Guid id, Veiculo veiculoAlterado)
        {
            var veiculo = await Get(id);
            veiculo.Marca = veiculoAlterado.Marca;
            veiculo.Modelo = veiculoAlterado.Modelo;
            await _context.Veiculos.ReplaceOneAsync(v => v.Id == id, veiculo);
        }

        public async Task SetModelo(Guid id, string modelo)
        {
            await _context.Veiculos.FindOneAndUpdateAsync(
                v => v.Id == id,
                Builders<Veiculo>.Update.Set(v => v.Modelo, modelo)
            );
        }

        /*************************************************************************************/

        public async Task InsertPrecoPorVeiculo(Guid id, Preco preco)
        {
            var veiculo = await Get(id);
            veiculo.Precos.Add(preco);
            await _context.Veiculos.ReplaceOneAsync(v => v.Id == id, veiculo);
        }

        public async Task InsertPrecoSemVeiculo(Guid id, Preco preco)
        {
            var filter = Builders<Veiculo>.Filter.Eq(v => v.Id, id);

            var update = Builders<Veiculo>.Update.Push<Preco>(v => v.Precos, preco);

            await _context.Veiculos.FindOneAndUpdateAsync(filter, update);
        }

        public async Task UpdateUltimoPrecoPorVeiculo(Guid id, Preco preco)
        {
            var veiculo = await Get(id);
            var ultimoPreco = veiculo.Precos.Last();
            ultimoPreco.Valor = preco.Valor;
            await _context.Veiculos.ReplaceOneAsync(v => v.Id == id, veiculo);
        }

        public async Task SetUltimoPrecoSemVeiculo(Guid id, Preco preco)
        {
            await _context.Veiculos.FindOneAndUpdateAsync(
                v => v.Id == id,
                Builders<Veiculo>.Update.Set(v => v.Precos.ElementAt(-1).Valor, preco.Valor)
            );
        }
    }
}