Beleza! Vamos criar uma aula bem didática e focada em **arrays** em C#, perfeita para quem está começando, como você pediu. Vou explicar de forma simples, passo a passo, com exemplos claros, sem tocar em tópicos avançados como LINQ ou classes personalizadas. Será como uma conversa com um amigo, te ensinando do zero o que são arrays e como usá-los. 😊

---

<xaiArtifact artifact_id="1c79eaa7-f0c5-4392-9d53-7b1d691a1462" artifact_version_id="44809c3e-29b4-4b0f-be4e-c520d0d76f96" title="AulaArrays.cs" contentType="text/csharp">

using System;

class Program
{
    static void Main()
    {
        // Aula sobre Arrays em C#
        Console.WriteLine("Bem-vindo à aula de Arrays em C#!");

        // 1. Criando um array
        // Um array de números com tamanho 3
        int[] numeros = new int[3];
        numeros[0] = 10; // Primeira posição
        numeros[1] = 20; // Segunda posição
        numeros[2] = 30; // Terceira posição

        // 2. Criando um array com valores iniciais
        string[] frutas = new string[] { "Maçã", "Banana", "Laranja" };

        // 3. Acessando elementos do array
        Console.WriteLine("Primeira fruta: " + frutas[0]); // Saída: Maçã
        Console.WriteLine("Segundo número: " + numeros[1]); // Saída: 20

        // 4. Contando elementos com Length
        Console.WriteLine("Quantas frutas? " + frutas.Length); // Saída: 3

        // 5. Percorrendo o array com for
        Console.WriteLine("Lista de frutas:");
        for (int i = 0; i < frutas.Length; i++)
        {
            Console.WriteLine("Fruta " + i + ": " + frutas[i]);
        }

        // 6. Percorrendo o array com foreach
        Console.WriteLine("Números no array:");
        foreach (int numero in numeros)
        {
            Console.WriteLine("Número: " + numero);
        }

        // 7. Modificando um elemento
        frutas[1] = "Manga"; // Substitui "Banana" por "Manga"
        Console.WriteLine("Nova fruta na posição 1: " + frutas[1]); // Saída: Manga

        // 8. Ordenando o array
        Array.Sort(frutas);
        Console.WriteLine("Frutas em ordem alfabética:");
        foreach (string fruta in frutas)
        {
            Console.WriteLine(fruta);
        }

        // 9. Exercício prático
        Console.WriteLine("\nExercício: Trabalhando com array de notas");
        double[] notas = new double[] { 7.5, 8.0, 6.5, 9.0 };
        Console.WriteLine("Notas dos alunos:");
        for (int i = 0; i < notas.Length; i++)
        {
            Console.WriteLine("Aluno " + (i + 1) + ": " + notas[i]);
        }
        // Ordenando as notas
        Array.Sort(notas);
        Console.WriteLine("Notas em ordem crescente:");
        foreach (double nota in notas)
        {
            Console.WriteLine(nota);
        }
    }
}

</xaiArtifact>

---

### **Aula: Arrays em C# para Iniciantes**

#### **O que é um array?**
Um **array** em C# é como uma prateleira com gavetas numeradas, onde cada gaveta guarda uma coisa (um número, uma palavra, etc.). O importante é que:
- O **tamanho** do array é fixo: se você criar um array com 3 gavetas, ele sempre terá 3 gavetas.
- Todas as gavetas guardam o mesmo tipo de coisa (ex.: só números ou só palavras).
- Cada gaveta tem um número (índice), começando do 0.

Por exemplo:
- Um array de 3 números: `[10, 20, 30]`
- Um array de 4 palavras: `["Maçã", "Banana", "Laranja", "Manga"]`

---

#### **1. Como criar um array?**
Para criar um array, você precisa dizer:
- Qual é o tipo de dado (ex.: `int` para números, `string` para palavras).
- Quantos espaços (gavetas) ele terá.

**Exemplo 1: Criando um array vazio**
```csharp
int[] numeros = new int[3]; // Cria um array com 3 espaços para números
numeros[0] = 10; // Coloca 10 na primeira gaveta
numeros[1] = 20; // Coloca 20 na segunda gaveta
numeros[2] = 30; // Coloca 30 na terceira gaveta
```

- `int[]` diz que o array guarda números inteiros.
- `new int[3]` cria 3 espaços (inicialmente com valor 0).
- Você coloca valores usando os índices: `numeros[0]`, `numeros[1]`, etc.

**Exemplo 2: Criando um array com valores iniciais**
```csharp
string[] frutas = new string[] { "Maçã", "Banana", "Laranja" };
```

- Aqui, criamos um array com 3 palavras já definidas.
- Não precisamos dizer o tamanho, porque o C# conta os itens dentro de `{}`.

---

#### **2. Acessando itens no array**
Cada item no array tem uma posição (índice), começando do 0. Para acessar, use o nome do array e o índice entre colchetes `[ ]`.

**Exemplo:**
```csharp
string[] frutas = new string[] { "Maçã", "Banana", "Laranja" };
Console.WriteLine(frutas[0]); // Mostra: Maçã
Console.WriteLine(frutas[2]); // Mostra: Laranja
```

- `frutas[0]` é o primeiro item, `frutas[1]` é o segundo, e assim por diante.

**Cuidado**: Se tentar acessar um índice que não existe (ex.: `frutas[3]` em um array de 3 itens), vai dar erro (`IndexOutOfRangeException`).

---

#### **3. Quantos itens tem no array?**
Para saber o tamanho do array, use a propriedade `Length`. É como contar quantas gavetas a prateleira tem.

**Exemplo:**
```csharp
string[] frutas = new string[] { "Maçã", "Banana", "Laranja" };
Console.WriteLine("Quantas frutas? " + frutas.Length); // Mostra: 3
```

---

#### **4. Percorrendo o array**
Às vezes, você quer olhar cada item do array. Existem duas formas principais: usando `for` ou `foreach`.

**Usando `for`:**
```csharp
string[] frutas = new string[] { "Maçã", "Banana", "Laranja" };
for (int i = 0; i < frutas.Length; i++)
{
    Console.WriteLine("Fruta na posição " + i + ": " + frutas[i]);
}
```

**Saída:**
```
Fruta na posição 0: Maçã
Fruta na posição 1: Banana
Fruta na posição 2: Laranja
```

- O `for` é bom quando você precisa saber o índice de cada item.

**Usando `foreach`:**
```csharp
string[] frutas = new string[] { "Maçã", "Banana", "Laranja" };
foreach (string fruta in frutas)
{
    Console.WriteLine("Fruta: " + fruta);
}
```

**Saída:**
```
Fruta: Maçã
Fruta: Banana
Fruta: Laranja
```

- O `foreach` é mais simples quando você só quer os valores, sem se preocupar com os índices.

---

#### **5. Modificando itens no array**
Você pode mudar o valor de uma gaveta (posição) do array usando o índice.

**Exemplo:**
```csharp
string[] frutas = new string[] { "Maçã", "Banana", "Laranja" };
frutas[1] = "Manga"; // Substitui "Banana" por "Manga"
Console.WriteLine(frutas[1]); // Mostra: Manga
```

- Só dá pra mudar o valor, não o tamanho do array. Você não pode adicionar ou remover gavetas.

---

#### **6. Ordenando o array**
Para colocar os itens em ordem (alfabética para palavras ou numérica para números), use o método `Array.Sort`.

**Exemplo:**
```csharp
string[] frutas = new string[] { "Laranja", "Maçã", "Banana" };
Array.Sort(frutas); // Coloca em ordem alfabética
foreach (string fruta in frutas)
{
    Console.WriteLine(fruta);
}
```

**Saída:**
```
Banana
Laranja
Maçã
```

**Outro exemplo com números:**
```csharp
int[] numeros = new int[] { 30, 10, 20 };
Array.Sort(numeros); // Coloca em ordem numérica
foreach (int numero in numeros)
{
    Console.WriteLine(numero);
}
```

**Saída:**
```
10
20
30
```

- Para usar `Array.Sort`, você precisa da linha `using System;` no topo do código.

---

#### **7. Diferença entre arrays e listas**
Você já viu listas na aula anterior, então vamos comparar:
- **Arrays**: Tamanho fixo (não cresce nem diminui). Ex.: `int[] numeros = new int[3];`
- **Listas**: Tamanho dinâmico (você pode adicionar ou remover itens). Ex.: `List<int> numeros = new List<int>();`
- Use arrays quando souber exatamente quantos itens vai precisar e não for mudar o tamanho.

---

#### **8. Exercício prático**
Crie um programa que:
1. Crie um array de 4 notas (ex.: 7.5, 8.0, 6.5, 9.0).
2. Mostre todas as notas usando `foreach`.
3. Ordene as notas em ordem crescente.
4. Mostre as notas ordenadas.

**Solução (já incluída no código acima, mas vamos destacar):**
```csharp
double[] notas = new double[] { 7.5, 8.0, 6.5, 9.0 };
Console.WriteLine("Notas dos alunos:");
foreach (double nota in notas)
{
    Console.WriteLine(nota);
}
Array.Sort(notas);
Console.WriteLine("Notas em ordem crescente:");
foreach (double nota in notas)
{
    Console.WriteLine(nota);
}
```

**Saída:**
```
Notas dos alunos:
7.5
8
6.5
9
Notas em ordem crescente:
6.5
7.5
8
9
```

---

#### **9. Dicas importantes**
- **Tamanho fixo**: Você não pode adicionar ou remover itens de um array. Se precisar disso, use uma `List<T>` (como vimos na aula anterior).
- **Cuidado com índices**: Sempre use índices entre 0 e `Length - 1`. Por exemplo, em um array de 3 itens, os índices válidos são 0, 1 e 2.
- **Pratique**: Tente criar arrays com números, palavras ou outros tipos (como `double` para notas) e brincar com `for`, `foreach` e `Array.Sort`.

---

#### **10. Resumo dos comandos**
- `new tipo[tamanho]`: Cria um array com um tamanho fixo.
- `array[índice]`: Acessa ou modifica um item.
- `Length`: Diz quantos itens o array tem.
- `Array.Sort(array)`: Coloca o array em ordem.
- `for` e `foreach`: Usados para percorrer o array.
