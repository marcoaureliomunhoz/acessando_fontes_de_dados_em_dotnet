using Dapper.FluentMap.Dommel.Mapping;
using WebApplication1.Infra.FontesDados._Fontes.Tabelas;

namespace WebApplication1.Infra.FontesDados.Dapper.Map
{
    public class TabLivroMap : DommelEntityMap<TabLivro>
    {
        public TabLivroMap()
        {
            ToTable("Livro");
            Map(x => x.LivroId).IsKey().IsIdentity();
        }
    }
}
