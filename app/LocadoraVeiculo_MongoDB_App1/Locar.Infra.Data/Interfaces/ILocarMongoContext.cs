using Locar.Domain.Entities;
using MongoDB.Driver;

namespace Locar.Infra.Data.Interfaces
{
    public interface ILocarMongoContext : IMongoContext
    {
        IMongoCollection<Veiculo> Veiculos { get; }
    }
}