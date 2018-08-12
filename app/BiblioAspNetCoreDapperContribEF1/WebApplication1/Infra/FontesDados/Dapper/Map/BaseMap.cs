using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace WebApplication1.Infra.FontesDados.Dapper.Map
{
    public class BaseMap
    {
        public BaseMap()
        {
            //RealizeMap();
        }

        protected void RealizeMap()
        {
            if (FluentMapper.EntityMaps.IsEmpty)
            {
                FluentMapper.Initialize(c =>
                {
                    c.AddMap(new Map.TabLivroMap());
                    c.ForDommel();
                });
            }
        }
    }
}
