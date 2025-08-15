
# Fundamentos Da Linguagem C#


## **Aula 06 — Estruturas Condicionais (`if` e `else`)**

Bem-vindo à nossa sexta aula\! Até agora, nossos programas executaram as instruções linha por linha, de cima para baixo. Mas na vida real, precisamos tomar decisões. É aí que entram as **estruturas condicionais**, que permitem que seu código escolha qual caminho seguir.

-----

### **1. O que é uma Estrutura Condicional?**

Uma estrutura condicional, como o `if-else`, é como uma encruzilhada no seu código. Ela verifica se uma condição é verdadeira ou falsa e, com base nisso, executa um bloco de código específico.

> 🧠 **Pense assim:**
>
>   * `Se` chover (`if`), `então` eu levo um guarda-chuva.
>   * `Senão` (`else`), eu saio sem ele.

-----

### **2. A Estrutura `if` e `else`**

A sintaxe básica em C\# é a seguinte:

```csharp
if (condição)
{
    // Este bloco de código é executado se a condição for verdadeira.
}
else
{
    // Este bloco de código é executado se a condição for falsa.
}
```

  * **`if`:** É a palavra-chave que inicia a verificação.
  * **`(condição)`:** É a expressão que será avaliada. O resultado deve ser sempre um `bool` (verdadeiro ou falso).
  * **`{ }`:** As chaves delimitam um "bloco de código". Todo o código dentro das chaves pertence a essa estrutura condicional.

**Observação importante:** Se houver apenas uma linha de código a ser executada dentro do `if` ou `else`, as chaves são opcionais. No entanto, é uma boa prática sempre usá-las para evitar erros e manter o código mais legível.

-----

### **3. Operadores de Comparação**

Para criar as condições, usamos os **operadores de comparação**. Eles comparam dois valores e retornam `true` (verdadeiro) ou `false` (falso).

| Operador | Significado | Exemplo | Retorno |
| :--- | :--- | :--- | :--- |
| `==` | Igual a | `idade == 18` | `true` se `idade` for 18 |
| `!=` | Diferente de | `nome != "Maria"` | `true` se `nome` não for "Maria" |
| `>` | Maior que | `nota > 7` | `true` se `nota` for maior que 7 |
| `<` | Menor que | `altura < 1.70` | `true` se `altura` for menor que 1.70 |
| `>=` | Maior ou igual a | `idade >= 18` | `true` se `idade` for 18 ou mais |
| `<=` | Menor ou igual a | `nota <= 5` | `true` se `nota` for 5 ou menos |

-----

### **4. Exemplo Prático: Verificando a Idade**

Vamos criar um programa que verifica se uma pessoa é maior de idade.

```csharp
using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Digite sua idade: ");
        string entradaIdade = Console.ReadLine();

        // Tenta converter a entrada para um número inteiro.
        if (int.TryParse(entradaIdade, out int idade))
        {
            // A conversão deu certo. Agora, vamos tomar a decisão.
            if (idade >= 18)
            {
                Console.WriteLine("Você é maior de idade!");
            }
            else
            {
                Console.WriteLine("Você é menor de idade!");
            }
        }
        else
        {
            // A conversão falhou.
            Console.WriteLine("Idade inválida. Por favor, digite um número.");
        }
    }
}
```

**Análise do Código:**

  * Usamos `int.TryParse()` para garantir que a entrada é um número. Se for, a variável `idade` é criada e a condição do primeiro `if` é `true`.
  * O segundo `if` verifica a condição `idade >= 18`. Se for verdadeira, a primeira mensagem é exibida. Se for falsa, a segunda mensagem, no bloco `else`, é exibida.
  * Se a conversão inicial falhar, o primeiro `if` será `false` e o `else` dele será executado, exibindo a mensagem de erro.

-----

### **5. Resumo da Aula**

  * **`if`:** Permite que seu código tome decisões.
  * **`else`:** Executa um bloco de código caso a condição do `if` seja falsa.
  * **Condição:** É uma expressão que retorna `true` ou `false`, geralmente usando operadores de comparação (`==`, `!=`, `>`, `<`, `>=`, `<=`).
  * **Estrutura:** `if (condição) { ... } else { ... }`.

-----

### **6. Exercício Prático**

Crie um programa que:

1.  Pede ao usuário para digitar uma senha.
2.  Armazena a senha em uma variável `string`.
3.  Usa uma estrutura `if-else` para verificar se a senha digitada é igual a `"1234"`.
4.  Se a senha estiver correta, exibe a mensagem "Acesso permitido\!".
5.  Se a senha estiver incorreta, exibe a mensagem "Acesso negado\!".
