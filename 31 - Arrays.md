# Estruturas de Dados em C#

## Aula 31 - Introdução aos Arrays

Bem-vindo ao capítulo de Estruturas de Dados e Coleções em C#! Depois de dominar os fundamentos e a Programação Orientada a Objetos (POO), é hora de aprender sobre **arrays**, uma das estruturas de dados mais simples e úteis. Arrays são como uma prateleira de caixas numeradas: cada caixa guarda um item, e você pode acessá-las facilmente pelo número da caixa.

Nesta aula, vamos explorar **arrays unidimensionais** (uma linha de caixas) e **arrays multidimensionais** (uma grade ou tabela de caixas), com exemplos práticos do dia a dia.

### Objetivo

Entender o que são arrays unidimensionais e multidimensionais, como declará-los, manipulá-los e usá-los em C# para organizar dados de forma eficiente.

## O que é um Array?

Um **array** é uma estrutura de dados que armazena uma coleção de elementos do mesmo tipo (como números ou textos) em posições numeradas, chamadas **índices**. Cada elemento pode ser acessado diretamente pelo seu índice, começando do 0.

Pense em um array como uma fileira de gavetas em uma cômoda. Cada gaveta tem um número (índice), e você pode guardar ou pegar algo dela sabendo o número.

### Características dos Arrays

- **Tamanho fixo**: Após criado, o tamanho do array não pode mudar.
- **Tipo único**: Todos os elementos devem ser do mesmo tipo (ex.: todos `int` ou todos `string`).
- **Acesso por índice**: Usa números (0, 1, 2...) para acessar elementos.
- **Eficiente**: Ideal para armazenar e acessar dados em ordem.

## Arrays Unidimensionais

Um **array unidimensional** é uma lista linear de elementos, como uma única prateleira com caixas numeradas.

### Declarando e Inicializando

```csharp
// Declaração de um array
int[] notas; // Array de inteiros, ainda não inicializado

// Inicialização com tamanho fixo (5 elementos)
notas = new int[5];

// Atribuindo valores
notas[0] = 90;
notas[1] = 85;
notas[2] = 88;
notas[3] = 92;
notas[4] = 95;

// Declaração e inicialização em uma linha
int[] notas2 = new int[] { 90, 85, 88, 92, 95 };
```

**Exemplo do dia a dia**: Um array unidimensional é como uma lista de compras. Cada item (ex.: "maçã", "pão") está em uma posição, e você pode acessar o item dizendo "o primeiro da lista" (índice 0).

### Acessando e Manipulando

Você pode acessar ou modificar elementos usando o índice.

```csharp
class Program
{
    static void Main(string[] args)
    {
        int[] notas = new int[] { 90, 85, 88, 92, 95 };
        Console.WriteLine($"Primeira nota: {notas[0]}"); // Exibe: 90
        notas[1] = 87; // Altera o segundo elemento
        Console.WriteLine($"Nova segunda nota: {notas[1]}"); // Exibe: 87
    }
}
```

### Percorrendo um Array

Use loops (como `for` ou `foreach`) para trabalhar com todos os elementos.

```csharp
class Program
{
    static void Main(string[] args)
    {
        int[] notas = new int[] { 90, 85, 88, 92, 95 };

        // Usando for
        for (int i = 0; i < notas.Length; i++)
        {
            Console.WriteLine($"Nota {i + 1}: {notas[i]}");
        }

        // Usando foreach
        foreach (int nota in notas)
        {
            Console.WriteLine($"Nota: {nota}");
        }
    }
}
```

**Exemplo do dia a dia**: Percorrer um array é como verificar cada item da sua lista de compras para ver se você comprou tudo.

### Propriedade `Length`

A propriedade `Length` retorna o tamanho do array.

```csharp
int[] notas = new int[5];
Console.WriteLine($"Tamanho do array: {notas.Length}"); // Exibe: 5
```

## Arrays Multidimensionais

Um **array multidimensional** organiza dados em mais de uma dimensão, como uma tabela (bidimensional) ou um cubo (tridimensional). O mais comum é o **array bidimensional**, que funciona como uma grade ou matriz.

### Declarando e Inicializando Arrays Bidimensionais

```csharp
// Declaração de um array bidimensional (3 linhas x 2 colunas)
int[,] matriz = new int[3, 2];

// Atribuindo valores
matriz[0, 0] = 1; // Linha 0, Coluna 0
matriz[0, 1] = 2;
matriz[1, 0] = 3;
matriz[1, 1] = 4;
matriz[2, 0] = 5;
matriz[2, 1] = 6;

// Inicialização direta
int[,] matriz2 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
```

**Exemplo do dia a dia**: Um array bidimensional é como uma tabela de notas de alunos, onde cada linha representa um aluno e cada coluna uma disciplina (ex.: Matemática e Português).

### Acessando e Manipulando Arrays Bidimensionais

Use dois índices para acessar elementos: um para a linha e outro para a coluna.

```csharp
class Program
{
    static void Main(string[] args)
    {
        int[,] notas = new int[,] { { 90, 85 }, { 88, 92 }, { 95, 87 } };
        Console.WriteLine($"Nota do aluno 1 em Matemática: {notas[0, 0]}"); // Exibe: 90
        notas[1, 1] = 94; // Altera a nota do aluno 2 em Português
        Console.WriteLine($"Nova nota do aluno 2 em Português: {notas[1, 1]}"); // Exibe: 94
    }
}
```

### Percorrendo Arrays Bidimensionais

Use loops aninhados para percorrer todas as linhas e colunas.

```csharp
class Program
{
    static void Main(string[] args)
    {
        int[,] notas = new int[,] { { 90, 85 }, { 88, 92 }, { 95, 87 } };

        // Usando for aninhado
        for (int i = 0; i < notas.GetLength(0); i++) // Linhas
        {
            for (int j = 0; j < notas.GetLength(1); j++) // Colunas
            {
                Console.WriteLine($"Aluno {i + 1}, Disciplina {j + 1}: {notas[i, j]}");
            }
        }
    }
}
```

**Exemplo do dia a dia**: Percorrer um array bidimensional é como verificar as notas de uma planilha, linha por linha, coluna por coluna.

### Propriedade `GetLength`

A propriedade `GetLength(dimensão)` retorna o tamanho de uma dimensão específica (0 para linhas, 1 para colunas).

```csharp
int[,] matriz = new int[3, 2];
Console.WriteLine($"Linhas: {matriz.GetLength(0)}"); // Exibe: 3
Console.WriteLine($"Colunas: {matriz.GetLength(1)}"); // Exibe: 2
```

## Arrays Multidimensionais com Mais Dimensões

Embora menos comuns, arrays com três ou mais dimensões são possíveis. Por exemplo, um array tridimensional pode ser usado para representar um cubo de dados.

```csharp
int[,,] cubo = new int[2, 2, 2];
cubo[0, 0, 0] = 1; // Posição no "cubo"
```

**Exemplo do dia a dia**: Um array tridimensional é como um armário com gavetas organizadas em andares, fileiras e profundidade.

## Cuidados ao Usar Arrays

- **Índices fora do limite**: Tentar acessar um índice inexistente (ex.: `notas[5]` em um array de tamanho 5) causa um erro (`IndexOutOfRangeException`).
- **Tamanho fixo**: Arrays não podem ser redimensionados após criados. Para coleções dinâmicas, veremos listas em outra aula.
- **Inicialização padrão**: Elementos de um array são inicializados com valores padrão (ex.: 0 para `int`, `null` para `string`).

```csharp
int[] notas = new int[3];
Console.WriteLine(notas[0]); // Exibe: 0 (valor padrão)
```

## Boas Práticas com Arrays

- **Use nomes descritivos**: Como `notas` ou `matrizNotas`, em vez de `array1`.
- **Valide índices**: Evite acessar índices fora do limite com verificações ou usando `Length`/`GetLength`.
- **Prefira `foreach` para leitura**: Quando não precisar dos índices, use `foreach` para simplificar.
- **Considere alternativas**: Para tamanhos dinâmicos, use coleções como `List<T>` (veremos depois).

## Conclusão

Você agora entende **arrays unidimensionais** e **multidimensionais** em C#! Arrays unidimensionais são como listas de compras, perfeitas para dados lineares. Arrays multidimensionais são como tabelas ou grades, ideais para dados estruturados como planilhas. Eles são eficientes para armazenar e acessar dados, mas têm tamanho fixo.

**Próximos passos**: Tente criar um programa que use um array unidimensional para armazenar notas de alunos e calcular a média. Ou use um array bidimensional para representar um tabuleiro de jogo da velha (3x3). Quanto mais você praticar, mais natural será usar arrays!
