# Programação Assíncrona em C#

## Aula 57 - Conceitos de `async` e `await`

Bem-vindo ao capítulo de **Programação Assíncrona** em C#! Após explorarmos LINQ e manipulação de dados, agora vamos abordar a programação assíncrona, uma técnica essencial para criar aplicações responsivas e eficientes. Em C#, os modificadores `async` e `await` simplificam a escrita de código assíncrono, permitindo executar operações demoradas, como leitura de arquivos ou chamadas a APIs, sem bloquear a thread principal.

Nesta aula, vamos introduzir os conceitos de `async` e `await`, explicar como eles funcionam e demonstrar seu uso com exemplos práticos no contexto angolano, como processar transações bancárias ou carregar relatórios de forma assíncrona. Vamos abordar a sintaxe, o modelo de execução, o tratamento de erros e boas práticas para garantir código robusto.

### Objetivo

Entender os fundamentos de programação assíncrona com `async` e `await`, aprender a aplicá-los em operações de entrada/saída (como leitura de arquivos ou chamadas a serviços) e usar essas técnicas em cenários reais, como carregar dados de clientes ou transações em kwanzas sem travar a aplicação.

## O que é Programação Assíncrona?

**Programação assíncrona** permite que uma tarefa seja executada em segundo plano, liberando a thread principal para realizar outras operações. Em C#, isso é feito com os modificadores `async` e `await`, que trabalham com o tipo `Task` para gerenciar operações assíncronas.

- **Por que usar?**
  - Evita bloqueios em interfaces gráficas (ex.: WPF, MAUI).
  - Melhora a escalabilidade em servidores (ex.: ASP.NET).
  - Otimiza operações demoradas, como acesso a arquivos, bancos de dados ou APIs.
- **Exemplo do dia a dia**: Em um sistema bancário, carregar um relatório de transações de um servidor sem congelar a interface do usuário.

### Características

- **Namespace**: Requer `using System.Threading.Tasks;`.
- **Modificador `async`**: Marca um método como assíncrono, permitindo o uso de `await`.
- **Operador `await`**: Pausa a execução do método até que uma tarefa esteja concluída, sem bloquear a thread.
- **Tipos de retorno**:
  - `Task`: Para métodos assíncronos sem retorno.
  - `Task<T>`: Para métodos que retornam um valor do tipo `T`.
  - `ValueTask<T>`: Para operações assíncronas de curta duração (menos comum).
- **Exceções comuns**:
  - `TaskCanceledException`: Operação cancelada.
  - `IOException`: Erros em operações de entrada/saída.
  - `HttpRequestException`: Erros em chamadas de rede.

## Como Funciona `async` e `await`

- Um método marcado com `async` retorna uma `Task` ou `Task<T>` e pode conter `await` para esperar a conclusão de operações assíncronas.
- O `await` suspende a execução do método até a tarefa estar concluída, mas libera a thread para outras atividades.
- O compilador transforma o método assíncrono em uma máquina de estados, gerenciando a continuidade após o `await`.

**Exemplo do dia a dia**: Em um aplicativo de multibanco, carregar o saldo de um cliente de um servidor remoto sem travar a interface enquanto os dados são buscados.

## Exemplo 1: Lendo um Arquivo de Forma Assíncrona

Vamos ler um arquivo de texto contendo transações de forma assíncrona, simulando um log de um sistema bancário.

```csharp
using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string caminhoArquivo = "transacoes.txt";

        try
        {
            // Escrever algumas transações no arquivo (síncrono, para configuração inicial)
            await File.WriteAllTextAsync(caminhoArquivo, 
                "17/09/2025,José dos Santos,5000.00 Kz\n" +
                "17/09/2025,Maria da Silva,3000.00 Kz");

            // Ler arquivo de forma assíncrona
            Console.WriteLine("Lendo transações...");
            string conteudo = await File.ReadAllTextAsync(caminhoArquivo);

            Console.WriteLine("Transações lidas:");
            Console.WriteLine(conteudo);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Erro: O arquivo {caminhoArquivo} não foi encontrado.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro de leitura: {ex.Message}");
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
Lendo transações...
Transações lidas:
17/09/2025,José dos Santos,5000.00 Kz
17/09/2025,Maria da Silva,3000.00 Kz
```

**Explicação detalhada**:
- `async Task Main`: O método `Main` é marcado como assíncrono (suportado a partir do C# 7.1).
- `await File.WriteAllTextAsync`: Escreve no arquivo de forma assíncrona.
- `await File.ReadAllTextAsync`: Lê o arquivo sem bloquear a thread principal.
- Exceções como `FileNotFoundException` e `IOException` tratam erros comuns de I/O.
- **Contexto**: Em um sistema de relatórios, ler logs de transações sem travar a aplicação.

## Exemplo 2: Processando Transações com LINQ de Forma Assíncrona

Vamos combinar `async`/`await` com LINQ para processar transações de um arquivo de forma assíncrona.

```csharp
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

public class Transacao
{
    public string Cliente { get; set; }
    public double Valor { get; set; }
    public DateTime Data { get; set; }
}

class Program
{
    static async Task Main(string[] args)
    {
        string caminhoArquivo = "transacoes.txt";

        try
        {
            // Escrever transações no arquivo
            string[] transacoes = new[]
            {
                "17/09/2025,José dos Santos,5000.00",
                "17/09/2025,Maria da Silva,3000.00",
                "17/09/2025,Ana Pereira,7500.00"
            };
            await File.WriteAllLinesAsync(caminhoArquivo, transacoes);

            // Ler e processar transações de forma assíncrona
            Console.WriteLine("Processando transações...");
            string[] linhas = await File.ReadAllLinesAsync(caminhoArquivo);

            List<Transacao> transacoesLista = linhas
                .Select(linha =>
                {
                    string[] partes = linha.Split(',');
                    return new Transacao
                    {
                        Data = DateTime.Parse(partes[0]),
                        Cliente = partes[1],
                        Valor = double.Parse(partes[2])
                    };
                })
                .ToList();

            // Filtrar e ordenar com LINQ
            var transacoesFiltradas = transacoesLista
                .Where(t => t.Valor > 4000.00)
                .OrderBy(t => t.Cliente);

            Console.WriteLine("\nTransações acima de 4.000 Kz:");
            foreach (var t in transacoesFiltradas)
            {
                Console.WriteLine($"Cliente: {t.Cliente}, Valor: {t.Valor:F2} Kz, Data: {t.Data:dd/MM/yyyy}");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Erro: O arquivo {caminhoArquivo} não foi encontrado.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Formato inválido no arquivo de transações.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro de leitura: {ex.Message}");
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
Processando transações...
Transações acima de 4.000 Kz:
Cliente: Ana Pereira, Valor: 7500,00 Kz, Data: 17/09/2025
Cliente: José dos Santos, Valor: 5000,00 Kz, Data: 17/09/2025
```

**Explicação detalhada**:
- `await File.WriteAllLinesAsync` e `await File.ReadAllLinesAsync` realizam I/O assíncrono.
- LINQ (`Select`, `Where`, `OrderBy`) processa os dados em memória após a leitura.
- Exceções como `FormatException` tratam erros de parsing.
- **Contexto**: Em um sistema bancário, carregar e filtrar transações de um arquivo sem bloquear a interface.

## Exemplo 3: Chamada Assíncrona a uma API (Simulada)

Vamos simular uma chamada a uma API para carregar saldos de clientes, usando `async`/`await`.

```csharp
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

public class Cliente
{
    public string Nome { get; set; }
    public double Saldo { get; set; }
}

class Program
{
    // Simula uma chamada a uma API
    static async Task<List<Cliente>> ObterClientesAsync()
    {
        // Simula atraso de rede
        await Task.Delay(2000); // 2 segundos
        return new List<Cliente>
        {
            new Cliente { Nome = "José dos Santos", Saldo = 10000.00 },
            new Cliente { Nome = "Maria da Silva", Saldo = 3000.00 },
            new Cliente { Nome = "Ana Pereira", Saldo = 7500.00 }
        };
    }

    static async Task Main(string[] args)
    {
        try
        {
            Console.WriteLine("Carregando dados de clientes...");
            List<Cliente> clientes = await ObterClientesAsync();

            Console.WriteLine("\nClientes carregados:");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, Saldo: {cliente.Saldo:F2} Kz");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar clientes: {ex.Message}");
        }
    }
}
```

**Saída**:
```
Carregando dados de clientes...
Clientes carregados:
Nome: José dos Santos, Saldo: 10000,00 Kz
Nome: Maria da Silva, Saldo: 3000,00 Kz
Nome: Ana Pereira, Saldo: 7500,00 Kz
```

**Explicação detalhada**:
- `Task.Delay` simula um atraso de rede (ex.: chamada HTTP real).
- `await ObterClientesAsync` espera a conclusão da tarefa sem bloquear a thread.
- O programa permanece responsivo durante o "carregamento".
- **Contexto**: Em um aplicativo móvel de multibanco, carregar saldos de clientes de um servidor remoto.

## Boas Práticas para `async`/`await`

- **Use `async Task` em vez de `async void`**: Exceto para manipuladores de eventos, `async void` pode dificultar o tratamento de erros.
- **Sempre use `await` em métodos assíncronos**: Evite retornar `Task` sem `await`, a menos que seja intencional (ex.: fire-and-forget).
- **Trate exceções adequadamente**: Use `try-catch` para capturar erros como `IOException` ou `HttpRequestException`.
- **Evite bloqueios com `.Result` ou `.Wait()`**: Isso pode causar deadlocks, especialmente em interfaces gráficas.
- **Configure `ConfigureAwait(false)` quando possível**: Em bibliotecas ou código sem contexto de UI, melhora o desempenho ao evitar a sincronização com a thread original.
  ```csharp
  string conteudo = await File.ReadAllTextAsync(caminhoArquivo).ConfigureAwait(false);
  ```
- **Use métodos assíncronos nativos**: Prefira métodos como `File.ReadAllTextAsync` em vez de `File.ReadAllText`.
- **Teste com cenários reais**: Simule atrasos ou falhas (ex.: rede lenta, arquivo ausente) para garantir robustez.
- **Evite excesso de tarefas assíncronas**: Use assincronia apenas para operações demoradas (I/O, rede, etc.).

## Performance com `async`/`await`

- **Benefícios**:
  - Libera a thread principal para outras tarefas, como atualizar a UI.
  - Melhora a escalabilidade em servidores (ex.: ASP.NET).
- **Cuidados**:
  - Muitos `await` em sequência podem aumentar a sobrecarga de gerenciamento de tarefas.
  - Use `ValueTask<T>` para operações curtas e frequentes, como cache em memória.
  - Monitore o uso de threads em aplicações com alta concorrência.

## Conclusão

Você agora entende os fundamentos de **programação assíncrona** com `async` e `await` em C#, incluindo como usá-los para operações de entrada/saída e chamadas a APIs. Essas técnicas garantem que aplicações permaneçam responsivas, especialmente em sistemas que lidam com transações ou relatórios em kwanzas. No contexto local, são ideais para sistemas bancários, aplicativos móveis ou relatórios que exigem acesso a arquivos ou servidores.

**Próximos passos**: Tente criar um programa que combine `async`/`await` com LINQ para carregar e processar transações de um arquivo ou API de forma assíncrona. Experimente tratar erros como falhas de rede ou arquivos corrompidos. Quanto mais você praticar, mais confiante ficará em usar programação assíncrona!
