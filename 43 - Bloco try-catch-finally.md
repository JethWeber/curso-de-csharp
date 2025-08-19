# Gerenciamento de Exceções em C#

## Aula 43 - Blocos `try-catch-finally`

Bem-vindo ao capítulo de Gerenciamento de Exceções em C#! Após explorarmos manipulação de strings e expressões regulares, é hora de aprender como lidar com **exceções**, que são erros que ocorrem durante a execução de um programa. Em C#, os blocos `try-catch-finally` são usados para capturar, tratar e gerenciar exceções, garantindo que o programa continue funcionando de forma controlada mesmo quando algo dá errado.

Nesta aula, vamos entender o que são exceções, como usar os blocos `try`, `catch` e `finally`, e aplicar essas técnicas em exemplos práticos com foco no contexto angolano, como processar transações bancárias ou validar dados de clientes.

### Objetivo

Entender o conceito de exceções em C#, aprender a usar os blocos `try-catch-finally` para gerenciar erros e aplicá-los em cenários reais, como sistemas de pagamento ou cadastros.

## O que são Exceções?

Uma **exceção** é um evento anormal que ocorre durante a execução de um programa, como tentar dividir por zero, acessar um arquivo inexistente ou usar um índice inválido em uma lista. Em C#, exceções são representadas por objetos derivados da classe `System.Exception`.

Pense em exceções como problemas inesperados em uma transação bancária: por exemplo, tentar sacar dinheiro sem saldo suficiente. O gerenciamento de exceções permite lidar com esses problemas sem que o programa "quebre".

### Características das Exceções

- **Hierarquia**: Todas as exceções derivam de `System.Exception`.
- **Blocos `try-catch`**: Usados para capturar e tratar exceções.
- **Bloco `finally`**: Garante a execução de código, independentemente de uma exceção ocorrer.
- **Namespace `System`**: Não é necessário importar namespaces adicionais para exceções básicas.

## Estrutura dos Blocos `try-catch-finally`

- **`try`**: Contém o código que pode gerar uma exceção.
- **`catch`**: Captura e trata exceções específicas ou genéricas.
- **`finally`**: Executa código após o `try` e `catch`, independentemente de uma exceção ocorrer (útil para liberar recursos).

### Sintaxe

```csharp
try
{
    // Código que pode gerar uma exceção
}
catch (ExceptionType ex)
{
    // Tratamento da exceção
}
finally
{
    // Código executado sempre
}
```

## Exemplo Básico de `try-catch`

### Validando Saque Bancário

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        double saldo = 5000.00; // Saldo em kwanzas
        double valorSaque = 6000.00;

        try
        {
            if (valorSaque > saldo)
            {
                throw new Exception("Saldo insuficiente para o saque.");
            }
            saldo -= valorSaque;
            Console.WriteLine($"Saque de {valorSaque:F2} Kz realizado. Novo saldo: {saldo:F2} Kz");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
```

**Saída**:
```
Erro: Saldo insuficiente para o saque.
```

**Exemplo do dia a dia**: Em um multibanco, verificar se o cliente tem saldo suficiente antes de realizar um saque, exibindo uma mensagem de erro se a operação falhar.

## Usando Múltiplos Blocos `catch`

Você pode usar vários blocos `catch` para tratar diferentes tipos de exceções.

### Exemplo: Processando Entrada de Dados

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite o número do bilhete de identidade (ex.: 123456789LA123):");
        string entrada = Console.ReadLine();

        try
        {
            if (string.IsNullOrWhiteSpace(entrada))
            {
                throw new ArgumentNullException("O bilhete não pode estar vazio.");
            }
            if (entrada.Length != 14)
            {
                throw new FormatException("O bilhete deve ter 14 caracteres.");
            }
            Console.WriteLine($"Bilhete válido: {entrada}");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Erro de entrada: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Erro de formato: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
}
```

**Exemplo do dia a dia**: Validar um bilhete de identidade em um sistema de registo civil, como ao abrir uma conta num banco, tratando diferentes tipos de erros (entrada vazia, formato incorreto).

## Usando o Bloco `finally`

O bloco `finally` é executado sempre, mesmo se uma exceção ocorrer ou não. É útil para liberar recursos, como fechar conexões ou arquivos.

### Exemplo: Gerenciando Transação Bancária

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        double saldo = 10000.00;
        double valorTransferencia = 12000.00;
        bool transacaoIniciada = false;

        try
        {
            Console.WriteLine("Iniciando transferência...");
            transacaoIniciada = true;

            if (valorTransferencia > saldo)
            {
                throw new Exception("Saldo insuficiente para a transferência.");
            }
            saldo -= valorTransferencia;
            Console.WriteLine($"Transferência de {valorTransferencia:F2} Kz realizada. Novo saldo: {saldo:F2} Kz");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro na transferência: {ex.Message}");
        }
        finally
        {
            if (transacaoIniciada)
            {
                Console.WriteLine("Transação finalizada.");
            }
        }
    }
}
```

**Saída**:
```
Iniciando transferência...
Erro na transferência: Saldo insuficiente para a transferência.
Transação finalizada.
```

**Exemplo do dia a dia**: Em um sistema de transferências bancárias via aplicativo, o bloco `finally` pode registrar o fim da transação, mesmo se ela falhar, como em operações no BAI Mobile.

## Lançando Exceções Personalizadas

Você pode criar exceções personalizadas para cenários específicos, derivando de `Exception`.

### Exemplo: Exceção para Limite de Saque

```csharp
using System;

class SaldoInsuficienteException : Exception
{
    public SaldoInsuficienteException(string message) : base(message)
    {
    }
}

class ContaBancaria
{
    public double Saldo { get; set; }

    public ContaBancaria(double saldo)
    {
        Saldo = saldo;
    }

    public void Sacar(double valor)
    {
        if (valor > Saldo)
        {
            throw new SaldoInsuficienteException($"Saldo insuficiente. Saldo atual: {Saldo:F2} Kz, Saque: {valor:F2} Kz");
        }
        Saldo -= valor;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContaBancaria conta = new ContaBancaria(2000.00);

        try
        {
            conta.Sacar(3000.00);
            Console.WriteLine($"Saque realizado. Novo saldo: {conta.Saldo:F2} Kz");
        }
        catch (SaldoInsuficienteException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Operação concluída.");
        }
    }
}
```

**Saída**:
```
Erro: Saldo insuficiente. Saldo atual: 2000,00 Kz, Saque: 3000,00 Kz
Operação concluída.
```

**Exemplo do dia a dia**: Em um sistema de multibanco, criar uma exceção personalizada para informar ao cliente que o saldo é insuficiente, com detalhes sobre o valor disponível e o valor solicitado.

## Boas Práticas para Gerenciamento de Exceções

- **Capture exceções específicas**: Use `catch` para tipos específicos (ex.: `ArgumentNullException`) antes de um `catch` genérico (`Exception`).
- **Use `finally` para liberar recursos**: Como fechar conexões ou registrar logs.
- **Evite `catch` genérico desnecessário**: Só use `catch (Exception)` para erros inesperados.
- **Lance exceções significativas**: Use mensagens claras e, se necessário, crie exceções personalizadas.
- **Não ignore exceções**: Evite blocos `catch` vazios, pois isso pode ocultar problemas.
- **Valide cedo**: Combine validações de entrada com `try-catch` para evitar exceções desnecessárias.
- **Documente exceções**: Comente o motivo de cada bloco `catch` ou `throw`.

## Conclusão

Você agora entende como usar os blocos `try-catch-finally` em C# para gerenciar exceções. Essas estruturas permitem capturar e tratar erros, garantindo que o programa lide com problemas de forma controlada. O bloco `finally` é útil para ações que devem sempre ocorrer, como finalizar transações. No contexto local, essas técnicas são essenciais em sistemas como multibancos, aplicativos de transferência ou cadastros.

**Próximos passos**: Tente criar um programa que simule uma transação bancária, como um depósito ou saque, usando `try-catch-finally` para tratar erros como saldo insuficiente ou entradas inválidas. Quanto mais você praticar, mais natural será gerenciar exceções!
