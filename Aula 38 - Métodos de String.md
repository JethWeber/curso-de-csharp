# Manipulação de Strings e Expressões Regulares em C#

## Aula 38 - Métodos de String

Bem-vindo ao capítulo de Manipulação de Strings e Expressões Regulares em C#! Após explorarmos estruturas de dados, é hora de mergulhar no mundo das **strings**, que são fundamentais para processar textos em qualquer aplicação. Strings em C# são objetos imutáveis da classe `System.String`, e oferecem uma ampla gama de métodos para manipulação, como extrair partes de texto, substituir conteúdo, dividir strings ou combiná-las.

Nesta aula, vamos aprender os principais métodos de manipulação de strings, como `Substring`, `Replace`, `Split`, `Join` e outros, com exemplos práticos do dia a dia.

### Objetivo

Entender os métodos de manipulação de strings em C#, como usá-los para processar textos de forma eficiente e aplicá-los em cenários reais.

## O que é uma String?

Uma **string** em C# é uma sequência de caracteres (tipo `System.String`) usada para representar texto. Strings são **imutáveis**, ou seja, qualquer operação que parece modificar uma string cria uma nova string. Isso garante segurança, mas exige cuidado com desempenho em operações repetitivas.

Pense em uma string como uma frase em um editor de texto: você pode cortar partes, substituir palavras ou dividir a frase em palavras individuais.

### Características das Strings

- **Imutáveis**: Operações como `Replace` ou `ToUpper` retornam uma nova string.
- **Parte do namespace `System`**: Não é necessário importar namespaces adicionais para métodos básicos.
- **Métodos ricos**: A classe `String` oferece métodos para busca, substituição, divisão, formatação e mais.
- **Indexação**: Cada caractere tem um índice (baseado em 0).

## Métodos Principais de String

Vamos explorar os métodos mais comuns para manipulação de strings, com exemplos práticos.

### 1. `Substring`

Extrai uma parte da string com base em um índice inicial e, opcionalmente, um comprimento.

- **Assinatura**: `string Substring(int startIndex)` ou `string Substring(int startIndex, int length)`
- **Uso**: Extrair trechos específicos de texto.

#### Exemplo de `Substring`

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string texto = "Olá, mundo!";

        // Extraindo "mundo"
        string sub = texto.Substring(5, 5);
        Console.WriteLine(sub); // Exibe: mundo

        // Extraindo do índice 5 até o final
        string subFim = texto.Substring(5);
        Console.WriteLine(subFim); // Exibe: mundo!
    }
}
```

**Exemplo do dia a dia**: Extrair o nome de um arquivo a partir de um caminho completo, como obter "relatorio.pdf" de "C:\Documentos\relatorio.pdf".

**Cuidado**: Passar um índice inválido ou comprimento maior que o disponível causa um `ArgumentOutOfRangeException`.

### 2. `Replace`

Substitui todas as ocorrências de uma substring (ou caractere) por outra.

- **Assinatura**: `string Replace(string oldValue, string newValue)` ou `string Replace(char oldChar, char newChar)`
- **Uso**: Substituir palavras ou caracteres em um texto.

#### Exemplo de `Replace`

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string texto = "Eu gosto de C++!";

        // Substituindo "C++" por "C#"
        string novoTexto = texto.Replace("C++", "C#");
        Console.WriteLine(novoTexto); // Exibe: Eu gosto de C#!

        // Substituindo 'o' por '0'
        string comZero = texto.Replace('o', '0');
        Console.WriteLine(comZero); // Exibe: Eu g0st0 de C++!
    }
}
```

**Exemplo do dia a dia**: Corrigir palavras em um texto, como substituir "colour" por "color" em documentos.

### 3. `Split`

Divide uma string em um array de substrings com base em um delimitador.

- **Assinatura**: `string[] Split(char[] separator)` ou `string[] Split(string separator, StringSplitOptions options)`
- **Uso**: Separar texto em partes, como palavras ou campos.

#### Exemplo de `Split`

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string frase = "Maçã,Banana,Laranja,Morango";

        // Dividindo por vírgula
        string[] frutas = frase.Split(',');
        foreach (string fruta in frutas)
        {
            Console.WriteLine(fruta); // Exibe: Maçã, Banana, Laranja, Morango (em linhas separadas)
        }

        // Dividindo com opção para remover entradas vazias
        string dados = "João;;Maria;Ana";
        string[] nomes = dados.Split(';', StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine(string.Join(", ", nomes)); // Exibe: João, Maria, Ana
    }
}
```

**Exemplo do dia a dia**: Processar uma linha de um arquivo CSV, onde os campos são separados por vírgulas ou ponto e vírgula.

### 4. `Join`

Combina elementos de um array (ou coleção) em uma única string, com um delimitador.

- **Assinatura**: `string Join(string separator, string[] value)`
- **Uso**: Criar uma string a partir de várias partes.

#### Exemplo de `Join`

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string[] frutas = { "Maçã", "Banana", "Laranja" };

        // Combinando com vírgula e espaço
        string lista = string.Join(", ", frutas);
        Console.WriteLine(lista); // Exibe: Maçã, Banana, Laranja
    }
}
```

**Exemplo do dia a dia**: Gerar uma lista de e-mails separados por vírgula para enviar um convite.

### 5. Outros Métodos Úteis

- `ToUpper()` e `ToLower()`: Converte a string para maiúsculas ou minúsculas.
- `Trim()`, `TrimStart()`, `TrimEnd()`: Remove espaços (ou caracteres específicos) do início, fim ou ambos.
- `Contains(string value)`: Verifica se uma substring existe.
- `StartsWith(string value)` e `EndsWith(string value)`: Verifica se a string começa ou termina com uma substring.
- `IndexOf(string value)`: Retorna o índice da primeira ocorrência de uma substring (ou -1 se não encontrada).
- `Length`: Retorna o número de caracteres na string.

#### Exemplo Combinado

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string texto = "  Olá, Mundo!  ";

        // Convertendo para minúsculas
        Console.WriteLine(texto.ToLower()); // Exibe:   olá, mundo!  

        // Removendo espaços
        string semEspacos = texto.Trim();
        Console.WriteLine(semEspacos); // Exibe: Olá, Mundo!

        // Verificando conteúdo
        Console.WriteLine($"Contém 'Mundo'? {semEspacos.Contains("Mundo")}"); // Exibe: True
        Console.WriteLine($"Começa com 'Olá'? {semEspacos.StartsWith("Olá")}"); // Exibe: True

        // Encontrando índice
        int indice = semEspacos.IndexOf("Mundo");
        Console.WriteLine($"Índice de 'Mundo': {indice}"); // Exibe: 5

        // Tamanho da string
        Console.WriteLine($"Tamanho: {semEspacos.Length}"); // Exibe: 10
    }
}
```

**Exemplo do dia a dia**: Normalizar um texto (remover espaços extras com `Trim`, converter para minúsculas com `ToLower`) antes de salvá-lo em um banco de dados.

## Manipulação de Strings com Objetos

Strings são frequentemente usadas para representar ou manipular dados de objetos personalizados, como formatar informações.

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

        // Usando Join para criar uma lista formatada
        string listaProdutos = string.Join("; ", produtos);
        Console.WriteLine(listaProdutos); // Exibe: Notebook - R$3500,99; Mouse - R$99,90

        // Formatando cada produto com Substring e Replace
        foreach (Produto p in produtos)
        {
            string nome = p.Nome.ToUpper();
            string precoFormatado = p.Preco.ToString("F2").Replace(".", ",");
            Console.WriteLine($"{nome}: R${precoFormatado}");
        }
        // Exibe:
        // NOTEBOOK: R$3500,99
        // MOUSE: R$99,90
    }
}
```

**Exemplo do dia a dia**: Formatando uma lista de produtos para exibição em um relatório ou e-commerce, usando métodos como `ToUpper` e `Replace`.

## Boas Práticas para Manipulação de Strings

- **Evite concatenação repetitiva**: Como strings são imutáveis, usar `+` em loops pode ser ineficiente. Prefira `StringBuilder` para concatenações intensivas.
- **Valide índices**: Antes de usar `Substring` ou `IndexOf`, verifique se os índices são válidos para evitar exceções.
- **Use `StringSplitOptions`**: Em `Split`, use `RemoveEmptyEntries` para ignorar entradas vazias.
- **Normalize strings**: Use `Trim`, `ToLower` ou `ToUpper` para padronizar entradas antes de comparações.
- **Combine com LINQ**: Para manipulações complexas, combine métodos de string com LINQ (ex.: filtrar strings que contêm um termo).
- **Use nomes descritivos**: Para variáveis que representam strings, como `nomeCliente` ou `mensagemErro`.

## Conclusão

Você agora entende os principais métodos de manipulação de strings em C#, como `Substring`, `Replace`, `Split`, `Join`, `ToUpper`, `Trim` e outros. Essas ferramentas permitem processar textos de forma eficiente, desde extrair partes de uma string até formatar dados para exibição. Com esses métodos, você pode lidar com tarefas comuns, como processar arquivos, formatar relatórios ou validar entradas de usuário.

**Próximos passos**: Tente criar um programa que processe um texto, como dividir uma frase em palavras com `Split`, extrair uma parte com `Substring` ou substituir termos com `Replace`. Quanto mais você praticar, mais natural será manipular strings!
