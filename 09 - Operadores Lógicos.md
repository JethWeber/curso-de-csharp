
# Fundamentos Da Linguagem C#


## **Aula 09 — Operadores Lógicos**

Até agora, aprendemos a fazer uma única verificação em um `if`. Mas e se precisarmos de mais de uma condição? Por exemplo, "Se a idade for maior que 18 **E** a senha estiver correta"? Para isso, usamos os **operadores lógicos**, que nos permitem combinar múltiplas condições para tomar decisões mais complexas.

-----

### **1. Os Três Operadores Lógicos Principais**

Os operadores lógicos trabalham com valores `bool` (`true` ou `false`) e retornam um novo valor `bool` como resultado.

| Operador | Nome | Exemplo | Descrição |
| :--- | :--- | :--- | :--- |
| `&&` | **E (AND)** | `cond1 && cond2` | Retorna `true` apenas se **ambas** as condições forem verdadeiras. |
|  `II` | **OU (OR)** | `cond1 II cond2` | Retorna `true` se **pelo menos uma** das condições for verdadeira. |
| `!` | **NÃO (NOT)** | `!cond1` | Nega o valor, transformando `true` em `false` e `false` em `true`. |

-----

### **2. Exemplos Práticos**

Vamos usar as variáveis `x` e `y` do seu exemplo para entender como cada operador funciona.

```csharp
int x = 12;
int y = 20;

// Operador AND (&&)
// Condição: 'x é igual a 10 E y é igual a 20?'
// (12 == 10)  && (20 == 20)
//  false      &&   true       -> O resultado é false
Console.WriteLine(x == 10 && y == 20); // Saída: False

// Operador OR (||)
// Condição: 'y é igual a 10 OU y é igual a 20?'
// (20 == 10)  || (20 == 20)
//  false      ||   true      -> O resultado é true
Console.WriteLine(y == 10 || y == 20); // Saída: True

// Operador NOT (!)
// Condição: 'NÃO (y é igual a x)?'
// !(20 == 12)
// !(false)   -> O resultado é true
Console.WriteLine(!(y == x)); // Saída: True
```

-----

### **3. Combinando Lógica com `if-else`**

É na combinação com as estruturas condicionais que os operadores lógicos se tornam poderosos. Eles nos permitem criar regras mais complexas.

**Exemplo: Verificando um login**

```csharp
using System;

public class Program
{
    public static void Main()
    {
        string nomeUsuario = "admin";
        string senha = "123";

        Console.WriteLine("Bem-vindo ao sistema de login.");
        Console.Write("Digite o nome de usuário: ");
        string entradaUsuario = Console.ReadLine();
        
        Console.Write("Digite a senha: ");
        string entradaSenha = Console.ReadLine();

        // A condição combina duas verificações com o operador &&
        if (entradaUsuario == nomeUsuario && entradaSenha == senha)
        {
            Console.WriteLine("Acesso concedido. Bem-vindo, " + entradaUsuario + "!");
        }
        else
        {
            Console.WriteLine("Usuário ou senha incorretos.");
        }
    }
}
```

-----

### **4. Resumo da Aula**

  * **Operadores Lógicos:** Permitem combinar e inverter condições.
  * **`&&` (AND):** Exige que todas as condições sejam verdadeiras.
  * **`||` (OR):** Exige que pelo menos uma condição seja verdadeira.
  * **`!` (NOT):** Nega o resultado de uma condição.
  * **Uso Prático:** São essenciais para criar regras complexas em estruturas como `if` e `while`.

-----

### **5. Exercício Prático**

Crie um programa que verifica se um aluno foi aprovado em uma disciplina.

1.  Peça ao usuário para digitar a nota final do aluno e a sua frequência (em porcentagem).
2.  Armazene os valores em variáveis `double` para a nota e `int` para a frequência.
3.  Use um `if-else` com o operador lógico `&&` para verificar se:
      * `nota >= 7.0` **E** `frequencia >= 75`
4.  Exiba uma mensagem informando se o aluno foi "Aprovado" ou "Reprovado".
5.  Desafio extra: Use `Console.WriteLine` e `||` para exibir uma mensagem adicional se a nota for menor que 7 **OU** a frequência for menor que 75.
