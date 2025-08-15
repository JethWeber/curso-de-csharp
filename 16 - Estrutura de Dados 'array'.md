
# Fundamentos Da Linguagem C#

## **Aula 16 — Coleções: Arrays**

Até agora, aprendemos a guardar valores em variáveis individuais. Mas e se quisermos guardar vários valores do mesmo tipo, como as notas de uma turma ou uma lista de nomes? Para isso, usamos as **coleções**, e a mais fundamental delas é o **Array**.

-----

### **1. O que é um Array?**

Um **Array** é uma estrutura de dados que armazena uma **coleção de elementos do mesmo tipo** em posições sequenciais na memória. Pense nele como uma "gaveta" com um número fixo de "compartimentos", onde cada compartimento pode guardar um valor.

**Características principais:**

  * **Tamanho Fixo:** O tamanho de um array é definido na criação e não pode ser alterado.
  * **Índices:** Cada elemento tem uma posição numerada, começando do zero (`0`).

> 🧠 **Exemplo:** Um array de 3 notas `[7.5, 8.0, 9.5]`.
>
>   * A nota `7.5` está no índice `0`.
>   * A nota `8.0` está no índice `1`.
>   * A nota `9.5` está no índice `2`.

-----

### **2. Criando um Array**

Existem duas formas principais de criar um array:

#### **Método 1: Declarando o tamanho e adicionando os valores depois**

```csharp
// Cria um array de 3 inteiros, que começa com valores padrão (zero)
int[] numeros = new int[3];

// Atribuindo valores a cada posição
numeros[0] = 10;
numeros[1] = 20;
numeros[2] = 30;
```

  * `int[]`: Declara que o array irá guardar valores do tipo `int`.
  * `new int[3]`: Cria um novo array com 3 posições.

#### **Método 2: Declarando com valores iniciais**

```csharp
// Cria e inicializa um array de strings com 3 elementos
string[] frutas = new string[] { "Maçã", "Banana", "Laranja" };
```

  * Aqui, o C\# infere que o tamanho do array é 3, com base no número de elementos fornecidos.

-----

### **3. Acessando e Modificando Elementos**

Para acessar ou modificar um elemento, você usa o nome do array seguido do índice entre colchetes `[]`.

```csharp
string[] frutas = new string[] { "Maçã", "Banana", "Laranja" };

// Acessando um elemento
Console.WriteLine("Primeira fruta: " + frutas[0]); // Saída: Maçã

// Modificando um elemento
frutas[1] = "Manga"; // O segundo elemento agora é "Manga"
Console.WriteLine("Nova fruta na posição 1: " + frutas[1]); // Saída: Manga
```

**Importante:** Tentar acessar um índice que não existe (ex: `frutas[3]` em um array de 3 elementos) resultará em um erro de `IndexOutOfRangeException`.

-----

### **4. Propriedade `Length` e Métodos Úteis**

  * **`Length`:** É a propriedade que retorna o número total de elementos no array.
  * **`Array.Sort()`:** É um método estático que ordena os elementos do array em ordem crescente (numérica ou alfabética).

<!-- end list -->

```csharp
string[] frutas = new string[] { "Laranja", "Maçã", "Banana" };

// Obtendo o tamanho
Console.WriteLine("O array tem " + frutas.Length + " elementos."); // Saída: 3

// Ordenando o array
Array.Sort(frutas);
Console.WriteLine("Primeira fruta ordenada: " + frutas[0]); // Saída: Banana
```

-----

### **5. Percorrendo um Array com Laços de Repetição**

Para processar todos os elementos de um array, você pode usar os laços `for` ou `foreach`.

#### **Usando `for` (acesso por índice)**

Perfeito quando você precisa saber a posição de cada item.

```csharp
string[] frutas = new string[] { "Maçã", "Banana", "Laranja" };

for (int i = 0; i < frutas.Length; i++)
{
    Console.WriteLine($"A fruta no índice {i} é: {frutas[i]}");
}
```

#### **Usando `foreach` (acesso por valor)**

A forma mais simples de percorrer todos os itens, sem se preocupar com os índices.

```csharp
string[] frutas = new string[] { "Maçã", "Banana", "Laranja" };

foreach (string fruta in frutas)
{
    Console.WriteLine($"A fruta é: {fruta}");
}
```

-----

### **6. Resumo da Aula**

  * **Arrays:** São coleções de tamanho fixo para guardar elementos do mesmo tipo.
  * **Criação:** Use `new tipo[tamanho]` ou `{ valores }`.
  * **Acesso:** Use o nome do array e o índice entre colchetes (`[índice]`). O índice começa em `0`.
  * **`Length`:** Propriedade que retorna o número de elementos.
  * **Laços:** Use `for` para acesso por índice e `foreach` para percorrer todos os valores.
  * **Diferença de `List`:** Arrays têm tamanho fixo, enquanto `List` tem tamanho dinâmico.

-----

### **7. Exercício Prático**

Crie um programa que:

1.  Crie um array chamado `numerosSorteados` com 5 números inteiros de sua escolha.
2.  Use um laço `foreach` para exibir cada um dos números sorteados.
3.  Use o método `Array.Sort()` para ordenar o array.
4.  Use um laço `for` para exibir os números novamente, mas agora mostrando a posição e o valor (ex: "Número na posição 0: 12").
