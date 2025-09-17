# Entrada/Saída e Manipulação de Arquivos em C#

## Aula 50 - Manipulação de Arquivos Binários (`BinaryReader`, `BinaryWriter`)

Bem-vindo ao capítulo de Entrada/Saída e Manipulação de Arquivos em C#! Após aprendermos a trabalhar com arquivos de texto usando `StreamReader` e `StreamWriter`, e gerenciar diretórios com `Directory` e `DirectoryInfo`, agora vamos explorar a **manipulação de arquivos binários** com as classes `BinaryReader` e `BinaryWriter` do namespace `System.IO`. Arquivos binários são usados para armazenar dados em formato compacto, como estruturas de dados complexas, configurações ou registros financeiros, e são especialmente úteis quando a eficiência de armazenamento ou a leitura de dados brutos é importante.

Nesta aula, vamos detalhar como usar `BinaryReader` e `BinaryWriter` para ler e escrever dados binários, com exemplos práticos no contexto angolano, como salvar e recuperar registros de transações bancárias ou configurações de sistemas. Vamos abordar a sintaxe, os métodos principais, o tratamento de exceções e boas práticas para garantir operações seguras e eficientes.

### Objetivo

Entender como usar `BinaryReader` e `BinaryWriter` para manipular arquivos binários em C#, aplicar essas técnicas em cenários reais, como salvar registros de transações em kwanzas, e gerenciar erros com blocos `try-catch`.

## O que são Arquivos Binários?

Arquivos binários armazenam dados em formato bruto (bytes), em vez de texto legível por humanos, como em arquivos `.txt` ou `.csv`. Eles são ideais para:
- Armazenar dados estruturados (ex.: números, datas, structs).
- Economizar espaço, pois não convertem dados em texto.
- Garantir alta performance em leitura/escrita.

As classes `BinaryReader` e `BinaryWriter` simplificam a manipulação de arquivos binários, permitindo ler e escrever tipos primitivos (como `int`, `double`, `string`) diretamente em bytes.

**Exemplo do dia a dia**: Em um sistema de multibanco, salvar transações em um arquivo binário para reduzir o tamanho do arquivo e agilizar o processamento, em vez de usar um arquivo de texto.

### Características de `BinaryReader` e `BinaryWriter`

- **Namespace `System.IO`**: Requer `using System.IO;`.
- **Suporte a tipos primitivos**: Permitem ler/escrever `int`, `double`, `string`, `bool`, etc.
- **Codificação**: `BinaryWriter` usa UTF-8 por padrão para strings, mas pode ser configurado.
- **Gerenciamento de recursos**: Use `using` para garantir que os fluxos sejam fechados.
- **Exceções comuns**:
  - `FileNotFoundException`: Arquivo não encontrado.
  - `IOException`: Erros gerais de entrada/saída.
  - `EndOfStreamException`: Tentativa de ler além do fim do arquivo.

## Usando `BinaryWriter` para Escrita de Arquivos Binários

A classe `BinaryWriter` escreve tipos primitivos em um fluxo binário. Métodos principais incluem:
- `Write(int)`: Escreve um inteiro.
- `Write(double)`: Escreve um número de ponto flutuante.
- `Write(string)`: Escreve uma string (com comprimento prefixado).
- `Flush()`: Força a escrita imediata no fluxo.

### Exemplo: Salvando Transações em um Arquivo Binário

Vamos salvar um registro de transações bancárias (cliente, valor, data) em um arquivo binário.

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
}

class Program
{
    static void Main(string[] args)
    {
        string caminhoArquivo = "transacoes.bin";
        Transacao transacao = new Transacao("José dos Santos", 5000.00, DateTime.Now);

        try
        {
            using (FileStream fs = new FileStream(caminhoArquivo, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(transacao.Cliente);
                writer.Write(transacao.Valor);
                writer.Write(transacao.Data.ToBinary()); // Converte DateTime para long
                Console.WriteLine("Transação salva em formato binário.");
            }
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

**Saída**:
```
Transação salva em formato binário.
```

**Explicação detalhada**:
- `FileStream` cria ou sobrescreve o arquivo `transacoes.bin`.
- `BinaryWriter` escreve a string `Cliente`, o `double` `Valor` e a `Data` (convertida para `long` com `ToBinary()`).
- O bloco `using` garante que o arquivo seja fechado corretamente.
- Exceções como `IOException` tratam erros de escrita.

**Exemplo do dia a dia**: Em um sistema de multibanco, salvar transações em um arquivo binário para compactar dados e agilizar a recuperação, como em relatórios diários de transações em kwanzas.

## Usando `BinaryReader` para Leitura de Arquivos Binários

A classe `BinaryReader` lê tipos primitivos de um fluxo binário. Métodos principais incluem:
- `ReadString()`: Lê uma string.
- `ReadDouble()`: Lê um número de ponto flutuante.
- `ReadInt64()`: Lê um inteiro de 64 bits (usado para `DateTime.ToBinary`).

### Exemplo: Lendo Transações de um Arquivo Binário

Vamos ler o arquivo `transacoes.bin` criado anteriormente.

```csharp
using System;
using System.IO;

class Transacao
{
    public string Cliente { get; set; }
    public double Valor { get; set; }
    public DateTime Data { get; set; }

    public override string ToString()
    {
        return $"Cliente: {Cliente}, Valor: {Valor:F2} Kz, Data: {Data:dd/MM/yyyy HH:mm:ss}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        string caminhoArquivo = "transacoes.bin";

        try
        {
            using (FileStream fs = new FileStream(caminhoArquivo, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                Transacao transacao = new Transacao
                {
                    Cliente = reader.ReadString(),
                    Valor = reader.ReadDouble(),
                    Data = DateTime.FromBinary(reader.ReadInt64())
                };
                Console.WriteLine("Transação lida:");
                Console.WriteLine(transacao);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Erro: O arquivo {caminhoArquivo} não foi encontrado.");
        }
        catch (EndOfStreamException)
        {
            Console.WriteLine("Erro: Fim do arquivo atingido inesperadamente.");
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

**Saída** (exemplo):
```
Transação lida:
Cliente: José dos Santos, Valor: 5000,00 Kz, Data: 17/09/2025 22:30:00
```

**Explicação detalhada**:
- `FileStream` abre o arquivo em modo leitura (`FileMode.Open`).
- `BinaryReader` lê os dados na mesma ordem em que foram escritos: string, double, long (para `DateTime`).
- Exceções como `FileNotFoundException` e `EndOfStreamException` tratam erros comuns.
- O bloco `using` garante que o arquivo seja fechado.

**Exemplo do dia a dia**: Em um sistema de auditoria bancária, ler transações de um arquivo binário para verificar histórico de saques ou depósitos em kwanzas.

## Trabalhando com Múltiplos Registros

Para salvar e ler várias transações, você pode incluir um contador ou usar um loop até o fim do arquivo.

### Exemplo: Salvando e Lendo Múltiplas Transações

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

    public override string ToString()
    {
        return $"Cliente: {Cliente}, Valor: {Valor:F2} Kz, Data: {Data:dd/MM/yyyy HH:mm:ss}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        string caminhoArquivo = "transacoes_multiplas.bin";
        List<Transacao> transacoes = new List<Transacao>
        {
            new Transacao("José dos Santos", 5000.00, DateTime.Now),
            new Transacao("Maria da Silva", 3000.00, DateTime.Now.AddHours(-1))
        };

        // Escrever transações
        try
        {
            using (FileStream fs = new FileStream(caminhoArquivo, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(transacoes.Count); // Escreve o número de transações
                foreach (var transacao in transacoes)
                {
                    writer.Write(transacao.Cliente);
                    writer.Write(transacao.Valor);
                    writer.Write(transacao.Data.ToBinary());
                }
                Console.WriteLine("Transações salvas com sucesso.");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro de escrita: {ex.Message}");
            return;
        }

        // Ler transações
        try
        {
            using (FileStream fs = new FileStream(caminhoArquivo, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                int count = reader.ReadInt32(); // Lê o número de transações
                List<Transacao> transacoesLidas = new List<Transacao>();
                for (int i = 0; i < count; i++)
                {
                    transacoesLidas.Add(new Transacao(
                        reader.ReadString(),
                        reader.ReadDouble(),
                        DateTime.FromBinary(reader.ReadInt64())
                    ));
                }

                Console.WriteLine("Transações lidas:");
                foreach (var transacao in transacoesLidas)
                {
                    Console.WriteLine(transacao);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Erro: O arquivo {caminhoArquivo} não foi encontrado.");
        }
        catch (EndOfStreamException)
        {
            Console.WriteLine("Erro: Fim do arquivo atingido inesperadamente.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro de leitura: {ex.Message}");
        }
    }
}
```

**Saída** (exemplo):
```
Transações salvas com sucesso.
Transações lidas:
Cliente: José dos Santos, Valor: 5000,00 Kz, Data: 17/09/2025 22:30:00
Cliente: Maria da Silva, Valor: 3000,00 Kz, Data: 17/09/2025 21:30:00
```

**Explicação detalhada**:
- `BinaryWriter` escreve o número de transações como um contador, seguido pelos dados de cada transação.
- `BinaryReader` lê o contador primeiro, depois itera para ler cada transação.
- Exceções garantem que erros como fim de arquivo ou arquivo ausente sejam tratados.

**Exemplo do dia a dia**: Em um sistema de gestão financeira, salvar e recuperar um conjunto de transações diárias em um arquivo binário para auditoria ou relatórios.

## Combinando com `Directory`/`DirectoryInfo`

Você pode usar `BinaryReader`/`BinaryWriter` com `Directory` ou `DirectoryInfo` para organizar arquivos binários em diretórios.

### Exemplo: Organizando Transações por Dia

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

    public override string ToString()
    {
        return $"Cliente: {Cliente}, Valor: {Valor:F2} Kz, Data: {Data:dd/MM/yyyy HH:mm:ss}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        string caminhoBase = "TransacoesPorDia";
        string diaAtual = DateTime.Now.ToString("yyyy-MM-dd");
        string caminhoArquivo = Path.Combine(caminhoBase, $"transacoes_{diaAtual}.bin");
        List<Transacao> transacoes = new List<Transacao>
        {
            new Transacao("José dos Santos", 5000.00, DateTime.Now),
            new Transacao("Maria da Silva", 3000.00, DateTime.Now)
        };

        try
        {
            // Criar diretório
            Directory.CreateDirectory(caminhoBase);

            // Escrever transações
            using (FileStream fs = new FileStream(caminhoArquivo, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(transacoes.Count);
                foreach (var transacao in transacoes)
                {
                    writer.Write(transacao.Cliente);
                    writer.Write(transacao.Valor);
                    writer.Write(transacao.Data.ToBinary());
                }
            }

            // Ler e exibir transações
            DirectoryInfo dirInfo = new DirectoryInfo(caminhoBase);
            foreach (FileInfo file in dirInfo.GetFiles($"transacoes_{diaAtual}.bin"))
            {
                using (FileStream fs = new FileStream(file.FullName, FileMode.Open))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    int count = reader.ReadInt32();
                    Console.WriteLine($"Transações em {file.Name}:");
                    for (int i = 0; i < count; i++)
                    {
                        Transacao transacao = new Transacao(
                            reader.ReadString(),
                            reader.ReadDouble(),
                            DateTime.FromBinary(reader.ReadInt64())
                        );
                        Console.WriteLine(transacao);
                    }
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Erro: Permissão negada para acessar {caminhoBase}.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro de entrada/saída: {ex.Message}");
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
Transações em transacoes_2025-09-17.bin:
Cliente: José dos Santos, Valor: 5000,00 Kz, Data: 17/09/2025 22:30:00
Cliente: Maria da Silva, Valor: 3000,00 Kz, Data: 17/09/2025 22:30:00
```

**Explicação detalhada**:
- `Directory.CreateDirectory` cria a pasta base.
- `BinaryWriter` salva as transações em um arquivo binário nomeado por data.
- `DirectoryInfo.GetFiles` localiza o arquivo do dia atual.
- `BinaryReader` lê as transações, usando o contador para iterar.

**Exemplo do dia a dia**: Em um sistema de gestão bancária, organizar transações diárias em arquivos binários separados por data, facilitando auditorias ou análises.

## Boas Práticas para Manipulação de Arquivos Binários

- **Use o bloco `using`**: Garante que `FileStream`, `BinaryReader` e `BinaryWriter` sejam fechados corretamente.
- **Trate exceções específicas**: Capture `FileNotFoundException`, `EndOfStreamException` e `IOException`.
- **Mantenha a ordem de leitura/escrita consistente**: Leia na mesma ordem em que escreveu para evitar erros.
- **Use contadores para múltiplos registros**: Inclua o número de itens ao salvar listas para facilitar a leitura.
- **Especifique codificação para strings**: Use `BinaryWriter` com UTF-8 ou outra codificação explícita se necessário.
- **Evite arquivos binários para dados legíveis**: Use arquivos de texto para logs ou relatórios que precisam ser lidos por humanos.
- **Organize arquivos em diretórios**: Combine com `Directory`/`DirectoryInfo` para estruturar dados.
- **Teste com arquivos pequenos primeiro**: Valide o formato binário antes de processar grandes volumes de dados.

## Conclusão

Você agora entende como usar `BinaryReader` e `BinaryWriter` para manipular arquivos binários em C#, permitindo salvar e recuperar dados estruturados de forma eficiente. Essas classes são ideais para cenários que exigem compactação e desempenho, como registros de transações ou configurações. No contexto local, essas técnicas são úteis em sistemas bancários, auditorias ou gestão de dados, onde arquivos binários podem otimizar o armazenamento de transações em kwanzas.

**Próximos passos**: Tente criar um programa que salve uma lista de clientes (nome, telefone, saldo) em um arquivo binário e leia os dados para gerar um relatório. Experimente organizar os arquivos por data usando `DirectoryInfo` e trate erros como arquivos corrompidos. Quanto mais você praticar, mais confiante ficará em manipular arquivos binários!
