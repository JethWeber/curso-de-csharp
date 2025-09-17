# Entrada/Saída e Manipulação de Arquivos em C#

## Aula 49 - Trabalhando com Diretórios (`Directory`, `DirectoryInfo`)

Bem-vindo ao capítulo de Entrada/Saída e Manipulação de Arquivos em C#! Na aula anterior, aprendemos a usar `StreamReader` e `StreamWriter` para ler e escrever arquivos de texto. Agora, vamos explorar como gerenciar **diretórios** (pastas) no sistema de arquivos, utilizando as classes `Directory` e `DirectoryInfo` do namespace `System.IO`. Essas classes permitem criar, excluir, listar e manipular diretórios, o que é essencial para organizar dados, como relatórios de transações, backups ou arquivos de clientes.


Nesta aula, vamos abordar detalhadamente as funcionalidades de `Directory` (métodos estáticos) e `DirectoryInfo` (métodos de instância), com exemplos práticos no contexto angolano, como gerenciar pastas para relatórios bancários ou cadastros. Vamos também enfatizar o tratamento de exceções para lidar com erros comuns, como permissões insuficientes ou diretórios inexistentes.

### Objetivo

Entender como usar as classes `Directory` e `DirectoryInfo` para gerenciar diretórios em C#, incluindo criação, exclusão, listagem e manipulação, e aplicar essas técnicas em cenários reais, como organizar arquivos de transações ou backups.

## O que são `Directory` e `DirectoryInfo`?

- **`Directory`**: Uma classe estática que fornece métodos para manipular diretórios sem precisar criar uma instância. Ideal para operações pontuais, como criar ou excluir uma pasta.
- **`DirectoryInfo`**: Uma classe que representa um diretório específico como um objeto, permitindo acesso a propriedades e métodos de instância. Útil para operações repetitivas no mesmo diretório.

Ambas pertencem ao namespace `System.IO` e trabalham com o sistema de arquivos para gerenciar diretórios e seus conteúdos.

**Exemplo do dia a dia**: Em um sistema bancário, usar `Directory` para criar uma pasta para logs diários de transações ou `DirectoryInfo` para gerenciar uma estrutura de pastas para relatórios anuais.

### Características

- **Namespace `System.IO`**: Requer `using System.IO;`.
- **Métodos comuns**:
  - Criar, excluir e mover diretórios.
  - Listar arquivos e subdiretórios.
  - Verificar existência e propriedades (ex.: data de criação).
- **Exceções comuns**:
  - `DirectoryNotFoundException`: Diretório não encontrado.
  - `IOException`: Erros gerais de entrada/saída.
  - `UnauthorizedAccessException`: Permissões insuficientes.

## Usando a Classe `Directory`

A classe `Directory` oferece métodos estáticos para manipular diretórios. Principais métodos incluem:
- `CreateDirectory(path)`: Cria um diretório.
- `Delete(path, recursive)`: Exclui um diretório (opcionalmente com conteúdo).
- `Exists(path)`: Verifica se um diretório existe.
- `GetFiles(path)`: Lista arquivos em um diretório.
- `GetDirectories(path)`: Lista subdiretórios.
- `Move(source, dest)`: Move um diretório.

### Exemplo: Criando e Listando Diretórios

```csharp
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string caminhoPasta = "RelatoriosTransacoes";

        try
        {
            // Criar diretório
            if (!Directory.Exists(caminhoPasta))
            {
                Directory.CreateDirectory(caminhoPasta);
                Console.WriteLine($"Diretório {caminhoPasta} criado com sucesso.");
            }

            // Criar um arquivo de exemplo
            File.WriteAllText(Path.Combine(caminhoPasta, "transacao_2025_09.txt"), "Transação: 5000 Kz");

            // Listar arquivos
            Console.WriteLine("Arquivos no diretório:");
            string[] arquivos = Directory.GetFiles(caminhoPasta);
            foreach (string arquivo in arquivos)
            {
                Console.WriteLine(Path.GetFileName(arquivo));
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Erro: Permissão negada para acessar {caminhoPasta}.");
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

**Saída**:
```
Diretório RelatoriosTransacoes criado com sucesso.
Arquivos no diretório:
transacao_2025_09.txt
```

**Explicação detalhada**:
- `Directory.Exists` verifica se a pasta já existe para evitar erros.
- `Directory.CreateDirectory` cria a pasta, incluindo subdiretórios se o caminho for composto (ex.: "Relatorios/2025").
- `Directory.GetFiles` lista todos os arquivos no diretório.
- `Path.Combine` constrói caminhos de forma segura, respeitando o sistema operacional.
- Exceções como `UnauthorizedAccessException` tratam erros de permissão.

**Exemplo do dia a dia**: Em um sistema bancário, criar uma pasta para armazenar relatórios mensais de transações em kwanzas e listar os arquivos gerados.

## Usando a Classe `DirectoryInfo`

A classe `DirectoryInfo` representa um diretório específico como um objeto, permitindo acesso a propriedades como `Name`, `FullName`, `CreationTime` e métodos de instância. Principais métodos incluem:
- `Create()`: Cria o diretório.
- `Delete(bool recursive)`: Exclui o diretório (opcionalmente com conteúdo).
- `GetFiles()`: Lista arquivos.
- `GetDirectories()`: Lista subdiretórios.
- `MoveTo(dest)`: Move o diretório.

### Exemplo: Gerenciando Diretórios com `DirectoryInfo`

```csharp
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string caminhoPasta = "CadastrosClientes";
        DirectoryInfo dirInfo = new DirectoryInfo(caminhoPasta);

        try
        {
            // Criar diretório
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                Console.WriteLine($"Diretório {dirInfo.Name} criado em {dirInfo.FullName}.");
            }

            // Criar um arquivo de exemplo
            File.WriteAllText(Path.Combine(caminhoPasta, "cliente1.txt"), "Nome: Maria da Silva");

            // Listar arquivos e propriedades
            Console.WriteLine("Arquivos no diretório:");
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                Console.WriteLine($"{file.Name}, Criado em: {file.CreationTime}");
            }

            // Criar subdiretório
            DirectoryInfo subDir = dirInfo.CreateSubdirectory("2025");
            Console.WriteLine($"Subdiretório {subDir.Name} criado.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Erro: Permissão negada para acessar {caminhoPasta}.");
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

**Saída**:
```
Diretório CadastrosClientes criado em [caminho completo].
Arquivos no diretório:
cliente1.txt, Criado em: 17/09/2025 22:25:00
Subdiretório 2025 criado.
```

**Explicação detalhada**:
- `DirectoryInfo` cria um objeto para o diretório `CadastrosClientes`.
- `Exists` verifica se o diretório existe.
- `CreateSubdirectory` cria uma subpasta.
- `GetFiles` retorna objetos `FileInfo`, que fornecem propriedades como `CreationTime`.
- Exceções são tratadas para lidar com erros comuns.

**Exemplo do dia a dia**: Em um sistema de registo de clientes, criar uma pasta para armazenar cadastros e organizar subpastas por ano, como para auditorias anuais.

## Combinando `Directory`, `DirectoryInfo` e Manipulação de Arquivos

Você pode combinar `Directory`/`DirectoryInfo` com `StreamReader`/`StreamWriter` para gerenciar diretórios e processar seus arquivos.

### Exemplo: Organizando Relatórios por Mês

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
        string caminhoBase = "RelatoriosMensais";
        DirectoryInfo dirInfo = new DirectoryInfo(caminhoBase);
        List<Transacao> transacoes = new List<Transacao>
        {
            new Transacao("José dos Santos", 5000.00, DateTime.Now),
            new Transacao("Maria da Silva", 3000.00, DateTime.Now)
        };

        try
        {
            // Criar diretório base
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            // Criar subdiretório para o mês atual
            string mesAtual = DateTime.Now.ToString("yyyy-MM");
            DirectoryInfo subDir = dirInfo.CreateSubdirectory(mesAtual);

            // Escrever relatório
            string caminhoArquivo = Path.Combine(subDir.FullName, $"relatorio_{mesAtual}.txt");
            using (StreamWriter writer = new StreamWriter(caminhoArquivo))
            {
                writer.WriteLine($"Relatório de Transações - {mesAtual}");
                writer.WriteLine("=============================");
                double total = 0;
                foreach (var transacao in transacoes)
                {
                    writer.WriteLine($"Cliente: {transacao.Cliente}, Valor: {transacao.Valor:F2} Kz");
                    total += transacao.Valor;
                }
                writer.WriteLine($"Total: {total:F2} Kz");
            }

            // Listar arquivos no subdiretório
            Console.WriteLine($"Arquivos em {subDir.Name}:");
            foreach (FileInfo file in subDir.GetFiles())
            {
                Console.WriteLine($"{file.Name}, Tamanho: {file.Length} bytes");
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

**Saída**:
```
Arquivos em 2025-09:
relatorio_2025-09.txt, Tamanho: [tamanho em bytes]
```

**Conteúdo de `relatorio_2025-09.txt`**:
```
Relatório de Transações - 2025-09
=============================
Cliente: José dos Santos, Valor: 5000,00 Kz
Cliente: Maria da Silva, Valor: 3000,00 Kz
Total: 8000,00 Kz
```

**Explicação detalhada**:
- `DirectoryInfo` cria uma pasta base e um subdiretório para o mês atual.
- `StreamWriter` grava um relatório de transações no subdiretório.
- `GetFiles` lista os arquivos criados, com informações como tamanho.
- Exceções tratam erros como permissões ou falhas de escrita.

**Exemplo do dia a dia**: Em um sistema de gestão financeira, organizar relatórios de transações por mês em pastas separadas, como para auditorias em uma empresa em Talatona.

## Boas Práticas para Trabalhar com Diretórios

- **Use `using` para `DirectoryInfo` quando necessário**: Embora `DirectoryInfo` não implemente `IDisposable`, use `using` para `StreamReader`/`StreamWriter` ao manipular arquivos.
- **Verifique existência antes de manipular**: Use `Directory.Exists` ou `DirectoryInfo.Exists` para evitar erros.
- **Trate exceções específicas**: Capture `DirectoryNotFoundException`, `IOException` e `UnauthorizedAccessException`.
- **Use `Path.Combine` para caminhos**: Garante compatibilidade entre sistemas operacionais.
- **Evite caminhos absolutos**: Prefira caminhos relativos ou configuráveis para portabilidade.
- **Cuidado ao excluir diretórios**: Use `Delete(true)` com cautela, pois exclui recursivamente.
- **Organize diretórios logicamente**: Estruture pastas por data, tipo ou cliente para facilitar a gestão.
- **Registre operações críticas**: Logue criações ou exclusões de diretórios para auditoria.

## Conclusão

Você agora entende como usar `Directory` e `DirectoryInfo` para gerenciar diretórios em C#, incluindo criação, exclusão, listagem e manipulação. Essas classes são essenciais para organizar dados, como relatórios ou cadastros, e podem ser combinadas com `StreamReader`/`StreamWriter` para processar arquivos. No contexto local, essas técnicas são úteis em sistemas bancários, gestão de vendas ou auditorias, garantindo uma organização eficiente e segura dos dados.

**Próximos passos**: Tente criar um programa que organize arquivos de transações em subdiretórios por ano e mês, listando os arquivos criados e tratando erros como permissões. Quanto mais você praticar, mais confiante ficará em gerenciar diretórios!
