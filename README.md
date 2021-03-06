# Acessando Fontes de Dados em .NET

**ADO.NET**  
Conjunto de classes e interfaces de acesso a fontes dados locais e remotos. A fonte de dados pode ser uma base de dados ou um arquivo XML por exemplo.

- Principais classes do ADO.NET: 

Classe | Descrição
--- | ---
**Connection** | Responsável por fazer a comunicação com a fonte de dados.
**Command** | Serve para a definição e para a compilação de instruções SQL.
**DataReader** | Otimizada para leitura unidirecional de bases de dados. Quando de trata de leitura é o recurso mais rápido que se tem. Apesar de não ser navegável, a conexão fica aberta, o que favorece a atualização de dados em tempo real.
**DataSet** | Nos fornece uma série de recursos para acesso e manipulação de dados independente de qual seja a fonte. Internamente o DataSet possui uma collection de **DataTables**, o que nos permite vincular a um único DataSet várias fontes de dados. Diferentemente de DataReader, DataSet não prioriza performance e sim, quantidade de recursos. Com DataSet é possível alterar, inserir, excluir, ler e navegar pelos dados. É importante salientar que as alterações não são persistidas na fonte de dados, tudo ocorre apenas em memória. DataSet é útil, por exemplo, quando se deseja gerar um relatório que necessite de um processamento pesado. Em vez de realizar o processamento no servidor podemos trazer os dados para a memória do dispositivo cliente e neste sim, processar e gerar o relatório.
**DataAdapter** | Serve como ponte entre bases de dados e o DataSet. Não tem como carregar uma tabela diretamente através do DataSet, primeiro realiza-se a leitura da tabela através de um Command e depois realiza-se o preenchimento do DataSet através do DataAdapter. Portanto se for necessário manipular em memória os dados de uma tabela precisamos de um DataAdapter.

- Namespaces básicos:

Namespace | Descrição
--- | --- 
**System.Data** | pacote de classes fundamentais de acesso a dados, como **DataSet** e **DataReader**.
**System.Data.SqlTypes** | pacotes de classes que representam tipos de dados comuns em bases de dados e que o .NET não possui nativamente. Um exemplo é a classe **SqlMoney**.

- APIs de baixo nível para conexão com fontes de dados:
    - OLE DB: desenvolvida e mantida pela própria Microsoft.
    - ODBC: padrão baseado em **drivers** nativos.
    - Providers Nativos: apis nativas.

**Frameworks de Acesso a Dados ou ORMs**  
O acesso a dados através de ADO.NET, apesar de ser mais performático, é complexo e custoso. Em certas ocasiões não há necessidade de se priorizar performance. É neste cenário que surgem os frameworks ORMs, eles abstraem a complexidade das opeações de acesso a dados deixando para o desenvolvedor a tarefa mais importante que é a modelagem do domínio.

- Os principais são:
    - Entity Framework
    - nHibernate

> Para auxiliar na utilização dos frameworks de acesso e melhorar a produtividade de desenvolvimento a Microsoft introduziu no .NET 3.5 um conjunto de recursos chamado **LINQ** que **converte instruções de alto nível** em **instruções de baixo nível**. Os recursos foram dividos em pacotes especialistas.

- LINQ to Objects: especializado em traduzir instruções de alto nível de acesso a objetos.
- LINQ to DataSets: especializado em traduzir instruções de alto nível de acesso a DataSets.
- LINQ to Entities: especializado em traduzir instruções de alto nível de acesso a bases de dados.
- LINQ to SQL: especializado em traduzir instruções de alto nível de acesso a bases de dados SQL Server.
- LINQ to XML: especializado em traduzir instruções de alto nível de acesso a arquivos XML.

```csharp
using System;
using System.Linq; //namespace necessário

class Program 
{
    static void Main(string[] args)
    {
        //fonte de dados
        int[] salariosDaEmpresa = { 5000, 7000, 8500, 1300, 2000, 2500, 1000 };

        //consulta LINQ em alto nível
        var salariosDeUmDesenvolvedor = 
                from salario 
                in salariosDaEmpresa 
                where salario < 1500
                orderby salario 
                select salario;

        var aux = "";
        foreach (var salario in salariosDeUmDesenvolvedor) 
        {
            aux += (aux.Length>0?",":"") + $"{salario}";
        }
        Console.WriteLine($"Quanto ganham os desenvolvedores desta empresa => {aux}");
        Console.ReadKey();
    }
}
```

**Micro Frameworks de Acesso a Dados ou Micro ORMs**  
Uma outra forma de acessar dados é através de micro-orms, que são bibliotecas de extensão do ADO.NET que facilitam o acesso direto aos dados e ainda propiciam uma performance de acesso melhor que os ORMs.

**Entity Framework (EF)**  
Framework ORM nativo da plataforma .NET criado pela própria Microsoft. 

- Classes importantes:
    - DbContext: representa um contexto de dados.
    - DbSet\<Entity\>: representa um conjunto de dados de um contexto.

- Abordagens:

. | Centrado no Modelo | Centrado no Código 
--- | --- | --- 
Banco não existe | Model First - o banco é gerado a partir de arquivos EDMX | Code First - o banco é gerado por migrations a partir de classes, mapeamentos e convenções
Banco já existe | Database First - engenharia reversa gera os arquivos EDMX | Code First - engenharia reversa gera as classes e os mapeamentos

- Conceitos:
    - Change Tracking: rastreamento de mudanças.
    - Formas de carregamento: Eagler, Lazy e Explicit.
    - Convensões: o EF trabalha com convensões para evitar que o desenvolvedor tenha que ficar mapeando tudo.
    - O EF guarda em cache informações e estruturas para agilizar os acessos. Apenas o primeiro acesso é um pouco demorado. Inclusive a liberação de contextos e a criação de novos é menos custosa a partir da segunda vez.

- Definindo o modo de operação e configurações iniciais:

```csharp
public class MeuContextoDb : DbContext 
{
    public MeuContextoDb() : base("string_connection")
    {
        //aqui podemos indicar para quem o EF vai passar os registros de Log
        Database.Log = Console.Write; 

        //o EF é Code First por padrão
        //e vem com migração automática ativada
        //aqui estamos desativando a migração automática para evitar 
        //a modificação da base de dados
        //na inicialização do contexto
        Database.SetInitializer<MeuContextoDb>(null);

        //aqui estamos desabilitando o modo lazy loading (carregamento tardio)
        Configuration.LazyLoadingEnabled = false;

        //aqui estamos desabilitando a criação de proxies que são necessários para se fazer lazy loading e também para se fazer o tracking (rastreio de mudanças)
        Configuration.ProxyCreationEnabled = false;
    }
}
```

- Removendo convensões com Fluent API:

```csharp
protected override void ModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
    modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
}
```

- Configurando propriedades com Fluent API:

```csharp
protected override void ModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
    modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));
    modelBuilder.Properties<string>().Configure(p => p.IsUnicode(false));
}
```

- Configurando através de mapeamento com Fluent API:

```csharp
public class EditoraMap : EntityTypeConfiguration<Editora> 
{
    public EditoraMap() 
    {
        ToTable("Editora");
        HasKey(x => x.EditoraId);
        Property(x => x.Nome)
            .HasColumnType("varchar")
            .HasMaxLength(100);
    }
}

protected override void ModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Configurations.Add(new EditoraMap());
}
```

- Transação com EF:

Por padrão, se o provedor de banco de dados oferecer suporte a transações, todas as alterações em uma única chamada para *SaveChanges()* serão aplicadas em uma transação. Se qualquer uma das alterações falhar, a transação é revertida e nenhuma das alterações será aplicada ao banco de dados. Isso significa que é garantido que o *SaveChanges()* terá êxito ou sairá do banco de dados sem modificação caso ocorra algum erro. Para a maioria dos aplicativos, esse comportamento padrão é suficiente. Você só deve controlar as transações manualmente se os requisitos do aplicativo considerarem necessário. 

Fonte: https://docs.microsoft.com/pt-br/ef/core/saving/transactions 


- Cuidados e Boas Práticas com EF:
    - Devemos tomar muito cuidado ao anexar um objeto de um contexto A em outro contexto B.
    - Devemos tomar muito cuidado ao anexar um objeto livre de contexto em um dado contexto. O ideal é localizar e alterar o objeto preso/rastreado pelo contexto.
    - Uma boa prática é utilizar o padrão UnitOfWork para evitar a existência de várias instâncias do mesmo contexto e desacoplar os repositórios do contexto. Esse padrão determina que deve existir uma classe que guarda uma única instância do contexto e que serve como intermediador entre os repositórios e o contexto.
    - O ideal é destruir/liberar o contexto o mais cedo possível, pois a atualização de uma lista inteira é menos custosa ao recriar o contexto e selecionar novamente. Depois de um tempo de alterações o EF cria uma série de mecanismos de controle/rastreio e o acesso a ao contexto vai ficando mais lento. Por isso, é melhor liberar o contexto o mais cedo possível.
    - Projeção: técnica indicada para filtrar colunas e objetos em tabelas complexas e com número alto de registros. A projeção ajuda na performance das consultas. O retorna é mais rápido.
        - Projeção por métodos:
            - First ou FirstOrDefault
            - Single ou SingleOrDefault
            - Groupby
            - Orderby
        - Projeção por tipos anônimos:
            - var resultado = from reg in ctx.Editoras where reg.Nome.Contains("Brasil") select new { reg.EditoraId, reg.Nome };
    - Muito cuidado com o tipo da coleção em consultas com LINQ. Em retornos convertidos para IEnumerable o compilador usa delegates e neste caso os filtros são feitos no lado do cliente. Em retornos convertidos para IQueryable o compilador usa expressions e neste caso os filtros são feitos no lado do servidor. O simples fato de indicar o tipo do retorno pode resultar em perda de performance, principalmente quando estamos lhe dando com um grande volume de dados (em pequenos volumes não sentimos grande diferença).
    - Uma boa prática, quando o recurso de tracking está ativado (ProxyCreationEnabled = true), é efetuar consultas e utilizar **AsNoTracking()** antes de **ToList()**. 
    ```csharp
    using (var db = new MyAppDbContext())
    {
        var livros = db.Livros.AsNoTracking().ToList(); 
        //...
    }
    ```
    - Muito cuidado com o posicionamento de **ToList()**. Seu posicionamento deve ser sempre no final.
    ```csharp
    //errado
    db.Livros.ToList().Where(x => x.Titulo.Contains("DDD")).ToList();

    //correto
    db.Livros.Where(x => x.Titulo.Contains("DDD")).ToList();
    ```
    - Quando a necessidade é apenas o retorno de uma ou algumas colunas específicas uma boa prática é filtrar as colunas antes de ToList().
    ```csharp
    //aqui estou interessado apenas nos títulos dos livros de Marco
    db.Livros.Include(x => x.Autor)
             .Where(x => x.Autor.Nome.Contains("Marco"))
             .Select(x => x.Titulo)
             .ToList(); 

    //aqui estou interessado apenas nos títulos e nos anos de publicação dos livros de Marco
    db.Livros.Include(x => x.Autor)
             .Where(x => x.Autor.Nome.Contains("Marco"))
             .Select(x => new {
                 x.Titulo, 
                 x.AnoPublicacao
             })
             .ToList(); 
    ```
    - Outra boa prática é realizar consultas em lote, ou seja, várias consultas aproveitando-se da mesma conexão.
    - Avalie a possibilidade de usar uma solução híbrida de acesso a dados, ou seja, usar o EF para escrita/gravação e, por exemplo, o Dapper para leitura/consulta.

- Importante: 
    - As propriedades de navegação devem ser marcadas como **virtual** para que o EF realize o **lazy loading**.
    - Quando o **lazy loading** está ativado não precisa fazer **include** de propriedades virtuais de navegação, pois o carregamento ocorre automaticamente assim que as propriedades são acessadas.

- Evolução: 
    - EF 4
    - EF 5
    - EF 6 - introduziu muitas melhorias:
        - Interceptação de comandos para Logging e análise de desempenho.
        - Disponibilização de métodos assíncronos para consulta, alteração e exclusão.
        - Customização de convenções através de Fluent API. A customização pode ser específica por entidade ou pode ser genérica.
        - Mapeamento das operações de inclusão, alteração e exclusão para Stored Procedures. 
        - Resiliência de conexão. 
        - Múltiplos contextos por banco. 
        - Criação de contexto mesmo com uma conexão aberta.
        - Enums e tipos espaciais no .NET4. 
        - Serviços de pluralização e singularização plugáveis através de pacotes NuGet. 
        - Melhorias de desempenho. 
    - EF 6.0.1
    - EF 6.0.2
    - EF 6.1 - também introduziu várias melhorias:
        - Atributo de configuração de índice (clustered ou nonclustered). 
        - Melhorias na API de interceptação de comandos. 
        - Melhorias de desempenho.
    - EF 6.1.1
    - EF 6.1.2
    - **EF 6.2 - Released 10/2017**
        - EF.Functions.Like()
    - EF 6.3

**Entity Framework Core**  

Evolução
- EF Core 1.0/1.1 
    - Backing Fields
    - Batching: transações em lote. 
    - Provider In-Memory 
    - Shadow Properties 
    - Alternate Keys 
    - Raw SQL Queries (SqlFrom): sql puro + linq. 
- EF Core 2.0 
    - Table Splitting
    - EntityTypeConfiguration
    - Owned Types  
    - Database Scalar Function Mapping 
    - HasQueryFilter: filtro padrão, ou seja, filtro que sempre deve ocorrer ao consultar uma determinada tabela.
    - EF.Functions.Like()
    - DbContext pooling: services.AddDbContextPool\<MyAppContext>(...)
    - Explicity Compiled Queries 
    - String Interpolation in Raw Sql (https://www.infoq.com/br/news/2017/10/EF-Core-2.0-4). 
- EF Core 2.1 
    - Table Splitting
    - Lazy loading: com UseLazyLoadingProxies você indica que todas as propriedades **virtual** devem ser carregadas tardiamente. Ainda estão estudando uma forma melhor para lidar com carregamento tardio sem definir para toda a aplicação. Com o lazy loading você não precisa usar **Include()**, pois o próprio entity se encarrega de carregar as dependências ao usar.
    - GroupBy no banco. Até a versão 2.0 o group by era feito em memória **(isso é extremamente importante)**. 
    - Mapeamento de views com QueryType. 
    - Transação. 
    - Ainda não tem suporte para relações N para N.
- EF Core 2.2
    - Suporte a dados espaciais.
    - OwnsMany.
    - TagWith.
- EF Core 3.0
    - Novo provedor LINQ com geração de consultas mais eficazes.
    - Por padrão o EF3 pode lançar exceção em runtime para expressões que não podem ser avaliadas e convertidas. Para que o EF faça isso você precisa "forçar/explicitar" com AsEnumerable() ou ToList() ou semelhante.
    - Com a restrição de avaliação de expressões e com melhoramentos no provedor LINQ a tendencia é que a instrução SQL gerada seja mais limpa e somente uma instrução seja executada.
    - Suporte a Cosmos DB.
    - Suporte a C# 8.0.
    - Fluxos assíncronos.
    - Agora para definir uma propriedade como nullable será necessário usar o símbolo **?**. Até então uma string sem esse marcador era considerada por padrão como nullable. Agora você precisa explicitar se deseja ou não que tipos como string sejam nullables de fato.
    - Interceptação de operações de banco de dados.
- EF Core 5.0 (próxima versão)
    - *Propriedades de navegação muitos para muitos*.
    - Mapeamento de herança de tabela por tipo.
    - Melhoramentos gerais.

> - Uma das deficiências do EF Core está no relacionamento **N para N**. O recurso está disponível, mas apresenta problemas. Para usar é necessário definir uma classe associativa e fazer o devido mapeamento.
> - Outra deficiência é o **lazy loading**. O recurso, até a versão 2.0, não estava disponível. Para carregar propriedades virtuais é necessário usar **Include** e **ThenInclude** para carregamento adiantado (eagler) ou usar **context.Entry(blog).Collection(b => b.Posts).Load()** para carregamento explícito. A partir da versão 2.1 até existe a opção de carregamento tardio, mas ainda não é a melhor das soluções. Estão estudando formas de melhorar. 
> - https://docs.microsoft.com/pt-br/ef/core/querying/related-data 

--- 
 
**Fontes** 

- https://docs.microsoft.com/pt-br/ef/core/what-is-new/
- https://github.com/aspnet/EntityFramework6
- https://github.com/aspnet/EntityFramework6/wiki
- https://github.com/aspnet/EntityFramework6/wiki/Roadmap 
- https://msdn.microsoft.com/en-us/library/gg696172(v=vs.103).aspx 
- https://msdn.microsoft.com/en-us/library/aa937723(v=vs.113).aspx 
- https://github.com/aspnet/EntityFrameworkCore 
- https://github.com/aspnet/EntityFrameworkCore/wiki/roadmap
- https://docs.microsoft.com/en-us/ef/ (tudo sobre o EF direto da microsoft)
- https://docs.microsoft.com/en-us/ef/core/ (tudo sobre o EF Core direto da microsoft)
- https://docs.microsoft.com/pt-br/ef/core/modeling/relationships (relacionamentos)
- https://github.com/StackExchange/Dapper
- https://www.youtube.com/watch?v=d3FvOAPVPCo  
- https://www.youtube.com/watch?v=W2WUrvSYJhE (EF - Boas Práticas)
- https://www.youtube.com/watch?v=rFSwbT2I7Pw (EF Core 2.0) 
- https://www.youtube.com/watch?v=y2NP38lUZHw (EF Core + Dapper) 
- https://github.com/andreluizsecco/AspnetCore.EFCore_Dapper 
- https://www.youtube.com/watch?v=MTjUr1SAkbk (Dapper) 
- https://github.com/renatogroffe/Dapper-DotNetCore2/tree/master/Dapper_DotNetCore2 
- https://www.youtube.com/watch?v=rqKWMynFLNA (Relacionamentos no EF)
- https://www.youtube.com/watch?v=J7rxPec4hls (Fluent Mapping no EF)
- https://www.learnentityframeworkcore.com  
- http://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx   
- http://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx  
