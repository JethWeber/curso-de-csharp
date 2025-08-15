
# Fundamentos Da Linguagem C#

## **Aula 10 — Mini-Projeto: Criando uma Calculadora Básica**

Chegamos a um marco importante\! Nesta aula, vamos colocar todos os conhecimentos das aulas anteriores em prática. Vamos construir uma **mini-calculadora** que pode somar, subtrair, multiplicar e dividir dois números.

-----

### **1. Estrutura do Programa**

Nossa calculadora vai seguir uma sequência lógica de passos:

1.  Receber o primeiro número do usuário.
2.  Receber o operador matemático (`+`, `-`, `*`, `/`).
3.  Receber o segundo número do usuário.
4.  Realizar a operação matemática com base no operador escolhido.
5.  Exibir o resultado na tela.

-----

### **2. O Código da Calculadora**

Vamos criar um programa que faz exatamente isso. Abra seu editor de código e digite o seguinte.

```csharp
using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("---- Mini-Calculadora ----");

        // 1. Recebe o primeiro número e converte para double
        Console.Write("Digite o primeiro número: ");
        if (!double.TryParse(Console.ReadLine(), out double num1))
        {
            Console.WriteLine("Erro: O primeiro valor não é um número válido!");
            return; // Encerra o programa
        }

        // 2. Recebe o operador
        Console.Write("Digite o operador (+, -, *, /): ");
        string operador = Console.ReadLine();

        // 3. Recebe o segundo número e converte para double
        Console.Write("Digite o segundo número: ");
        if (!double.TryParse(Console.ReadLine(), out double num2))
        {
            Console.WriteLine("Erro: O segundo valor não é um número válido!");
            return; // Encerra o programa
        }
        
        // Variável para armazenar o resultado
        double resultado = 0;

        // 4. Usa a estrutura condicional para escolher a operação
        if (operador == "+")
        {
            resultado = num1 + num2;
        }
        else if (operador == "-")
        {
            resultado = num1 - num2;
        }
        else if (operador == "*")
        {
            resultado = num1 * num2;
        }
        else if (operador == "/")
        {
            // Evita a divisão por zero
            if (num2 != 0)
            {
                resultado = num1 / num2;
            }
            else
            {
                Console.WriteLine("Erro: Não é possível dividir por zero!");
                return; // Encerra o programa
            }
        }
        else
        {
            Console.WriteLine("Erro: Operador inválido!");
            return; // Encerra o programa
        }

        // 5. Exibe o resultado
        Console.WriteLine($"\nResultado: {num1} {operador} {num2} = {resultado}");
    }
}
```

-----

### **3. Explicação Detalhada do Código**

  * `double.TryParse()`: Usamos este método duas vezes para ler os números. Ele é seguro porque evita que o programa pare de funcionar se o usuário digitar um texto em vez de um número.
  * `return;`: Esta instrução é usada para "sair" do método `Main` e encerrar o programa caso ocorra um erro (como uma entrada inválida ou divisão por zero).
  * Estrutura `if-else if`: É o coração da nossa calculadora. O programa verifica qual operador foi digitado e executa apenas a operação correspondente.
  * `if (num2 != 0)`: Esta é uma verificação crucial\! Não podemos dividir um número por zero em matemática, e na programação isso causaria um erro. Por isso, usamos uma estrutura condicional para evitar que isso aconteça.
  * `Console.WriteLine($"\nResultado: {num1} {operador} {num2} = {resultado}");`: Esta linha usa um recurso chamado **string interpolation** (interpolação de string). Em vez de usar `+` para juntar as variáveis, usamos o cifrão (`$`) no início e colocamos as variáveis diretamente entre chaves `{}`. Isso torna o código mais limpo e fácil de ler.

-----

### **4. Resumo da Aula**

Nesta aula, você aprendeu a:

  * Construir um programa completo usando o que foi aprendido.
  * Usar a lógica de programação para resolver um problema real.
  * Combinar diferentes conceitos (entrada, operadores, condicionais) de forma eficaz.
  * Lidar com possíveis erros do usuário de forma segura.

-----

### **5. Próximos Passos**
 
Na próxima aula, vamos falar sobre **estruturas de controle swhitch-case**.
