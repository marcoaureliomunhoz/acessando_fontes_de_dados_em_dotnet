using Locar.Infra.Data.Interfaces;
using Locar.Infra.Data.Maps;
using MongoDB.Driver;
using Locar.Infra.Data.Configurations;
using System.Collections.Generic;
using Locar.Domain.Entities;

namespace Locar.Infra.Data.Contexts
{
    public class LocarMongoContext : ILocarMongoContext
    {
        private IMongoDatabase _database;
        private MongoClient _mongoClient;
        private ILocarMongoDatabaseSettings _settings;

        public LocarMongoContext(ILocarMongoDatabaseSettings settings)
        {
            _settings = settings;
        }

        private IMongoCollection<Veiculo> _veiculos;
        public IMongoCollection<Veiculo> Veiculos
        { 
            get 
            {
                Map();
                Configure();
                if (_veiculos == null) _veiculos = _database.GetCollection<Veiculo>("Veiculos");
                return _veiculos;
            }
        }

        private void Configure()
        {
            if (_mongoClient == null)
            {
                _mongoClient = new MongoClient(_settings.ConnectionString);
            }

            if (_database == null && _mongoClient != null)
            {
                _database = _mongoClient.GetDatabase(_settings.DatabaseName);
            }
        }

        private void Map()
        {
            if (_mongoClient == null)
            {
                VeiculoMap.Configure(); 
            }
        }
    }
}