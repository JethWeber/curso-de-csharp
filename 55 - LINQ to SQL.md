# LINQ (Language Integrated Query) em C#

## Aula 55 - LINQ to SQL (Básico)

Bem-vindo ao capítulo de LINQ (Language Integrated Query) em C#! Após explorarmos os operadores LINQ, como `Where`, `Select`, `OrderBy` e `GroupBy`, para manipular coleções em memória, agora vamos introduzir o **LINQ to SQL**, uma tecnologia que permite consultar bancos de dados relacionais usando a sintaxe LINQ. O LINQ to SQL mapeia tabelas de banco de dados para classes C#, permitindo realizar consultas de forma intuitiva, como se fossem coleções em memória.

Nesta aula, vamos abordar os conceitos básicos do LINQ to SQL, incluindo a configuração de um contexto de dados, mapeamento de tabelas e execução de consultas simples. Vamos usar exemplos práticos no contexto angolano, como consultar transações bancárias ou cadastros de clientes em um banco de dados, e discutir boas práticas e tratamento de erros.

**Nota**: O LINQ to SQL é uma tecnologia mais antiga, usada principalmente com o Microsoft SQL Server. Para projetos modernos, o **Entity Framework Core** é recomendado, mas o LINQ to SQL ainda é útil em sistemas legados ou para aprendizado.

### Objetivo

Entender os fundamentos do LINQ to SQL, configurar um contexto de dados, mapear tabelas para classes C#, realizar consultas básicas (como filtrar e ordenar) e aplicar essas técnicas em cenários reais, como consultar transações em kwanzas ou clientes em um banco de dados.

## O que é LINQ to SQL?

**LINQ to SQL** é uma implementação do LINQ que permite consultar bancos de dados relacionais (geralmente SQL Server) usando a sintaxe LINQ (Query Syntax ou Method Syntax). Ele traduz consultas LINQ em comandos SQL, eliminando a necessidade de escrever SQL manualmente. Cada tabela do banco é mapeada para uma classe C#, e os registros são representados como objetos.

### Características

- **Namespace**: Requer `using System.Data.Linq;`.
- **Contexto de dados**: A classe `DataContext` gerencia a conexão com o banco e o mapeamento de tabelas.
- **Mapeamento**: Tabelas são mapeadas para classes com atributos como `[Table]` e `[Column]`.
- **Consultas**: Usa os mesmos operadores LINQ (`Where`, `Select`, etc.) aplicados a tabelas.
- **Exceções comuns**:
  - `SqlException`: Erros de conexão ou consulta no banco de dados.
  - `InvalidOperationException`: Operações inválidas, como acessar dados nulos.
  - `ArgumentNullException`: Parâmetros nulos, como uma conexão inválida.

**Exemplo do dia a dia**: Em um sistema bancário, usar LINQ to SQL para consultar transações acima de 10.000 Kz ou listar clientes de uma cidade específica diretamente de um banco de dados.

## Configurando o LINQ to SQL

Para usar o LINQ to SQL, você precisa:
1. Um banco de dados SQL Server com tabelas (ex.: `Clientes`, `Transacoes`).
2. Uma conexão com o banco (string de conexão).
3. Classes C# para mapear as tabelas.
4. Um `DataContext` para gerenciar a comunicação com o banco.

### Passos para Configuração

1. **Criar o banco de dados**: Por exemplo, um banco chamado `BancoAngola` com as tabelas:
   - `Clientes` (Id, Nome, Cidade, Saldo)
   - `Transacoes` (Id, ClienteId, Valor, Data)

2. **Adicionar referências**:
   - Adicione o namespace `System.Data.Linq` ao projeto.
   - Certifique-se de que o projeto referencia o assembly `System.Data.Linq`.

3. **Mapear tabelas para classes**:
   - Use atributos como `[Table]` e `[Column]` ou gere classes automaticamente com o **LINQ to SQL Designer** (no Visual Studio, arquivo `.dbml`).

4. **Configurar a string de conexão**:
   - Defina no arquivo de configuração (`App.config`) ou no código.

**Nota**: Para simplificar, os exemplos abaixo usarão mapeamento manual com classes C#. Em projetos reais, o LINQ to SQL Designer pode gerar essas classes automaticamente.

## Exemplo 1: Consultando Clientes com LINQ to SQL

Vamos configurar classes para mapear a tabela `Clientes` e realizar uma consulta para filtrar clientes com saldo acima de 5.000 Kz.

### Configuração das Classes

```csharp
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Collections.Generic;

// Mapeamento da tabela Clientes
[Table(Name = "Clientes")]
public class Cliente
{
    [Column(IsPrimaryKey = true)]
    public int Id { get; set; }
    [Column]
    public string Nome { get; set; }
    [Column]
    public string Cidade { get; set; }
    [Column]
    public double Saldo { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // String de conexão (ajuste para seu servidor SQL)
        string connectionString = "Data Source=SEU_SERVIDOR;Initial Catalog=BancoAngola;Integrated Security=True";

        try
        {
            // Criar contexto de dados
            using (DataContext db = new DataContext(connectionString))
            {
                // Mapear tabela Clientes
                Table<Cliente> clientes = db.GetTable<Cliente>();

                // Query Syntax: Filtrar clientes com saldo > 5.000 Kz
                var consultaQuery = from c in clientes
                                   where c.Saldo > 5000.00
                                   orderby c.Nome
                                   select c;

                Console.WriteLine("Clientes com saldo acima de 5.000 Kz (Query Syntax):");
                foreach (var cliente in consultaQuery)
                {
                    Console.WriteLine($"Nome: {cliente.Nome}, Cidade: {cliente.Cidade}, Saldo: {cliente.Saldo:F2} Kz");
                }

                // Method Syntax
                var consultaMethod = clientes
                    .Where(c => c.Saldo > 5000.00)
                    .OrderBy(c => c.Nome);

                Console.WriteLine("\nClientes com saldo acima de 5.000 Kz (Method Syntax):");
                foreach (var cliente in consultaMethod)
                {
                    Console.WriteLine($"Nome: {cliente.Nome}, Cidade: {cliente.Cidade}, Saldo: {cliente.Saldo:F2} Kz");
                }
            }
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            Console.WriteLine($"Erro de banco de dados: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
}
```

**Saída** (exemplo, supondo dados no banco):
```
Clientes com saldo acima de 5.000 Kz (Query Syntax):
Nome: Ana Pereira, Cidade: Luanda, Saldo: 7500,00 Kz
Nome: José dos Santos, Cidade: Luanda, Saldo: 10000,00 Kz

Clientes com saldo acima de 5.000 Kz (Method Syntax):
Nome: Ana Pereira, Cidade: Luanda, Saldo: 7500,00 Kz
Nome: José dos Santos, Cidade: Luanda, Saldo: 10000,00 Kz
```

**Explicação detalhada**:
- A classe `Cliente` mapeia a tabela `Clientes` com atributos `[Table]` e `[Column]`.
- `DataContext` estabelece a conexão com o banco.
- `GetTable<Cliente>` obtém a tabela mapeada.
- `Where` e `OrderBy` filtram e ordenam os dados, traduzidos automaticamente para SQL.
- Exceções como `SqlException` tratam erros de conexão ou consulta.

**Exemplo do dia a dia**: Em um sistema bancário, consultar clientes com saldo elevado para oferecer serviços premium.

## Exemplo 2: Consultando Transações com Relacionamento

Vamos mapear as tabelas `Clientes` e `Transacoes`, realizar uma consulta com `Join` para combinar dados e calcular o total de transações por cliente.

### Configuração das Classes

```csharp
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Collections.Generic;

// Mapeamento da tabela Clientes
[Table(Name = "Clientes")]
public class Cliente
{
    [Column(IsPrimaryKey = true)]
    public int Id { get; set; }
    [Column]
    public string Nome { get; set; }
    [Column]
    public string Cidade { get; set; }
    [Column]
    public double Saldo { get; set; }
}

// Mapeamento da tabela Transacoes
[Table(Name = "Transacoes")]
public class Transacao
{
    [Column(IsPrimaryKey = true)]
    public int Id { get; set; }
    [Column]
    public int ClienteId { get; set; }
    [Column]
    public double Valor { get; set; }
    [Column]
    public DateTime Data { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=SEU_SERVIDOR;Initial Catalog=BancoAngola;Integrated Security=True";

        try
        {
            using (DataContext db = new DataContext(connectionString))
            {
                Table<Cliente> clientes = db.GetTable<Cliente>();
                Table<Transacao> transacoes = db.GetTable<Transacao>();

                // Query Syntax: Juntar clientes e transações
                var consultaQuery = from c in clientes
                                   join t in transacoes on c.Id equals t.ClienteId
                                   group t by c.Nome into g
                                   select new
                                   {
                                       Cliente = g.Key,
                                       TotalTransacoes = g.Count(),
                                       TotalValor = g.Sum(t => t.Valor)
                                   };

                Console.WriteLine("Total de transações por cliente (Query Syntax):");
                foreach (var item in consultaQuery)
                {
                    Console.WriteLine($"Cliente: {item.Cliente}, Transações: {item.TotalTransacoes}, Total: {item.TotalValor:F2} Kz");
                }

                // Method Syntax
                var consultaMethod = clientes
                    .Join(transacoes,
                          c => c.Id,
                          t => t.ClienteId,
                          (c, t) => new { c.Nome, t.Valor })
                    .GroupBy(x => x.Nome)
                    .Select(g => new
                    {
                        Cliente = g.Key,
                        TotalTransacoes = g.Count(),
                        TotalValor = g.Sum(x => x.Valor)
                    });

                Console.WriteLine("\nTotal de transações por cliente (Method Syntax):");
                foreach (var item in consultaMethod)
                {
                    Console.WriteLine($"Cliente: {item.Cliente}, Transações: {item.TotalTransacoes}, Total: {item.TotalValor:F2} Kz");
                }
            }
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            Console.WriteLine($"Erro de banco de dados: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
}
```

**Saída** (exemplo, supondo dados no banco):
```
Total de transações por cliente (Query Syntax):
Cliente: José dos Santos, Transações: 2, Total: 7000,00 Kz
Cliente: Maria da Silva, Transações: 1, Total: 3000,00 Kz

Total de transações por cliente (Method Syntax):
Cliente: José dos Santos, Transações: 2, Total: 7000,00 Kz
Cliente: Maria da Silva, Transações: 1, Total: 3000,00 Kz
```

**Explicação detalhada**:
- As classes `Cliente` e `Transacao` mapeiam as tabelas correspondentes.
- `join` combina `Clientes` e `Transacoes` pela chave `Id`/`ClienteId`.
- `group by` agrupa transações por cliente, e `Sum` calcula o total de valores.
- O `DataContext` traduz a consulta LINQ em SQL para execução no banco.

**Exemplo do dia a dia**: Em um sistema de auditoria bancária, calcular o total de transações por cliente para relatórios financeiros.

## Inserindo e Atualizando Dados

O LINQ to SQL também permite inserir, atualizar e excluir registros.

### Exemplo: Inserindo uma Nova Transação

```csharp
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

[Table(Name = "Transacoes")]
public class Transacao
{
    [Column(IsPrimaryKey = true)]
    public int Id { get; set; }
    [Column]
    public int ClienteId { get; set; }
    [Column]
    public double Valor { get; set; }
    [Column]
    public DateTime Data { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=SEU_SERVIDOR;Initial Catalog=BancoAngola;Integrated Security=True";

        try
        {
            using (DataContext db = new DataContext(connectionString))
            {
                Table<Transacao> transacoes = db.GetTable<Transacao>();

                // Inserir nova transação
                Transacao novaTransacao = new Transacao
                {
                    Id = 0, // Auto-incrementado pelo banco
                    ClienteId = 1, // Supondo cliente com Id 1
                    Valor = 4500.00,
                    Data = DateTime.Now
                };

                transacoes.InsertOnSubmit(novaTransacao);
                db.SubmitChanges();
                Console.WriteLine("Nova transação inserida com sucesso.");

                // Consultar transações recentes
                var transacoesRecentes = transacoes
                    .Where(t => t.Data > DateTime.Now.AddHours(-24))
                    .OrderByDescending(t => t.Data);

                Console.WriteLine("\nTransações recentes:");
                foreach (var t in transacoesRecentes)
                {
                    Console.WriteLine($"ClienteId: {t.ClienteId}, Valor: {t.Valor:F2} Kz, Data: {t.Data:dd/MM/yyyy HH:mm}");
                }
            }
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            Console.WriteLine($"Erro de banco de dados: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
}
```

**Saída** (exemplo):
```
Nova transação inserida com sucesso.

Transações recentes:
ClienteId: 1, Valor: 4500,00 Kz, Data: 17/09/2025 23:20
```

**Explicação detalhada**:
- `InsertOnSubmit` marca a transação para inserção.
- `SubmitChanges` executa a inserção no banco.
- A consulta com `Where` e `OrderByDescending` lista transações recentes.

**Exemplo do dia a dia**: Em um sistema de multibanco, registrar uma nova transação de saque ou depósito.

## Boas Práticas para LINQ to SQL

- **Use `using` para o `DataContext`**: Garante que a conexão com o banco seja fechada.
- **Trate exceções específicas**: Capture `SqlException` para erros de banco e `InvalidOperationException` para operações inválidas.
- **Valide dados antes de inserir**: Verifique valores nulos ou inválidos para evitar erros no banco.
- **Evite consultas desnecessárias**: Combine operações em uma única consulta para reduzir acessos ao banco.
- **Use LINQ to SQL Designer para projetos grandes**: Gera classes automaticamente, economizando tempo.
- **Considere o Entity Framework Core para projetos modernos**: É mais flexível e suporta múltiplos bancos de dados.
- **Teste com dados reais**: Verifique consultas com um banco de teste para garantir corretude.
- **Monitore o desempenho**: Use ferramentas como o SQL Server Profiler para analisar as consultas geradas.

## Conclusão

Você agora entende os fundamentos do **LINQ to SQL**, incluindo a configuração de um `DataContext`, mapeamento de tabelas, consultas com `Where`, `Join` e `GroupBy`, e operações de inserção. Essas técnicas permitem consultar e manipular bancos de dados de forma intuitiva, como em relatórios de transações ou cadastros de clientes em kwanzas. No contexto local, o LINQ to SQL é útil em sistemas bancários ou de gestão que utilizam SQL Server.

**Próximos passos**: Tente criar um programa que consulte uma tabela de clientes e transações, junte-as com `Join`, agrupe por cidade e insira uma nova transação. Experimente tratar erros como falhas de conexão ou chaves estrangeiras inválidas. Quanto mais você praticar, mais confiante ficará em usar LINQ to SQL!

**Nota**: Substitua `SEU_SERVIDOR` pela string de conexão real do seu SQL Server. Se não tiver um banco configurado, você pode testar com um banco local ou usar o Entity Framework Core para maior portabilidade.
