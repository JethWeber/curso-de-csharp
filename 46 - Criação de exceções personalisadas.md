# Gerenciamento de Exceções em C#

## Aula 46 - Criação de Exceções Personalizadas

Bem-vindo ao capítulo de Gerenciamento de Exceções em C#! Na aula anterior, aprendemos a lançar exceções com a palavra-chave `throw`, utilizando tipos embutidos como `ArgumentException` e `InvalidOperationException`. Agora, vamos nos aprofundar na **criação de exceções personalizadas**, que permitem definir erros específicos para o contexto do seu programa. Exceções personalizadas são ideais para representar condições de erro únicas no seu domínio, como falhas em transações bancárias ou validações em sistemas de cadastro, oferecendo mensagens claras e informações adicionais para facilitar o tratamento.

Nesta aula, vamos explorar passo a passo como criar exceções personalizadas, derivando de `System.Exception`, e como usá-las em cenários práticos no contexto angolano, como sistemas de pagamento ou registo de clientes. Vamos ser didáticos, detalhando a estrutura, as boas práticas e exemplos realistas.

### Objetivo

Entender como criar exceções personalizadas em C#, derivando da classe `Exception`, e aplicá-las em cenários reais, como validações de transações em kwanzas ou cadastros de clientes, garantindo mensagens claras e informações úteis para tratamento de erros.

## O que são Exceções Personalizadas?

Uma **exceção personalizada** é uma classe que você cria, derivada de `System.Exception` (ou de uma de suas subclasses), para representar erros específicos do seu domínio. Elas permitem:
- Adicionar propriedades específicas, como valores ou códigos de erro.
- Fornecer mensagens detalhadas que refletem o contexto do erro.
- Melhorar a legibilidade e manutenção do código.

Pense em exceções personalizadas como alertas personalizados em um sistema de multibanco: em vez de uma mensagem genérica como "Erro", você pode criar uma exceção que diga "Saldo insuficiente para transferência de 10.000 Kz" e inclua o saldo atual.

### Características das Exceções Personalizadas

- **Derivação de `Exception`**: Toda exceção personalizada deve herdar de `System.Exception` ou de uma subclasse (ex.: `ArgumentException`).
- **Propriedades extras**: Você pode adicionar propriedades para fornecer contexto, como valores envolvidos no erro.
- **Construtores padrão**: Siga as convenções de construtores para compatibilidade com o sistema de exceções do .NET.
- **Namespace `System`**: Não é necessário importar namespaces adicionais para a classe base `Exception`.

## Estrutura de uma Exceção Personalizada

Para criar uma exceção personalizada, você define uma nova classe que herda de `Exception` e implementa os construtores padrão do .NET. Abaixo está a estrutura recomendada:

```csharp
using System;

public class MinhaExcecaoPersonalizada : Exception
{
    // Propriedades adicionais (opcional)
    public string DetalheExtra { get; }

    // Construtor padrão
    public MinhaExcecaoPersonalizada() : base()
    {
    }

    // Construtor com mensagem
    public MinhaExcecaoPersonalizada(string message) : base(message)
    {
    }

    // Construtor com mensagem e detalhe extra
    public MinhaExcecaoPersonalizada(string message, string detalheExtra) 
        : base(message)
    {
        DetalheExtra = detalheExtra;
    }

    // Construtor com mensagem e exceção interna
    public MinhaExcecaoPersonalizada(string message, Exception innerException) 
        : base(message, innerException)
    {
    }

    // Construtor com mensagem, detalhe extra e exceção interna
    public MinhaExcecaoPersonalizada(string message, string detalheExtra, Exception innerException) 
        : base(message, innerException)
    {
        DetalheExtra = detalheExtra;
    }
}
```

**Explicação detalhada**:
- **Herança**: A classe herda de `Exception` para integrar-se ao sistema de exceções do .NET.
- **Construtores**:
  - O construtor padrão (`new MinhaExcecaoPersonalizada()`) é usado para erros simples sem mensagem.
  - O construtor com mensagem (`new MinhaExcecaoPersonalizada("Erro")`) permite definir uma descrição do erro.
  - O construtor com exceção interna (`innerException`) é útil para encadear erros causados por outros.
  - Propriedades extras (como `DetalheExtra`) fornecem contexto adicional.
- **Boa prática**: Implemente todos os construtores padrão para compatibilidade e flexibilidade.

## Exemplo 1: Exceção Personalizada para Saldo Insuficiente

Vamos criar uma exceção personalizada para lidar com tentativas de saque ou transferência que excedem o saldo em um sistema bancário.

```csharp
using System;

public class SaldoInsuficienteException : Exception
{
    public double SaldoAtual { get; }
    public double ValorSolicitado { get; }

    public SaldoInsuficienteException(string message, double saldoAtual, double valorSolicitado) 
        : base(message)
    {
        SaldoAtual = saldoAtual;
        ValorSolicitado = valorSolicitado;
    }

    public SaldoInsuficienteException(string message, double saldoAtual, double valorSolicitado, Exception innerException) 
        : base(message, innerException)
    {
        SaldoAtual = saldoAtual;
        ValorSolicitado = valorSolicitado;
    }
}

class ContaBancaria
{
    public double Saldo { get; private set; }

    public ContaBancaria(double saldo)
    {
        Saldo = saldo;
    }

    public void Sacar(double valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(valor), "O valor do saque deve ser maior que zero.");
        }
        if (valor > Saldo)
        {
            throw new SaldoInsuficienteException(
                "Saldo insuficiente para realizar o saque.", 
                Saldo, 
                valor
            );
        }
        Saldo -= valor;
        Console.WriteLine($"Saque de {valor:F2} Kz realizado. Novo saldo: {Saldo:F2} Kz");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContaBancaria conta = new ContaBancaria(5000.00);

        try
        {
            conta.Sacar(6000.00);
        }
        catch (SaldoInsuficienteException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            Console.WriteLine($"Saldo atual: {ex.SaldoAtual:F2} Kz, Valor solicitado: {ex.ValorSolicitado:F2} Kz");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro de argumento: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
}
```

**Saída**:
```
Erro: Saldo insuficiente para realizar o saque.
Saldo atual: 5000,00 Kz, Valor solicitado: 6000,00 Kz
```

**Explicação detalhada**:
- A classe `SaldoInsuficienteException` herda de `Exception` e adiciona propriedades `SaldoAtual` e `ValorSolicitado` para fornecer contexto.
- O método `Sacar` lança a exceção personalizada se o saldo for insuficiente, ou `ArgumentOutOfRangeException` se o valor for inválido.
- O bloco `catch` usa as propriedades da exceção para exibir uma mensagem detalhada.

**Exemplo do dia a dia**: Em um multibanco, informar ao cliente que o saque não pode ser realizado por falta de saldo, mostrando o saldo disponível e o valor solicitado, para clareza.

## Exemplo 2: Exceção Personalizada para Validação de Bilhete de Identidade

Vamos criar uma exceção personalizada para validar o formato de um bilhete de identidade (ex.: `123456789LA123`).

```csharp
using System;
using System.Text.RegularExpressions;

public class BilheteInvalidoException : Exception
{
    public string Bilhete { get; }

    public BilheteInvalidoException(string message, string bilhete) 
        : base(message)
    {
        Bilhete = bilhete;
    }

    public BilheteInvalidoException(string message, string bilhete, Exception innerException) 
        : base(message, innerException)
    {
        Bilhete = bilhete;
    }
}

class CadastroCliente
{
    public void Registrar(string bilhete)
    {
        string pattern = @"^\d{9}[A-Z]{2}\d{3}$";
        if (string.IsNullOrWhiteSpace(bilhete))
        {
            throw new ArgumentNullException(nameof(bilhete), "O bilhete não pode ser nulo ou vazio.");
        }
        if (!Regex.IsMatch(bilhete, pattern))
        {
            throw new BilheteInvalidoException(
                "O bilhete deve seguir o formato 123456789LA123 (9 dígitos, 2 letras maiúsculas, 3 dígitos).",
                bilhete
            );
        }
        Console.WriteLine($"Bilhete {bilhete} registrado com sucesso.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        CadastroCliente cadastro = new CadastroCliente();

        try
        {
            cadastro.Registrar("12345678LA123"); // Formato inválido
        }
        catch (BilheteInvalidoException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            Console.WriteLine($"Bilhete informado: {ex.Bilhete}");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Erro de argumento: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
}
```

**Saída**:
```
Erro: O bilhete deve seguir o formato 123456789LA123 (9 dígitos, 2 letras maiúsculas, 3 dígitos).
Bilhete informado: 12345678LA123
```

**Explicação detalhada**:
- A classe `BilheteInvalidoException` armazena o bilhete inválido como uma propriedade.
- O método `Registrar` usa `Regex` para validar o formato do bilhete e lança a exceção personalizada se o padrão não for atendido.
- O bloco `catch` exibe a mensagem de erro e o bilhete informado para ajudar na correção.

**Exemplo do dia a dia**: Em um sistema de registo civil ou bancário, validar o formato do bilhete de identidade antes de permitir a abertura de uma conta ou registo de cliente.

## Exemplo 3: Exceção Personalizada com Exceção Interna

Às vezes, uma exceção personalizada é causada por outra exceção (ex.: erro de formatação em uma conversão). Use `innerException` para encadear erros.

```csharp
using System;

public class TransacaoInvalidaException : Exception
{
    public double Valor { get; }

    public TransacaoInvalidaException(string message, double valor, Exception innerException) 
        : base(message, innerException)
    {
        Valor = valor;
    }
}

class ProcessadorPagamentos
{
    public void Processar(string valorString)
    {
        try
        {
            double valor = double.Parse(valorString); // Pode gerar FormatException
            if (valor <= 0)
            {
                throw new TransacaoInvalidaException(
                    "O valor da transação deve ser maior que zero.",
                    valor,
                    null
                );
            }
            Console.WriteLine($"Processando pagamento de {valor:F2} Kz...");
        }
        catch (FormatException ex)
        {
            throw new TransacaoInvalidaException(
                "Formato de valor inválido. Use ponto para decimais (ex.: 5000.00).",
                0,
                ex
            );
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ProcessadorPagamentos processador = new ProcessadorPagamentos();

        try
        {
            processador.Processar("5000,00"); // Formato inválido
        }
        catch (TransacaoInvalidaException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Causa: {ex.InnerException.Message}");
            }
        }
    }
}
```

**Saída**:
```
Erro: Formato de valor inválido. Use ponto para decimais (ex.: 5000.00).
Causa: A cadeia de caracteres de entrada não estava em um formato correto.
```

**Explicação detalhada**:
- A exceção `TransacaoInvalidaException` encapsula uma `FormatException` como `innerException`.
- O `catch` externo exibe a mensagem principal e a causa interna, fornecendo mais contexto.

**Exemplo do dia a dia**: Em um aplicativo de pagamentos móveis, validar o valor inserido pelo usuário e relatar erros de formato, mantendo a causa original para depuração.

## Boas Práticas para Exceções Personalizadas

- **Herdar de `Exception` ou subclasses relevantes**: Use `Exception` para erros gerais ou uma classe específica (ex.: `ArgumentException`) para erros relacionados.
- **Implemente os construtores padrão**: Inclua os quatro construtores (vazio, com mensagem, com `innerException`, e com ambos) para compatibilidade.
- **Adicione propriedades úteis**: Inclua dados relevantes (ex.: valores, códigos) para facilitar o tratamento.
- **Forneça mensagens claras**: Descreva o erro e, se possível, sugira uma correção (ex.: "Use o formato 123456789LA123").
- **Evite excesso de personalização**: Crie exceções personalizadas apenas para erros específicos do domínio; use tipos embutidos para casos comuns.
- **Use `innerException` para encadear erros**: Quando o erro é causado por outra exceção, passe-a no construtor.
- **Documente com comentários XML**: Use `/// <exception>` para indicar que seu método pode lançar a exceção personalizada.
- **Teste suas exceções**: Escreva testes unitários para garantir que a exceção é lançada e tratada corretamente.

## Conclusão

Você agora entende como criar e usar **exceções personalizadas** em C#, derivando de `System.Exception` e adicionando propriedades específicas para seu domínio. Com exemplos práticos, vimos como aplicar essas exceções em cenários como validação de saques, bilhetes de identidade e transações, fornecendo mensagens claras e informações úteis. No contexto local, essas técnicas são cruciais em sistemas bancários, registos civis ou plataformas de pagamento, onde erros precisam ser comunicados de forma precisa e compreensível.

**Próximos passos**: Tente criar um programa que simule um sistema de registo ou pagamento, definindo uma exceção personalizada para um caso específico, como um limite de transação excedido ou formato de telefone inválido. Experimente capturar e exibir os detalhes da exceção. Quanto mais você praticar, mais natural será criar exceções personalizadas!
