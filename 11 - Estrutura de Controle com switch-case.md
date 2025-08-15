
# Fundamentos Da Linguagem C#

## **Aula 11 — Estrutura Condicional `switch`**

Na última aula, vimos como o `if-else if` nos permite tomar decisões. Mas e se a decisão depende de uma única variável que pode ter muitos valores possíveis, como os dias da semana ou as opções de um menu? Para esses casos, o C\# oferece uma ferramenta mais limpa e organizada: a estrutura **`switch`**.

-----

### **1. O que é o `switch`?**

O `switch` é uma estrutura de controle que testa o valor de uma variável em relação a uma lista de valores possíveis. É uma alternativa mais elegante para uma longa sequência de `if-else if`.

> 🧠 **Pense assim:**
>
>   * `Escolha` um dia da semana.
>   * `No caso` de ser 1, chame-o de Domingo.
>   * `No caso` de ser 2, chame-o de Segunda.
>   * `No caso` de nenhum valor ser encontrado, chame-o de "Inválido".

-----

### **2. A Estrutura `switch`**

A sintaxe básica é a seguinte:

```csharp
switch (variavel)
{
    case valor1:
        // Código a ser executado se variavel for igual a valor1
        break;
    case valor2:
        // Código a ser executado se variavel for igual a valor2
        break;
    default:
        // Código a ser executado se nenhum caso for correspondido
        break;
}
```

  * **`switch`:** A palavra-chave que inicia a estrutura. A variável entre parênteses é a que será comparada.
  * **`case`:** Define um possível valor para a variável. O código abaixo do `case` é executado se o valor corresponder.
  * **`break`:** É **obrigatório** no final de cada `case` em C\#. Ele serve para "quebrar" a execução e sair da estrutura `switch`. Sem ele, o código continuaria a ser executado nos próximos `case`s.
  * **`default`:** É opcional e funciona como um `else`. O código dentro do `default` é executado se nenhum `case` corresponder ao valor da variável.

-----

### **3. Exemplo Prático: Dias da Semana**

Vamos refazer o seu exemplo, adicionando a segurança do `TryParse` que aprendemos nas aulas anteriores, para garantir que o programa não dê erro se o usuário digitar algo que não seja um número.

```csharp
using System;

public class Program
{
    public static void Main()
    {
        Console.Clear(); // Limpa a tela do console

        Console.Write("De 1 a 7, digite um número para o dia da semana: ");
        string entrada = Console.ReadLine();
        
        string diaSemana;

        // Tenta converter a entrada para um número inteiro.
        if (int.TryParse(entrada, out int dia))
        {
            switch (dia)
            {
                case 1:
                    diaSemana = "Domingo";
                    break;
                case 2:
                    diaSemana = "Segunda-feira";
                    break;
                case 3:
                    diaSemana = "Terça-feira";
                    break;
                case 4:
                    diaSemana = "Quarta-feira";
                    break;
                case 5:
                    diaSemana = "Quinta-feira";
                    break;
                case 6:
                    diaSemana = "Sexta-feira";
                    break;
                case 7:
                    diaSemana = "Sábado";
                    break;
                default:
                    diaSemana = "Dia inválido!";
                    break;
            }
        }
        else
        {
            diaSemana = "Entrada inválida. Por favor, digite um número.";
        }
        
        Console.WriteLine("\nO dia correspondente é: " + diaSemana);
    }
}
```

**Por que usar `switch` aqui?**

  * **Código mais limpo:** Fica muito mais fácil de ler do que uma sequência de `if (dia == 1) else if (dia == 2) ...`.
  * **Clareza:** Fica óbvio que o programa está verificando múltiplos valores possíveis para a variável `dia`.

-----

### **4. Resumo da Aula**

  * **`switch`:** Uma alternativa ao `if-else if` para testar uma variável contra múltiplos valores.
  * **`case`:** Define cada valor possível.
  * **`break`:** Interrompe a execução do `switch` após um `case` ser encontrado. É essencial em C\#\!
  * **`default`:** Opcional, executa se nenhum `case` for correspondido.

-----

### **5. Exercício Prático**

Crie um programa que exibe uma mensagem de saudação com base na hora do dia.

1.  Peça ao usuário para digitar a hora do dia (de 0 a 23).
2.  Use um `switch` para exibir:
      * "Bom dia\!" para horas entre 6 e 11 (você pode usar um `case` para cada número, como `case 6: case 7: ...`).
      * "Boa tarde\!" para horas entre 12 e 18.
      * "Boa noite\!" para horas entre 19 e 23.
      * "Boa madrugada\!" para horas entre 0 e 5.
      * "Hora inválida\!" para qualquer outro valor.
