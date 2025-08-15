
# Fundamentos Da Linguagem C#


## **Aula 13 — Estruturas de Repetição: Laço `do-while`**

Na aula anterior, aprendemos sobre o laço `while`, que verifica a condição **antes** de executar o código. Agora, vamos conhecer o `do-while`, que é muito similar, mas com uma diferença crucial: ele garante que o bloco de código será executado **pelo menos uma vez**, independentemente da condição.

-----

### **1. O que é o Laço `do-while`?**

O laço `do-while` (em português, "faça-enquanto") é uma estrutura de repetição que executa o código no bloco `do` e, **depois**, verifica a condição no `while`. Se a condição for verdadeira, o ciclo se repete.

> 🧠 **Pense assim:**
>
>   * `Faça` a pergunta ao cliente.
>   * `Enquanto` a resposta for inválida, `faça` a pergunta novamente.

Este laço é perfeito para situações onde você precisa que o código seja executado no mínimo uma vez, como em menus de programas ou validação de entrada de dados.

-----

### **2. A Estrutura do `do-while`**

A sintaxe é um pouco diferente do `while` e exige um ponto e vírgula no final.

```csharp
do
{
    // Este bloco de código será executado pelo menos uma vez.
    // E será repetido enquanto a condição for verdadeira.
} while (condição); // Não se esqueça do ponto e vírgula!
```

-----

### **3. Exemplo Simples: Garantindo a Execução**

Vamos ver a principal diferença entre o `while` e o `do-while` com um exemplo simples.

```csharp
int numero = 10;

// Exemplo com 'while'
while (numero < 5)
{
    Console.WriteLine("Esta linha nunca será executada.");
}

// Exemplo com 'do-while'
do
{
    Console.WriteLine("Esta linha será executada pelo menos uma vez.");
} while (numero < 5);
```

Neste caso, a condição `(numero < 5)` é `false` desde o início. O laço `while` não executa, mas o laço `do-while` executa o código uma vez antes de verificar a condição e parar.

-----

### **4. Exemplo Prático: Repetindo com o Usuário**

Vamos melhorar o seu exemplo, corrigindo o erro de digitação (`brek` para `break`) e usando `TryParse` para garantir uma entrada segura.

```csharp
using System;

public class Program
{
    public static void Main()
    {
        int i;
        
        do // O laço começa a executar o código imediatamente
        {
            Console.Clear();
            Console.WriteLine("Olá Mundo!");
            
            Console.Write("\n\nDigite 1 para continuar e 0 para parar: ");
            string entrada = Console.ReadLine();

            // Tenta converter a entrada para um número inteiro.
            if (!int.TryParse(entrada, out i))
            {
                // Se a entrada for inválida, 'i' recebe 1 para continuar o laço
                i = 1; 
                Console.WriteLine("\nEntrada inválida. Por favor, digite 1 ou 0.");
                System.Threading.Thread.Sleep(2000); // Pausa por 2 segundos
            }
        } while (i != 0); // A condição é verificada aqui, no final da primeira execução

        Console.WriteLine("\nPrograma encerrado.");
    }
}
```

**Análise das Melhorias:**

  * **`do-while` na prática:** Este laço é a escolha natural para este tipo de lógica. O programa sempre exibe a mensagem "Olá Mundo\!" pelo menos uma vez, e só depois pergunta se deve continuar.
  * **Redundância:** O `if(i == 0) break;` é redundante, pois a própria condição `while (i != 0);` no final do laço já lida com a saída, tornando o código mais limpo.
  * **Segurança:** O uso de `int.TryParse()` evita que o programa dê erro se o usuário digitar um valor inválido.

-----

### **5. Resumo da Aula**

  * **Laço `do-while`:** Executa o código **pelo menos uma vez** e depois verifica a condição para repetir.
  * **Diferença para `while`:** A condição é verificada no final do laço, não no início.
  * **Uso ideal:** Perfeito para cenários onde a primeira execução é garantida, como menus de programas ou validação de senhas.

-----

### **6. Exercício Prático**

Crie um programa que pede um número entre 1 e 10 ao usuário. O programa deve continuar pedindo até que o usuário digite um número que esteja no intervalo correto.

1.  Crie uma variável `numero` do tipo `int`.
2.  Use um laço `do-while`.
3.  Dentro do laço, peça para o usuário digitar um número e armazene-o em `numero` usando `int.TryParse()`.
4.  A condição do `do-while` deve ser: `(numero < 1 || numero > 10)`. O laço só deve parar quando o número estiver entre 1 e 10.
5.  Quando o laço terminar, exiba a mensagem "Número válido: " e o número digitado.
