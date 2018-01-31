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
    modelBuilder.Conventions
        .Remove<PluralizingTableNameConvention>();
        .Remove<OneToManyCascadeDeleteConvention>();
        .Remove<ManyToManyCascadeDeleteConvention>();
}
```

- Configurando propriedades com Fluent API:

```csharp
protected override void ModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Properties<string>()
        .Configure(p => p.HasColumnType("varchar"))
        .Configure(p => p.HasMaxLength(1000))
        .Configure(p => p.IsUnicode(false));
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

- Importante: 
    - As propriedades de navegação devem ser marcadas como **virtual** para que o EF realize o **lazzy loading**.

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
    - EF 6.3

--- 

**Fontes** 

- https://github.com/aspnet/EntityFramework6
- https://github.com/aspnet/EntityFramework6/wiki
- https://github.com/aspnet/EntityFramework6/wiki/Roadmap
- https://msdn.microsoft.com/en-us/library/gg696172(v=vs.103).aspx 
- https://msdn.microsoft.com/en-us/library/aa937723(v=vs.113).aspx 
- https://www.youtube.com/watch?v=d3FvOAPVPCo 
