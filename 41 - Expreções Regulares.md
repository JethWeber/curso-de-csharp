# Manipulação de Strings e Expressões Regulares em C#

## Aula 41 - Expressões Regulares (`Regex`)

Bem-vindo ao capítulo de Manipulação de Strings e Expressões Regulares em C#! Após explorarmos métodos de string, formatação e o `StringBuilder`, é hora de mergulhar nas **expressões regulares** (ou `Regex`), uma ferramenta poderosa para busca, validação e manipulação de padrões de texto. Em C#, a classe `System.Text.RegularExpressions.Regex` permite trabalhar com expressões regulares para realizar tarefas complexas, como validar e-mails, extrair números de um texto ou substituir padrões específicos.

Nesta aula, vamos aprender o que são expressões regulares, como usá-las em C# com a classe `Regex` e aplicar seus métodos em exemplos práticos do dia a dia.

### Objetivo

Entender o conceito de expressões regulares, os métodos principais da classe `Regex` em C# e como aplicá-los para buscar, validar e manipular padrões de texto de forma eficiente.

## O que são Expressões Regulares?

Uma **expressão regular** (ou *regex*) é uma sequência de caracteres que define um padrão de busca. Ela é usada para corresponder, extrair ou substituir partes de um texto que seguem esse padrão. Em C#, a classe `Regex` (namespace `System.Text.RegularExpressions`) oferece métodos para trabalhar com esses padrões.

Pense em uma expressão regular como um filtro avançado em um editor de texto: você pode procurar por algo específico, como "todos os números de telefone" ou "palavras que começam com 'A'".

### Características das Expressões Regulares

- **Poderosas e flexíveis**: Permitem encontrar padrões complexos, como e-mails, URLs ou datas.
- **Namespace `System.Text.RegularExpressions`**: Requer `using System.Text.RegularExpressions;`.
- **Sintaxe específica**: Usa caracteres especiais (ex.: `\d`, `.`, `*`) para definir padrões.
- **Aplicações comuns**: Validação de entrada, extração de dados, substituição de texto.

## Sintaxe Básica de Expressões Regulares

Aqui estão alguns elementos comuns em expressões regulares:

- **Literais**: Caracteres exatos, como `abc` para corresponder a "abc".
- **Metacaracteres**:
  - `.` : Corresponde a qualquer caractere (exceto nova linha).
  - `\d` : Corresponde a um dígito (0-9).
  - `\w` : Corresponde a um caractere alfanumérico (a-z, A-Z, 0-9, _).
  - `\s` : Corresponde a um espaço em branco.
- **Quantificadores**:
  - `*` : 0 ou mais ocorrências.
  - `+` : 1 ou mais ocorrências.
  - `?` : 0 ou 1 ocorrência.
  - `{n}` : Exatamente *n* ocorrências.
- **Grupos e classes**:
  - `[abc]` : Corresponde a um caractere entre 'a', 'b' ou 'c'.
  - `[^abc]` : Corresponde a qualquer caractere exceto 'a', 'b' ou 'c'.
  - `(abc)` : Agrupa "abc" como um padrão.
- **Âncoras**:
  - `^` : Início da string.
  - `$` : Fim da string.

Exemplo: O padrão `\d{3}-\d{3}-\d{4}` corresponde a um número de telefone no formato "123-456-7890".

## Métodos Principais da Classe `Regex`

A classe `Regex` oferece métodos para trabalhar com padrões:

- `IsMatch(string input, string pattern)`: Verifica se o texto corresponde ao padrão.
- `Match(string input, string pattern)`: Retorna a primeira correspondência.
- `Matches(string input, string pattern)`: Retorna todas as correspondências.
- `Replace(string input, string pattern, string replacement)`: Substitui correspondências pelo texto especificado.
- `Split(string input, string pattern)`: Divide a string com base no padrão.

## Exemplo Básico de `Regex`

### Validando um E-mail

```csharp
using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string email = "joao@example.com";
        string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        // Verificando se o e-mail é válido
        bool isValid = Regex.IsMatch(email, pattern);
        Console.WriteLine($"E-mail válido? {isValid}"); // Exibe: E-mail válido? True

        // Testando um e-mail inválido
        email = "joao@.com";
        isValid = Regex.IsMatch(email, pattern);
        Console.WriteLine($"E-mail válido? {isValid}"); // Exibe: E-mail válido? False
    }
}
```

**Explicação do padrão**:
- `^` : Início da string.
- `[\w-\.]+` : Um ou mais caracteres alfanuméricos, hífen ou ponto.
- `@` : Caractere literal "@".
- `([\w-]+\.)+` : Um ou mais grupos de caracteres alfanuméricos ou hífen, seguidos por um ponto.
- `[\w-]{2,4}` : Domínio de 2 a 4 caracteres (ex.: com, org).
- `$` : Fim da string.

**Exemplo do dia a dia**: Validar entradas de formulários, como e-mails, em um sistema web.

## Extraindo Dados com `Regex`

### Exemplo: Extraindo Números de Telefone

```csharp
using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string texto = "Contatos: (11) 91234-5678, (21) 98765-4321";
        string pattern = @"\(\d{2}\)\s\d{5}-\d{4}";

        // Encontrando todas as correspondências
        MatchCollection matches = Regex.Matches(texto, pattern);
        foreach (Match match in matches)
        {
            Console.WriteLine($"Telefone: {match.Value}");
        }
        // Exibe:
        // Telefone: (11) 91234-5678
        // Telefone: (21) 98765-4321
    }
}
```

**Explicação do padrão**:
- `\(\d{2}\)` : Parênteses com dois dígitos (ex.: (11)).
- `\s` : Espaço em branco.
- `\d{5}-\d{4}` : 5 dígitos, hífen, 4 dígitos (ex.: 91234-5678).

**Exemplo do dia a dia**: Extrair números de telefone de um texto, como em um sistema de CRM.

## Substituindo Texto com `Regex`

### Exemplo: Mascara Números Sensíveis

```csharp
using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string texto = "Cartão: 1234-5678-9012-3456";
        string pattern = @"\d{4}-\d{4}-\d{4}-\d{4}";

        // Substituindo o número do cartão por asteriscos
        string resultado = Regex.Replace(texto, pattern, "****-****-****-****");
        Console.WriteLine(resultado); // Exibe: Cartão: ****-****-****-****
    }
}
```

**Exemplo do dia a dia**: Ocultar informações sensíveis, como números de cartão de crédito, em logs ou relatórios.

## Dividindo Texto com `Regex`

### Exemplo: Dividindo por Delimitadores Variáveis

```csharp
using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string texto = "Maçã;Banana,Laranja Morango";
        string pattern = @"[;,\s]+"; // Divide por ;, ,, ou espaços

        // Dividindo o texto
        string[] frutas = Regex.Split(texto, pattern);
        Console.WriteLine(string.Join(", ", frutas)); // Exibe: Maçã, Banana, Laranja, Morango
    }
}
```

**Explicação do padrão**:
- `[;,\s]+` : Um ou mais caracteres que são ponto e vírgula, vírgula ou espaço.

**Exemplo do dia a dia**: Processar arquivos CSV com delimitadores variados (vírgula, ponto e vírgula, espaço).

## `Regex` com Objetos Personalizados

Expressões regulares podem ser usadas para extrair ou validar dados de objetos personalizados.

```csharp
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Pedido
{
    public string Codigo { get; set; }
    public string Descricao { get; set; }

    public Pedido(string codigo, string descricao)
    {
        Codigo = codigo;
        Descricao = descricao;
    }

    public override string ToString()
    {
        return $"{Codigo}: {Descricao}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Pedido> pedidos = new List<Pedido>
        {
            new Pedido("PED-001", "Notebook"),
            new Pedido("INV-002", "Mouse"),
            new Pedido("PED-003", "Teclado")
        };

        string pattern = @"^PED-\d{3}$"; // Corresponde a códigos como PED-001

        // Filtrando pedidos com código PED-xxx
        foreach (var pedido in pedidos)
        {
            if (Regex.IsMatch(pedido.Codigo, pattern))
            {
                Console.WriteLine(pedido);
            }
        }
        // Exibe:
        // PED-001: Notebook
        // PED-003: Teclado
    }
}
```

**Exemplo do dia a dia**: Filtrar pedidos com códigos específicos (ex.: começando com "PED-") em um sistema de gerenciamento.

## Boas Práticas para Expressões Regulares

- **Teste seus padrões**: Use ferramentas como Regex101.com para validar expressões antes de usá-las no código.
- **Evite padrões complexos desnecessários**: Regex pode ser difícil de ler; use métodos de string simples quando possível.
- **Compile expressões para desempenho**: Use `RegexOptions.Compiled` para padrões usados repetidamente (ex.: `new Regex(pattern, RegexOptions.Compiled)`).
- **Valide entradas**: Certifique-se de que o texto de entrada não é nulo para evitar `ArgumentNullException`.
- **Use grupos para extração**: Utilize parênteses `( )` para capturar partes específicas do padrão.
- **Documente padrões**: Adicione comentários explicando o que o padrão faz, especialmente se for complexo.
- **Combine com LINQ**: Use `Regex` com LINQ para processar coleções de strings de forma eficiente.

## Conclusão

Você agora entende como usar **expressões regulares** em C# com a classe `Regex`. Com métodos como `IsMatch`, `Matches`, `Replace` e `Split`, você pode validar, extrair e manipular padrões de texto de forma poderosa. Expressões regulares são ideais para tarefas como validar e-mails, extrair números ou mascarar dados sensíveis, mas exigem cuidado para garantir legibilidade e desempenho.

**Próximos passos**: Tente criar um programa que valide CPFs ou extraia datas de um texto usando `Regex`. Quanto mais você praticar, mais natural será usar expressões regulares para resolver problemas complexos de manipulação de texto!
