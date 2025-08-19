# Manipulação de Strings e Expressões Regulares em C#

## Aula 39 - Formatação de Strings (`String.Format`, Interpolação de Strings)

Bem-vindo ao capítulo de Manipulação de Strings e Expressões Regulares em C#! Após aprendermos sobre os métodos de manipulação de strings, como `Substring`, `Replace`, `Split` e `Join`, é hora de explorar como **formatar strings** para criar textos bem estruturados e legíveis. A formatação de strings é essencial para exibir dados de forma clara, como em relatórios, mensagens ou interfaces de usuário.

Nesta aula, vamos aprender como usar `String.Format` e a **interpolação de strings** (usando `$` e `{}`) para formatar strings, com exemplos práticos do dia a dia.

### Objetivo

Entender como formatar strings em C# usando `String.Format` e interpolação de strings, aplicando-os para criar textos formatados de maneira eficiente e legível em cenários reais.

## O que é Formatação de Strings?

**Formatação de strings** é o processo de combinar texto fixo com valores de variáveis ou expressões, criando uma string final bem estruturada. Em C#, isso pode ser feito com `String.Format` (método tradicional) ou com **interpolação de strings** (introduzida no C# 6.0), que é mais moderna e legível.

Pense na formatação de strings como criar um modelo de e-mail personalizado, onde você insere o nome do destinatário e outros dados dinâmicos em um texto padrão.

### Características

- **Legibilidade**: Formatar strings torna o texto mais claro para usuários.
- **Flexibilidade**: Permite combinar variáveis, números, datas e outros tipos de dados.
- **Parte do namespace `System`**: Não é necessário importar namespaces adicionais para os métodos básicos.
- **Suporte a formatação avançada**: Inclui opções para números, datas e alinhamento.

## 1. `String.Format`

O método `String.Format` cria uma string combinando um modelo (com espaços reservados) e valores fornecidos. Os espaços reservados são índices entre chaves `{}`.

### Sintaxe

```csharp
string String.Format(string format, params object[] args);
```

- `format`: String com espaços reservados (ex.: `{0}`, `{1}`).
- `args`: Valores a serem inseridos nos espaços reservados.

### Exemplo de `String.Format`

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string nome = "João";
        int idade = 25;
        double saldo = 1234.5678;

        // Usando String.Format
        string mensagem = String.Format("Olá, {0}! Você tem {1} anos e um saldo de R${2:F2}.", nome, idade, saldo);
        Console.WriteLine(mensagem); // Exibe: Olá, João! Você tem 25 anos e um saldo de R$1234,57.
    }
}
```

**Exemplo do dia a dia**: Gerar uma mensagem de boas-vindas em um sistema bancário, incluindo o nome do cliente e o saldo formatado.

### Formatação Avançada com `String.Format`

Você pode usar especificadores de formato para controlar a exibição de números, datas, etc.

- `{0:C}`: Formato de moeda (ex.: R$1.234,57 no Brasil).
- `{0:N2}`: Número com duas casas decimais (ex.: 1.234,57).
- `{0:D2}`: Inteiro com dois dígitos (ex.: 05).
- `{0:yyyy-MM-dd}`: Formato de data.

#### Exemplo com Formatação Avançada

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string nome = "Maria";
        double preco = 199.99;
        DateTime data = DateTime.Now;

        string recibo = String.Format("Cliente: {0}, Compra: {1:C}, Data: {2:dd/MM/yyyy}", nome, preco, data);
        Console.WriteLine(recibo); // Exibe: Cliente: Maria, Compra: R$199,99, Data: 20/08/2025
    }
}
```

**Cuidado**: Passar um índice inválido em `String.Format` (ex.: `{2}` com apenas dois argumentos) causa um `FormatException`.

## 2. Interpolação de Strings

A **interpolação de strings** é uma forma mais moderna e legível de formatar strings, introduzida no C# 6.0. Usa o prefixo `$` e expressões dentro de chaves `{}` diretamente no texto.

### Sintaxe

```csharp
string mensagem = $"Texto com {variavel} e {expressao}";
```

### Exemplo de Interpolação de Strings

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string nome = "Ana";
        int idade = 30;
        double saldo = 1234.5678;

        // Usando interpolação de strings
        string mensagem = $"Olá, {nome}! Você tem {idade} anos e um saldo de R${saldo:F2}.";
        Console.WriteLine(mensagem); // Exibe: Olá, Ana! Você tem 30 anos e um saldo de R$1234,57.
    }
}
```

**Exemplo do dia a dia**: Criar uma mensagem personalizada em um aplicativo, inserindo o nome do usuário e outros dados dinâmicos.

### Formatação Avançada com Interpolação

A interpolação suporta os mesmos especificadores de formato que `String.Format`, usando a sintaxe `{expressao:formato}`.

#### Exemplo com Formatação Avançada

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string nome = "Carlos";
        double preco = 199.99;
        DateTime data = DateTime.Now;

        string recibo = $"Cliente: {nome}, Compra: {preco:C}, Data: {data:dd/MM/yyyy}";
        Console.WriteLine(recibo); // Exibe: Cliente: Carlos, Compra: R$199,99, Data: 20/08/2025
    }
}
```

### Alinhamento e Preenchimento

A interpolação permite alinhar texto com `{expressao, alinhamento:formato}`:
- Positivo: Alinhamento à direita.
- Negativo: Alinhamento à esquerda.

#### Exemplo de Alinhamento

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string nome = "João";
        double preco = 99.9;

        // Alinhando à direita com 10 caracteres
        string linha = $"Produto: {nome,10} | Preço: {preco,8:C}";
        Console.WriteLine(linha); // Exibe: Produto:       João | Preço:  R$99,90
    }
}
```

**Exemplo do dia a dia**: Gerar uma tabela formatada para exibir produtos em um relatório.

## Formatação com Objetos Personalizados

Strings formatadas podem ser usadas para exibir informações de objetos personalizados, combinando com `ToString` ou interpolação.

```csharp
using System;
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

    public override string ToString()
    {
        return $"{Nome} - R${Preco:F2}";
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

        // Usando String.Format com lista
        for (int i = 0; i < produtos.Count; i++)
        {
            string linha = String.Format("Produto {0}: {1,-10} | R${2,8:F2}", i + 1, produtos[i].Nome, produtos[i].Preco);
            Console.WriteLine(linha);
        }
        // Exibe:
        // Produto 1: Notebook    | R$3500,99
        // Produto 2: Mouse       | R$  99,90

        // Usando interpolação de strings
        foreach (var p in produtos)
        {
            string linha = $"Produto: {p.Nome,-10} | Preço: {p.Preco,8:C}";
            Console.WriteLine(linha);
        }
        // Exibe:
        // Produto: Notebook    | Preço: R$3500,99
        // Produto: Mouse       | Preço:   R$99,90
    }
}
```

**Exemplo do dia a dia**: Gerar um relatório de produtos em um sistema de e-commerce, formatando nomes e preços de forma alinhada.

## Comparação entre `String.Format` e Interpolação de Strings

- **`String.Format`**:
  - Mais verboso, usa índices numéricos.
  - Útil em cenários onde o formato é definido dinamicamente (ex.: em arquivos de configuração).
  - Menos intuitivo para iniciantes.
- **Interpolação de Strings**:
  - Mais legível e concisa, usa variáveis diretamente.
  - Melhor para código moderno e manutenção.
  - Suporta expressões complexas dentro de `{}` (ex.: `{idade + 1}`).

## Boas Práticas para Formatação de Strings

- **Prefira interpolação de strings**: É mais legível e menos propensa a erros em códigos modernos.
- **Use especificadores de formato**: Para controlar a exibição de números, datas e moedas (ex.: `C`, `F2`, `dd/MM/yyyy`).
- **Valide dados**: Certifique-se de que as variáveis usadas não são nulas para evitar `NullReferenceException`.
- **Considere `StringBuilder` para loops**: Para formatações em grande quantidade, use `StringBuilder` para melhor desempenho.
- **Alinhe texto quando necessário**: Use alinhamento em relatórios ou tabelas para melhorar a legibilidade.
- **Combine com LINQ**: Para formatar coleções, combine formatação com LINQ para filtrar ou transformar dados.

## Conclusão

Você agora entende como formatar strings em C# usando `String.Format` e interpolação de strings. Essas ferramentas permitem criar textos bem estruturados, combinando variáveis e formatos personalizados para números, datas e alinhamento. A interpolação de strings é a abordagem moderna, enquanto `String.Format` é útil em cenários específicos. Com essas técnicas, você pode criar mensagens, relatórios e interfaces de usuário mais claras e profissionais.

**Próximos passos**: Tente criar um programa que gere um relatório formatado com uma lista de produtos, usando interpolação de strings para alinhar nomes e preços, ou use `String.Format` para criar um modelo de e-mail personalizado. Quanto mais você praticar, mais natural será formatar strings!
