# Manipulação de Strings e Expressões Regulares em C#

## Aula 40 - `StringBuilder` para Manipulação Eficiente

Bem-vindo ao capítulo de Manipulação de Strings e Expressões Regulares em C#! Após aprendermos sobre métodos de string e formatação, é hora de explorar o **`StringBuilder`**, uma classe projetada para manipulação eficiente de strings, especialmente em cenários que envolvem múltiplas alterações ou concatenações. Como strings em C# são **imutáveis**, operações repetitivas com strings podem ser ineficientes. O `StringBuilder` resolve esse problema ao permitir modificações em uma única instância de buffer de texto.

Nesta aula, vamos aprender o que é o `StringBuilder`, como usá-lo e quando ele é mais apropriado do que strings comuns, com exemplos práticos do dia a dia.

### Objetivo

Entender a classe `StringBuilder` em C#, seus métodos principais e como usá-la para manipular strings de forma eficiente em cenários de alto desempenho.

## O que é `StringBuilder`?

A classe **`StringBuilder`** (namespace `System.Text`) é uma alternativa mutável às strings imutáveis (`System.String`). Em vez de criar uma nova string para cada operação, o `StringBuilder` mantém um buffer interno que pode ser modificado diretamente, reduzindo o uso de memória e melhorando o desempenho em operações repetitivas, como concatenações em loops.

Pense no `StringBuilder` como um caderno onde você pode escrever, apagar e reescrever texto na mesma página, em vez de criar uma nova página para cada alteração.

### Características do `StringBuilder`

- **Mutável**: Permite modificar o conteúdo sem criar novos objetos.
- **Namespace `System.Text`**: Requer `using System.Text;`.
- **Alta performance**: Ideal para concatenações repetitivas ou manipulações em grande escala.
- **Capacidade dinâmica**: O buffer interno cresce automaticamente conforme necessário.
- **Conversão para string**: Use `ToString()` para obter a string final.

## Quando Usar `StringBuilder`?

Use `StringBuilder` em vez de strings em cenários como:
- Concatenações em loops (ex.: construir um relatório ou log).
- Manipulação de strings grandes ou complexas.
- Operações repetitivas que modificam o conteúdo (ex.: substituições ou inserções).

**Não use `StringBuilder`** para operações simples ou únicas, pois a sobrecarga de criar um `StringBuilder` pode superar os benefícios em comparação com strings normais.

## Métodos Principais do `StringBuilder`

- `Append(value)`: Adiciona texto ao final do buffer.
- `AppendLine(value)`: Adiciona texto seguido de uma nova linha.
- `Insert(index, value)`: Insere texto em um índice específico.
- `Remove(startIndex, length)`: Remove caracteres a partir de um índice.
- `Replace(oldValue, newValue)`: Substitui todas as ocorrências de um texto.
- `Clear()`: Remove todo o conteúdo do buffer.
- `ToString()`: Converte o conteúdo do buffer em uma string.
- `Length`: Retorna o número de caracteres no buffer.
- `Capacity`: Retorna ou define a capacidade do buffer interno.

## Exemplo Básico de `StringBuilder`

```csharp
using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();

        // Adicionando texto
        sb.Append("Olá, ");
        sb.Append("mundo!");

        // Convertendo para string
        string resultado = sb.ToString();
        Console.WriteLine(resultado); // Exibe: Olá, mundo!

        // Adicionando com nova linha
        sb.AppendLine("Bem-vindo ao C#!");
        Console.WriteLine(sb.ToString());
        // Exibe:
        // Olá, mundo!
        // Bem-vindo ao C#!
    }
}
```

**Exemplo do dia a dia**: Construir uma mensagem de boas-vindas em um aplicativo, adicionando partes do texto dinamicamente.

## Comparação: `String` vs. `StringBuilder`

### Usando Strings (Ineficiente em Loops)

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string texto = "";
        for (int i = 0; i < 1000; i++)
        {
            texto += i.ToString() + ", "; // Cria uma nova string a cada iteração
        }
        Console.WriteLine(texto.Length); // Exibe o tamanho da string
    }
}
```

**Problema**: Cada `+=` cria uma nova string, consumindo memória e tempo, especialmente em loops grandes.

### Usando `StringBuilder` (Eficiente)

```csharp
using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 1000; i++)
        {
            sb.Append(i.ToString()).Append(", "); // Modifica o buffer internamente
        }
        Console.WriteLine(sb.Length); // Exibe o tamanho da string
    }
}
```

**Vantagem**: O `StringBuilder` modifica o buffer interno, evitando a criação de múltiplas strings.

**Exemplo do dia a dia**: Construir um log ou relatório com milhares de linhas, onde cada linha é adicionada dinamicamente.

## Manipulação Avançada com `StringBuilder`

### Exemplo com Métodos Diversos

```csharp
using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder("Olá, mundo!");

        // Inserindo texto
        sb.Insert(5, "querido ");
        Console.WriteLine(sb.ToString()); // Exibe: Olá, querido mundo!

        // Substituindo texto
        sb.Replace("mundo", "C#");
        Console.WriteLine(sb.ToString()); // Exibe: Olá, querido C#!

        // Removendo texto
        sb.Remove(0, 5); // Remove "Olá, "
        Console.WriteLine(sb.ToString()); // Exibe: querido C#!

        // Limpando o buffer
        sb.Clear();
        sb.Append("Novo texto");
        Console.WriteLine(sb.ToString()); // Exibe: Novo texto
    }
}
```

**Exemplo do dia a dia**: Editar um texto dinamicamente em um editor, inserindo, removendo ou substituindo partes do conteúdo.

## `StringBuilder` com Objetos Personalizados

O `StringBuilder` pode ser usado para formatar dados de objetos personalizados, especialmente em relatórios ou saídas complexas.

```csharp
using System;
using System.Text;
using System.Collections.Generic;

class Produto
{
    public string Nome { get; set; }
    public double Preco { get; set; }

    public Produto(string nome, double preco)
    {
        Nome = nome;
        Preco = preco;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Produto> produtos = new List<Produto>
        {
            new Produto("Notebook", 3500.99),
            new Produto("Mouse", 99.90)
        };

        StringBuilder relatorio = new StringBuilder();
        relatorio.AppendLine("Relatório de Produtos");
        relatorio.AppendLine("=====================");

        foreach (var p in produtos)
        {
            relatorio.AppendLine($"Produto: {p.Nome,-10} | Preço: R${p.Preco,8:F2}");
        }

        Console.WriteLine(relatorio.ToString());
        // Exibe:
        // Relatório de Produtos
        // =====================
        // Produto: Notebook    | Preço: R$3500,99
        // Produto: Mouse       | Preço: R$  99,90
    }
}
```

**Exemplo do dia a dia**: Gerar um relatório de produtos em um sistema de e-commerce, construindo o texto linha por linha de forma eficiente.

## Boas Práticas para `StringBuilder`

- **Use `StringBuilder` em loops ou operações repetitivas**: Para evitar a criação de múltiplas strings.
- **Evite `StringBuilder` para operações simples**: Para poucas concatenações, strings normais ou interpolação são suficientes.
- **Defina a capacidade inicial quando possível**: Use o construtor `StringBuilder(int capacity)` para reduzir realocações (ex.: `new StringBuilder(1000)`).
- **Aproveite métodos encadeados**: Métodos como `Append` retornam o próprio `StringBuilder`, permitindo chamadas encadeadas (ex.: `sb.Append("a").Append("b")`).
- **Converta para string apenas no final**: Use `ToString()` somente quando o resultado final for necessário.
- **Combine com formatação**: Use interpolação ou `AppendFormat` para formatar números, datas, etc., dentro do `StringBuilder`.

## Conclusão

Você agora entende a classe `StringBuilder` em C# e como usá-la para manipular strings de forma eficiente. Diferente das strings imutáveis, o `StringBuilder` é ideal para operações repetitivas, como concatenações em loops ou construção de textos complexos. Com métodos como `Append`, `Insert`, `Replace` e `Remove`, você pode criar e modificar textos de maneira performática.

**Próximos passos**: Tente criar um programa que gere um log ou relatório usando `StringBuilder`, como um resumo de transações ou uma lista formatada de dados. Quanto mais você praticar, mais natural será usar `StringBuilder` para otimizar a manipulação de strings!
