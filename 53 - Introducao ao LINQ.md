# LINQ (Language Integrated Query) em C#

## Aula 53 - Introdução ao LINQ: Sintaxe de Consulta (Query Syntax) e Método (Method Syntax)

Bem-vindo ao capítulo de LINQ (Language Integrated Query) em C#! Após explorarmos entrada/saída e manipulação de arquivos, agora vamos mergulhar no LINQ, uma poderosa ferramenta do .NET que permite consultar coleções de dados (como listas, arrays ou bases de dados) de forma clara e concisa. LINQ é amplamente utilizado para filtrar, ordenar, agrupar e transformar dados, sendo essencial em aplicações como sistemas bancários, relatórios ou gestão de clientes.

Nesta aula, vamos introduzir o LINQ, explicando suas duas sintaxes principais: **Query Syntax** (semelhante a SQL) e **Method Syntax** (baseada em métodos). Vamos explorar como usá-las com exemplos práticos no contexto angolano, como filtrar transações ou clientes, e abordar boas práticas e tratamento de erros.

### Objetivo

Entender o conceito de LINQ, aprender as diferenças entre **Query Syntax** e **Method Syntax**, e aplicar essas técnicas para consultar coleções de dados, como listas de transações ou cadastros de clientes, com exemplos claros e robustos.

## O que é LINQ?

**LINQ (Language Integrated Query)** é uma funcionalidade do .NET que permite consultar dados de forma integrada na linguagem C#, usando uma sintaxe declarativa. Ele funciona com qualquer coleção que implemente `IEnumerable<T>` (ex.: listas, arrays) ou fontes de dados como bancos de dados (via LINQ to SQL ou Entity Framework).

### Características

- **Namespace**: Requer `using System.Linq;`.
- **Fontes de dados**: Listas, arrays, XML, bases de dados, etc.
- **Operações comuns**: Filtrar (`where`), ordenar (`orderby`), agrupar (`group by`), juntar (`join`), selecionar (`select`).
- **Duas sintaxes**:
  - **Query Syntax**: Parece SQL, com palavras-chave como `from`, `where`, `select`.
  - **Method Syntax**: Usa métodos de extensão como `Where`, `OrderBy`, `Select`.
- **Exceções comuns**:
  - `InvalidOperationException`: Operações inválidas, como acessar o primeiro elemento de uma coleção vazia.
  - `ArgumentNullException`: Coleção ou função nula.

**Exemplo do dia a dia**: Em um sistema bancário, usar LINQ para filtrar transações acima de 10.000 Kz ou listar clientes por ordem alfabética.

## Query Syntax (Sintaxe de Consulta)

A **Query Syntax** usa uma sintaxe semelhante a SQL, com palavras-chave como `from`, `where`, `orderby` e `select`. É mais legível para consultas complexas e ideal para quem está familiarizado com SQL.

### Exemplo: Filtrando e Ordenando Clientes

Vamos filtrar clientes com saldo acima de 5.000 Kz e ordená-los por nome.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class Cliente
{
    public string Nome { get; set; }
    public double Saldo { get; set; }
    public string Telefone { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Cliente> clientes = new List<Cliente>
        {
            new Cliente { Nome = "José dos Santos", Saldo = 10000.00, Telefone = "+244 923 456 789" },
            new Cliente { Nome = "Maria da Silva", Saldo = 3000.00, Telefone = "+244 912 345 678" },
            new Cliente { Nome = "Ana Pereira", Saldo = 7500.00, Telefone = "+244 921 234 567" }
        };

        try
        {
            // Query Syntax
            var consulta = from cliente in clientes
                          where cliente.Saldo > 5000.00
                          orderby cliente.Nome
                          select cliente;

            Console.WriteLine("Clientes com saldo acima de 5.000 Kz (Query Syntax):");
            foreach (var cliente in consulta)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, Saldo: {cliente.Saldo:F2} Kz");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
}
```

**Saída**:
```
Clientes com saldo acima de 5.000 Kz (Query Syntax):
Nome: Ana Pereira, Saldo: 7500,00 Kz
Nome: José dos Santos, Saldo: 10000,00 Kz
```

**Explicação detalhada**:
- `from cliente in clientes`: Define a fonte de dados (`clientes`) e a variável de iteração (`cliente`).
- `where cliente.Saldo > 5000.00`: Filtra clientes com saldo superior a 5.000 Kz.
- `orderby cliente.Nome`: Ordena por nome em ordem alfabética.
- `select cliente`: Seleciona o objeto completo.
- O resultado é armazenado em `consulta` como um `IEnumerable<Cliente>`.

**Exemplo do dia a dia**: Em um sistema de gestão bancária, listar clientes com saldo elevado para oferecer serviços premium.

## Method Syntax (Sintaxe de Métodos)

A **Method Syntax** usa métodos de extensão definidos no namespace `System.Linq`, como `Where`, `OrderBy` e `Select`. É mais concisa e flexível, mas pode ser menos legível em consultas complexas.

### Exemplo: Filtrando e Ordenando Clientes (Method Syntax)

Vamos reescrever o exemplo anterior usando Method Syntax.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class Cliente
{
    public string Nome { get; set; }
    public double Saldo { get; set; }
    public string Telefone { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Cliente> clientes = new List<Cliente>
        {
            new Cliente { Nome = "José dos Santos", Saldo = 10000.00, Telefone = "+244 923 456 789" },
            new Cliente { Nome = "Maria da Silva", Saldo = 3000.00, Telefone = "+244 912 345 678" },
            new Cliente { Nome = "Ana Pereira", Saldo = 7500.00, Telefone = "+244 921 234 567" }
        };

        try
        {
            // Method Syntax
            var consulta = clientes
                .Where(c => c.Saldo > 5000.00)
                .OrderBy(c => c.Nome)
                .Select(c => c);

            Console.WriteLine("Clientes com saldo acima de 5.000 Kz (Method Syntax):");
            foreach (var cliente in consulta)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, Saldo: {cliente.Saldo:F2} Kz");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
}
```

**Saída**:
```
Clientes com saldo acima de 5.000 Kz (Method Syntax):
Nome: Ana Pereira, Saldo: 7500,00 Kz
Nome: José dos Santos, Saldo: 10000,00 Kz
```

**Explicação detalhada**:
- `Where(c => c.Saldo > 5000.00)`: Filtra usando uma expressão lambda.
- `OrderBy(c => c.Nome)`: Ordena por nome.
- `Select(c => c)`: Seleciona o objeto completo (opcional neste caso).
- A sintaxe encadeada é mais fluida, mas menos parecida com SQL.

**Exemplo do dia a dia**: Em um sistema de relatórios, filtrar clientes com saldo elevado para análise financeira.

## Comparando Query Syntax e Method Syntax

| Característica          | Query Syntax                       | Method Syntax                      |
|-------------------------|------------------------------------|------------------------------------|
| **Estilo**              | Semelhante a SQL, mais declarativo | Baseado em métodos, mais funcional |
| **Legibilidade**        | Melhor para consultas complexas    | Melhor para consultas simples      |
| **Flexibilidade**       | Limitada por palavras-chave       | Mais flexível com lambdas         |
| **Exemplo**             | `from c in clientes where ...`    | `clientes.Where(c => ...)`        |

**Dica**: Ambas produzem o mesmo resultado, pois a Query Syntax é traduzida para Method Syntax pelo compilador. Use a que for mais clara para o contexto.

## Exemplo Prático: Agrupando Transações por Cliente

Vamos usar ambas as sintaxes para agrupar transações por cliente e calcular o total de valores em kwanzas.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class Transacao
{
    public string Cliente { get; set; }
    public double Valor { get; set; }
    public DateTime Data { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Transacao> transacoes = new List<Transacao>
        {
            new Transacao { Cliente = "José dos Santos", Valor = 5000.00, Data = DateTime.Now },
            new Transacao { Cliente = "Maria da Silva", Valor = 3000.00, Data = DateTime.Now },
            new Transacao { Cliente = "José dos Santos", Valor = 2000.00, Data = DateTime.Now.AddHours(-1) }
        };

        try
        {
            // Query Syntax
            Console.WriteLine("Agrupamento com Query Syntax:");
            var consultaQuery = from transacao in transacoes
                               group transacao by transacao.Cliente into grupo
                               select new
                               {
                                   Cliente = grupo.Key,
                                   Total = grupo.Sum(t => t.Valor)
                               };

            foreach (var item in consultaQuery)
            {
                Console.WriteLine($"Cliente: {item.Cliente}, Total: {item.Total:F2} Kz");
            }

            // Method Syntax
            Console.WriteLine("\nAgrupamento com Method Syntax:");
            var consultaMethod = transacoes
                .GroupBy(t => t.Cliente)
                .Select(g => new
                {
                    Cliente = g.Key,
                    Total = g.Sum(t => t.Valor)
                });

            foreach (var item in consultaMethod)
            {
                Console.WriteLine($"Cliente: {item.Cliente}, Total: {item.Total:F2} Kz");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
}
```

**Saída**:
```
Agrupamento com Query Syntax:
Cliente: José dos Santos, Total: 7000,00 Kz
Cliente: Maria da Silva, Total: 3000,00 Kz

Agrupamento com Method Syntax:
Cliente: José dos Santos, Total: 7000,00 Kz
Cliente: Maria da Silva, Total: 3000,00 Kz
```

**Explicação detalhada**:
- **Query Syntax**: Usa `group by` para agrupar transações por cliente e `select` para criar um objeto anônimo com o total.
- **Method Syntax**: Usa `GroupBy` e `Select` com expressões lambda para o mesmo resultado.
- `Sum(t => t.Valor)` calcula o total por cliente.
- Exceções genéricas são tratadas, embora sejam raras em consultas LINQ em memória.

**Exemplo do dia a dia**: Em um sistema bancário, calcular o total de transações por cliente para relatórios financeiros ou auditorias.

## Tratamento de Erros com LINQ

LINQ é geralmente seguro em coleções em memória, mas erros podem ocorrer:
- **Coleções nulas**: Verifique se a coleção não é nula antes da consulta.
- **Operações inválidas**: Métodos como `First` ou `Single` podem lançar `InvalidOperationException` se a coleção estiver vazia.
- **Fontes externas**: Consultas a bancos de dados podem lançar exceções específicas (ex.: `SqlException`).

### Exemplo: Tratando Erros

```csharp
using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Cliente> clientes = null;

        try
        {
            if (clientes == null)
            {
                throw new ArgumentNullException(nameof(clientes), "A lista de clientes não pode ser nula.");
            }

            var consulta = clientes.Where(c => c.Saldo > 5000.00).ToList();
            Console.WriteLine("Clientes encontrados: " + consulta.Count);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
}
```

**Saída**:
```
Erro: A lista de clientes não pode ser nula.
```

**Explicação detalhada**:
- Verifica explicitamente se a coleção é nula para evitar `NullReferenceException`.
- Usa `ArgumentNullException` para fornecer uma mensagem clara.

**Exemplo do dia a dia**: Em um sistema de relatórios, verificar se a lista de clientes foi carregada antes de gerar um relatório de saldos.

## Boas Práticas para Uso de LINQ

- **Escolha a sintaxe apropriada**: Use **Query Syntax** para consultas complexas e legibilidade; use **Method Syntax** para simplicidade ou operações avançadas.
- **Verifique coleções nulas**: Sempre valide a fonte de dados antes da consulta.
- **Evite consultas desnecessárias**: Chame `.ToList()` ou `.ToArray()` apenas quando necessário para materializar resultados.
- **Use métodos seguros**: Prefira `FirstOrDefault` ou `SingleOrDefault` em vez de `First` ou `Single` para evitar exceções em coleções vazias.
- **Otimize desempenho**: Para grandes coleções, evite múltiplas iterações; combine operações em uma única consulta.
- **Teste consultas**: Verifique o resultado de consultas com dados reais, especialmente em cenários com fontes externas.
- **Documente consultas complexas**: Use comentários para explicar consultas longas ou complexas.

## Conclusão

Você agora entende os fundamentos do **LINQ** em C#, incluindo as sintaxes **Query Syntax** e **Method Syntax**. Com elas, você pode filtrar, ordenar, agrupar e transformar dados de forma eficiente, como em relatórios de transações ou cadastros de clientes. No contexto local, essas técnicas são ideais para sistemas bancários, lojas ou auditorias, onde consultar dados como saldos ou transações em kwanzas é comum.

**Próximos passos**: Tente criar um programa que use LINQ para filtrar transações acima de um valor, agrupar por cliente e ordenar por data, usando ambas as sintaxes. Experimente tratar erros como coleções nulas ou vazias. Quanto mais você praticar, mais confiante ficará em usar LINQ!
