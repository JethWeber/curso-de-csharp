# Entrada/Saída e Manipulação de Arquivos em C#

## Aula 51 - Serialização (JSON, XML)

Bem-vindo ao capítulo de Entrada/Saída e Manipulação de Arquivos em C#! Após aprendermos a manipular arquivos de texto com `StreamReader`/`StreamWriter`, diretórios com `Directory`/`DirectoryInfo`, e arquivos binários com `BinaryReader`/`BinaryWriter`, agora vamos explorar a **serialização**, um processo que converte objetos em formatos como JSON ou XML para armazenamento ou transmissão, e a desserialização, que converte esses formatos de volta em objetos. Esses formatos são amplamente usados para salvar configurações, compartilhar dados entre sistemas ou gerar relatórios.

Nesta aula, vamos detalhar como serializar e desserializar objetos em JSON (usando `System.Text.Json`) e XML (usando `System.Xml.Serialization`), com exemplos práticos no contexto angolano, como salvar cadastros de clientes ou configurações de transações bancárias. Vamos abordar a sintaxe, as bibliotecas necessárias, o tratamento de exceções e boas práticas para garantir operações robustas.

### Objetivo

Entender como realizar serialização e desserialização em JSON e XML em C#, aplicar essas técnicas em cenários reais, como salvar dados de clientes ou transações em kwanzas, e gerenciar erros com blocos `try-catch`.

## O que é Serialização?

**Serialização** é o processo de converter um objeto (ou estrutura de dados) em um formato que possa ser armazenado (ex.: em um arquivo) ou transmitido (ex.: via rede). **Desserialização** é o processo inverso, reconstruindo o objeto a partir do formato serializado. JSON e XML são formatos populares devido à sua legibilidade e suporte em várias plataformas.

- **JSON (JavaScript Object Notation)**: Um formato leve e legível, ideal para APIs e armazenamento compacto.
- **XML (Extensible Markup Language)**: Um formato mais estruturado, usado em sistemas legados ou configurações complexas.

**Exemplo do dia a dia**: Em um sistema bancário, serializar uma lista de transações em JSON para enviar a um servidor ou salvar configurações de uma conta em XML para integração com outros sistemas.

### Características

- **Namespaces**:
  - JSON: `System.Text.Json` (C# moderno, .NET Core e posteriores) ou `Newtonsoft.Json` (biblioteca externa).
  - XML: `System.Xml.Serialization`.
- **Vantagens**:
  - JSON: Compacto, amplamente usado em APIs modernas.
  - XML: Suporta esquemas complexos, usado em sistemas empresariais.
- **Exceções comuns**:
  - `JsonException`: Erros de serialização/desserialização JSON.
  - `InvalidOperationException`: Erros em XML, como formatos inválidos.
  - `IOException`: Erros de entrada/saída ao acessar arquivos.

## Serialização e Desserialização JSON com `System.Text.Json`

A biblioteca `System.Text.Json` (incluída no .NET Core e .NET 5+) é usada para serializar e desserializar objetos em JSON. Requer `using System.Text.Json;`.

### Exemplo: Salvando e Lendo Clientes em JSON

Vamos serializar uma lista de clientes em um arquivo JSON e desserializá-la.

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
        string caminhoArquivo = "clientes.json";
        List<Cliente> clientes = new List<Cliente>
        {
            new Cliente { Nome = "José dos Santos", Telefone = "+244 923 456 789", Saldo = 5000.00 },
            new Cliente { Nome = "Maria da Silva", Telefone = "+244 912 345 678", Saldo = 3000.00 }
        };

        // Serializar para JSON
        try
        {
            var opcoes = new JsonSerializerOptions { WriteIndented = true }; // Formatação legível
            string jsonString = JsonSerializer.Serialize(clientes, opcoes);
            File.WriteAllText(caminhoArquivo, jsonString);
            Console.WriteLine("Clientes salvos em JSON com sucesso.");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Erro de serialização JSON: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro de escrita: {ex.Message}");
        }

        // Desserializar de JSON
        try
        {
            string jsonLido = File.ReadAllText(caminhoArquivo);
            List<Cliente> clientesLidos = JsonSerializer.Deserialize<List<Cliente>>(jsonLido);
            Console.WriteLine("Clientes lidos do JSON:");
            foreach (var cliente in clientesLidos)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, Telefone: {cliente.Telefone}, Saldo: {cliente.Saldo:F2} Kz");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Erro: O arquivo {caminhoArquivo} não foi encontrado.");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Erro de desserialização JSON: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro de leitura: {ex.Message}");
        }
    }
}
```

**Conteúdo de `clientes.json`**:
```json
[
  {
    "Nome": "José dos Santos",
    "Telefone": "+244 923 456 789",
    "Saldo": 5000.0
  },
  {
    "Nome": "Maria da Silva",
    "Telefone": "+244 912 345 678",
    "Saldo": 3000.0
  }
]
```

**Saída**:
```
Clientes salvos em JSON com sucesso.
Clientes lidos do JSON:
Nome: José dos Santos, Telefone: +244 923 456 789, Saldo: 5000,00 Kz
Nome: Maria da Silva, Telefone: +244 912 345 678, Saldo: 3000,00 Kz
```

**Explicação detalhada**:
- `JsonSerializer.Serialize` converte a lista de clientes em uma string JSON, com `WriteIndented = true` para formatação legível.
- `File.WriteAllText` salva o JSON no arquivo.
- `JsonSerializer.Deserialize` reconstrói a lista de objetos a partir do JSON.
- Exceções como `JsonException` tratam erros de formato, e `FileNotFoundException` lida com arquivos ausentes.

**Exemplo do dia a dia**: Em um sistema de gestão de clientes para uma loja em Talatona, salvar cadastros em JSON para sincronizar com um servidor ou aplicativo móvel.

## Serialização e Desserialização XML com `System.Xml.Serialization`

A biblioteca `System.Xml.Serialization` é usada para serializar e desserializar objetos em XML. Requer `using System.Xml.Serialization;`.

### Exemplo: Salvando e Lendo Transações em XML

Vamos serializar uma lista de transações bancárias em um arquivo XML e desserializá-la.

```csharp
using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

public class Transacao
{
    public string Cliente { get; set; }
    public double Valor { get; set; }
    public DateTime Data { get; set; }
}

[XmlRoot("Transacoes")]
public class ListaTransacoes
{
    [XmlElement("Transacao")]
    public List<Transacao> Transacoes { get; set; } = new List<Transacao>();
}

class Program
{
    static void Main(string[] args)
    {
        string caminhoArquivo = "transacoes.xml";
        ListaTransacoes lista = new ListaTransacoes
        {
            Transacoes = new List<Transacao>
            {
                new Transacao { Cliente = "José dos Santos", Valor = 5000.00, Data = DateTime.Now },
                new Transacao { Cliente = "Maria da Silva", Valor = 3000.00, Data = DateTime.Now.AddHours(-1) }
            }
        };

        // Serializar para XML
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ListaTransacoes));
            using (FileStream fs = new FileStream(caminhoArquivo, FileMode.Create))
            {
                serializer.Serialize(fs, lista);
                Console.WriteLine("Transações salvas em XML com sucesso.");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Erro de serialização XML: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro de escrita: {ex.Message}");
        }

        // Desserializar de XML
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ListaTransacoes));
            using (FileStream fs = new FileStream(caminhoArquivo, FileMode.Open))
            {
                ListaTransacoes listaLida = (ListaTransacoes)serializer.Deserialize(fs);
                Console.WriteLine("Transações lidas do XML:");
                foreach (var transacao in listaLida.Transacoes)
                {
                    Console.WriteLine($"Cliente: {transacao.Cliente}, Valor: {transacao.Valor:F2} Kz, Data: {transacao.Data:dd/MM/yyyy HH:mm:ss}");
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Erro: O arquivo {caminhoArquivo} não foi encontrado.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Erro de desserialização XML: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro de leitura: {ex.Message}");
        }
    }
}
```

**Conteúdo de `transacoes.xml`**:
```xml
<?xml version="1.0" encoding="utf-8"?>
<Transacoes>
  <Transacao>
    <Cliente>José dos Santos</Cliente>
    <Valor>5000</Valor>
    <Data>2025-09-17T22:30:00</Data>
  </Transacao>
  <Transacao>
    <Cliente>Maria da Silva</Cliente>
    <Valor>3000</Valor>
    <Data>2025-09-17T21:30:00</Data>
  </Transacao>
</Transacoes>
```

**Saída**:
```
Transações salvas em XML com sucesso.
Transações lidas do XML:
Cliente: José dos Santos, Valor: 5000,00 Kz, Data: 17/09/2025 22:30:00
Cliente: Maria da Silva, Valor: 3000,00 Kz, Data: 17/09/2025 21:30:00
```

**Explicação detalhada**:
- A classe `ListaTransacoes` usa atributos `[XmlRoot]` e `[XmlElement]` para personalizar a estrutura XML.
- `XmlSerializer.Serialize` converte o objeto em XML, e `Deserialize` reconstrói o objeto.
- O bloco `using` com `FileStream` garante que o arquivo seja fechado.
- Exceções como `InvalidOperationException` tratam erros de formato XML.

**Exemplo do dia a dia**: Em um sistema bancário, salvar transações em XML para integração com sistemas legados ou relatórios de auditoria.

## Combinando Serialização com Diretórios

Você pode combinar JSON/XML com `Directory`/`DirectoryInfo` para organizar dados em pastas.

### Exemplo: Salvando Transações por Dia em JSON

```csharp
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

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
        string caminhoBase = "TransacoesPorDia";
        string diaAtual = DateTime.Now.ToString("yyyy-MM-dd");
        string caminhoArquivo = Path.Combine(caminhoBase, $"transacoes_{diaAtual}.json");
        List<Transacao> transacoes = new List<Transacao>
        {
            new Transacao { Cliente = "José dos Santos", Valor = 5000.00, Data = DateTime.Now },
            new Transacao { Cliente = "Maria da Silva", Valor = 3000.00, Data = DateTime.Now }
        };

        try
        {
            // Criar diretório
            Directory.CreateDirectory(caminhoBase);

            // Serializar para JSON
            var opcoes = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(transacoes, opcoes);
            File.WriteAllText(caminhoArquivo, jsonString);

            // Listar arquivos e ler JSON
            DirectoryInfo dirInfo = new DirectoryInfo(caminhoBase);
            foreach (FileInfo file in dirInfo.GetFiles($"transacoes_{diaAtual}.json"))
            {
                string jsonLido = File.ReadAllText(file.FullName);
                List<Transacao> transacoesLidas = JsonSerializer.Deserialize<List<Transacao>>(jsonLido);
                Console.WriteLine($"Transações em {file.Name}:");
                foreach (var transacao in transacoesLidas)
                {
                    Console.WriteLine($"Cliente: {transacao.Cliente}, Valor: {transacao.Valor:F2} Kz, Data: {transacao.Data:dd/MM/yyyy HH:mm:ss}");
                }
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
Transações em transacoes_2025-09-17.json:
Cliente: José dos Santos, Valor: 5000,00 Kz, Data: 17/09/2025 22:30:00
Cliente: Maria da Silva, Valor: 3000,00 Kz, Data: 17/09/2025 22:30:00
```

**Explicação detalhada**:
- `Directory.CreateDirectory` cria a pasta base.
- `JsonSerializer.Serialize` salva as transações em um arquivo JSON por data.
- `DirectoryInfo.GetFiles` localiza o arquivo do dia atual, e `JsonSerializer.Deserialize` lê os dados.
- Exceções tratam erros de formato ou acesso ao arquivo.

**Exemplo do dia a dia**: Em um sistema de gestão financeira, organizar transações diárias em arquivos JSON por data, para auditorias ou integração com outros sistemas.

## Boas Práticas para Serialização

- **Use `using` para fluxos**: Garante que `FileStream` seja fechado em XML ou ao combinar com arquivos.
- **Trate exceções específicas**: Capture `JsonException`, `InvalidOperationException` e `IOException`.
- **Valide dados antes da serialização**: Evite salvar objetos com valores inválidos (ex.: nulos em campos obrigatórios).
- **Use formatação legível para JSON**: `WriteIndented = true` facilita a leitura humana durante desenvolvimento.
- **Defina atributos XML quando necessário**: Use `[XmlRoot]` e `[XmlElement]` para personalizar a estrutura XML.
- **Escolha o formato certo**: Use JSON para APIs modernas ou dados compactos; XML para sistemas legados ou esquemas complexos.
- **Organize arquivos em diretórios**: Use `Directory`/`DirectoryInfo` para estruturar arquivos por data ou tipo.
- **Teste a desserialização**: Verifique se os dados podem ser lidos corretamente após a serialização.

## Conclusão

Você agora entende como realizar **serialização e desserialização** em JSON (com `System.Text.Json`) e XML (com `System.Xml.Serialization`) em C#. Essas técnicas permitem salvar e recuperar objetos de forma estruturada, sendo ideais para cadastros, transações ou configurações. No contexto local, são úteis em sistemas bancários, lojas ou auditorias, onde dados como transações em kwanzas precisam ser armazenados ou compartilhados.

**Próximos passos**: Tente criar um programa que serialize uma lista de clientes ou transações em JSON e XML, organize os arquivos em pastas por data e leia os dados para gerar um relatório. Experimente tratar erros como formatos inválidos ou arquivos ausentes. Quanto mais você praticar, mais confiante ficará em usar serialização!
