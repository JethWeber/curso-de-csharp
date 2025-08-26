
# Estruturas de Dados em C#

## Aula 35 - Introdução aos Conjuntos (`HashSet<T>`, `SortedSet<T>`)

Bem-vindo ao capítulo de Estruturas de Dados e Coleções em C#! Após explorarmos arrays, listas, dicionários, filas e pilhas, é hora de conhecer os **conjuntos** (`HashSet<T>` e `SortedSet<T>`), estruturas de dados que armazenam elementos **únicos** de forma eficiente. Conjuntos são ideais quando você precisa garantir que não haja duplicatas e deseja realizar operações como união, interseção ou diferença.


Nesta aula, vamos aprender o que são conjuntos, como usá-los em C# e quando aplicá-los, com exemplos práticos do dia a dia.


### Objetivo

Entender os conceitos de conjuntos (`HashSet<T>` e `SortedSet<T>`), como declará-los, manipulá-los e usá-los em C# para gerenciar coleções de elementos únicos.

## O que são Conjuntos?

Um **conjunto** é uma coleção genérica que armazena elementos **únicos**, sem duplicatas, e não mantém uma ordem fixa de inserção (exceto no caso de `SortedSet<T>`, que ordena os elementos). Conjuntos são úteis para verificar a existência de itens, eliminar duplicatas ou realizar operações matemáticas de conjuntos.

Pense em um conjunto como uma lista de convidados para uma festa: cada pessoa aparece apenas uma vez, e você pode facilmente verificar se alguém está na lista.

### Características dos Conjuntos

- **Elementos únicos**: Não permite duplicatas.
- **Parte do namespace `System.Collections.Generic`**: Requer `using System.Collections.Generic;`.
- **Alta performance**: Operações como verificar a existência de um elemento são muito rápidas.
- **Tipos principais**:
  - `HashSet<T>`: Armazena elementos sem ordem específica, otimizado para desempenho.
  - `SortedSet<T>`: Armazena elementos em ordem crescente, ideal para casos que exigem ordenação.

## Declarando e Usando um `HashSet<T>`

Para usar conjuntos, inclua o namespace `System.Collections.Generic`.

### Métodos Principais do `HashSet<T>`

- `Add(T item)`: Adiciona um elemento ao conjunto (ignora se já existe).
- `Remove(T item)`: Remove um elemento do conjunto.
- `Contains(T item)`: Verifica se um elemento está no conjunto.
- `Count`: Retorna o número de elementos no conjunto.
- `Clear()`: Remove todos os elementos.
- Operações de conjuntos:
  - `UnionWith`: Combina elementos de dois conjuntos.
  - `IntersectWith`: Mantém apenas os elementos comuns a dois conjuntos.
  - `ExceptWith`: Remove os elementos de outro conjunto.

### Exemplo de `HashSet<T>`

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        HashSet<string> convidados = new HashSet<string>();

        // Adicionando convidados
        convidados.Add("João");
        convidados.Add("Maria");
        convidados.Add("João"); // Ignorado, pois já existe

        Console.WriteLine($"Convidados: {string.Join(", ", convidados)}"); // Exibe: João, Maria
        Console.WriteLine($"Total de convidados: {convidados.Count}"); // Exibe: 2

        // Verificando se um convidado está na lista
        Console.WriteLine($"Maria está na lista? {convidados.Contains("Maria")}"); // Exibe: True

        // Operações de conjuntos
        HashSet<string> novosConvidados = new HashSet<string> { "Maria", "Ana" };
        convidados.UnionWith(novosConvidados); // Adiciona Ana
        Console.WriteLine($"Após união: {string.Join(", ", convidados)}"); // Exibe: João, Maria, Ana

        // Removendo um convidado
        convidados.Remove("João");
        Console.WriteLine($"Após remover João: {string.Join(", ", convidados)}"); // Exibe: Maria, Ana
    }
}
```

**Exemplo do dia a dia**: Um `HashSet<T>` é como uma lista de e-mails únicos para enviar convites. Você pode adicionar endereços, mas duplicatas são automaticamente ignoradas, e é fácil verificar se um e-mail já está na lista (`Contains`).

**Cuidado**: O `HashSet<T>` não mantém a ordem de inserção, então os elementos podem aparecer em qualquer ordem ao iterar.

## Declarando e Usando um `SortedSet<T>`

O `SortedSet<T>` é semelhante ao `HashSet<T>`, mas mantém os elementos em **ordem crescente**. É útil quando você precisa de elementos únicos e ordenados.

### Métodos Principais do `SortedSet<T>`

- Mesmos métodos do `HashSet<T>` (`Add`, `Remove`, `Contains`, `Count`, `Clear`, etc.).
- `Min` e `Max`: Retornam o menor e o maior elemento do conjunto.
- Operações de conjuntos: `UnionWith`, `IntersectWith`, `ExceptWith`.

### Exemplo de `SortedSet<T>`

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        SortedSet<int> notas = new SortedSet<int>();

        // Adicionando notas
        notas.Add(85);
        notas.Add(90);
        notas.Add(85); // Ignorado, pois já existe
        notas.Add(75);

        Console.WriteLine($"Notas: {string.Join(", ", notas)}"); // Exibe: 75, 85, 90
        Console.WriteLine($"Menor nota: {notas.Min}"); // Exibe: 75
        Console.WriteLine($"Maior nota: {notas.Max}"); // Exibe: 90

        // Verificando se uma nota está no conjunto
        Console.WriteLine($"Nota 85 existe? {notas.Contains(85)}"); // Exibe: True

        // Operação de interseção
        SortedSet<int> outrasNotas = new SortedSet<int> { 85, 95 };
        notas.IntersectWith(outrasNotas);
        Console.WriteLine($"Notas comuns: {string.Join(", ", notas)}"); // Exibe: 85
    }
}
```

**Exemplo do dia a dia**: Um `SortedSet<T>` é como uma lista ordenada de pontuações em um jogo, onde você quer manter apenas pontuações únicas e exibi-las em ordem crescente.

## Conjuntos com Objetos

Tanto `HashSet<T>` quanto `SortedSet<T>` podem armazenar objetos de classes personalizadas, desde que sejam implementados os métodos `Equals` e `GetHashCode` (para `HashSet<T>`) ou `IComparable<T>` (para `SortedSet<T>`).

```csharp
using System;
using System.Collections.Generic;

class Produto
{
    public string Nome { get; set; }
    public int Id { get; set; }

    public Produto(string nome, int id)
    {
        Nome = nome;
        Id = id;
    }

    public override bool Equals(object obj)
    {
        if (obj is Produto outro)
            return Id == outro.Id;
        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{Nome} (ID: {Id})";
    }
}

class Program
{
    static void Main(string[] args)
    {
        HashSet<Produto> estoque = new HashSet<Produto>();

        // Adicionando produtos
        estoque.Add(new Produto("Caneta", 1));
        estoque.Add(new Produto("Lápis", 2));
        estoque.Add(new Produto("Caneta", 1)); // Ignorado, pois ID já existe

        Console.WriteLine($"Produtos: {string.Join(", ", estoque)}"); // Exibe: Caneta (ID: 1), Lápis (ID: 2)

        // Verificando se um produto está no estoque
        Produto caneta = new Produto("Caneta", 1);
        Console.WriteLine($"Caneta ID 1 existe? {estoque.Contains(caneta)}"); // Exibe: True
    }
}
```

**Exemplo do dia a dia**: Um `HashSet<Produto>` pode ser usado para gerenciar um estoque de produtos únicos com base em um ID, garantindo que não haja duplicatas.

## Comparação entre `HashSet<T>`, `SortedSet<T>`, Listas e Dicionários

- **HashSet<T>**: Elementos únicos, sem ordem, ideal para verificações rápidas e operações de conjuntos.
- **SortedSet<T>**: Elementos únicos, ordenados, ideal para dados ordenados sem duplicatas.
- **Listas**: Permitem duplicatas, acesso por índice, flexíveis para manipulação geral.
- **Dicionários**: Acesso por chave, ideais para associações rápidas, mas não garantem ordem ou unicidade.

## Boas Práticas com Conjuntos

- **Use nomes descritivos**: Como `convidados` ou `notas`, em vez de `set1`.
- **Escolha o tipo certo**: Use `HashSet<T>` para desempenho máximo quando a ordem não importa; use `SortedSet<T>` quando precisa de ordenação.
- **Implemente `Equals` e `GetHashCode`**: Para objetos personalizados em `HashSet<T>`.
- **Use operações de conjuntos**: Aproveite `UnionWith`, `IntersectWith` e `ExceptWith` para manipulações complexas.
- **Verifique duplicatas**: Conjuntos são perfeitos para garantir unicidade em coleções.

## Conclusão

Você agora entende **conjuntos (`HashSet<T>` e `SortedSet<T>`)** em C#! `HashSet<T>` é ideal para coleções de elementos únicos com alta performance, enquanto `SortedSet<T>` adiciona ordenação aos elementos. Com métodos como `Add`, `Remove`, `Contains` e operações de conjuntos, você pode gerenciar dados de forma eficiente e sem duplicatas.

**Próximos passos**: Tente criar um programa que use `HashSet<T>` para gerenciar uma lista de e-mails únicos ou `SortedSet<T>` para organizar pontuações de um jogo em ordem crescente. Quanto mais você praticar, mais natural será usar conjuntos!
