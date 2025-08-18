
# Estruturas de Dados em C#

## Aula 32 - Introdução às Listas

Bem-vindo ao capítulo de Estruturas de Dados e Coleções em C#! Após aprender sobre arrays, é hora de explorar **listas**, ou `List<T>`, uma estrutura de dados mais flexível. Enquanto arrays são como prateleiras com um número fixo de caixas, listas são como cadernos de anotações: você pode adicionar, remover ou reorganizar páginas (itens) sempre que quiser.

Nesta aula, vamos aprender o que são listas, como usá-las em C# e por que são tão úteis, com exemplos práticos do dia a dia.

### Objetivo

Entender o que são listas (`List<T>`), como declará-las, manipulá-las e usá-las em C# para armazenar e gerenciar dados de forma dinâmica.

## O que é uma Lista (`List<T>`)?

Uma **lista** (`List<T>`) é uma coleção dinâmica que armazena elementos do mesmo tipo, permitindo adicionar, remover ou modificar elementos sem um tamanho fixo. O `T` significa que a lista é **genérica**, ou seja, você define o tipo de dados que ela vai armazenar (ex.: `List<int>` para números inteiros ou `List<string>` para textos).

Pense em uma lista como uma lista de compras que você pode expandir ou encurtar a qualquer momento, diferente de um array, que tem tamanho fixo.

### Características das Listas

- **Tamanho dinâmico**: Cresce ou diminui conforme você adiciona ou remove elementos.
- **Tipo único**: Todos os elementos são do mesmo tipo, definido pelo `T`.
- **Acesso por índice**: Como arrays, usa índices começando em 0.
- **Parte do namespace `System.Collections.Generic`**: Requer `using System.Collections.Generic;`.

## Declarando e Inicializando uma Lista

Para usar listas, inclua o namespace `System.Collections.Generic` no topo do código.

```csharp
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Declaração de uma lista
        List<string> compras;

        // Inicialização
        compras = new List<string>();

        // Declaração e inicialização com elementos
        List<string> compras2 = new List<string> { "Maçã", "Pão", "Leite" };
    }
}
```

**Exemplo do dia a dia**: Uma lista é como um aplicativo de tarefas no celular. Você pode começar com uma lista vazia e adicionar itens (tarefas) conforme necessário.

## Adicionando e Removendo Elementos

A classe `List<T>` oferece métodos úteis para manipular elementos:

- `Add(T item)`: Adiciona um elemento ao final da lista.
- `Remove(T item)`: Remove a primeira ocorrência do elemento.
- `RemoveAt(int index)`: Remove o elemento no índice especificado.
- `Clear()`: Remove todos os elementos.

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> compras = new List<string>();
        
        // Adicionando elementos
        compras.Add("Maçã");
        compras.Add("Pão");
        compras.Add("Leite");
        Console.WriteLine($"Itens: {string.Join(", ", compras)}"); // Exibe: Maçã, Pão, Leite

        // Removendo elemento
        compras.Remove("Pão");
        Console.WriteLine($"Após remover Pão: {string.Join(", ", compras)}"); // Exibe: Maçã, Leite

        // Removendo por índice
        compras.RemoveAt(0); // Remove Maçã
        Console.WriteLine($"Após remover índice 0: {string.Join(", ", compras)}"); // Exibe: Leite

        // Limpando a lista
        compras.Clear();
        Console.WriteLine($"Tamanho após limpar: {compras.Count}"); // Exibe: 0
    }
}
```

**Exemplo do dia a dia**: É como gerenciar uma lista de compras. Você adiciona itens ao ir ao mercado, remove algo se mudar de ideia e pode apagar tudo após comprar.

## Acessando e Modificando Elementos

Você pode acessar ou modificar elementos usando índices, como em arrays.

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> notas = new List<int> { 90, 85, 88 };
        
        // Acessando elemento
        Console.WriteLine($"Primeira nota: {notas[0]}"); // Exibe: 90

        // Modificando elemento
        notas[1] = 87;
        Console.WriteLine($"Nova segunda nota: {notas[1]}"); // Exibe: 87
    }
}
```

**Cuidado**: Acessar um índice inválido (ex.: `notas[10]` em uma lista com 3 elementos) causa um erro (`ArgumentOutOfRangeException`).

## Propriedades e Métodos Úteis

- **`Count`**: Retorna o número de elementos na lista (similar ao `Length` de arrays).
- **`Contains(T item)`**: Verifica se um elemento está na lista.
- **`IndexOf(T item)`**: Retorna o índice da primeira ocorrência de um elemento.
- **`Sort()`**: Ordena a lista.
- **`Reverse()`**: Inverte a ordem dos elementos.

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> notas = new List<int> { 90, 85, 88, 92 };

        // Propriedade Count
        Console.WriteLine($"Total de notas: {notas.Count}"); // Exibe: 4

        // Verificando se contém um elemento
        Console.WriteLine($"Contém 85? {notas.Contains(85)}"); // Exibe: True

        // Encontrando índice
        Console.WriteLine($"Índice de 88: {notas.IndexOf(88)}"); // Exibe: 2

        // Ordenando
        notas.Sort();
        Console.WriteLine($"Notas ordenadas: {string.Join(", ", notas)}"); // Exibe: 85, 88, 90, 92

        // Invertendo
        notas.Reverse();
        Console.WriteLine($"Notas invertidas: {string.Join(", ", notas)}"); // Exibe: 92, 90, 88, 85
    }
}
```

**Exemplo do dia a dia**: É como organizar sua lista de tarefas. Você pode contar quantas tarefas tem, verificar se uma tarefa específica está na lista, encontrar sua posição ou ordená-las por prioridade.

## Percorrendo uma Lista

Use loops `for` ou `foreach` para percorrer os elementos, como em arrays.

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> tarefas = new List<string> { "Estudar", "Trabalhar", "Descansar" };

        // Usando for
        for (int i = 0; i < tarefas.Count; i++)
        {
            Console.WriteLine($"Tarefa {i + 1}: {tarefas[i]}");
        }

        // Usando foreach
        foreach (string tarefa in tarefas)
        {
            Console.WriteLine($"Tarefa: {tarefa}");
        }
    }
}
```

**Exemplo do dia a dia**: Percorrer uma lista é como verificar cada item da sua agenda para planejar o dia.

## Listas com Objetos

Listas podem armazenar objetos de classes personalizadas, permitindo criar estruturas mais complexas.

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
        List<Produto> carrinho = new List<Produto>();
        carrinho.Add(new Produto("Maçã", 2.50));
        carrinho.Add(new Produto("Pão", 4.00));

        foreach (Produto produto in carrinho)
        {
            Console.WriteLine(produto); // Exibe: Maçã: R$2.5, Pão: R$4
        }
    }
}
```

**Exemplo do dia a dia**: É como um carrinho de compras online, onde cada item é um produto com nome e preço, e a lista gerencia todos os itens.

## Comparação com Arrays

- **Tamanho**: Arrays têm tamanho fixo; listas são dinâmicas.
- **Flexibilidade**: Listas têm métodos como `Add`, `Remove` e `Sort`, enquanto arrays requerem mais trabalho manual.
- **Uso**: Use arrays para dados fixos e simples; use listas para dados que mudam frequentemente.

## Boas Práticas com Listas

- **Use nomes descritivos**: Como `compras` ou `notas`, em vez de `lista1`.
- **Valide índices**: Verifique `Count` antes de acessar índices para evitar erros.
- **Prefira `foreach` para leitura**: Use quando não precisar de índices.
- **Use listas para dinamismo**: Prefira `List<T>` a arrays quando o tamanho ou conteúdo pode mudar.

## Conclusão

Você agora entende **listas (`List<T>`)** em C#! Elas são como cadernos de anotações flexíveis, permitindo adicionar, remover e organizar dados dinamicamente. Comparadas a arrays, listas são mais versáteis para gerenciar coleções que mudam. Com métodos como `Add`, `Remove` e `Sort`, você pode manipular dados com facilidade.

**Próximos passos**: Tente criar um programa que use uma `List<string>` para gerenciar uma lista de tarefas, permitindo adicionar e remover itens via entrada do usuário. Ou use uma `List<Produto>` para simular um carrinho de compras com cálculo de total. Quanto mais você praticar, mais natural será usar listas!
