Vamos criar uma aula completa sobre listas em C#, cobrindo desde o básico até conceitos mais avançados, com exemplos práticos e explicações claras. A ideia é te ensinar como usar a classe `List<T>` do C#, que é uma das estruturas de dados mais versáteis e comuns na linguagem.

---

### **Aula: Trabalhando com Listas em C#**

#### **1. O que é uma Lista em C#?**
A classe `List<T>` é uma coleção dinâmica fornecida pelo namespace `System.Collections.Generic`. Diferente de arrays, que têm tamanho fixo, listas podem crescer ou diminuir dinamicamente conforme você adiciona ou remove elementos. O `T` indica que a lista é **genérica**, ou seja, você define o tipo de dados que ela vai armazenar (ex.: `int`, `string`, objetos personalizados, etc.).

**Características principais:**
- **Dinâmica**: Pode aumentar ou diminuir de tamanho.
- **Tipada**: Só armazena um tipo específico de dados (definido pelo `T`).
- **Métodos úteis**: Possui métodos para adicionar, remover, buscar, ordenar e manipular elementos.
- **Indexada**: Os elementos são acessados por índices, começando em 0.

---

#### **2. Como criar uma Lista?**
Para usar listas, você precisa importar o namespace `System.Collections.Generic`. Veja como criar uma lista:

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Criando uma lista de inteiros
        List<int> numeros = new List<int>();

        // Criando uma lista de strings
        List<string> nomes = new List<string>();

        // Criando uma lista com valores iniciais
        List<double> precos = new List<double> { 10.5, 20.0, 15.75 };
    }
}
```

- `List<int>` cria uma lista que só aceita números inteiros.
- Você pode inicializar a lista vazia ou com valores iniciais usando `{}`.
- O `using System.Collections.Generic` é necessário para usar `List<T>`.

---

#### **3. Métodos e Operações Comuns**

A classe `List<T>` oferece muitos métodos úteis. Vamos explorar os mais comuns com exemplos.

##### **3.1. Adicionar Elementos**
- `Add(T item)`: Adiciona um elemento ao final da lista.
- `AddRange(IEnumerable<T> collection)`: Adiciona múltiplos elementos de uma coleção.

```csharp
List<string> frutas = new List<string>();
frutas.Add("Maçã"); // Adiciona "Maçã"
frutas.Add("Banana"); // Adiciona "Banana"

List<string> maisFrutas = new List<string> { "Laranja", "Manga" };
frutas.AddRange(maisFrutas); // Adiciona "Laranja" e "Manga"

Console.WriteLine(string.Join(", ", frutas)); // Saída: Maçã, Banana, Laranja, Manga
```

##### **3.2. Acessar Elementos**
- Os elementos são acessados pelo índice (começando em 0).
- Propriedade `Count`: Retorna o número de elementos na lista.

```csharp
List<string> frutas = new List<string> { "Maçã", "Banana", "Laranja" };
Console.WriteLine(frutas[0]); // Saída: Maçã
Console.WriteLine($"Total de frutas: {frutas.Count}"); // Saída: Total de frutas: 3
```

##### **3.3. Remover Elementos**
- `Remove(T item)`: Remove a primeira ocorrência de um item.
- `RemoveAt(int index)`: Remove o elemento no índice especificado.
- `Clear()`: Remove todos os elementos.

```csharp
List<string> frutas = new List<string> { "Maçã", "Banana", "Laranja" };
frutas.Remove("Banana"); // Remove "Banana"
frutas.RemoveAt(0); // Remove "Maçã" (índice 0)
Console.WriteLine(string.Join(", ", frutas)); // Saída: Laranja

frutas.Clear(); // Limpa a lista
Console.WriteLine($"Total de frutas: {frutas.Count}"); // Saída: Total de frutas: 0
```

##### **3.4. Buscar Elementos**
- `Contains(T item)`: Verifica se um item está na lista.
- `Find(Predicate<T> match)`: Busca o primeiro elemento que satisfaz uma condição.
- `IndexOf(T item)`: Retorna o índice da primeira ocorrência de um item.

```csharp
List<int> numeros = new List<int> { 10, 20, 30, 40 };

if (numeros.Contains(20))
    Console.WriteLine("20 está na lista!");

int primeiroMaiorQue25 = numeros.Find(x => x > 25); // Retorna 30
Console.WriteLine($"Primeiro número > 25: {primeiroMaiorQue25}");

int indice = numeros.IndexOf(40); // Retorna 3
Console.WriteLine($"Índice do 40: {indice}");
```

##### **3.5. Ordenar e Inverter**
- `Sort()`: Ordena a lista em ordem crescente.
- `Reverse()`: Inverte a ordem dos elementos.

```csharp
List<int> numeros = new List<int> { 40, 10, 30, 20 };
numeros.Sort(); // Ordena: 10, 20, 30, 40
Console.WriteLine(string.Join(", ", numeros)); // Saída: 10, 20, 30, 40

numeros.Reverse(); // Inverte: 40, 30, 20, 10
Console.WriteLine(string.Join(", ", numeros)); // Saída: 40, 30, 20, 10
```

---

#### **4. Iterando sobre uma Lista**
Você pode percorrer uma lista usando loops como `for`, `foreach` ou métodos como `ForEach`.

```csharp
List<string> nomes = new List<string> { "Ana", "Bruno", "Carla" };

// Usando foreach
foreach (string nome in nomes)
{
    Console.WriteLine(nome);
}

// Usando ForEach com lambda
nomes.ForEach(nome => Console.WriteLine(nome));

// Usando for
for (int i = 0; i < nomes.Count; i++)
{
    Console.WriteLine($"Índice {i}: {nomes[i]}");
}
```

---

#### **5. Listas com Objetos Personalizados**
Você pode usar listas para armazenar objetos de classes personalizadas. Por exemplo:

```csharp
class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

    public override string ToString() => $"{Nome}, {Idade} anos";
}

List<Pessoa> pessoas = new List<Pessoa>
{
    new Pessoa("Ana", 25),
    new Pessoa("Bruno", 30),
    new Pessoa("Carla", 20)
};

// Ordenar por idade
pessoas.Sort((p1, p2) => p1.Idade.CompareTo(p2.Idade));

foreach (var pessoa in pessoas)
{
    Console.WriteLine(pessoa); // Saída: Carla, 20 anos | Ana, 25 anos | Bruno, 30 anos
}
```

---

#### **6. Cuidados e Boas Práticas**
- **Evite acessar índices inválidos**: Sempre verifique o `Count` antes de acessar um índice para evitar `IndexOutOfRangeException`.
- **Capacidade inicial**: Se souber o tamanho aproximado da lista, use `new List<T>(capacidade)` para melhorar a performance.
- **Use LINQ para consultas avançadas**: O LINQ (Language Integrated Query) é ótimo para filtrar, ordenar e transformar listas.

Exemplo com LINQ:
```csharp
List<int> numeros = new List<int> { 1, 2, 3, 4, 5 };
var pares = numeros.Where(x => x % 2 == 0).ToList(); // Retorna { 2, 4 }
Console.WriteLine(string.Join(", ", pares)); // Saída: 2, 4
```

---

#### **7. Exercício Prático**
Crie um programa que:
1. Crie uma lista de strings com nomes de cidades.
2. Adicione 3 cidades usando `Add`.
3. Remova uma cidade específica.
4. Ordene a lista em ordem alfabética.
5. Exiba as cidades usando `foreach`.

**Solução**:
```csharp
List<string> cidades = new List<string>();
cidades.Add("São Paulo");
cidades.Add("Rio de Janeiro");
cidades.Add("Belo Horizonte");

cidades.Remove("Rio de Janeiro");
cidades.Sort();

foreach (string cidade in cidades)
{
    Console.WriteLine(cidade); // Saída: Belo Horizonte, São Paulo
}
```

---

#### **8. Quando usar Listas?**
- Use `List<T>` quando precisar de uma coleção dinâmica que permite adicionar, remover ou acessar elementos por índice.
- Para coleções fixas, considere arrays (`T[]`).
- Para outras necessidades, explore coleções como `Dictionary<TKey, TValue>` (para pares chave-valor) ou `HashSet<T>` (para conjuntos únicos).

---

#### **9. Resumo dos Principais Métodos**
| Método         | Descrição                                    |
|----------------|----------------------------------------------|
| `Add`          | Adiciona um elemento ao final da lista.      |
| `AddRange`     | Adiciona múltiplos elementos.                |
| `Remove`       | Remove a primeira ocorrência de um item.     |
| `RemoveAt`     | Remove o elemento no índice especificado.    |
| `Clear`        | Remove todos os elementos.                   |
| `Contains`     | Verifica se um item está na lista.           |
| `Find`         | Busca um elemento com base em uma condição.  |
| `Sort`         | Ordena a lista.                              |
| `Reverse`      | Inverte a ordem dos elementos.               |
| `Count`        | Retorna o número de elementos.               |

