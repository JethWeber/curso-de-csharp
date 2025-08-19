# Gerenciamento de Exceções em C#

## Aula 45 - Lançamento de Exceções (`throw`)

Bem-vindo ao capítulo de Gerenciamento de Exceções em C#! Na aula anterior, exploramos a hierarquia de exceções e os tipos mais comuns, como `Exception`, `ArgumentException` e `FormatException`. Agora, vamos nos aprofundar no **lançamento de exceções** usando a palavra-chave `throw`. Lançar exceções permite que você sinalize erros de forma controlada, fornecendo informações úteis para quem usa seu código. Vamos entender como e quando usar `throw`, criar exceções personalizadas e aplicar essas técnicas em cenários práticos, com exemplos detalhados no contexto angolano, como validações em sistemas bancários ou de cadastro.

Esta aula será didática e detalhada, explicando passo a passo o conceito de `throw`, sua sintaxe, os tipos de exceções a lançar e as melhores práticas para garantir que seu código seja robusto e claro.

### Objetivo

Entender como lançar exceções em C# com a palavra-chave `throw`, aprender a escolher o tipo de exceção apropriado, criar exceções personalizadas e aplicar essas técnicas em cenários reais, como validação de transações ou entradas de usuário.

## O que é Lançar uma Exceção?

**Lançar uma exceção** é o ato de sinalizar que ocorreu um erro ou condição anormal durante a execução do programa, usando a palavra-chave `throw`. Quando você lança uma exceção, o fluxo do programa é interrompido, e o controle é passado para o bloco `catch` mais próximo que possa tratá-la. Isso permite que você gerencie erros de forma estruturada, em vez de deixar o programa "quebrar".

Pense em lançar uma exceção como acionar um alarme em uma agência bancária: quando algo sai errado (ex.: tentativa de saque sem saldo), você alerta o sistema para que o problema seja tratado adequadamente.

### Características do `throw`

- **Palavra-chave `throw`**: Usada para criar e lançar uma instância de uma classe derivada de `System.Exception`.
- **Tipos de exceções**: Você pode lançar exceções embutidas (ex.: `ArgumentException`) ou criar exceções personalizadas.
- **Mensagens claras**: Sempre inclua mensagens descritivas para facilitar a depuração.
- **Interrupção do fluxo**: O código após o `throw` não é executado, a menos que esteja em um bloco `finally`.

## Sintaxe do `throw`

A sintaxe básica para lançar uma exceção é:

```csharp
throw new ExceptionType("Mensagem de erro");
```

- **`ExceptionType`**: O tipo de exceção, como `ArgumentException` ou uma classe personalizada.
- **Mensagem**: Uma string que explica o erro, idealmente com detalhes úteis.
- **Parâmetros adicionais**: Alguns tipos, como `ArgumentException`, aceitam o nome do parâmetro inválido.

### Exemplo Básico: Lançando uma Exceção

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            ValidarIdade(15);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static void ValidarIdade(int idade)
    {
        if (idade < 18)
        {
            throw new ArgumentException("A idade deve ser maior ou igual a 18.", nameof(idade));
        }
        Console.WriteLine("Idade válida!");
    }
}
```

**Saída**:
```
Erro: A idade deve ser maior ou igual a 18. (Parameter 'idade')
```

**Explicação detalhada**:
- O método `ValidarIdade` verifica se a idade é menor que 18.
- Se for, lança uma `ArgumentException` com uma mensagem clara e o nome do parâmetro (`nameof(idade)`).
- O bloco `catch` captura a exceção e exibe a mensagem.

**Exemplo do dia a dia**: Em um sistema de registo para abertura de contas bancárias, validar que o cliente tem idade mínima de 18 anos antes de prosseguir.

## Escolhendo o Tipo de Exceção para Lançar

Escolher o tipo certo de exceção é crucial para tornar o código claro e facilitar o tratamento por outros desenvolvedores. Aqui estão as diretrizes para os tipos mais comuns:

1. **`ArgumentException`** (e subtipos):
   - Use para argumentos inválidos em métodos.
   - Subtipos:
     - **`ArgumentNullException`**: Para argumentos `null` quando não permitido.
     - **`ArgumentOutOfRangeException`**: Para valores fora do intervalo permitido.
   - Inclua o nome do parâmetro com `nameof(parametro)`.

2. **`InvalidOperationException`**:
   - Use quando uma operação não é válida no estado atual do objeto.

3. **`FormatException`**:
   - Use para entradas de formato incorreto, como ao converter strings.

4. **`Exception`**:
   - Evite lançar diretamente, exceto em casos genéricos onde nenhum tipo específico se aplica.
   - Sempre prefira um tipo mais específico.

5. **Exceções personalizadas**:
   - Crie para erros específicos do seu domínio, derivando de `Exception`.

### Exemplo: Validando Transação Bancária

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            ProcessarTransferencia(null, 5000.00);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Erro de argumento nulo: {ex.Message} (Parâmetro: {ex.ParamName})");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro de argumento: {ex.Message}");
        }
    }

    static void ProcessarTransferencia(string contaDestino, double valor)
    {
        if (contaDestino == null)
        {
            throw new ArgumentNullException(nameof(contaDestino), "A conta de destino não pode ser nula.");
        }
        if (valor <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(valor), "O valor da transferência deve ser maior que zero.");
        }
        Console.WriteLine($"Transferência de {valor:F2} Kz para {contaDestino} processada.");
    }
}
```

**Saída**:
```
Erro de argumento nulo: A conta de destino não pode ser nula. (Parâmetro: contaDestino)
```

**Explicação detalhada**:
- `ArgumentNullException` é lançada se `contaDestino` é nula.
- `ArgumentOutOfRangeException` verifica se o valor é inválido (não positivo).
- O uso de `nameof` ajuda a identificar o parâmetro problemático.

**Exemplo do dia a dia**: Em um aplicativo de transferências móveis, validar que a conta de destino foi informada e o valor é positivo antes de processar uma transferência em kwanzas.

## Criando e Lançando Exceções Personalizadas

Para erros específicos do seu domínio, crie uma classe derivada de `Exception`. Isso permite adicionar propriedades extras e mensagens mais úteis.

### Exemplo: Exceção Personalizada para Saldo Insuficiente

```csharp
using System;

class SaldoInsuficienteException : Exception
{
    public double SaldoAtual { get; }
    public double ValorSolicitado { get; }

    public SaldoInsuficienteException(string message, double saldoAtual, double valorSolicitado) 
        : base(message)
    {
        SaldoAtual = saldoAtual;
        ValorSolicitado = valorSolicitado;
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
        if (valor <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(valor), "O valor do saque deve ser maior que zero.");
        }
        if (valor > Saldo)
        {
            throw new SaldoInsuficienteException(
                "Saldo insuficiente para o saque.", 
                Saldo, 
                valor
            );
        }
        Saldo -= valor;
        Console.WriteLine($"Saque de {valor:F2} Kz realizado. Saldo atual: {Saldo:F2} Kz");
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
        }
        catch (SaldoInsuficienteException ex)
        {
            Console.WriteLine($"Erro: {ex.Message} Saldo: {ex.SaldoAtual:F2} Kz, Solicitado: {ex.ValorSolicitado:F2} Kz");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro de argumento: {ex.Message}");
        }
    }
}
```

**Saída**:
```
Erro: Saldo insuficiente para o saque. Saldo: 2000,00 Kz, Solicitado: 3000,00 Kz
```

**Explicação detalhada**:
- A classe `SaldoInsuficienteException` adiciona propriedades `SaldoAtual` e `ValorSolicitado` para fornecer contexto.
- O método `Sacar` lança a exceção personalizada se o saldo for insuficiente, ou `ArgumentOutOfRangeException` se o valor for inválido.
- O bloco `catch` exibe detalhes específicos da exceção personalizada.

**Exemplo do dia a dia**: Em um multibanco, lançar uma exceção personalizada quando o cliente tenta sacar mais kwanzas do que tem disponível, informando o saldo atual e o valor solicitado.

## Relançando Exceções

Às vezes, você pode querer capturar uma exceção, realizar alguma ação (como log) e relançá-la para tratamento posterior. Use `throw` sem argumentos para preservar o `StackTrace`.

### Exemplo: Relançando Exceção

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            TentarAcessoSistema("123456789LA123");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro crítico: {ex.Message}");
        }
    }

    static void TentarAcessoSistema(string bilhete)
    {
        try
        {
            ValidarBilhete(bilhete);
            Console.WriteLine("Acesso permitido.");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Log: Erro ao validar bilhete: {ex.Message}");
            throw; // Relança a exceção original
        }
    }

    static void ValidarBilhete(string bilhete)
    {
        if (bilhete.Length != 14)
        {
            throw new FormatException("O bilhete deve ter 14 caracteres.");
        }
    }
}
```

**Saída**:
```
Log: Erro ao validar bilhete: O bilhete deve ter 14 caracteres.
Erro crítico: O bilhete deve ter 14 caracteres.
```

**Explicação detalhada**:
- `throw` (sem argumentos) no bloco `catch` relança a exceção original, preservando o `StackTrace`.
- Isso permite registrar o erro (ex.: em um log) e passar o controle para um `catch` superior.

**Exemplo do dia a dia**: Em um sistema de registo civil, validar o bilhete de identidade e registrar falhas antes de relançar o erro para o sistema principal.

## Boas Práticas para Lançamento de Exceções

- **Escolha o tipo correto**: Use exceções específicas (ex.: `ArgumentException`) em vez de `Exception` genérica.
- **Inclua mensagens claras**: Descreva o erro e, se possível, sugira uma solução (ex.: "O valor deve ser maior que zero").
- **Use `nameof` para parâmetros**: Em `ArgumentException`, especifique o parâmetro com `nameof(parametro)` para clareza.
- **Crie exceções personalizadas quando necessário**: Para erros específicos do domínio, como transações bancárias.
- **Evite lançar exceções para fluxo normal**: Use condicionais (`if`) para casos esperados; reserve `throw` para erros excepcionais.
- **Preserve o `StackTrace` ao relançar**: Use `throw` sem argumentos em vez de `throw ex` para manter o rastreamento original.
- **Valide entradas cedo**: Lance exceções o mais cedo possível para evitar processamento desnecessário.
- **Documente exceções lançadas**: Use comentários XML (`/// <exception>`) para informar quais exceções um método pode lançar.

## Conclusão

Você agora entende como lançar exceções em C# usando `throw`, desde exceções embutidas como `ArgumentException` e `InvalidOperationException` até exceções personalizadas para cenários específicos. Lançar exceções permite sinalizar erros de forma clara e controlada, facilitando o tratamento em blocos `catch`. No contexto local, essas técnicas são essenciais em sistemas como multibancos, aplicativos de transferência ou cadastros, onde erros como saldo insuficiente ou entradas inválidas precisam ser tratados com precisão.

**Próximos passos**: Tente criar um programa que simule um sistema de pagamento, lançando exceções personalizadas para casos como saldo insuficiente ou conta inválida. Experimente relançar exceções após registrar logs. Quanto mais você praticar, mais confiante ficará em usar `throw` para gerenciar erros!
