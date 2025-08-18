# Estruturas de Dados em C#

## Aula 34 - Introdução às Filas e Pilhas

Bem-vindo ao capítulo de Estruturas de Dados e Coleções em C#! Após aprender sobre arrays, listas e dicionários, é hora de explorar **filas** (`Queue<T>`) e **pilhas** (`Stack<T>`), duas estruturas de dados fundamentais que organizam elementos de forma específica. Filas são como uma fila de supermercado, onde o primeiro a chegar é o primeiro a ser atendido. Pilhas são como uma pilha de pratos, onde você só pode pegar ou colocar pratos no topo.

Nesta aula, vamos aprender o que são filas e pilhas, como usá-las em C# e quando aplicá-las, com exemplos práticos do dia a dia.

### Objetivo

Entender os conceitos de filas (`Queue<T>`) e pilhas (`Stack<T>`), como declará-las, manipulá-las e usá-las em C# para gerenciar dados de forma ordenada.

## O que são Filas (`Queue<T>`)?

Uma **fila** (`Queue<T>`) é uma coleção genérica que organiza elementos na ordem **FIFO** (First In, First Out – Primeiro a Entrar, Primeiro a Sair). Isso significa que o primeiro elemento adicionado é o primeiro a ser removido.

Pense em uma fila como uma fila de pessoas esperando no caixa de um supermercado: quem chega primeiro é atendido primeiro.

### Características das Filas

- **Ordem FIFO**: O elemento mais antigo é removido primeiro.
- **Tamanho dinâmico**: Cresce conforme você adiciona elementos.
- **Parte do namespace `System.Collections.Generic`**: Requer `using System.Collections.Generic;`.
- **Acesso limitado**: Só permite adicionar no final e remover do início.

## Declarando e Usando uma Fila

Para usar filas, inclua o namespace `System.Collections.Generic`.

### Métodos Principais

- `Enqueue(T item)`: Adiciona um elemento ao final da fila.
- `Dequeue()`: Remove e retorna o elemento do início da fila.
- `Peek()`: Retorna o elemento do início sem removê-lo.
- `Count`: Retorna o número de elementos na fila.
- `Clear()`: Remove todos os elementos.

### Exemplo de Fila

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Queue<string> filaSupermercado = new Queue<string>();

        // Adicionando pessoas à fila
        filaSupermercado.Enqueue("João");
        filaSupermercado.Enqueue("Maria");
        filaSupermercado.Enqueue("Ana");

        Console.WriteLine($"Pessoas na fila: {string.Join(", ", filaSupermercado)}"); // Exibe: João, Maria, Ana
        Console.WriteLine($"Total de pessoas: {filaSupermercado.Count}"); // Exibe: 3

        // Atendendo a primeira pessoa
        string proximo = filaSupermercado.Dequeue();
        Console.WriteLine($"Atendido: {proximo}"); // Exibe: João
        Console.WriteLine($"Pessoas restantes: {string.Join(", ", filaSupermercado)}"); // Exibe: Maria, Ana

        // Verificando quem é o próximo sem remover
        Console.WriteLine($"Próximo na fila: {filaSupermercado.Peek()}"); // Exibe: Maria
    }
}
```

**Exemplo do dia a dia**: Uma fila é como a espera em um banco. Cada cliente entra no final da fila (`Enqueue`) e é atendido quando chega ao início (`Dequeue`). O caixa pode verificar quem é o próximo (`Peek`) sem atender ainda.

**Cuidado**: Chamar `Dequeue` ou `Peek` em uma fila vazia causa um erro (`InvalidOperationException`). Verifique `Count` antes.

```csharp
if (filaSupermercado.Count > 0)
{
    Console.WriteLine(filaSupermercado.Dequeue());
}
```

## O que são Pilhas (`Stack<T>`)?

Uma **pilha** (`Stack<T>`) é uma coleção genérica que organiza elementos na ordem **LIFO** (Last In, First Out – Último a Entrar, Primeiro a Sair). Isso significa que o último elemento adicionado é o primeiro a ser removido.

Pense em uma pilha como uma pilha de pratos: você coloca um prato no topo e só pode retirar o prato do topo.

### Características das Pilhas

- **Ordem LIFO**: O elemento mais recente é removido primeiro.
- **Tamanho dinâmico**: Cresce conforme você adiciona elementos.
- **Parte do namespace `System.Collections.Generic`**: Requer `using System.Collections.Generic;`.
- **Acesso limitado**: Só permite adicionar e remover do topo.

## Declarando e Usando uma Pilha

### Métodos Principais

- `Push(T item)`: Adiciona um elemento ao topo da pilha.
- `Pop()`: Remove e retorna o elemento do topo da pilha.
- `Peek()`: Retorna o elemento do topo sem removê-lo.
- `Count`: Retorna o número de elementos na pilha.
- `Clear()`: Remove todos os elementos.

### Exemplo de Pilha

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Stack<string> pilhaPratos = new Stack<string>();

        // Adicionando pratos à pilha
        pilhaPratos.Push("Prato Azul");
        pilhaPratos.Push("Prato Vermelho");
        pilhaPratos.Push("Prato Branco");

        Console.WriteLine($"Pratos na pilha: {string.Join(", ", pilhaPratos)}"); // Exibe: Prato Branco, Prato Vermelho, Prato Azul
        Console.WriteLine($"Total de pratos: {pilhaPratos.Count}"); // Exibe: 3

        // Retirando o prato do topo
        string topo = pilhaPratos.Pop();
        Console.WriteLine($"Retirado: {topo}"); // Exibe: Prato Branco
        Console.WriteLine($"Pratos restantes: {string.Join(", ", pilhaPratos)}"); // Exibe: Prato Vermelho, Prato Azul

        // Verificando o topo sem remover
        Console.WriteLine($"Prato no topo: {pilhaPratos.Peek()}"); // Exibe: Prato Vermelho
    }
}
```

**Exemplo do dia a dia**: Uma pilha é como uma pilha de papéis na sua mesa. Você adiciona um papel no topo (`Push`) e só pode retirar o papel mais recente do topo (`Pop`). Você pode olhar o papel de cima (`Peek`) sem tirá-lo.

**Cuidado**: Chamar `Pop` ou `Peek` em uma pilha vazia causa um erro (`InvalidOperationException`). Verifique `Count` antes.

```csharp
if (pilhaPratos.Count > 0)
{
    Console.WriteLine(pilhaPratos.Pop());
}
```

## Filas e Pilhas com Objetos

Tanto filas quanto pilhas podem armazenar objetos de classes personalizadas, permitindo estruturas mais complexas.

```csharp
using System;
using System.Collections.Generic;

class Tarefa
{
    public string Descricao { get; set; }
    public int Prioridade { get; set; }

    public Tarefa(string descricao, int prioridade)
    {
        Descricao = descricao;
        Prioridade = prioridade;
    }

    public override string ToString()
    {
        return $"{Descricao} (Prioridade: {Prioridade})";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Fila de tarefas
        Queue<Tarefa> filaTarefas = new Queue<Tarefa>();
        filaTarefas.Enqueue(new Tarefa("Estudar C#", 1));
        filaTarefas.Enqueue(new Tarefa("Enviar e-mail", 2));

        Console.WriteLine($"Próxima tarefa: {filaTarefas.Dequeue()}"); // Exibe: Estudar C# (Prioridade: 1)

        // Pilha de tarefas
        Stack<Tarefa> pilhaTarefas = new Stack<Tarefa>();
        pilhaTarefas.Push(new Tarefa("Revisar código", 1));
        pilhaTarefas.Push(new Tarefa("Testar programa", 2));

        Console.WriteLine($"Tarefa mais recente: {pilhaTarefas.Pop()}"); // Exibe: Testar programa (Prioridade: 2)
    }
}
```

**Exemplo do dia a dia**: Uma fila de tarefas é como uma lista de afazeres em ordem de chegada (ex.: tarefas do dia). Uma pilha de tarefas é como lembretes em post-its, onde você lida com o mais recente primeiro.

## Comparação entre Filas, Pilhas, Listas e Dicionários

- **Filas**: Ordem FIFO, ideais para processos sequenciais (ex.: fila de impressão).
- **Pilhas**: Ordem LIFO, ideais para reversão de ações (ex.: desfazer em editores de texto).
- **Listas**: Acesso por índice, tamanho dinâmico, flexíveis para manipulação geral.
- **Dicionários**: Acesso por chave, ideais para associações rápidas.

## Boas Práticas com Filas e Pilhas

- **Use nomes descritivos**: Como `filaTarefas` ou `pilhaPratos`, em vez de `queue1`.
- **Verifique `Count`**: Antes de chamar `Dequeue`, `Pop`, ou `Peek` para evitar erros.
- **Escolha a estrutura certa**: Use filas para processos FIFO (ex.: atendimento) e pilhas para processos LIFO (ex.: desfazer).
- **Combine com objetos**: Use classes personalizadas para modelar dados complexos.

## Conclusão

Você agora entende **filas (`Queue<T>`)** e **pilhas (`Stack<T>`)** em C#! Filas são como filas de espera, seguindo a ordem FIFO, perfeitas para processos sequenciais. Pilhas são como pilhas de objetos, seguindo a ordem LIFO, ideais para ações reversíveis. Com métodos como `Enqueue`/`Dequeue` e `Push`/`Pop`, você pode gerenciar dados de forma ordenada e eficiente.

**Próximos passos**: Tente criar um programa que simule uma fila de clientes em um banco, usando `Queue<T>`, ou uma pilha de comandos para implementar uma função "desfazer", usando `Stack<T>`. Quanto mais você praticar, mais natural será usar filas e pilhas!
