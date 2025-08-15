
# Fundamentos Da Linguagem C#

## **Aula 12 — Estruturas de Repetição: Laço `while`**

Até agora, nossos programas executam comandos uma única vez. Mas e se precisarmos repetir a mesma tarefa várias vezes, como imprimir uma mensagem 100 vezes ou continuar pedindo uma senha até que ela esteja correta? Para isso, usamos os **laços de repetição** (ou *loops*). O primeiro que vamos aprender é o `while`.

-----

### **1. O que é o Laço `while`?**

O laço `while` (em português, "enquanto") é a estrutura de repetição mais simples. Ele executa um bloco de código **enquanto** uma condição for verdadeira.

> 🧠 **Pense assim:**
>
>   * `Enquanto` a panela estiver vazia, adicione mais arroz.
>   * `Enquanto` a senha estiver incorreta, continue pedindo a senha.

O `while` verifica a condição **antes** de cada repetição. Se a condição começar como falsa, o bloco de código nunca será executado.

-----

### **2. A Estrutura do `while`**

A sintaxe é bem direta e se parece com o `if` que já conhecemos:

```csharp
while (condição)
{
    // Este bloco de código será repetido
    // enquanto a condição for verdadeira.
}
```

**ATENÇÃO:** É crucial que algo dentro do laço mude a condição para `false` em algum momento, senão o programa entrará em um "laço infinito" e nunca parará de executar.

-----

### **3. Exemplo Simples: Um Contador**

Vamos começar com um exemplo básico para entender o fluxo de repetição.

```csharp
int contador = 0; // O laço começa com contador = 0

while (contador < 5) // Condição: o laço continua enquanto contador for menor que 5
{
    Console.WriteLine("O valor do contador é: " + contador);
    contador++; // Esta linha incrementa o contador. É o que evita o laço infinito!
}

Console.WriteLine("O laço terminou!");
```

**Fluxo de Execução:**

1.  `contador` é 0. `0 < 5` é `true`. Entra no laço.
2.  Imprime "O valor do contador é: 0". `contador` vira 1.
3.  `contador` é 1. `1 < 5` é `true`. Repete.
4.  ...
5.  `contador` é 4. `4 < 5` é `true`. Repete.
6.  Imprime "O valor do contador é: 4". `contador` vira 5.
7.  `contador` é 5. `5 < 5` é `false`. O laço para.
8.  O programa continua, exibindo "O laço terminou\!".

-----

### **4. Exemplo Prático: Repetindo com o Usuário**

Vamos melhorar o seu exemplo, corrigindo o erro de digitação (`brek` para `break`) e usando `TryParse` para garantir uma entrada segura.

```csharp
using System;

public class Program
{
    public static void Main()
    {
        int i = 1;

        while (i != 0) // O laço continua ENQUANTO 'i' for diferente de zero
        {
            Console.Clear();
            Console.WriteLine("Olá Mundo!");
            
            Console.Write("\n\nDigite 1 para continuar e 0 para parar: ");
            string entrada = Console.ReadLine();

            // Usamos TryParse para garantir que a entrada é um número
            if (!int.TryParse(entrada, out i))
            {
                // Se a entrada for inválida, 'i' recebe 1 para continuar o laço
                i = 1; 
                Console.WriteLine("\nEntrada inválida. Por favor, digite 1 ou 0.");
                System.Threading.Thread.Sleep(2000); // Pausa por 2 segundos
            }
        }

        Console.WriteLine("\nPrograma encerrado.");
    }
}
```

**Análise das Melhorias:**

  * **Condição do `while`:** A condição `while (i != 0)` já diz tudo. O laço só para quando `i` for `0`. O `if (i == 0) break;` é redundante, pois a própria condição do laço já lida com isso.
  * **`TryParse`:** Garante que o programa não vai quebrar se o usuário digitar "abc" em vez de "1" ou "0". Se a entrada for inválida, a variável `i` não será alterada, e o programa continua pedindo a entrada correta.
  * **`System.Threading.Thread.Sleep(2000)`:** Usamos este comando para dar tempo ao usuário de ler a mensagem de erro antes que a tela seja limpa.

-----

### **5. Resumo da Aula**

  * **Laço `while`:** Repete um bloco de código enquanto a condição for `true`.
  * **Condição:** É verificada no início de cada repetição.
  * **Perigo:** Cuidado com laços infinitos\! Certifique-se de que a condição se tornará `false` em algum momento.

-----

### **6. Exercício Prático**

Crie um programa que pede a senha ao usuário e só para de pedir quando a senha for correta.

1.  Crie uma variável `senhaCorreta = "1234"`.
2.  Crie uma variável `senhaDigitada` do tipo `string`.
3.  Use um laço `while` com a condição `while (senhaDigitada != senhaCorreta)`.
4.  Dentro do laço, peça para o usuário digitar a senha e atribua o valor a `senhaDigitada`.
5.  Quando o laço terminar, exiba a mensagem "Senha correta\! Acesso permitido.".
