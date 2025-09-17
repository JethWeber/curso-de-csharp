# Entrada/Saída e Manipulação de Arquivos em C#

## Aula 48 - Leitura e Escrita de Arquivos (`StreamReader`, `StreamWriter`)

Bem-vindo ao capítulo de Entrada/Saída e Manipulação de Arquivos em C#! Após dominarmos o gerenciamento de exceções, é hora de explorar como **ler e escrever arquivos** no sistema de arquivos, uma tarefa essencial para muitos aplicativos, como salvar dados de clientes, registrar transações ou gerar relatórios. Em C#, as classes `StreamReader` e `StreamWriter` (namespace `System.IO`) são ferramentas poderosas para trabalhar com arquivos de texto, permitindo ler e gravar dados de forma eficiente.

Nesta aula, vamos aprender como usar `StreamReader` para ler arquivos e `StreamWriter` para escrever arquivos, com exemplos práticos no contexto angolano, como gerenciar registos de transações bancárias ou listas de clientes. Vamos abordar a sintaxe, os métodos principais e boas práticas, incluindo o tratamento de exceções para lidar com erros comuns, como arquivos inexistentes.

### Objetivo

Entender como usar `StreamReader` e `StreamWriter` para ler e escrever arquivos de texto em C#, aplicar essas técnicas em cenários reais, como salvar dados de transações ou ler informações de clientes, e gerenciar erros com blocos `try-catch`.

## O que são `StreamReader` e `StreamWriter`?

- **`StreamReader`**: Uma classe que lê caracteres de um fluxo (stream), geralmente um arquivo de texto. É ideal para ler linhas de texto, como em arquivos CSV ou logs.
- **`StreamWriter`**: Uma classe que escreve caracteres em um fluxo, geralmente um arquivo de texto. É usada para criar ou atualizar arquivos com dados, como relatórios.

Ambas as classes pertencem ao namespace `System.IO` e trabalham com fluxos (streams), que são sequências de dados. Elas são otimizadas para arquivos de texto e suportam codificações como UTF-8.

**Exemplo do dia a dia**: Em um sistema de gestão bancária, usar `StreamWriter` para salvar um log de transações em kwanzas e `StreamReader` para ler uma lista de clientes a partir de um arquivo.

### Características

- **Namespace `System.IO`**: Requer `using System.IO;`.
- **Suporte a codificação**: Permite especificar codificações (ex.: UTF-8, ASCII).
- **Gerenciamento de recursos**: Use `using` ou blocos `try-finally` para fechar arquivos automaticamente.
- **Exceções comuns**:
  - `FileNotFoundException`: Arquivo não encontrado.
  - `IOException`: Erros gerais de entrada/saída.
  - `UnauthorizedAccessException`: Permissões insuficientes.

## Usando `StreamReader` para Leitura de Arquivos

A classe `StreamReader` oferece métodos para ler arquivos de texto, como:
- `ReadLine()`: Lê uma linha de texto.
- `ReadToEnd()`: Lê todo o conteúdo do arquivo como uma string.
- `Read()`: Lê um único caractere.

### Exemplo: Lendo uma Lista de Clientes

Vamos ler um arquivo `clientes.txt` com informações de clientes no formato: `Nome,Telefone`.

```csharp
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string caminhoArquivo = "clientes.txt";

        try
        {
            using (StreamReader reader = new StreamReader(caminhoArquivo))
            {
                Console.WriteLine("Lista de Clientes:");
                string linha;
                while ((linha = reader.ReadLine()) != null)
                {
                    string[] dados = linha.Split(',');
                    Console.WriteLine($"Nome: {dados[0]}, Telefone: {dados[1]}");
                }
            }
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

**Conteúdo de `clientes.txt`**:
```
José dos Santos,+244 923 456 789
Maria da Silva,+244 912 345 678
```

**Saída**:
```
Lista de Clientes:
Nome: José dos Santos, Telefone: +244 923 456 789
Nome: Maria da Silva, Telefone: +244 912 345 678
```

**Explicação detalhada**:
- O bloco `using` cria uma instância de `StreamReader` e garante que o arquivo seja fechado automaticamente.
- `ReadLine()` lê cada linha até retornar `null` (fim do arquivo).
- `Split(',')` divide a linha em nome e telefone.
- Exceções como `FileNotFoundException` são tratadas para lidar com erros comuns.

**Exemplo do dia a dia**: Em um sistema de registo de clientes para uma loja em Talatona, ler uma lista de clientes a partir de um arquivo para enviar promoções via SMS.

## Usando `StreamWriter` para Escrita de Arquivos

A classe `StreamWriter` oferece métodos para escrever em arquivos de texto, como:
- `Write(string)`: Escreve texto sem nova linha.
- `WriteLine(string)`: Escreve texto com uma nova linha.
- `Flush()`: Força a escrita imediata no arquivo.

### Exemplo: Salvando um Log de Transações

Vamos criar um arquivo `transacoes.txt` para registrar transações bancárias.

```csharp
using System;
using System.IO;

class Transacao
{
    public string Cliente { get; set; }
    public double Valor { get; set; }
    public DateTime Data { get; set; }

    public Transacao(string cliente, double valor, DateTime data)
    {
        Cliente = cliente;
        Valor = valor;
        Data = data;
    }

    public override string ToString()
    {
        return $"{Data:dd/MM/yyyy HH:mm:ss},{Cliente},{Valor:F2}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        string caminhoArquivo = "transacoes.txt";
        Transacao transacao = new Transacao("José dos Santos", 5000.00, DateTime.Now);

        try
        {
            using (StreamWriter writer = new StreamWriter(caminhoArquivo, true)) // true para append
            {
                writer.WriteLine(transacao.ToString());
                Console.WriteLine("Transação registrada com sucesso.");
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Erro: Permissão negada para escrever em {caminhoArquivo}.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro de escrita: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
}
```

**Conteúdo de `transacoes.txt` (após execução)**:
```
17/09/2025 22:19:00,José dos Santos,5000.00
```

**Saída**:
```
Transação registrada com sucesso.
```

**Explicação detalhada**:
- `StreamWriter(caminhoArquivo, true)` abre o arquivo em modo append (adiciona ao final).
- `WriteLine` grava a transação no formato CSV.
- O bloco `using` garante que o arquivo seja fechado corretamente.
- Exceções como `UnauthorizedAccessException` tratam erros de permissão.

**Exemplo do dia a dia**: Em um sistema de multibanco, registrar todas as transações realizadas (saques, depósitos) em um arquivo de log para auditoria.

## Combinando `StreamReader` e `StreamWriter`

Você pode combinar leitura e escrita para processar dados, como ler transações, calcular um total e salvar um relatório.

### Exemplo: Gerando Relatório de Transações

```csharp
using System;
using System.IO;
using System.Collections.Generic;

class Transacao
{
    public string Cliente { get; set; }
    public double Valor { get; set; }
    public DateTime Data { get; set; }

    public Transacao(string cliente, double valor, DateTime data)
    {
        Cliente = cliente;
        Valor = valor;
        Data = data;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string caminhoEntrada = "transacoes.txt";
        string caminhoSaida = "relatorio.txt";
        List<Transacao> transacoes = new List<Transacao>();

        // Lendo transações
        try
        {
            using (StreamReader reader = new StreamReader(caminhoEntrada))
            {
                string linha;
                while ((linha = reader.ReadLine()) != null)
                {
                    string[] dados = linha.Split(',');
                    DateTime data = DateTime.Parse(dados[0]);
                    string cliente = dados[1];
                    double valor = double.Parse(dados[2]);
                    transacoes.Add(new Transacao(cliente, valor, data));
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Erro: O arquivo {caminhoEntrada} não foi encontrado.");
            return;
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Formato inválido no arquivo de transações.");
            return;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro de leitura: {ex.Message}");
            return;
        }

        // Calculando total
        double total = 0;
        foreach (var transacao in transacoes)
        {
            total += transacao.Valor;
        }

        // Escrevendo relatório
        try
        {
            using (StreamWriter writer = new StreamWriter(caminhoSaida))
            {
                writer.WriteLine("Relatório de Transações");
                writer.WriteLine("======================");
                foreach (var transacao in transacoes)
                {
                    writer.WriteLine($"Data: {transacao.Data:dd/MM/yyyy}, Cliente: {transacao.Cliente}, Valor: {transacao.Valor:F2} Kz");
                }
                writer.WriteLine($"Total: {total:F2} Kz");
            }
            Console.WriteLine("Relatório gerado com sucesso.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro de escrita: {ex.Message}");
        }
    }
}
```

**Conteúdo de `transacoes.txt`**:
```
17/09/2025 22:19:00,José dos Santos,5000.00
17/09/2025 22:20:00,Maria da Silva,3000.00
```

**Conteúdo de `relatorio.txt`**:
```
Relatório de Transações
======================
Data: 17/09/2025, Cliente: José dos Santos, Valor: 5000,00 Kz
Data: 17/09/2025, Cliente: Maria da Silva, Valor: 3000,00 Kz
Total: 8000,00 Kz
```

**Saída**:
```
Relatório gerado com sucesso.
```

**Explicação detalhada**:
- `StreamReader` lê as transações de `transacoes.txt` e cria objetos `Transacao`.
- `StreamWriter` gera um relatório formatado em `relatorio.txt`, com o total das transações.
- Exceções como `FormatException` tratam erros no formato dos dados.

**Exemplo do dia a dia**: Em um sistema bancário, ler um log de transações diárias, calcular o total em kwanzas e gerar um relatório para auditoria.

## Boas Práticas para Leitura e Escrita de Arquivos

- **Use o bloco `using`**: Garante que `StreamReader` e `StreamWriter` sejam fechados automaticamente, liberando recursos.
- **Trate exceções específicas**: Capture `FileNotFoundException`, `IOException` e `UnauthorizedAccessException` para erros comuns.
- **Valide dados lidos**: Verifique o formato dos dados com `try-catch` ou métodos como `TryParse`.
- **Especifique codificação quando necessário**: Use `new StreamReader(caminho, Encoding.UTF8)` para garantir compatibilidade com caracteres especiais.
- **Evite caminhos absolutos**: Use caminhos relativos ou configuráveis para portabilidade.
- **Considere desempenho**: Para arquivos grandes, leia linha por linha com `ReadLine` em vez de `ReadToEnd`.
- **Faça backup de dados críticos**: Antes de sobrescrever arquivos, considere criar cópias de segurança.
- **Documente o formato do arquivo**: Comente o formato esperado (ex.: CSV com "Data,Cliente,Valor") para facilitar manutenção.

## Conclusão

Você agora entende como usar `StreamReader` e `StreamWriter` para ler e escrever arquivos de texto em C#. Essas classes são fundamentais para manipular dados persistentes, como logs de transações ou listas de clientes. Com blocos `using` e tratamento de exceções, você pode garantir operações seguras e robustas. No contexto local, essas técnicas são úteis em sistemas como multibancos, registos de vendas ou auditorias financeiras.

**Próximos passos**: Tente criar um programa que leia um arquivo de transações, valide os dados (ex.: formato de telefone ou valor) e gere um relatório resumido em outro arquivo. Experimente tratar diferentes tipos de erros, como arquivo ausente ou formato inválido. Quanto mais você praticar, mais confiante ficará em manipular arquivos!
