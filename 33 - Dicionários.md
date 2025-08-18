
# Estruturas de Dados em C#

## Aula 33 - Introdução aos Dicionários

Bem-vindo ao capítulo de Estruturas de Dados e Coleções em C#! Após aprender sobre arrays e listas, é hora de explorar **dicionários**, ou `Dictionary<TKey, TValue>`, uma estrutura poderosa para associar chaves a valores. Pense em um dicionário como uma agenda telefônica: cada nome (chave) está ligado a um número de telefone (valor), e você pode encontrar o número rapidamente usando o nome.

Nesta aula, vamos aprender o que são dicionários, como usá-los em C# e por que são úteis, com exemplos práticos do dia a dia.

### Objetivo

Entender o que são dicionários (`Dictionary<TKey, TValue>`), como declará-los, manipulá-los e usá-los em C# para armazenar e acessar dados de forma eficiente usando pares chave-valor.

## O que é um Dicionário (`Dictionary<TKey, TValue>`)?

Um **dicionário** (`Dictionary<TKey, TValue>`) é uma coleção genérica que armazena pares **chave-valor**, onde cada chave é única e usada para acessar seu valor correspondente. O `TKey` define o tipo da chave (ex.: `string`, `int`), e o `TValue` define o tipo do valor (ex.: `string`, `double`). Diferente de listas, que usam índices numéricos, dicionários usam chaves personalizadas.

Pense em um dicionário como um armário com gavetas rotuladas. Cada rótulo (chave) é único, e dentro da gaveta está o conteúdo (valor) que você procura.

### Características dos Dicionários

- **Chaves únicas**: Cada chave deve ser única; duplicatas causam erro.
- **Acesso rápido**: Valores são acessados rapidamente pela chave.
- **Tamanho dinâmico**: Como listas, dicionários podem crescer ou encolher.
- **Parte do namespace `System.Collections.Generic`**: Requer `using System.Collections.Generic;`.
- **Flexibilidade**: Chaves e valores podem ser de qualquer tipo, desde que consistentes.

## Declarando e Inicializando um Dicionário

Para usar dicionários, inclua o namespace `System.Collections.Generic` no topo do código.

```csharp
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Declaração de um dicionário
        Dictionary<string, int> idades;

        // Inicialização
        idades = new Dictionary<string, int>();

        // Declaração e inicialização com elementos
        Dictionary<string, int> idades2 = new Dictionary<string, int>
        {
            { "João", 25 },
            { "Maria", 30 },
            { "Ana", 28 }
        };
    }
}
```

**Exemplo do dia a dia**: Um dicionário é como uma lista de contatos no celular. Cada nome (chave) está associado a um número (valor), e você pode buscar o número pelo nome rapidamente.

## Adicionando e Removendo Elementos

A classe `Dictionary<TKey, TValue>` oferece métodos para manipular pares chave-valor:

- `Add(TKey key, TValue value)`: Adiciona um par chave-valor.
- `Remove(TKey key)`: Remove o par com a chave especificada.
- `Clear()`: Remove todos os pares.

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> idades = new Dictionary<string, int>();

        // Adicionando pares
        idades.Add("João", 25);
        idades.Add("Maria", 30);
        idades.Add("Ana", 28);
        Console.WriteLine($"Idades: João={idades["João"]}, Maria={idades["Maria"]}, Ana={idades["Ana"]}"); // Exibe: João=25, Maria=30, Ana=28

        // Removendo por chave
        idades.Remove("Maria");
        Console.WriteLine($"Após remover Maria, contém Maria? {idades.ContainsKey("Maria")}"); // Exibe: False

        // Limpando o dicionário
        idades.Clear();
        Console.WriteLine($"Tamanho após limpar: {idades.Count}"); // Exibe: 0
    }
}
```

**Exemplo do dia a dia**: É como gerenciar uma agenda. Você adiciona o contato "João" com seu número, remove "Maria" se ela mudar de número, ou apaga toda a agenda se quiser começar do zero.

## Acessando e Modificando Valores

Você acessa ou modifica valores usando a chave, como em um array com índices personalizados.

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, double> precos = new Dictionary<string, double>
        {
            { "Maçã", 2.50 },
            { "Pão", 4.00 }
        };

        // Acessando valor
        Console.WriteLine($"Preço da Maçã: R${precos["Maçã"]}"); // Exibe: 2.5

        // Modificando valor
        precos["Pão"] = 4.50;
        Console.WriteLine($"Novo preço do Pão: R${precos["Pão"]}"); // Exibe: 4.5

        // Adicionando ou atualizando
        precos["Leite"] = 3.00; // Adiciona se não existe
        precos["Maçã"] = 2.75; // Atualiza se já existe
    }
}
```

**Cuidado**: Acessar uma chave inexistente causa um erro (`KeyNotFoundException`). Use `ContainsKey` para verificar antes.

```csharp
if (precos.ContainsKey("Leite"))
{
    Console.WriteLine($"Preço do Leite: R${precos["Leite"]}");
}
else
{
    Console.WriteLine("Leite não encontrado!");
}
```

**Exemplo do dia a dia**: É como procurar um contato na agenda. Se o nome está lá, você vê o número; se não, precisa verificar antes para evitar erros.

## Propriedades e Métodos Úteis

- **`Count`**: Retorna o número de pares chave-valor.
- **`ContainsKey(TKey key)`**: Verifica se uma chave existe.
- **`ContainsValue(TValue value)`**: Verifica se um valor existe.
- **`Keys`**: Retorna uma coleção com todas as chaves.
- **`Values`**: Retorna uma coleção com todos os valores.
- **`TryGetValue(TKey key, out TValue value)`**: Tenta obter um valor sem lançar exceção.

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, string> alunos = new Dictionary<int, string>
        {
            { 101, "João" },
            { 102, "Maria" },
            { 103, "Ana" }
        };

        // Propriedade Count
        Console.WriteLine($"Total de alunos: {alunos.Count}"); // Exibe: 3

        // Verificando chave
        Console.WriteLine($"Contém matrícula 101? {alunos.ContainsKey(101)}"); // Exibe: True

        // Usando TryGetValue
        if (alunos.TryGetValue(102, out string nome))
        {
            Console.WriteLine($"Aluno 102: {nome}"); // Exibe: Maria
        }

        // Listando chaves e valores
        Console.WriteLine("Chaves: " + string.Join(", ", alunos.Keys)); // Exibe: 101, 102, 103
        Console.WriteLine("Valores: " + string.Join(", ", alunos.Values)); // Exibe: João, Maria, Ana
    }
}
```

**Exemplo do dia a dia**: É como consultar uma agenda para contar quantos contatos você tem, verificar se um nome está lá ou listar todos os nomes e números.

## Percorrendo um Dicionário

Use loops `foreach` para percorrer os pares chave-valor, geralmente com `KeyValuePair<TKey, TValue>`.

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, double> precos = new Dictionary<string, double>
        {
            { "Maçã", 2.50 },
            { "Pão", 4.00 },
            { "Leite", 3.00 }
        };

        // Percorrendo com foreach
        foreach (KeyValuePair<string, double> item in precos)
        {
            Console.WriteLine($"{item.Key}: R${item.Value}");
        }
        // Exibe:
        // Maçã: R$2.5
        // Pão: R$4
        // Leite: R$3
    }
}
```

**Exemplo do dia a dia**: É como revisar sua agenda, olhando cada contato (chave) e seu número (valor) um a um.

## Dicionários com Objetos

Dicionários podem armazenar objetos como valores, permitindo estruturas mais complexas.

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
        return $"{Nome}: R${Preco}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, Produto> estoque = new Dictionary<int, Produto>();
        estoque.Add(1, new Produto("Maçã", 2.50));
        estoque.Add(2, new Produto("Pão", 4.00));

        foreach (var item in estoque)
        {
            Console.WriteLine($"Código {item.Key}: {item.Value}");
        }
        // Exibe:
        // Código 1: Maçã: R$2.5
        // Código 2: Pão: R$4
    }
}
```

**Exemplo do dia a dia**: É como um sistema de estoque de uma loja, onde cada código de produto (chave) está ligado a detalhes como nome e preço (valor).

## Comparação com Listas e Arrays

- **Arrays**: Tamanho fixo, índices numéricos, menos flexíveis.
- **Listas**: Tamanho dinâmico, índices numéricos, ideais para sequências ordenadas.
- **Dicionários**: Tamanho dinâmico, chaves personalizadas, ideais para associações rápidas entre chaves e valores.

## Boas Práticas com Dicionários

- **Use chaves significativas**: Escolha chaves que façam sentido (ex.: nomes para idades, códigos para produtos).
- **Verifique chaves**: Use `ContainsKey` ou `TryGetValue` para evitar erros de chaves inexistentes.
- **Evite chaves duplicadas**: Certifique-se de que as chaves sejam únicas antes de adicionar.
- **Use para buscas rápidas**: Dicionários são ideais quando você precisa acessar valores por uma chave específica.

## Conclusão

Você agora entende **dicionários (`Dictionary<TKey, TValue>`)** em C#! Eles são como agendas que associam chaves únicas a valores, permitindo buscas rápidas e manipulação dinâmica. Com métodos como `Add`, `Remove` e `ContainsKey`, você pode gerenciar pares chave-valor com facilidade, desde listas de contatos até sistemas de estoque.

**Próximos passos**: Tente criar um programa que use um `Dictionary<string, double>` para gerenciar preços de produtos, permitindo adicionar, remover e consultar preços via entrada do usuário. Ou use um `Dictionary<int, Produto>` para simular um estoque com objetos. Quanto mais você praticar, mais natural será usar dicionários!
