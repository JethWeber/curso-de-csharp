
# Fundamentos Da Linguagem C#

## **Aula 05 — Operadores Aritméticos**

Até agora, aprendemos a guardar dados e a interagir com o usuário. Mas o que fazemos com esses dados? Para realizar cálculos e processar informações, usamos os **operadores aritméticos**. Eles são os símbolos que nos permitem fazer matemática no código.

-----

### **1. Conhecendo os Operadores Aritméticos**

Operadores aritméticos são os símbolos usados para executar operações matemáticas, como soma, subtração, multiplicação e divisão.

| Operador | Nome | Exemplo | Resultado | Explicação |
| :--- | :--- | :--- | :--- | :--- |
| `+` | **Soma** | `5 + 3` | `8` | Adiciona dois valores. |
| `-` | **Subtração** | `5 - 3` | `2` | Subtrai o segundo valor do primeiro. |
| `*` | **Multiplicação** | `5 * 3` | `15` | Multiplica dois valores. |
| `/` | **Divisão** | `5 / 3` | `1` | Divide o primeiro valor pelo segundo. |
| `%` | **Resto da Divisão** | `5 % 3` | `2` | Retorna o resto de uma divisão. |

**Observação sobre a Divisão (`/`)**
Em C\#, o resultado da divisão depende dos tipos de dados envolvidos:

  * **Divisão de inteiros:** O resultado é sempre um número inteiro. A parte decimal é simplesmente descartada. Por exemplo, `10 / 3` resulta em `3`.
  * **Divisão com decimais:** Se um dos números for do tipo `double` ou `float`, o resultado será um número com casas decimais. Por exemplo, `10.0 / 3` resulta em `3.3333333333333335`.

**Observação sobre a Potência (`**`)**
Em C\#, não existe um operador de potência como o `**` de algumas outras linguagens. Para fazer potência, usamos um método da classe `Math`.

  * Para calcular potência, usamos `Math.Pow()`.
      * Exemplo: `Math.Pow(base, expoente)`. `Math.Pow(2, 3)` retorna `8.0`.

-----

### **2. Exemplo Prático de Uso**

Vamos ver como usar esses operadores em um programa C\#. Crie um novo arquivo `Program.cs` e digite o código abaixo.

```csharp
namespace CalculadoraSimples;

public class Program
{
    public static void Main()
    {
        int numero1 = 10;
        int numero2 = 3;

        Console.WriteLine("--- Operações com Inteiros ---");
        Console.WriteLine("Soma: " + (numero1 + numero2));         // 10 + 3 = 13
        Console.WriteLine("Subtração: " + (numero1 - numero2));    // 10 - 3 = 7
        Console.WriteLine("Multiplicação: " + (numero1 * numero2)); // 10 * 3 = 30
        Console.WriteLine("Divisão: " + (numero1 / numero2));      // 10 / 3 = 3 (parte decimal descartada)
        Console.WriteLine("Resto da Divisão: " + (numero1 % numero2)); // 10 % 3 = 1

        Console.WriteLine("\n--- Operação de Potência ---");
        // Math.Pow() retorna um double. Usamos (int) para converter para inteiro.
        double baseNumero = 2;
        double expoente = 5;
        double resultadoPotencia = Math.Pow(baseNumero, expoente);
        Console.WriteLine(baseNumero + " elevado a " + expoente + " é: " + resultadoPotencia); // 2^5 = 32

        Console.WriteLine("\n--- Divisão com Decimais ---");
        double numero3 = 10.0; // Um dos números precisa ser decimal
        double numero4 = 3;
        Console.WriteLine("Divisão decimal: " + (numero3 / numero4)); // 10.0 / 3 = 3.3333...
    }
}
```

-----

### **3. Resumo da Aula**

  * **Operadores Aritméticos:** Símbolos como `+`, `-`, `*`, `/` e `%` para fazer cálculos matemáticos.
  * **Divisão:** Cuidado com a divisão de inteiros, que descarta a parte decimal. Para obter um resultado decimal, use um tipo `double` ou `float`.
  * **Potência:** Use o método `Math.Pow(base, expoente)` para calcular a potência.

-----

### **4. Exercício Prático**

Crie um novo programa que calcula o valor total de uma compra.

1.  Declare três variáveis `double`: `precoDoProduto`, `quantidade` e `valorTotal`.
2.  Atribua valores a `precoDoProduto` e `quantidade`.
3.  Use o operador de multiplicação (`*`) para calcular o `valorTotal`.
4.  Exiba o `valorTotal` na tela.
5.  Desafio extra: Use `Console.ReadLine()` para pegar o preço e a quantidade do usuário, e use `double.TryParse()` para garantir que a entrada seja válida.
