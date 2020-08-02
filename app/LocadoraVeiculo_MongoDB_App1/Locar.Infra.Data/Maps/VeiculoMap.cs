using Locar.Domain.Entities;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Locar.Infra.Data.Maps
{
    public class VeiculoMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Veiculo>(map =>{
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id).SetIdGenerator(CombGuidGenerator.Instance);
                map.MapMember(x => x.Marca).SetIsRequired(true);
                map.MapMember(x => x.Modelo).SetIsRequired(true);
                map.MapMember(x => x.Precos).SetIsRequired(true);
            });
        }
    }
}