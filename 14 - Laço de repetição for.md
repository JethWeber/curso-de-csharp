
# Fundamentos Da Linguagem C#

## **Aula 14 — Estruturas de Repetição: Laço `for`**

Nas últimas aulas, aprendemos sobre os laços `while` e `do-while`, que são ideais para repetir um código um número incerto de vezes. Agora, vamos conhecer o laço `for`, que é perfeito para situações em que você sabe exatamente quantas vezes precisa repetir uma tarefa.

-----

### **1. O que é o Laço `for`?**

O laço `for` é uma estrutura de repetição que condensa três partes importantes em uma única linha, tornando o código mais organizado e fácil de ler quando a repetição é baseada em um contador.

> 🧠 **Pense assim:**
>
>   * `Para` cada número de 1 a 10, imprima a mensagem.
>   * `Para` cada item na lista de compras, pegue o item.

-----

### **2. A Estrutura do `for`**

A sintaxe do `for` é composta por três partes dentro dos parênteses, separadas por ponto e vírgula `;`:

```csharp
for ( inicialização ; condição ; iterador )
{
    // Código a ser repetido
}
```

  * **1. `inicialização`:** (Executada apenas uma vez, no início)

      * É aqui que você declara e inicializa a variável de controle do laço (o "contador"). Exemplo: `int i = 0;`.

  * **2. `condição`:** (Verificada antes de cada repetição)

      * O laço continua a ser executado enquanto esta condição for `true`. Exemplo: `i < 10;`.

  * **3. `iterador`:** (Executado no final de cada repetição)

      * É aqui que você atualiza a variável de controle, geralmente com `++` ou `--`. Exemplo: `i++;`.

-----

### **3. Exemplo Prático: Contando até 10**

Vamos usar o seu exemplo e adicionar os detalhes para torná-lo mais claro.

```csharp
using System;

public class Program
{
    public static void Main()
    {
        // O laço for é perfeito para contagens
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine("O valor de i é: " + i);
        }

        Console.WriteLine("\nLaço de contagem concluído!");

        // Exemplo de contagem regressiva
        Console.WriteLine("\nContagem regressiva:");
        for (int j = 5; j > 0; j--)
        {
            Console.WriteLine(j);
        }
        Console.WriteLine("Decolar!");
    }
}
```

**Análise do Código:**

  * **Primeiro `for`:**

      * `int i = 1;` - Declara e inicializa o contador `i` com o valor 1.
      * `i <= 10;` - A condição é verificada. O laço roda enquanto `i` for menor ou igual a 10.
      * `i++` - Incrementa `i` em 1 a cada repetição.

  * **Segundo `for`:**

      * `int j = 5;` - O contador começa em 5.
      * `j > 0;` - O laço roda enquanto `j` for maior que 0.
      * `j--` - Decrementa `j` em 1 a cada repetição, fazendo a contagem regressiva.

-----

### **4. `for` vs. `while`**

| Característica | Laço `for` | Laço `while` |
| :--- | :--- | :--- |
| **Uso Ideal** | Quando o número de repetições é **conhecido**. | Quando o número de repetições é **desconhecido** (baseado em uma condição). |
| **Sintaxe** | **Compacta** e organizada (inicialização, condição, iteração na mesma linha). | **Flexível**. A inicialização e o iterador ficam fora da condição, em linhas separadas. |
| **Exemplo** | Imprimir números de 1 a 10. | Pedir uma senha até que esteja correta. |

-----

### **5. Resumo da Aula**

  * **Laço `for`:** Ideal para repetições controladas por um contador.
  * **Sintaxe:** `for (declaração; condição; atualização)`.
  * **Fluxo:** O contador é inicializado uma vez, a condição é verificada a cada rodada, e o contador é atualizado no final de cada rodada.

-----

### **6. Exercício Prático**

Crie um programa que calcula a soma de todos os números de 1 a 100.

1.  Declare uma variável `int soma = 0;`.
2.  Use um laço `for` para percorrer os números de 1 a 100.
3.  Dentro do laço, adicione o número atual à variável `soma` (use o operador `+=`).
4.  Após o laço, exiba o resultado final. O valor esperado é `5050`.
