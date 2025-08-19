# Estruturas de Dados em C#

## Aula 36 - Manipulação de Coleções (`Add`, `Remove`, `Contains`, etc.)

Bem-vindo ao capítulo de Estruturas de Dados e Coleções em C#! Após explorarmos arrays, listas, dicionários, filas, pilhas e conjuntos, é hora de nos aprofundarmos na **manipulação de coleções** em C#. Nesta aula, vamos focar nas operações comuns para gerenciar coleções, como `Add`, `Remove`, `Contains`, entre outras, e como elas se aplicam a diferentes tipos de coleções, incluindo `List<T>`, `Dictionary<TKey, TValue>`, `Queue<T>`, `Stack<T>`, `HashSet<T>` e `SortedSet<T>`.

Vamos aprender como realizar essas operações de forma eficiente e explorar exemplos práticos que mostram como elas são usadas no dia a dia.

### Objetivo

Entender as operações comuns de manipulação de coleções em C# (`Add`, `Remove`, `Contains`, etc.), suas aplicações em diferentes tipos de coleções e boas práticas para gerenciar dados de forma eficiente.

## O que é Manipulação de Coleções?

A manipulação de coleções envolve adicionar, remover, verificar a existência de elementos e realizar outras operações para gerenciar os dados armazenados em coleções como listas, dicionários e conjuntos. Essas operações são fundamentais para trabalhar com dados dinâmicos em aplicações reais, como sistemas de gerenciamento, jogos ou aplicativos de produtividade.

Pense na manipulação de coleções como organizar uma biblioteca: você pode adicionar livros, remover livros, verificar se um livro específico está disponível ou organizar a coleção de forma específica.

### Operações Comuns

As operações mais comuns em coleções genéricas do namespace `System.Collections.Generic` incluem:

- `Add`: Adiciona um elemento à coleção.
- `Remove`: Remove um elemento da coleção.
- `Contains`: Verifica se um elemento existe na coleção.
- `Clear`: Remove todos os elementos da coleção.
- `Count`: Retorna o número de elementos na coleção.
- Outras operações específicas, como `TryGetValue` (para dicionários) ou `UnionWith` (para conjuntos).

## Manipulação em Diferentes Coleções

Vamos explorar como essas operações se aplicam a diferentes coleções, com exemplos práticos.

### 1. Listas (`List<T>`)

`List<T>` é uma coleção ordenada que permite duplicatas e acesso por índice.

#### Métodos Principais

- `Add(T item)`: Adiciona um elemento ao final da lista.
- `Remove(T item)`: Remove a primeira ocorrência de um elemento.
- `RemoveAt(int index)`: Remove o elemento no índice especificado.
- `Contains(T item)`: Verifica se um elemento está na lista.
- `Clear()`: Remove todos os elementos.
- `IndexOf(T item)`: Retorna o índice da primeira ocorrência de um elemento.

#### Exemplo de `List<T>`

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> livros = new List<string>();

        // Adicionando livros
        livros.Add("1984");
        livros.Add("O Senhor dos Anéis");
        livros.Add("1984"); // Duplicatas são permitidas

        Console.WriteLine($"Livros: {string.Join(", ", livros)}"); // Exibe: 1984, O Senhor dos Anéis, 1984
        Console.WriteLine($"Total de livros: {livros.Count}"); // Exibe: 3

        // Verificando se um livro existe
        Console.WriteLine($"Contém '1984'? {livros.Contains("1984")}"); // Exibe: True

        // Removendo um livro
        livros.Remove("1984"); // Remove a primeira ocorrência
        Console.WriteLine($"Após remover '1984': {string.Join(", ", livros)}"); // Exibe: O Senhor dos Anéis, 1984

        // Removendo por índice
        livros.RemoveAt(0);
        Console.WriteLine($"Após remover índice 0: {string.Join(", ", livros)}"); // Exibe: 1984
    }
}
```

**Exemplo do dia a dia**: Uma lista de livros pode ser usada para gerenciar uma estante, onde você adiciona novos livros (`Add`), remove livros específicos (`Remove`) ou verifica se um livro está na estante (`Contains`).

### 2. Dicionários (`Dictionary<TKey, TValue>`)

`Dictionary<TKey, TValue>` armazena pares chave-valor, com acesso rápido por chave.

#### Métodos Principais

- `Add(TKey key, TValue value)`: Adiciona um par chave-valor.
- `Remove(TKey key)`: Remove o par associado à chave.
- `ContainsKey(TKey key)`: Verifica se uma chave existe.
- `ContainsValue(TValue value)`: Verifica se um valor existe.
- `TryGetValue(TKey key, out TValue value)`: Tenta obter o valor associado a uma chave.
- `Clear()`: Remove todos os pares.

#### Exemplo de `Dictionary<TKey, TValue>`

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, string> alunos = new Dictionary<int, string>();

        // Adicionando alunos
        alunos.Add(1, "João");
        alunos.Add(2, "Maria");

        Console.WriteLine($"Alunos: {string.Join(", ", alunos.Values)}"); // Exibe: João, Maria
        Console.WriteLine($"Total de alunos: {alunos.Count}"); // Exibe: 2

        // Verificando se uma chave existe
        Console.WriteLine($"Matrícula 1 existe? {alunos.ContainsKey(1)}"); // Exibe: True

        // Acessando um valor
        if (alunos.TryGetValue(1, out string nome))
        {
            Console.WriteLine($"Aluno com matrícula 1: {nome}"); // Exibe: João
        }

        // Removendo um aluno
        alunos.Remove(1);
        Console.WriteLine($"Após remover matrícula 1: {string.Join(", ", alunos.Values)}"); // Exibe: Maria
    }
}
```

**Exemplo do dia a dia**: Um dicionário pode ser usado para gerenciar matrículas de alunos, onde a chave é o número de matrícula e o valor é o nome do aluno. Você pode adicionar novos alunos (`Add`), remover alunos (`Remove`) ou verificar se uma matrícula existe (`ContainsKey`).

**Cuidado**: Tentar adicionar uma chave que já existe causa um erro (`ArgumentException`). Use `TryAdd` (disponível no .NET 5.0+) ou verifique com `ContainsKey` antes.

### 3. Filas (`Queue<T>`)

`Queue<T>` organiza elementos em ordem FIFO (First In, First Out).

#### Métodos Principais

- `Enqueue(T item)`: Adiciona um elemento ao final da fila.
- `Dequeue()`: Remove e retorna o elemento do início da fila.
- `Peek()`: Retorna o elemento do início sem removê-lo.
- `Contains(T item)`: Verifica se um elemento está na fila.
- `Clear()`: Remove todos os elementos.

#### Exemplo de `Queue<T>`

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Queue<string> filaBanco = new Queue<string>();

        // Adicionando clientes
        filaBanco.Enqueue("João");
        filaBanco.Enqueue("Maria");

        Console.WriteLine($"Fila: {string.Join(", ", filaBanco)}"); // Exibe: João, Maria
        Console.WriteLine($"Total na fila: {filaBanco.Count}"); // Exibe: 2

        // Verificando o próximo cliente
        Console.WriteLine($"Próximo cliente: {filaBanco.Peek()}"); // Exibe: João

        // Atendendo um cliente
        string atendido = filaBanco.Dequeue();
        Console.WriteLine($"Atendido: {atendido}"); // Exibe: João
        Console.WriteLine($"Fila restante: {string.Join(", ", filaBanco)}"); // Exibe: Maria
    }
}
```

**Exemplo do dia a dia**: Uma fila é como a espera em um banco, onde você adiciona clientes ao final (`Enqueue`) e atende o primeiro da fila (`Dequeue`).

**Cuidado**: Chamar `Dequeue` ou `Peek` em uma fila vazia causa um erro (`InvalidOperationException`). Verifique `Count` antes.

### 4. Pilhas (`Stack<T>`)

`Stack<T>` organiza elementos em ordem LIFO (Last In, First Out).

#### Métodos Principais

- `Push(T item)`: Adiciona um elemento ao topo da pilha.
- `Pop()`: Remove e retorna o elemento do topo.
- `Peek()`: Retorna o elemento do topo sem removê-lo.
- `Contains(T item)`: Verifica se um elemento está na pilha.
- `Clear()`: Remove todos os elementos.

#### Exemplo de `Stack<T>`

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Stack<string> historico = new Stack<string>();

        // Adicionando ações ao histórico
        historico.Push("Página Inicial");
        historico.Push("Perfil");
        historico.Push("Configurações");

        Console.WriteLine($"Histórico: {string.Join(", ", historico)}"); // Exibe: Configurações, Perfil, Página Inicial
        Console.WriteLine($"Total de ações: {historico.Count}"); // Exibe: 3

        // Verificando a última ação
        Console.WriteLine($"Última ação: {historico.Peek()}"); // Exibe: Configurações

        // Revertendo a última ação
        string ultimaAcao = historico.Pop();
        Console.WriteLine($"Ação desfeita: {ultimaAcao}"); // Exibe: Configurações
        Console.WriteLine($"Histórico restante: {string.Join(", ", historico)}"); // Exibe: Perfil, Página Inicial
    }
}
```

**Exemplo do dia a dia**: Uma pilha é como o histórico de navegação de um navegador, onde você adiciona páginas ao topo (`Push`) e reverte para a página anterior (`Pop`).

**Cuidado**: Chamar `Pop` ou `Peek` em uma pilha vazia causa um erro (`InvalidOperationException`). Verifique `Count` antes.

### 5. Conjuntos (`HashSet<T>` e `SortedSet<T>`)

`HashSet<T>` e `SortedSet<T>` armazenam elementos únicos, com `SortedSet<T>` mantendo a ordem crescente.

#### Métodos Principais

- `Add(T item)`: Adiciona um elemento (ignora duplicatas).
- `Remove(T item)`: Remove um elemento.
- `Contains(T item)`: Verifica se um elemento existe.
- `Clear()`: Remove todos os elementos.
- Operações de conjuntos: `UnionWith`, `IntersectWith`, `ExceptWith`.

#### Exemplo de `HashSet<T>`

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        HashSet<string> emails = new HashSet<string>();

        // Adicionando e-mails
        emails.Add("joao@email.com");
        emails.Add("maria@email.com");
        emails.Add("joao@email.com"); // Ignorado, pois já existe

        Console.WriteLine($"E-mails: {string.Join(", ", emails)}"); // Exibe: joao@email.com, maria@email.com
        Console.WriteLine($"Total de e-mails: {emails.Count}"); // Exibe: 2

        // Verificando se um e-mail existe
        Console.WriteLine($"joao@email.com existe? {emails.Contains("joao@email.com")}"); // Exibe: True

        // Realizando operação de união
        HashSet<string> novosEmails = new HashSet<string> { "maria@email.com", "ana@email.com" };
        emails.UnionWith(novosEmails);
        Console.WriteLine($"Após união: {string.Join(", ", emails)}"); // Exibe: joao@email.com, maria@email.com, ana@email.com
    }
}
```

**Exemplo do dia a dia**: Um `HashSet<T>` pode ser usado para gerenciar uma lista de e-mails únicos para envio de newsletters, garantindo que não haja duplicatas.

## Manipulação com Objetos Personalizados

As operações de manipulação podem ser usadas com classes personalizadas, desde que sejam implementados métodos como `Equals` e `GetHashCode` para coleções como `HashSet<T>` ou `Dictionary<TKey, TValue>`.

```csharp
using System;
using System.Collections.Generic;

class Pedido
{
    public int Id { get; set; }
    public string Descricao { get; set; }

    public Pedido(int id, string descricao)
    {
        Id = id;
        Descricao = descricao;
    }

    public override bool Equals(object obj)
    {
        if (obj is Pedido outro)
            return Id == outro.Id;
        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"Pedido {Id}: {Descricao}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        HashSet<Pedido> pedidos = new HashSet<Pedido>();

        // Adicionando pedidos
        pedidos.Add(new Pedido(1, "Notebook"));
        pedidos.Add(new Pedido(2, "Mouse"));
        pedidos.Add(new Pedido(1, "Notebook")); // Ignorado, pois ID já existe

        Console.WriteLine($"Pedidos: {string.Join(", ", pedidos)}"); // Exibe: Pedido 1: Notebook, Pedido 2: Mouse

        // Verificando se um pedido existe
        Pedido pedido = new Pedido(1, "Notebook");
        Console.WriteLine($"Pedido 1 existe? {pedidos.Contains(pedido)}"); // Exibe: True

        // Removendo um pedido
        pedidos.Remove(pedido);
        Console.WriteLine($"Após remover Pedido 1: {string.Join(", ", pedidos)}"); // Exibe: Pedido 2: Mouse
    }
}
```

**Exemplo do dia a dia**: Um `HashSet<Pedido>` pode ser usado para gerenciar pedidos únicos em um sistema de e-commerce, garantindo que não haja duplicatas com base no ID do pedido.

## Boas Práticas para Manipulação de Coleções

- **Use nomes descritivos**: Como `livros`, `alunos` ou `pedidos`, em vez de `list1` ou `dict1`.
- **Verifique antes de remover ou acessar**: Use `Count` ou `Contains` para evitar erros como `InvalidOperationException`.
- **Escolha a coleção certa**:
  - `List<T>` para dados ordenados com acesso por índice.
  - `Dictionary<TKey, TValue>` para acesso rápido por chave.
  - `Queue<T>` para processos FIFO.
  - `Stack<T>` para processos LIFO.
  - `HashSet<T>` ou `SortedSet<T>` para elementos únicos.
- **Use `Try`-métodos quando disponíveis**: Como `TryGetValue` ou `TryAdd` para evitar exceções.
- **Implemente `Equals` e `GetHashCode`**: Para objetos personalizados em dicionários e conjuntos.
- **Evite duplicatas desnecessárias**: Use `HashSet<T>` ou `SortedSet<T>` quando unicidade é importante.

## Conclusão

Você agora entende como manipular coleções em C# usando operações como `Add`, `Remove`, `Contains` e outras. Essas operações são fundamentais para gerenciar dados em `List<T>`, `Dictionary<TKey, TValue>`, `Queue<T>`, `Stack<T>`, `HashSet<T>` e `SortedSet<T>`. Com essas ferramentas, você pode criar sistemas eficientes para gerenciar dados dinâmicos em aplicações reais.

**Próximos passos**: Tente criar um programa que gerencie uma lista de tarefas usando `List<T>` com operações de adição e remoção, ou um sistema de pedidos únicos usando `HashSet<T>` para evitar duplicatas. Quanto mais você praticar, mais natural será manipular coleções!
