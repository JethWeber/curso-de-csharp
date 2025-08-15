
# Fundamentos Da Linguamgem De Progrmação C#


## **Aula 07 — Operadores de Atribuição, Incremento e Decremento**

Na aula anterior, aprendemos a fazer comparações com operadores como `>`, `<`, `==`. Agora, vamos explorar os operadores que nos ajudam a manipular e atualizar o valor de variáveis de forma mais rápida e concisa.

-----

### **1. Operadores de Atribuição**

O operador de atribuição mais simples que já conhecemos é o `=`. Ele pega o valor do lado direito e o guarda na variável do lado esquerdo.

```csharp
int numero = 10; // O valor 10 é ATRIBUÍDO à variável 'numero'.
```

Além da atribuição simples, existem operadores compostos que combinam uma operação aritmética com a atribuição. Eles são úteis para encurtar o código.

| Operador | Exemplo Curto | Equivalente a | Descrição |
| :--- | :--- | :--- | :--- |
| `+=` | `x += 5;` | `x = x + 5;` | Atribuição com Adição |
| `-=` | `x -= 5;` | `x = x - 5;` | Atribuição com Subtração |
| `*=` | `x *= 5;` | `x = x * 5;` | Atribuição com Multiplicação |
| `/=` | `x /= 5;` | `x = x / 5;` | Atribuição com Divisão |
| `%=` | `x %= 5;` | `x = x % 5;` | Atribuição com Módulo (resto da divisão) |

**Exemplo Prático**
Vamos ver como eles funcionam no código:

```csharp
int saldo = 100;
Console.WriteLine("Saldo inicial: " + saldo); // Saída: 100

// Adicionando 50 ao saldo
saldo += 50; // Equivalente a: saldo = saldo + 50;
Console.WriteLine("Saldo após depósito: " + saldo); // Saída: 150

// Subtraindo 20 do saldo
saldo -= 20; // Equivalente a: saldo = saldo - 20;
Console.WriteLine("Saldo após saque: " + saldo); // Saída: 130
```

-----

### **2. Operadores de Incremento e Decremento**

Estes operadores são ainda mais curtos. Eles são usados para adicionar ou subtrair exatamente `1` de uma variável numérica.

  * **`++` (Incremento):** Adiciona 1 ao valor da variável.
  * **`--` (Decremento):** Subtrai 1 do valor da variável.

**Exemplo Prático**

```csharp
int contador = 5;
Console.WriteLine("Contador inicial: " + contador); // Saída: 5

// Adicionando 1 ao contador
contador++; // Equivalente a: contador = contador + 1;
Console.WriteLine("Contador depois de incrementar: " + contador); // Saída: 6

// Subtraindo 1 do contador
contador--; // Equivalente a: contador = contador - 1;
Console.WriteLine("Contador depois de decrementar: " + contador); // Saída: 5
```

**Pré-Incremento vs. Pós-Incremento**
Os operadores `++` e `--` podem ser colocados antes ou depois da variável, e isso faz uma pequena diferença quando eles são usados em uma expressão.

  * **Pós-incremento (`contador++`):** Primeiro, a variável é usada na expressão, depois ela é incrementada.
  * **Pré-incremento (`++contador`):** Primeiro, a variável é incrementada, depois ela é usada na expressão.

<!-- end list -->

```csharp
int a = 10;
int b = a++; // 'b' recebe o valor de 'a' (10) ANTES de 'a' ser incrementado.
// a agora é 11, b é 10

int c = 10;
int d = ++c; // 'd' recebe o valor de 'c' (11) DEPOIS de 'c' ser incrementado.
// c agora é 11, d é 11
```

Para iniciantes, o mais seguro é usar esses operadores em linhas separadas para evitar confusão.

-----

### **3. Resumo da Aula**

  * **Atribuição:** Use operadores compostos como `+=`, `-=`, `*=` para encurtar operações como `x = x + y;`.
  * **Incremento (`++`):** Adiciona `1` ao valor da variável.
  * **Decremento (`--`):** Subtrai `1` do valor da variável.
  * A posição do `++` ou `--` importa. Use-os em linhas separadas até se sentir confortável com a diferença entre pré e pós-incremento/decremento.

-----

### **4. Exercício Prático**

Crie um programa que simule a contagem de estoque de um produto.

1.  Declare uma variável `int estoque = 50;`.
2.  Use `estoque += 10;` para simular a chegada de novos produtos. Exiba o novo estoque.
3.  Use `estoque -= 5;` para simular a venda de produtos. Exiba o estoque atualizado.
4.  Use `estoque++` para simular a adição de um único produto. Exiba o resultado.
5.  Use `estoque--` para simular a retirada de um único produto. Exiba o resultado.
