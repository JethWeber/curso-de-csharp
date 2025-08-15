
# Fundamentos Da Linguagem C#


## **Aula 08 — Operadores Relacionais**

Na aula anterior, usamos operadores de comparação para decidir se um usuário era maior ou menor de idade. Esses símbolos são chamados de **operadores relacionais**, pois eles verificam a **relação** entre dois valores e retornam sempre um valor `bool` (`true` ou `false`). Eles são a base de todas as tomadas de decisão nos seus programas.

-----

### **1. Conhecendo os Operadores Relacionais**

| Operador | Significado | Exemplo | Resultado |
| :--- | :--- | :--- | :--- |
| `==` | **Igual a** | `5 == 5` | `true` |
| `!=` | **Diferente de** | `10 != 5` | `true` |
| `>` | **Maior que** | `8 > 4` | `true` |
| `<` | **Menor que** | `2 < 7` | `true` |
| `>=` | **Maior ou igual a** | `5 >= 5` | `true` |
| `<=` | **Menor ou igual a** | `5 <= 5` | `true` |

-----

### **2. O Exemplo na Prática: Verificando a Idade**

O código a seguir é um exemplo clássico de como usar operadores relacionais para tomar decisões. Ele pede a idade do usuário e, com base nela, mostra uma mensagem.

```csharp
using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Digite a sua idade: ");
        string entrada = Console.ReadLine();

        // Tenta converter a entrada para um número inteiro.
        if (int.TryParse(entrada, out int idade))
        {
            // A conversão foi bem-sucedida. Agora, vamos verificar a idade.
            if (idade >= 18)
            {
                Console.WriteLine("Você é maior de idade!");
            }
            else if (idade >= 12)
            {
                Console.WriteLine("Você é um adolescente.");
            }
            else if (idade >= 6)
            {
                Console.WriteLine("Você não é mais uma criança.");
            }
            else
            {
                Console.WriteLine("Você é um bebê!");
            }
        }
        else
        {
            // A conversão falhou.
            Console.WriteLine("Entrada inválida. Por favor, digite um número.");
        }
    }
}
```

**Análise do Código:**

  * **Fluxo de Decisão:** A estrutura `if-else if` verifica as condições em ordem. Se uma condição for verdadeira, o código daquele bloco é executado, e o resto da estrutura é ignorado. Por isso, é importante organizar as condições para que as mais específicas venham primeiro. No nosso caso, verificamos do `maior ou igual a 18` até o `menor que 6` (que é o que sobra no `else`).
  * **Sintaxe correta:** No exemplo, substituímos o `!==` (que não existe em C\#) e usamos uma estrutura `if-else if` mais organizada e fácil de ler.

-----

### **3. Resumo da Aula**

  * **Operadores Relacionais:** São a base das tomadas de decisão e retornam sempre um valor `true` ou `false`.
  * **Símbolos:** Os principais são `==` (igualdade), `!=` (diferença), `>`, `<`, `>=`, `<=` (maior/menor).
  * **Estrutura de Decisão:** As condições são usadas dentro de estruturas como `if` e `if-else if` para controlar o fluxo do programa.
  * **Organização:** É crucial organizar a ordem das condições para que seu programa funcione corretamente e evite erros lógicos.

-----

### **4. Exercício Prático**

Crie um programa que verifica se um número é positivo, negativo ou zero.

1.  Peça ao usuário para digitar um número inteiro.
2.  Use `int.TryParse()` para guardar o valor na variável `numero`.
3.  Crie uma estrutura `if-else if-else` para:
      * Verificar se o número é maior que zero (`> 0`).
      * Verificar se o número é menor que zero (`< 0`).
      * Caso nenhuma das condições acima seja verdadeira, o número deve ser zero, então use um `else`.
4.  Exiba uma mensagem apropriada para cada caso.
