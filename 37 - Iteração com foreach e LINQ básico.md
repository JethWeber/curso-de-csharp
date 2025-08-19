# Estruturas de Dados em C#

## Aula 37 - Iteração com `foreach` e LINQ Básico

Bem-vindo ao capítulo de Estruturas de Dados e Coleções em C#! Após explorarmos como manipular coleções como listas, dicionários, filas, pilhas e conjuntos, é hora de aprender como **iterar** sobre essas coleções e realizar operações de consulta usando `foreach` e **LINQ** (Language Integrated Query). Essas ferramentas permitem acessar e processar elementos de coleções de forma eficiente e expressiva.

Nesta aula, vamos entender como usar o laço `foreach` para iterar sobre coleções e introduzir o básico do LINQ para filtrar, ordenar e transformar dados, com exemplos práticos do dia a dia.

### Objetivo

Entender como iterar sobre coleções em C# usando `foreach` e explorar os fundamentos do LINQ para realizar consultas simples, como filtragem e ordenação, em coleções como `List<T>`, `Dictionary<TKey, TValue>`, `Queue<T>`, `Stack<T>`, `HashSet<T>` e `SortedSet<T>`.

## O que é Iteração?

**Iteração** é o processo de percorrer os elementos de uma coleção, como uma lista ou conjunto, para acessar ou manipular cada item. Em C#, a iteração é comumente feita com o laço `foreach`, que simplifica o acesso aos elementos. Além disso, o **LINQ** oferece uma abordagem declarativa para consultar e transformar coleções, tornando o código mais legível e poderoso.

Pense na iteração como folhear as páginas de um livro: com `foreach`, você lê cada página uma a uma; com LINQ, você pode procurar páginas específicas ou organizá-las de forma eficiente.

### Pré-requisitos

- Todas as coleções genéricas (`List<T>`, `Dictionary<TKey, TValue>`, etc.) implementam a interface `IEnumerable<T>`, necessária para usar `foreach` e LINQ.
- Para LINQ, inclua o namespace `System.Linq` com `using System.Linq;`.

## Iteração com `foreach`

O laço `foreach` é usado para percorrer todos os elementos de uma coleção que implementa `IEnumerable<T>`. Ele é simples, legível e elimina a necessidade de gerenciar índices manualmente.

### Sintaxe do `foreach`

```csharp
foreach (var elemento in coleção)
{
    // Código para processar cada elemento
}
```

### Exemplo de `foreach` com `List<T>`

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> frutas = new List<string> { "Maçã", "Banana", "Laranja" };

        // Iterando com foreach
        foreach (string fruta in frutas)
        {
            Console.WriteLine($"Fruta: {fruta}");
        }
        // Exibe:
        // Fruta: Maçã
        // Fruta: Banana
        // Fruta: Laranja
    }
}
```

**Exemplo do dia a dia**: Usar `foreach` é como verificar cada item em uma lista de compras, processando um de cada vez.

### `foreach` com Outras Coleções

O `foreach` funciona com qualquer coleção que implemente `IEnumerable<T>`, como `Dictionary<TKey, TValue>`, `Queue<T>`, `Stack<T>` e `HashSet<T>`.

#### Exemplo com `Dictionary<TKey, TValue>`

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, string> alunos = new Dictionary<int, string>
        {
            { 1, "João" },
            { 2, "Maria" }
        };

        // Iterando com foreach
        foreach (KeyValuePair<int, string> aluno in alunos)
        {
            Console.WriteLine($"Matrícula: {aluno.Key}, Nome: {aluno.Value}");
        }
        // Exibe:
        // Matrícula: 1, Nome: João
        // Matrícula: 2, Nome: Maria
    }
}
```

**Cuidado**: O `foreach` é somente leitura, ou seja, você não pode modificar a coleção (adicionar ou remover elementos) durante a iteração, pois isso causa uma exceção (`InvalidOperationException`). Para modificações, use um laço `for` ou crie uma nova coleção.

## Introdução ao LINQ

**LINQ** (Language Integrated Query) é uma tecnologia do .NET que permite realizar consultas em coleções de forma declarativa, semelhante a consultas SQL. LINQ pode filtrar, ordenar, agrupar e transformar dados de maneira eficiente.

### Tipos de LINQ

- **LINQ com Sintaxe de Consulta** (Query Syntax): Semelhante a SQL, usa palavras-chave como `from`, `where` e `select`.
- **LINQ com Métodos** (Method Syntax): Usa métodos como `Where`, `OrderBy` e `Select`.

Ambas as sintaxes produzem o mesmo resultado, mas a sintaxe de métodos é mais comum por ser mais flexível.

### Métodos LINQ Básicos

- `Where`: Filtra elementos com base em uma condição.
- `OrderBy`: Ordena elementos em ordem crescente.
- `OrderByDescending`: Ordena elementos em ordem decrescente.
- `Select`: Transforma elementos em um novo formato.
- `Count`: Conta elementos que atendem a uma condição.
- `Any`: Verifica se há elementos que atendem a uma condição.
- `FirstOrDefault`: Retorna o primeiro elemento que atende a uma condição ou o valor padrão (ex.: `null` para tipos de referência).

### Exemplo de LINQ com `List<T>`

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> notas = new List<int> { 85, 90, 70, 95, 60 };

        // Filtrando notas maiores ou iguais a 80 (Query Syntax)
        var notasAltasQuery = from nota in notas
                             where nota >= 80
                             select nota;

        Console.WriteLine($"Notas altas (Query): {string.Join(", ", notasAltasQuery)}"); // Exibe: 85, 90, 95

        // Filtrando com Method Syntax
        var notasAltasMethod = notas.Where(n => n >= 80);
        Console.WriteLine($"Notas altas (Method): {string.Join(", ", notasAltasMethod)}"); // Exibe: 85, 90, 95

        // Ordenando notas em ordem crescente
        var notasOrdenadas = notas.OrderBy(n => n);
        Console.WriteLine($"Notas ordenadas: {string.Join(", ", notasOrdenadas)}"); // Exibe: 60, 70, 85, 90, 95

        // Contando notas altas
        int quantidadeNotasAltas = notas.Count(n => n >= 80);
        Console.WriteLine($"Quantidade de notas altas: {quantidadeNotasAltas}"); // Exibe: 3
    }
}
```

**Exemplo do dia a dia**: LINQ é como usar um filtro em uma planilha para encontrar apenas as linhas que atendem a certos critérios, como notas acima de 80.

### LINQ com Objetos Personalizados

LINQ é especialmente poderoso para trabalhar com coleções de objetos personalizados.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

class Aluno
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Aluno(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

    public override string ToString()
    {
        return $"{Nome} ({Idade} anos)";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Aluno> alunos = new List<Aluno>
        {
            new Aluno("João", 20),
            new Aluno("Maria", 17),
            new Aluno("Ana", 19)
        };

        // Filtrando alunos maiores de idade
        var maioresDeIdade = alunos.Where(a => a.Idade >= 18);
        Console.WriteLine($"Maiores de idade: {string.Join(", ", maioresDeIdade)}"); // Exibe: João (20 anos), Ana (19 anos)

        // Ordenando por nome
        var ordenadosPorNome = alunos.OrderBy(a => a.Nome);
        Console.WriteLine($"Ordenados por nome: {string.Join(", ", ordenadosPorNome)}"); // Exibe: Ana (19 anos), João (20 anos), Maria (17 anos)

        // Selecionando apenas nomes
        var nomes = alunos.Select(a => a.Nome);
        Console.WriteLine($"Nomes: {string.Join(", ", nomes)}"); // Exibe: João, Maria, Ana

        // Verificando se há menores de idade
        bool temMenores = alunos.Any(a => a.Idade < 18);
        Console.WriteLine($"Há menores de idade? {temMenores}"); // Exibe: True
    }
}
```

**Exemplo do dia a dia**: Usar LINQ com objetos é como filtrar uma lista de contatos para encontrar apenas pessoas com mais de 18 anos ou ordená-las por nome.

### LINQ com Outras Coleções

LINQ pode ser usado com qualquer coleção que implemente `IEnumerable<T>`, como `Dictionary<TKey, TValue>`, `HashSet<T>` ou `Queue<T>`.

#### Exemplo com `HashSet<T>`

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        HashSet<string> emails = new HashSet<string> { "joao@email.com", "maria@email.com", "ana@email.com" };

        // Filtrando e-mails que contêm "joao"
        var emailsFiltrados = emails.Where(e => e.Contains("joao"));
        Console.WriteLine($"E-mails com 'joao': {string.Join(", ", emailsFiltrados)}"); // Exibe: joao@email.com
    }
}
```

## Comparação entre `foreach` e LINQ

- **`foreach`**:
  - Ideal para iterações simples e diretas.
  - Requer escrever lógica explícita para filtragem ou transformação.
  - Menos conciso para operações complexas.
- **LINQ**:
  - Ideal para consultas complexas (filtragem, ordenação, transformação).
  - Mais conciso e declarativo.
  - Pode ser menos performático para operações muito simples devido à sobrecarga.

## Boas Práticas para Iteração e LINQ

- **Use `foreach` para iterações simples**: Quando você só precisa percorrer elementos sem transformações complexas.
- **Use LINQ para consultas**: Para filtragem, ordenação ou transformação de dados.
- **Evite modificar coleções durante `foreach`**: Isso causa exceções. Use LINQ ou crie uma nova coleção.
- **Use nomes claros em expressões LINQ**: Como `a => a.Idade` (para aluno) em vez de variáveis genéricas como `x`.
- **Prefira `FirstOrDefault` a `First`**: Para evitar exceções quando nenhum elemento é encontrado.
- **Verifique a performance**: LINQ é poderoso, mas pode ser menos eficiente que laços tradicionais em coleções muito grandes.
- **Combine LINQ com objetos**: Use LINQ para processar coleções de objetos personalizados de forma eficiente.

## Conclusão

Você agora entende como iterar sobre coleções em C# usando `foreach` e como realizar consultas poderosas com LINQ. O `foreach` é ideal para percorrer coleções de forma simples, enquanto o LINQ oferece uma maneira declarativa e expressiva de filtrar, ordenar e transformar dados. Com essas ferramentas, você pode processar dados em coleções como `List<T>`, `Dictionary<TKey, TValue>`, `HashSet<T>` e outras de maneira eficiente.

**Próximos passos**: Tente criar um programa que use `foreach` para exibir uma lista de produtos e LINQ para filtrar produtos com preço acima de um valor ou ordená-los por nome. Quanto mais você praticar, mais natural será usar `foreach` e LINQ!
