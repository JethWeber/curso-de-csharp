
# Fundamentos Da Linguagem C#


## **Aula 15 — Estruturas de Repetição: Laço `foreach`**

Nas aulas anteriores, vimos os laços `while` e `for`. O laço `while` é ideal para condições, e o `for` para contagens. Agora, vamos conhecer o laço `foreach`, que é a ferramenta perfeita para **percorrer coleções de dados**, como listas e arrays.

-----

### **1. O que é o Laço `foreach`?**

O laço `foreach` (em português, "para cada") é uma estrutura de repetição feita sob medida para iterar sobre todos os elementos de uma coleção, sem a necessidade de um contador manual. Ele automaticamente visita cada item, um por um, do início ao fim.

> 🧠 **Pense assim:**
>
>   * `Para cada` livro na prateleira, leia o título.
>   * `Para cada` número na lista, imprima o valor.

Ele simplifica o código e evita erros comuns, como ir além dos limites da coleção.

-----

### **2. A Estrutura do `foreach`**

A sintaxe é simples e muito intuitiva:

```csharp
foreach (tipoDeItem nomeDaVariavel in colecao)
{
    // Código a ser executado para cada item
}
```

  * **`tipoDeItem`:** O tipo de dado que cada item da coleção possui (ex.: `int`, `string`, `double`).
  * **`nomeDaVariavel`:** Um nome temporário para a variável que irá "segurar" o item atual do laço. Você pode escolher qualquer nome que seja descritivo (ex.: `numero`, `nome`, `item`).
  * **`in colecao`:** A coleção sobre a qual você irá iterar (ex.: `lista_numerica`, `nomesDosAlunos`).

-----

### **3. Exemplo Prático: Percorrendo uma Lista**

O seu exemplo é perfeito para ilustrar o uso do `foreach`. Vamos aprofundar na explicação do código.

```csharp
using System;
using System.Collections.Generic; // Para usar a classe List

public class Program
{
    public static void Main()
    {
        // 1. Criamos uma lista de números inteiros
        List<int> listaNumerica = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

        Console.WriteLine("Percorrendo a lista com 'foreach':");

        // 2. O laço 'foreach' irá passar por cada item da lista, um por um
        foreach (int numero in listaNumerica)
        {
            // 'numero' é a variável temporária que recebe o valor atual
            Console.WriteLine($"O item atual é: {numero}");
        }
    }
}
```

**Análise do Código:**

  * `using System.Collections.Generic;`: Esta linha é necessária para podermos usar a classe `List<T>`, que é o tipo de coleção mais comum em C\#.
  * `List<int> listaNumerica...`: Aqui, estamos criando uma nova lista chamada `listaNumerica` que só pode guardar valores do tipo `int`.
  * `foreach (int numero in listaNumerica)`:
      * O laço começa. Na primeira rodada, `numero` recebe o valor `1`.
      * Na segunda rodada, `numero` recebe o valor `2`.
      * O laço continua até que todos os itens tenham sido visitados.
      * Quando chega ao fim da lista (após o `8`), o laço termina automaticamente.

-----

### **4. `foreach` vs. `for`**

| Característica | Laço `foreach` | Laço `for` |
| :--- | :--- | :--- |
| **Uso Ideal** | Iterar sobre todos os itens de uma coleção, **do início ao fim**. | Quando você precisa de um **contador**, de acesso por índice ou de iterações em ordem não sequencial. |
| **Acesso a itens** | Acesso direto ao valor do item (`numero`). | Acesso por índice (`lista[i]`). |
| **Simplicidade** | Geralmente mais simples e mais seguro, pois não exige um contador. | Mais flexível, mas exige um controle manual do contador, podendo causar erros. |

-----

### **5. Resumo da Aula**

  * **Laço `foreach`:** A melhor opção para percorrer todos os itens de uma coleção.
  * **Sintaxe:** `foreach (tipo item in colecao)`.
  * **Vantagens:** Mais seguro, mais simples e mais legível para a maioria dos casos de iteração sobre coleções.

-----

### **6. Exercício Prático**

Crie um programa que calcula a média de notas de uma lista de alunos.

1.  Crie uma `List<double>` com pelo menos 5 notas.
2.  Crie uma variável `double soma = 0;`.
3.  Use um laço `foreach` para somar todas as notas da lista na variável `soma`.
4.  Após o laço, calcule a média dividindo a `soma` pelo número total de notas (`lista.Count`).
5.  Exiba a média final na tela.
