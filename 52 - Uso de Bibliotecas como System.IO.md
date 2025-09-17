# Entrada/Saída e Manipulação de Arquivos em C#

## Aula 52 - Uso de Bibliotecas como `System.IO`

Bem-vindo ao capítulo de Entrada/Saída e Manipulação de Arquivos em C#! Após explorarmos leitura e escrita de arquivos de texto, gerenciamento de diretórios, manipulação de arquivos binários e serialização, agora vamos consolidar o uso da biblioteca **`System.IO`**, que é central para operações de entrada/saída (I/O) em C#. Esta biblioteca fornece classes para trabalhar com arquivos, diretórios, fluxos e caminhos, sendo essencial para tarefas como salvar dados de transações, ler cadastros de clientes ou gerenciar logs.

Nesta aula, vamos detalhar as principais classes e funcionalidades de `System.IO`, incluindo `File`, `FileInfo`, `Path`, `FileStream`, e outras, com exemplos práticos no contexto angolano, como gerenciar relatórios bancários ou dados de vendas. Vamos abordar como combinar essas classes, tratar exceções e seguir boas práticas para operações seguras e eficientes.

### Objetivo

Entender as principais classes da biblioteca `System.IO`, aprender a usá-las para manipular arquivos e diretórios, e aplicar essas técnicas em cenários reais, como salvar logs de transações em kwanzas ou organizar cadastros de clientes, com tratamento adequado de erros.

## O que é a Biblioteca `System.IO`?

A biblioteca `System.IO` é um namespace do .NET que fornece classes para realizar operações de entrada/saída, incluindo:
- Manipulação de arquivos (ler, escrever, criar, excluir).
- Gerenciamento de diretórios (criar, listar, mover).
- Trabalho com fluxos (streams) para dados brutos.
- Manipulação de caminhos de arquivos e diretórios.

**Exemplo do dia a dia**: Em um sistema de multibanco, usar `System.IO` para salvar logs de transações em arquivos, criar pastas para relatórios mensais ou ler configurações de clientes a partir de arquivos.

### Principais Classes de `System.IO`

- **`File`**: Métodos estáticos para manipular arquivos (ex.: criar, excluir, ler).
- **`FileInfo`**: Métodos de instância para manipular um arquivo específico.
- **`Directory`**: Métodos estáticos para gerenciar diretórios.
- **`DirectoryInfo`**: Métodos de instância para um diretório específico.
- **`Path`**: Métodos estáticos para manipular caminhos de arquivos/diretórios.
- **`FileStream`**: Fluxo de bytes para leitura/escrita de arquivos.
- **`StreamReader`/`StreamWriter`**: Leitura/escrita de arquivos de texto.
- **`BinaryReader`/`BinaryWriter`**: Leitura/escrita de arquivos binários.

**Exceções comuns**:
- `FileNotFoundException`: Arquivo não encontrado.
- `DirectoryNotFoundException`: Diretório não encontrado.
- `IOException`: Erros gerais de entrada/saída.
- `UnauthorizedAccessException`: Permissões insuficientes.

## Usando a Classe `File`

A classe `File` oferece métodos estáticos para operações rápidas em arquivos, como criar, excluir, mover ou ler/escrever conteúdo.

### Exemplo: Manipulando um Log de Transações

```csharp
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string caminhoArquivo = "log_transacoes.txt";
        string[] transacoes = new[]
        {
            "17/09/2025 23:00:00,José dos Santos,5000.00 Kz",
            "17/09/2025 23:01:00,Maria da Silva,3000.00 Kz"
        };

        try
        {
            // Escrever transações no arquivo
            File.WriteAllLines(caminhoArquivo, transacoes);
            Console.WriteLine("Log de transações salvo com sucesso.");

            // Ler e exibir o arquivo
            Console.WriteLine("Conteúdo do log:");
            string[] linhas = File.ReadAllLines(caminhoArquivo);
            foreach (string linha in linhas)
            {
                Console.WriteLine(linha);
            }

            // Copiar o arquivo para backup
            string caminhoBackup = "log_transacoes_backup.txt";
            File.Copy(caminhoArquivo, caminhoBackup, true);
            Console.WriteLine($"Backup criado em {caminhoBackup}.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro de entrada/saída: {ex.Message}");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Erro: Permissão negada para acessar {caminhoArquivo}.");
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
Log de transações salvo com sucesso.
Conteúdo do log:
17/09/2025 23:00:00,José dos Santos,5000.00 Kz
17/09/2025 23:01:00,Maria da Silva,3000.00 Kz
Backup criado em log_transacoes_backup.txt.
```

**Explicação detalhada**:
- `File.WriteAllLines` escreve uma array de strings no arquivo, criando-o ou sobrescrevendo.
- `File.ReadAllLines` lê todas as linhas do arquivo como uma array de strings.
- `File.Copy` cria uma cópia do arquivo para backup.
- Exceções tratam erros como permissões ou falhas de I/O.

**Exemplo do dia a dia**: Em um sistema de multibanco, salvar um log diário de transações em kwanzas e criar backups automáticos para auditoria.

## Usando a Classe `FileInfo`

A classe `FileInfo` representa um arquivo específico, permitindo operações detalhadas com métodos de instância. É útil para manipulações repetitivas no mesmo arquivo.

### Exemplo: Gerenciando Arquivo de Configuração

```csharp
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string caminhoArquivo = "configuracao.txt";
        FileInfo fileInfo = new FileInfo(caminhoArquivo);

        try
        {
            // Criar ou atualizar arquivo
            using (StreamWriter writer = fileInfo.CreateText())
            {
                writer.WriteLine("Configurações do Sistema Bancário");
                writer.WriteLine("Moeda: Kwanza (Kz)");
                writer.WriteLine("LimiteTransacao: 100000.00");
            }
            Console.WriteLine($"Arquivo {fileInfo.Name} criado/atualizado.");

            // Exibir propriedades
            Console.WriteLine($"Tamanho: {fileInfo.Length} bytes");
            Console.WriteLine($"Criado em: {fileInfo.CreationTime}");
            Console.WriteLine($"Última modificação: {fileInfo.LastWriteTime}");

            // Ler conteúdo
            using (StreamReader reader = fileInfo.OpenText())
            {
                Console.WriteLine("Conteúdo do arquivo:");
                Console.WriteLine(reader.ReadToEnd());
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro de entrada/saída: {ex.Message}");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Erro: Permissão negada para acessar {caminhoArquivo}.");
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
Arquivo configuracao.txt criado/atualizado.
Tamanho: [tamanho em bytes]
Criado em: 17/09/2025 23:08:00
Última modificação: 17/09/2025 23:08:00
Conteúdo do arquivo:
Configurações do Sistema Bancário
Moeda: Kwanza (Kz)
LimiteTransacao: 100000.00
```

**Explicação detalhada**:
- `FileInfo.CreateText` cria ou sobrescreve o arquivo e retorna um `StreamWriter`.
- Propriedades como `Length`, `CreationTime` e `LastWriteTime` fornecem metadados.
- `FileInfo.OpenText` retorna um `StreamReader` para leitura.
- O bloco `using` garante que os fluxos sejam fechados.

**Exemplo do dia a dia**: Em um sistema de gestão bancária, salvar configurações como limite de transação ou moeda padrão em um arquivo e consultar suas propriedades.

## Usando a Classe `Path`

A classe `Path` fornece métodos estáticos para manipular caminhos de arquivos e diretórios de forma segura, respeitando as convenções do sistema operacional.

### Exemplo: Construindo e Validando Caminhos

```csharp
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string caminhoBase = "Relatorios";
            string ano = "2025";
            string mes = "09";
            string nomeArquivo = "transacoes.txt";
            string caminhoCompleto = Path.Combine(caminhoBase, ano, mes, nomeArquivo);

            // Criar diretório
            Directory.CreateDirectory(Path.GetDirectoryName(caminhoCompleto));

            // Escrever no arquivo
            File.WriteAllText(caminhoCompleto, "Transação: 5000 Kz");

            // Exibir informações do caminho
            Console.WriteLine($"Caminho completo: {caminhoCompleto}");
            Console.WriteLine($"Nome do arquivo: {Path.GetFileName(caminhoCompleto)}");
            Console.WriteLine($"Extensão: {Path.GetExtension(caminhoCompleto)}");
            Console.WriteLine($"Diretório pai: {Path.GetDirectoryName(caminhoCompleto)}");
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
Caminho completo: Relatorios\2025\09\transacoes.txt
Nome do arquivo: transacoes.txt
Extensão: .txt
Diretório pai: Relatorios\2025\09
```

**Explicação detalhada**:
- `Path.Combine` constrói caminhos de forma segura, usando o separador correto (`\` no Windows).
- `Path.GetDirectoryName` extrai o diretório pai para criar a estrutura de pastas.
- `Path.GetFileName` e `Path.GetExtension` fornecem partes do caminho.
- Exceções tratam erros como permissões ou caminhos inválidos.

**Exemplo do dia a dia**: Em um sistema de relatórios, organizar arquivos de transações por ano e mês, usando `Path` para criar caminhos consistentes.

## Combinando `System.IO` com Serialização

Você pode combinar `System.IO` com serialização (JSON/XML) para salvar objetos em arquivos estruturados.

### Exemplo: Salvando e Lendo Clientes com JSON

```csharp
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class Cliente
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public double Saldo { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        string caminhoBase = "Cadastros";
        string caminhoArquivo = Path.Combine(caminhoBase, "clientes.json");
        List<Cliente> clientes = new List<Cliente>
        {
            new Cliente { Nome = "José dos Santos", Telefone = "+244 923 456 789", Saldo = 5000.00 },
            new Cliente { Nome = "Maria da Silva", Telefone = "+244 912 345 678", Saldo = 3000.00 }
        };

        try
        {
            // Criar diretório
            Directory.CreateDirectory(caminhoBase);

            // Serializar para JSON
            var opcoes = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(clientes, opcoes);
            File.WriteAllText(caminhoArquivo, jsonString);
            Console.WriteLine($"Clientes salvos em {caminhoArquivo}.");

            // Ler e exibir metadados
            FileInfo fileInfo = new FileInfo(caminhoArquivo);
            Console.WriteLine($"Tamanho: {fileInfo.Length} bytes, Criado em: {fileInfo.CreationTime}");

            // Desserializar e exibir
            string jsonLido = File.ReadAllText(caminhoArquivo);
            List<Cliente> clientesLidos = JsonSerializer.Deserialize<List<Cliente>>(jsonLido);
            Console.WriteLine("Clientes lidos:");
            foreach (var cliente in clientesLidos)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, Telefone: {cliente.Telefone}, Saldo: {cliente.Saldo:F2} Kz");
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Erro de serialização/desserialização JSON: {ex.Message}");
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
Clientes salvos em Cadastros\clientes.json.
Tamanho: [tamanho em bytes], Criado em: 17/09/2025 23:08:00
Clientes lidos:
Nome: José dos Santos, Telefone: +244 923 456 789, Saldo: 5000,00 Kz
Nome: Maria da Silva, Telefone: +244 912 345 678, Saldo: 3000,00 Kz
```

**Explicação detalhada**:
- `Directory.CreateDirectory` cria a pasta para os dados.
- `Path.Combine` constrói o caminho do arquivo JSON.
- `File.WriteAllText` e `File.ReadAllText` manipulam o conteúdo JSON.
- `FileInfo` fornece metadados do arquivo.
- `JsonSerializer` realiza serialização/desserialização.

**Exemplo do dia a dia**: Em uma loja em Talatona, salvar cadastros de clientes em JSON, organizados em uma pasta, e consultar metadados para auditoria.

## Boas Práticas para Uso de `System.IO`

- **Use `using` para fluxos**: Garante que `FileStream`, `StreamReader`, `StreamWriter`, etc., sejam fechados corretamente.
- **Trate exceções específicas**: Capture `FileNotFoundException`, `IOException`, `UnauthorizedAccessException`, etc.
- **Use `Path` para caminhos**: Evite concatenar strings manualmente; use `Path.Combine` para portabilidade.
- **Verifique existência**: Use `File.Exists` ou `Directory.Exists` antes de operações.
- **Evite caminhos absolutos**: Prefira caminhos relativos ou configuráveis.
- **Combine com serialização**: Use JSON/XML para dados estruturados, combinando com `File` ou `FileStream`.
- **Registre operações críticas**: Logue criações, exclusões ou erros para auditoria.
- **Considere desempenho**: Para arquivos grandes, use fluxos (`FileStream`) em vez de métodos como `File.ReadAllText`.

## Conclusão

Você agora entende como usar a biblioteca `System.IO` para manipular arquivos e diretórios em C#, com classes como `File`, `FileInfo`, `Path` e `FileStream`. Essas ferramentas, combinadas com serialização ou fluxos, permitem gerenciar dados de forma eficiente e segura. No contexto local, são ideais para sistemas bancários, gestão de vendas ou cadastros, como salvar logs de transações em kwanzas ou organizar relatórios.

**Próximos passos**: Tente criar um programa que combine `System.IO` com JSON para salvar e ler uma lista de transações, organize os arquivos em pastas por data usando `Path` e `Directory`, e exiba metadados com `FileInfo`. Experimente tratar erros como permissões ou arquivos ausentes. Quanto mais você praticar, mais confiante ficará em usar `System.IO`!
