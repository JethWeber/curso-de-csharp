# Gerenciamento de Exceções em C#

## Aula 47 - Boas Práticas para Tratamento de Erros

Bem-vindo à última aula do capítulo de Gerenciamento de Exceções em C#! Após aprendermos sobre blocos `try-catch-finally`, tipos de exceções, lançamento de exceções com `throw` e criação de exceções personalizadas, agora vamos consolidar o conhecimento com **boas práticas para tratamento de erros**. Tratar erros de forma eficaz é essencial para criar aplicativos robustos, fáceis de manter e que oferecem uma boa experiência ao usuário, especialmente em cenários como sistemas bancários, cadastros ou plataformas de pagamento.

Nesta aula, vamos explorar detalhadamente as melhores práticas para gerenciar exceções, garantindo que o código seja claro, eficiente e seguro. Vamos abordar como evitar armadilhas comuns, como capturar exceções desnecessariamente ou ignorar erros, e aplicar essas práticas em exemplos práticos no contexto angolano, como validações em transações ou formulários.

### Objetivo

Entender e aplicar as boas práticas para tratamento de erros em C#, garantindo que as exceções sejam gerenciadas de forma clara, eficiente e adequada ao contexto, como em sistemas de pagamento em kwanzas ou registos de clientes.

## Por que Boas Práticas no Tratamento de Erros?

O tratamento inadequado de erros pode levar a problemas como:
- **Crashes do aplicativo**: Erros não tratados causam falhas inesperadas.
- **Experiência ruim do usuário**: Mensagens de erro genéricas ou ausência de feedback confundem o usuário.
- **Dificuldade de manutenção**: Código com tratamento de erros confuso é difícil de depurar.
- **Vulnerabilidades**: Ignorar erros pode expor falhas de segurança, como em sistemas financeiros.

Boas práticas garantem que o programa lide com erros de forma controlada, fornecendo mensagens úteis e mantendo a estabilidade.

**Exemplo do dia a dia**: Em um aplicativo de transferências móveis, um erro de saldo insuficiente deve ser tratado com uma mensagem clara, como "Saldo insuficiente: 5.000 Kz disponíveis, 10.000 Kz solicitados", em vez de travar o aplicativo.

## Boas Práticas para Tratamento de Erros

Abaixo, listamos as principais boas práticas, com explicações detalhadas e exemplos práticos.

### 1. **Capture Exceções Específicas Antes de Genéricas**

Sempre capture exceções específicas (ex.: `ArgumentNullException`) antes de capturar a classe base `Exception`. Isso permite tratar erros de forma precisa, evitando que erros específicos sejam mascarados por um `catch` genérico.

#### Exemplo: Validando Entrada de Cliente

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            ValidarCliente(null, 15);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Erro de argumento nulo: {ex.Message} (Parâmetro: {ex.ParamName})");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Erro de intervalo: {ex.Message} (Parâmetro: {ex.ParamName})");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }

    static void ValidarCliente(string nome, int idade)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentNullException(nameof(nome), "O nome do cliente não pode ser nulo ou vazio.");
        }
        if (idade < 18)
        {
            throw new ArgumentOutOfRangeException(nameof(idade), "O cliente deve ter pelo menos 18 anos.");
        }
        Console.WriteLine("Cliente válido!");
    }
}
```

**Saída**:
```
Erro de argumento nulo: O nome do cliente não pode ser nulo ou vazio. (Parâmetro: nome)
```

**Explicação detalhada**:
- O `catch (ArgumentNullException)` trata especificamente nomes nulos.
- O `catch (ArgumentOutOfRangeException)` lida com idades inválidas.
- O `catch (Exception)` é a "rede de segurança" para erros inesperados.
- A ordem importa: exceções específicas vêm primeiro.

**Exemplo do dia a dia**: Em um sistema de cadastro bancário, validar o nome e a idade do cliente antes de abrir uma conta, tratando cada erro de forma específica.

### 2. **Evite Blocos `catch` Vazios**

Nunca use um bloco `catch` vazio, pois isso "engole" o erro, dificultando a depuração e mascarando problemas. Sempre registre ou trate o erro de alguma forma.

#### Exemplo Incorreto (Evitar):

```csharp
try
{
    int[] valores = new int[2];
    valores[10] = 5; // Gera IndexOutOfRangeException
}
catch
{
    // Erro ignorado, sem feedback
}
```

#### Exemplo Correto:

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            int[] valores = new int[2];
            valores[10] = 5; // Gera IndexOutOfRangeException
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Erro de índice: {ex.Message}. Verifique o tamanho do array.");
            // Registrar o erro em um log, se necessário
        }
    }
}
```

**Saída**:
```
Erro de índice: O índice estava fora dos limites da matriz. Verifique o tamanho do array.
```

**Explicação detalhada**:
- O bloco `catch` fornece feedback claro, ajudando a identificar o problema.
- Registrar erros (ex.: em um arquivo de log) é útil para depuração em sistemas reais.

**Exemplo do dia a dia**: Em um sistema de gestão de stocks, tratar erros de acesso a índices inválidos ao consultar produtos, exibindo uma mensagem clara para o usuário ou registrando para análise.

### 3. **Forneça Mensagens de Erro Claras e Úteis**

As mensagens de erro devem ser descritivas, incluindo o contexto do erro e, se possível, uma sugestão de correção. Isso ajuda usuários e desenvolvedores a entenderem o problema.

#### Exemplo: Validação de Transferência

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
}

class ContaBancaria
{
    public double Saldo { get; private set; }

    public ContaBancaria(double saldo)
    {
        Saldo = saldo;
    }

    public void Transferir(double valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(valor), "O valor da transferência deve ser maior que zero.");
        }
        if (valor > Saldo)
        {
            throw new SaldoInsuficienteException(
                $"Saldo insuficiente. Disponível: {saldo:F2} Kz. Solicitado: {valor:F2} Kz.",
                Saldo,
                valor
            );
        }
        Saldo -= valor;
        Console.WriteLine($"Transferência de {valor:F2} Kz realizada.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContaBancaria conta = new ContaBancaria(2000.00);

        try
        {
            conta.Transferir(3000.00);
        }
        catch (SaldoInsuficienteException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
```

**Saída**:
```
Erro: Saldo insuficiente. Disponível: 2000,00 Kz. Solicitado: 3000,00 Kz.
```

**Explicação detalhada**:
- A mensagem da exceção inclui o saldo disponível e o valor solicitado, oferecendo contexto claro.
- Isso ajuda o usuário a entender por que a transferência falhou e o que fazer.

**Exemplo do dia a dia**: Em um aplicativo de transferências móveis, informar ao cliente exatamente por que a transferência falhou, incluindo o saldo disponível, para que ele possa ajustar o valor.

### 4. **Use Exceções Apenas para Condições Excepcionais**

Exceções são para erros inesperados, não para fluxo de controle normal. Use condicionais (`if`) para casos esperados.

#### Exemplo Incorreto (Evitar):

```csharp
try
{
    string input = "123";
    int numero = int.Parse(input); // Usa exceção para fluxo normal
    Console.WriteLine($"Número: {numero}");
}
catch (FormatException)
{
    Console.WriteLine("Entrada inválida.");
}
```

#### Exemplo Correto:

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string input = "123";
        if (int.TryParse(input, out int numero))
        {
            Console.WriteLine($"Número: {numero}");
        }
        else
        {
            Console.WriteLine("Entrada inválida. Digite um número válido.");
        }
    }
}
```

**Saída**:
```
Número: 123
```

**Explicação detalhada**:
- `int.TryParse` verifica se a conversão é possível sem lançar uma exceção, tornando o código mais eficiente.
- Exceções têm sobrecarga de desempenho; usá-las para fluxo normal é ineficiente.

**Exemplo do dia a dia**: Em um formulário de pagamento, validar o valor inserido com `double.TryParse` antes de processar, evitando exceções desnecessárias.

### 5. **Use `finally` para Liberar Recursos**

O bloco `finally` garante que recursos (ex.: conexões, arquivos) sejam liberados, mesmo se ocorrer uma exceção.

#### Exemplo: Gerenciando Log de Transações

```csharp
using System;

class Logger
{
    public bool Ativo { get; private set; }

    public void Iniciar()
    {
        Ativo = true;
        Console.WriteLine("Logger iniciado.");
    }

    public void Fechar()
    {
        Ativo = false;
        Console.WriteLine("Logger fechado.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Logger logger = new Logger();
        try
        {
            logger.Iniciar();
            throw new Exception("Erro simulado durante a transação.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        finally
        {
            if (logger.Ativo)
            {
                logger.Fechar();
            }
        }
    }
}
```

**Saída**:
```
Logger iniciado.
Erro: Erro simulado durante a transação.
Logger fechado.
```

**Explicação detalhada**:
- O bloco `finally` garante que o logger seja fechado, mesmo se ocorrer um erro.
- Isso evita vazamentos de recursos, como conexões abertas.

**Exemplo do dia a dia**: Em um sistema de multibanco, garantir que uma transação seja registrada (ou cancelada) em um log, mesmo se houver falha.

### 6. **Registre Exceções para Depuração**

Sempre registre detalhes da exceção (ex.: `Message`, `StackTrace`) em logs para facilitar a depuração, especialmente em sistemas críticos.

#### Exemplo: Registrando Erros

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            int[] valores = new int[2];
            valores[10] = 5; // Gera IndexOutOfRangeException
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");
            // Em um sistema real, salvar em um arquivo de log
        }
    }
}
```

**Saída**:
```
Erro: O índice estava fora dos limites da matriz.
StackTrace: [detalhes da pilha]
```

**Explicação detalhada**:
- O `StackTrace` mostra onde o erro ocorreu, ajudando na depuração.
- Em sistemas reais, use bibliotecas como Serilog ou NLog para salvar logs em arquivos.

**Exemplo do dia a dia**: Em um sistema de gestão de clientes, registrar erros de validação para análise posterior, como falhas ao processar um bilhete de identidade.

### 7. **Evite Capturar `NullReferenceException` Rotineiramente**

Em vez de capturar `NullReferenceException`, verifique nulos explicitamente com `if`.

#### Exemplo Correto:

```csharp
using System;

class Cliente
{
    public string Nome { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Cliente cliente = null;

        if (cliente == null)
        {
            Console.WriteLine("Erro: Cliente não foi inicializado.");
        }
        else
        {
            Console.WriteLine($"Nome: {cliente.Nome}");
        }
    }
}
```

**Saída**:
```
Erro: Cliente não foi inicializado.
```

**Explicação detalhada**:
- Verificar nulos evita a sobrecarga de exceções e torna o código mais claro.
- `NullReferenceException` é um sinal de erro de lógica; previna-o em vez de capturá-lo.

**Exemplo do dia a dia**: Em um sistema de cadastro, verificar se os dados do cliente foram carregados antes de exibi-los.

### 8. **Documente Exceções com Comentários XML**

Use comentários XML (`/// <exception>`) para documentar quais exceções um método pode lançar.

#### Exemplo:

```csharp
using System;

/// <summary>
/// Realiza uma transferência entre contas.
/// </summary>
/// <param name="valor">Valor em kwanzas a transferir.</param>
/// <exception cref="ArgumentOutOfRangeException">Lançada se o valor for menor ou igual a zero.</exception>
/// <exception cref="SaldoInsuficienteException">Lançada se o saldo for insuficiente.</exception>
public void Transferir(double valor)
{
    if (valor <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(valor), "O valor deve ser maior que zero.");
    }
    // Lógica de transferência
}
```

**Explicação detalhada**:
- A documentação XML ajuda outros desenvolvedores a entenderem quais exceções esperar.
- Ferramentas como o Visual Studio mostram essas informações ao usar o método.
                                                                                                                                   
**Exemplo do dia a dia**: Em um sistema de pagamentos, documentar exceções para métodos de transferência, facilitando o uso por outros desenvolvedores.

## Conclusão

Nesta aula, consolidamos as **boas práticas para tratamento de erros** em C#, abordando como capturar exceções específicas, evitar blocos `catch` vazios, fornecer mensagens claras, usar `finally` para liberar recursos, registrar erros, evitar exceções para fluxo normal e documentar métodos. Essas práticas garantem que seu código seja robusto, fácil de manter e ofereça uma boa experiência ao usuário, especialmente em sistemas críticos como multibancos ou cadastros.

**Próximos passos**: Tente criar um programa que simule um sistema de pagamento ou registo, aplicando pelo menos três dessas boas práticas, como capturar exceções específicas, registrar erros e usar mensagens claras. Quanto mais você praticar, mais natural será escrever código resiliente a erros!

Até a próxima Aula!
