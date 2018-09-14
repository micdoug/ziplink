# Projeto ZipLink

Neste projeto iremos desenvolver um encurtador de link. A ideia do aplicativo é permitir que sejam cadastrados URLs gigantes que desejamos encurtar para permitir o fácil acesso a ela. Os endereços cadastrados poderão ser deletados ou desativados, e as visitas para cada link serão contabilizadas. A última data de acesso também será contabilizada.

O site então terá as seguintes endpoints:
- `/`: Irá apresentar uma tela com todos os endereços atualmente cadastrados em forma de tabela com todas as informações. Nesta tela será possível pedir para cadastrar novos endereços, excluir, ativar e desativar.
- `/new`: Neste endereço será possível cadastrar um novo endereço a ser encurtado.
- `/delete/{id}`: Neste endereço será possível excluir um endereço cadastrado.
- `/enable/{id}`: Neste endereço será possível ativar um endereço cadastrado.
- `/disable/{id}`: Neste endereço será possível desativar um endereço cadastrado.
- `/go/{id}`: Neste endereço será possível acessar um endereço cadastrado internamente para ser reduzido. Como o id é numérico, o endereço se torna bem pequeno.

Iremos desenvolver este site em C# utilizando o `ASP.NET MVC 5` como framework WEB, `Bootstrap 4` como framework frontend, `MySQL` como sistema gerenciador de banco de dados e `Entity Framework 6` como framework de mapeamento objeto relacional, para facilitar a manipulação de registros no banco de dados.

O escopo do projeto pode mudar ao longo das nossas aulas. Podemos adicionar novas funcionalidades ou melhorar outras. E de forma alguma este documento está completo. Eu vou adicionando novo conteúdo ao longo das semanas.

## Primeiro Dia

No primeiro dia vamos focar na parte de modelagem de banco de dados e configuração da nossa aplicação para conectar no banco. Iremos utilizar o MySQL como SGBD. O objetivo é que você se sinta confortável em criar um projeto do zero e configurar uma conexão com o banco de dados, bem como executar comandos para criar, excluir, editar e pesquisar registros no banco utilizando Linq. Antes de começar é preciso configurar o ambiente de desenvolvimento. Iremos precisar do `Visual Studio 2017` e também do `MySQL Workbench`, `MySQL Community Server` e `MySQL .NET Connector` instalados na sua máquina. Caso não tenha algum destes componentes, instale.

### Criando o banco de Dados

Baseado na especificação nossa estrutura de banco de dados é bem simples. Iremos precisar apenas de uma tabela. Iremos chamar esta tabela de `Links` e ela conterá os campos `id, description, visited, lastVisit, enabled, url`. O comando a seguir irá criar um banco de dados e também a tabela necessária no nosso projeto:

```SQL
create schema ziplink;
use ziplink;
create table links (
    id integer primary key auto_increment,
    description varchar(200) not null,
    visited integer not null,
    lastVisit datetime not null,
    enabled boolean not null,
    url varchar(500) not null
);
```

Confira se o banco foi criado e a estrutura da tabela está consistente pelo `MySQL Workbench`.

### Criando o Projeto e Configurando Conexão com o Banco

Iremos criar um projeto `ASP.NET MVC` vazio, pois vamos adicionando os componentes a medida que formos evoluindo a aplicação. Iremos usar uma abordagem mais prática, então as coisas vão sendo explicadas ao longo da construção do código.

- Crie um projeto ASP.NET padrão vazio e selecionando para adicionar suporte a MVC.
- Crie um home controller vazio retornando uma string para o endereço padrão da aplicação. Iremos utilizar este controller para produzir código neste primeiro dia para testar interação com o banco de dados.
  ```csharp
  public class HomeController : Controller
  {
    public string Index()
    {
        // iremos adicionar código de acesso ao banco aqui depois
        return "Hello World";
    }
  }
  ```
- Atualize os pacotes nuget da aplicação.
- Adicione o pacote `MySql.Data.Entity.EF6` ao projeto. Neste ponto, vai aparecer que tem disponível uma atualização para o pacote `MySql.Data`, porém não atualize. Parece que a nova versão ainda está com problema para funcionar com o entity framework.
- Adicione uma connection string no arquivo webconfig com a seguinte assinatura:
    ```xml
    <connectionStrings>
        <add name="database" providerName="MySql.Data.MySqlClient" connectionString="database=ziplink;user=root;password=root;server=localhost;" />
    </connectionStrings>
    ```
- Criar uma classe `Link` para mapear a tabela do banco de dados. 
    ```csharp
    public class Link
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Visited { get; set; }
        public DateTime LastVisit { get; set; }
        public bool Enabled { get; set; }
        public string Url { get; set; }
    }
    ```
- Crie uma classe dentro do namespace infrastructure chamada `DatabaseContext`. Ela será utilizada para configurar o DbContext do entity framework. Anotar a classe com a configuração do MySQL.
    ```csharp
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DatabaseContext: DbContext
    {
        public DbSet<Link> Links { get; set; }
        public DatabaseContext(): base("database")
        {

        }
    }
    ```
- Inserir 
