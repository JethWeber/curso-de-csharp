# LINQ (Language Integrated Query) em C#

## Aula 54 - Operadores LINQ (`Where`, `Select`, `OrderBy`, `GroupBy`, etc.)

Bem-vindo ao capítulo de LINQ (Language Integrated Query) em C#! Após introduzirmos o LINQ com suas sintaxes de consulta (**Query Syntax**) e método (**Method Syntax**), agora vamos explorar os **operadores LINQ**, que são os blocos fundamentais para manipular e consultar coleções de dados. Operadores como `Where`, `Select`, `OrderBy`, `GroupBy` e outros permitem filtrar, transformar, ordenar e agrupar dados de forma eficiente e expressiva.

Nesta aula, vamos detalhar os principais operadores LINQ, explicando seu uso em ambas as sintaxes, com exemplos práticos no contexto angolano, como consultar transações bancárias, filtrar clientes ou gerar relatórios. Vamos abordar como combinar esses operadores, tratar erros e seguir boas práticas para criar consultas claras e otimizadas.

### Objetivo

Entender os principais operadores LINQ (`Where`, `Select`, `OrderBy`, `GroupBy`, `Join`, etc.), aplicá-los em cenários reais, como filtrar transações em kwanzas ou agrupar clientes por região, e combinar esses operadores para criar consultas robustas.

## Principais Operadores LINQ

Os operadores LINQ são métodos de extensão (usados em **Method Syntax**) ou palavras-chave (usadas em **Query Syntax**) que operam em coleções que implementam `IEnumerable<T>`. Eles podem ser categorizados em:

- **Filtragem**: `Where`, `OfType`
- **Projeção**: `Select`, `SelectMany`
- **Ordenação**: `OrderBy`, `OrderByDescending`, `ThenBy`, `ThenByDescending`
- **Agrupamento**: `GroupBy`
- **Junção**: `Join`, `GroupJoin`
- **Agregação**: `Count`, `Sum`, `Min`, `Max`, `Average`
- **Outros**: `First`, `FirstOrDefault`, `Single`, `SingleOrDefault`, `Any`, `All`

**Namespace**: Requer `using System.Linq;`.

**Exemplo do dia a dia**: Em um sistema bancário, usar `Where` para filtrar transações acima de 10.000 Kz, `GroupBy` para agrupar por cliente e `Sum` para calcular o total por cliente.

## 1. Filtragem com `Where`

O operador `Where` filtra elementos de uma coleção com base em uma condição.

### Exemplo: Filtrando Transações Acima de um Valor

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
            new Transacao { Cliente = "José dos Santos", Valor = 15000.00, Data = DateTime.Now },
            new Transacao { Cliente = "Maria da Silva", Valor = 3000.00, Data = DateTime.Now.AddHours(-1) },
            new Transacao { Cliente = "Ana Pereira", Valor = 8000.00, Data = DateTime.Now.AddHours(-2) }
        };

        try
        {
            // Query Syntax
            var transacoesFiltradasQuery = from t in transacoes
                                          where t.Valor > 5000.00
                                          select t;

            Console.WriteLine("Transações acima de 5.000 Kz (Query Syntax):");
            foreach (var t in transacoesFiltradasQuery)
            {
                Console.WriteLine($"Cliente: {t.Cliente}, Valor: {t.Valor:F2} Kz");
            }

            // Method Syntax
            var transacoesFiltradasMethod = transacoes.Where(t => t.Valor > 5000.00);

            Console.WriteLine("\nTransações acima de 5.000 Kz (Method Syntax):");
            foreach (var t in transacoesFiltradasMethod)
            {
                Console.WriteLine($"Cliente: {t.Cliente}, Valor: {t.Valor:F2} Kz");
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
Transações acima de 5.000 Kz (Query Syntax):
Cliente: José dos Santos, Valor: 15000,00 Kz
Cliente: Ana Pereira, Valor: 8000,00 Kz

Transações acima de 5.000 Kz (Method Syntax):
Cliente: José dos Santos, Valor: 15000,00 Kz
Cliente: Ana Pereira, Valor: 8000,00 Kz
```

**Explicação detalhada**:
- `where t.Valor > 5000.00` (Query Syntax) ou `Where(t => t.Valor > 5000.00)` (Method Syntax) filtra transações com valor superior a 5.000 Kz.
- O resultado é um `IEnumerable<Transacao>` com os elementos que atendem à condição.

**Exemplo do dia a dia**: Em um sistema de multibanco, filtrar transações de alto valor para revisão de segurança.

## 2. Projeção com `Select`

O operador `Select` transforma cada elemento da coleção, projetando-o em um novo formato (ex.: um objeto anônimo ou tipo específico).

### Exemplo: Selecionando Informações de Clientes

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class Cliente
{
    public string Nome { get; set; }
    public double Saldo { get; set; }
    public string Cidade { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Cliente> clientes = new List<Cliente>
        {
            new Cliente { Nome = "José dos Santos", Saldo = 10000.00, Cidade = "Luanda" },
            new Cliente { Nome = "Maria da Silva", Saldo = 3000.00, Cidade = "Benguela" },
            new Cliente { Nome = "Ana Pereira", Saldo = 7500.00, Cidade = "Luanda" }
        };

        try
        {
            // Query Syntax
            var clientesSelecionadosQuery = from c in clientes
                                           select new { c.Nome, c.Saldo };

            Console.WriteLine("Clientes selecionados (Query Syntax):");
            foreach (var c in clientesSelecionadosQuery)
            {
                Console.WriteLine($"Nome: {c.Nome}, Saldo: {c.Saldo:F2} Kz");
            }

            // Method Syntax
            var clientesSelecionadosMethod = clientes.Select(c => new { c.Nome, c.Saldo });

            Console.WriteLine("\nClientes selecionados (Method Syntax):");
            foreach (var c in clientesSelecionadosMethod)
            {
                Console.WriteLine($"Nome: {c.Nome}, Saldo: {c.Saldo:F2} Kz");
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
Clientes selecionados (Query Syntax):
Nome: José dos Santos, Saldo: 10000,00 Kz
Nome: Maria da Silva, Saldo: 3000,00 Kz
Nome: Ana Pereira, Saldo: 7500,00 Kz

Clientes selecionados (Method Syntax):
Nome: José dos Santos, Saldo: 10000,00 Kz
Nome: Maria da Silva, Saldo: 3000,00 Kz
Nome: Ana Pereira, Saldo: 7500,00 Kz
```

**Explicação detalhada**:
- `select new { c.Nome, c.Saldo }` (Query Syntax) ou `Select(c => new { c.Nome, c.Saldo })` (Method Syntax) projeta apenas o nome e saldo.
- O resultado é um `IEnumerable` de objetos anônimos.

**Exemplo do dia a dia**: Em um relatório bancário, extrair apenas nome e saldo para uma lista simplificada de clientes.

## 3. Ordenação com `OrderBy` e `ThenBy`

Os operadores `OrderBy` (ordem ascendente) e `OrderByDescending` (ordem descendente) ordenam coleções. `ThenBy` e `ThenByDescending` adicionam ordenações secundárias.

### Exemplo: Ordenando Transações por Valor e Data

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
            new Transacao { Cliente = "Maria da Silva", Valor = 3000.00, Data = DateTime.Now.AddHours(-1) },
            new Transacao { Cliente = "Ana Pereira", Valor = 5000.00, Data = DateTime.Now.AddHours(-2) }
        };

        try
        {
            // Query Syntax
            var transacoesOrdenadasQuery = from t in transacoes
                                          orderby t.Valor descending, t.Data
                                          select t;

            Console.WriteLine("Transações ordenadas (Query Syntax):");
            foreach (var t in transacoesOrdenadasQuery)
            {
                Console.WriteLine($"Cliente: {t.Cliente}, Valor: {t.Valor:F2} Kz, Data: {t.Data:dd/MM/yyyy HH:mm}");
            }

            // Method Syntax
            var transacoesOrdenadasMethod = transacoes
                .OrderByDescending(t => t.Valor)
                .ThenBy(t => t.Data);

            Console.WriteLine("\nTransações ordenadas (Method Syntax):");
            foreach (var t in transacoesOrdenadasMethod)
            {
                Console.WriteLine($"Cliente: {t.Cliente}, Valor: {t.Valor:F2} Kz, Data: {t.Data:dd/MM/yyyy HH:mm}");
            }
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
Transações ordenadas (Query Syntax):
Cliente: José dos Santos, Valor: 5000,00 Kz, Data: 17/09/2025 23:15
Cliente: Ana Pereira, Valor: 5000,00 Kz, Data: 17/09/2025 21:15
Cliente: Maria da Silva, Valor: 3000,00 Kz, Data: 17/09/2025 22:15

Transações ordenadas (Method Syntax):
Cliente: José dos Santos, Valor: 5000,00 Kz, Data: 17/09/2025 23:15
Cliente: Ana Pereira, Valor: 5000,00 Kz, Data: 17/09/2025 21:15
Cliente: Maria da Silva, Valor: 3000,00 Kz, Data: 17/09/2025 22:15
```

**Explicação detalhada**:
- `orderby t.Valor descending, t.Data` (Query Syntax) ou `OrderByDescending(t => t.Valor).ThenBy(t => t.Data)` (Method Syntax) ordena primeiro por valor (descendente) e depois por data (ascendente).
- `ThenBy` é usado para ordenação secundária.

**Exemplo do dia a dia**: Em um sistema de auditoria, ordenar transações por valor (maior primeiro) e data para revisar transações recentes de alto valor.

## 4. Agrupamento com `GroupBy`

O operador `GroupBy` agrupa elementos com base em uma chave, criando grupos que podem ser processados (ex.: somar valores).

### Exemplo: Agrupando Clientes por Cidade

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class Cliente
{
    public string Nome { get; set; }
    public double Saldo { get; set; }
    public string Cidade { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Cliente> clientes = new List<Cliente>
        {
            new Cliente { Nome = "José dos Santos", Saldo = 10000.00, Cidade = "Luanda" },
            new Cliente { Nome = "Maria da Silva", Saldo = 3000.00, Cidade = "Benguela" },
            new Cliente { Nome = "Ana Pereira", Saldo = 7500.00, Cidade = "Luanda" }
        };

        try
        {
            // Query Syntax
            var clientesPorCidadeQuery = from c in clientes
                                        group c by c.Cidade into grupo
                                        select new
                                        {
                                            Cidade = grupo.Key,
                                            TotalSaldo = grupo.Sum(c => c.Saldo),
                                            Clientes = grupo.ToList()
                                        };

            Console.WriteLine("Clientes agrupados por cidade (Query Syntax):");
            foreach (var grupo in clientesPorCidadeQuery)
            {
                Console.WriteLine($"Cidade: {grupo.Cidade}, Total Saldo: {grupo.TotalSaldo:F2} Kz");
                foreach (var c in grupo.Clientes)
                {
                    Console.WriteLine($"  - {c.Nome}, Saldo: {c.Saldo:F2} Kz");
                }
            }

            // Method Syntax
            var clientesPorCidadeMethod = clientes
                .GroupBy(c => c.Cidade)
                .Select(g => new
                {
                    Cidade = g.Key,
                    TotalSaldo = g.Sum(c => c.Saldo),
                    Clientes = g.ToList()
                });

            Console.WriteLine("\nClientes agrupados por cidade (Method Syntax):");
            foreach (var grupo in clientesPorCidadeMethod)
            {
                Console.WriteLine($"Cidade: {grupo.Cidade}, Total Saldo: {grupo.TotalSaldo:F2} Kz");
                foreach (var c in grupo.Clientes)
                {
                    Console.WriteLine($"  - {c.Nome}, Saldo: {c.Saldo:F2} Kz");
                }
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
Clientes agrupados por cidade (Query Syntax):
Cidade: Luanda, Total Saldo: 17500,00 Kz
  - José dos Santos, Saldo: 10000,00 Kz
  - Ana Pereira, Saldo: 7500,00 Kz
Cidade: Benguela, Total Saldo: 3000,00 Kz
  - Maria da Silva, Saldo: 3000,00 Kz

Clientes agrupados por cidade (Method Syntax):
Cidade: Luanda, Total Saldo: 17500,00 Kz
  - José dos Santos, Saldo: 10000,00 Kz
  - Ana Pereira, Saldo: 7500,00 Kz
Cidade: Benguela, Total Saldo: 3000,00 Kz
  - Maria da Silva, Saldo: 3000,00 Kz
```

**Explicação detalhada**:
- `group c by c.Cidade` (Query Syntax) ou `GroupBy(c => c.Cidade)` (Method Syntax) agrupa clientes por cidade.
- `select new` cria um objeto anônimo com a cidade, o total de saldos e a lista de clientes.
- `grupo.Sum(c => c.Saldo)` calcula o total por grupo.

**Exemplo do dia a dia**: Em um sistema bancário, agrupar clientes por cidade para relatórios regionais.

## 5. Junção com `Join`

O operador `Join` combina duas coleções com base em uma chave comum, semelhante a um `INNER JOIN` em SQL.

### Exemplo: Juntando Clientes e Transações

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class Cliente
{
    public string Nome { get; set; }
    public string Cidade { get; set; }
}

public class Transacao
{
    public string Cliente { get; set; }
    public double Valor { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Cliente> clientes = new List<Cliente>
        {
            new Cliente { Nome = "José dos Santos", Cidade = "Luanda" },
            new Cliente { Nome = "Maria da Silva", Cidade = "Benguela" }
        };

        List<Transacao> transacoes = new List<Transacao>
        {
            new Transacao { Cliente = "José dos Santos", Valor = 5000.00 },
            new Transacao { Cliente = "Maria da Silva", Valor = 3000.00 },
            new Transacao { Cliente = "José dos Santos", Valor = 2000.00 }
        };

        try
        {
            // Query Syntax
            var consultaJoinQuery = from c in clientes
                                   join t in transacoes on c.Nome equals t.Cliente
                                   select new { c.Nome, c.Cidade, t.Valor };

            Console.WriteLine("Junção de clientes e transações (Query Syntax):");
            foreach (var item in consultaJoinQuery)
            {
                Console.WriteLine($"Cliente: {item.Nome}, Cidade: {item.Cidade}, Valor: {item.Valor:F2} Kz");
            }

            // Method Syntax
            var consultaJoinMethod = clientes
                .Join(transacoes,
                      c => c.Nome,
                      t => t.Cliente,
                      (c, t) => new { c.Nome, c.Cidade, t.Valor });

            Console.WriteLine("\nJunção de clientes e transações (Method Syntax):");
            foreach (var item in consultaJoinMethod)
            {
                Console.WriteLine($"Cliente: {item.Nome}, Cidade: {item.Cidade}, Valor: {item.Valor:F2} Kz");
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
Junção de clientes e transações (Query Syntax):
Cliente: José dos Santos, Cidade: Luanda, Valor: 5000,00 Kz
Cliente: José dos Santos, Cidade: Luanda, Valor: 2000,00 Kz
Cliente: Maria da Silva, Cidade: Benguela, Valor: 3000,00 Kz

Junção de clientes e transações (Method Syntax):
Cliente: José dos Santos, Cidade: Luanda, Valor: 5000,00 Kz
Cliente: José dos Santos, Cidade: Luanda, Valor: 2000,00 Kz
Cliente: Maria da Silva, Cidade: Benguela, Valor: 3000,00 Kz
```

**Explicação detalhada**:
- `join t in transacoes on c.Nome equals t.Cliente` (Query Syntax) ou `Join` (Method Syntax) combina clientes e transações pela chave `Nome`/`Cliente`.
- O resultado inclui apenas pares correspondentes.

**Exemplo do dia a dia**: Em um sistema bancário, combinar informações de clientes com suas transações para relatórios detalhados.

## 6. Agregação com `Count`, `Sum`, `Min`, `Max`, `Average`

Operadores de agregação calculam valores resumidos de uma coleção.

### Exemplo: Calculando Estatísticas de Transações

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class Transacao
{
    public string Cliente { get; set; }
    public double Valor { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Transacao> transacoes = new List<Transacao>
        {
            new Transacao { Cliente = "José dos Santos", Valor = 5000.00 },
            new Transacao { Cliente = "Maria da Silva", Valor = 3000.00 },
            new Transacao { Cliente = "Ana Pereira", Valor = 8000.00 }
        };

        try
        {
            // Method Syntax
            int totalTransacoes = transacoes.Count();
            double somaValores = transacoes.Sum(t => t.Valor);
            double mediaValores = transacoes.Average(t => t.Valor);
            double maiorValor = transacoes.Max(t => t.Valor);
            double menorValor = transacoes.Min(t => t.Valor);

            Console.WriteLine("Estatísticas de transações:");
            Console.WriteLine($"Total de transações: {totalTransacoes}");
            Console.WriteLine($"Soma dos valores: {somaValores:F2} Kz");
            Console.WriteLine($"Média dos valores: {mediaValores:F2} Kz");
            Console.WriteLine($"Maior valor: {maiorValor:F2} Kz");
            Console.WriteLine($"Menor valor: {menorValor:F2} Kz");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Erro: A coleção está vazia.");
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
Estatísticas de transações:
Total de transações: 3
Soma dos valores: 16000,00 Kz
Média dos valores: 5333,33 Kz
Maior valor: 8000,00 Kz
Menor valor: 3000,00 Kz
```

**Explicação detalhada**:
- `Count`, `Sum`, `Average`, `Max` e `Min` calculam estatísticas diretamente.
- `InvalidOperationException` pode ocorrer se a coleção estiver vazia (ex.: em `Average`).

**Exemplo do dia a dia**: Em um relatório financeiro, calcular o total, média e valores extremos de transações diárias.

## Boas Práticas para Operadores LINQ

- **Combine operadores eficientemente**: Encadeie `Where`, `Select`, `OrderBy`, etc., em uma única consulta para evitar iterações múltiplas.
- **Use métodos seguros**: Prefira `FirstOrDefault` em vez de `First` para evitar `InvalidOperationException` em coleções vazias.
- **Valide coleções**: Verifique se a coleção não é nula ou vazia antes da consulta.
- **Evite consultas desnecessárias**: Materialize resultados com `.ToList()` ou `.ToArray()` apenas quando necessário.
- **Teste com dados reais**: Verifique o comportamento das consultas com diferentes tamanhos de coleções.
- **Documente consultas complexas**: Use comentários para explicar consultas com múltiplos operadores.
- **Considere desempenho**: Para grandes coleções, evite operações custosas como `OrderBy` em dados não filtrados.

## Conclusão

Você agora entende os principais **operadores LINQ**, como `Where`, `Select`, `OrderBy`, `GroupBy`, `Join` e agregadores, e como aplicá-los em ambas as sintaxes (**Query** e **Method**). Essas ferramentas permitem manipular coleções de forma poderosa, como filtrar transações, agrupar clientes ou calcular estatísticas. No contexto local, são ideais para sistemas bancários, gestão de vendas ou relatórios, onde consultar dados como transações em kwanzas é essencial.

**Próximos passos**: Tente criar um programa que combine `Where`, `GroupBy` e `Join` para gerar um relatório detalhado, como listar transações por cliente e cidade, com totais por grupo. Experimente tratar erros como coleções vazias ou nulas. Quanto mais você praticar, mais confiante ficará em usar LINQ!
