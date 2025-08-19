# Gerenciamento de Exceções em C#

## Aula 44 - Tipos de Exceções (`Exception`, `ArgumentException`, etc.)

Bem-vindo ao capítulo de Gerenciamento de Exceções em C#! Na aula anterior, exploramos os blocos `try-catch-finally` e como eles ajudam a capturar e tratar erros durante a execução do programa. Agora, vamos nos aprofundar nos **tipos de exceções**, que são as classes específicas usadas para representar diferentes categorias de erros. Entender esses tipos é fundamental para tratar exceções de forma precisa e eficaz, permitindo que você responda adequadamente a problemas como argumentos inválidos, operações não permitidas ou formatos incorretos.

Nesta aula, vamos explicar detalhadamente a hierarquia de exceções em C#, os tipos mais comuns (como `Exception`, `ArgumentException`, `FormatException` e outros) e como usá-los em códigos práticos. Vamos passo a passo, com exemplos claros, para que você compreenda não só o "o quê", mas também o "por quê" e o "como" de cada tipo de exceção.

### Objetivo

Entender a hierarquia e os tipos de exceções em C#, aprender a identificar quando usar cada um e aplicar esses conhecimentos para tratar erros de forma específica em cenários reais, como validações de dados ou operações financeiras.

## A Hierarquia de Exceções em C#

Em C#, todas as exceções derivam da classe base **`System.Exception`**, que fornece propriedades comuns como `Message` (mensagem de erro), `StackTrace` (rastreamento da pilha de chamadas) e `InnerException` (exceção interna, útil para exceções aninhadas). Essa hierarquia permite que você capture exceções genéricas ou específicas, dependendo da necessidade.

Aqui vai uma visão detalhada da hierarquia:

- **`System.Exception`**: A classe base para todas as exceções. Use-a como "rede de segurança" para capturar qualquer erro não tratado especificamente.
  - Propriedades principais:
    - `Message`: Uma string que descreve o erro (ex.: "Divisão por zero").
    - `StackTrace`: Mostra a sequência de métodos que levaram à exceção.
    - `InnerException`: Refere-se a uma exceção que causou a atual (útil em cenários encadeados).
    - `Source`: Nome da aplicação ou objeto que causou a exceção.
    - `TargetSite`: Método onde a exceção ocorreu.

- **Exceções Derivadas Comuns**:
  - **`System.SystemException`**: Base para exceções lançadas pelo runtime do .NET, como erros aritméticos ou de índice.
    - **`ArgumentException`**: Lançada quando um argumento passado para um método é inválido. É uma exceção comum em validações de entrada.
      - Subtipos:
        - **`ArgumentNullException`**: Quando um argumento é `null` e não deveria ser.
        - **`ArgumentOutOfRangeException`**: Quando um argumento está fora do intervalo permitido (ex.: índice negativo em uma lista).
    - **`InvalidOperationException`**: Lançada quando uma operação não é válida no estado atual do objeto (ex.: chamar um método em um objeto não inicializado).
    - **`FormatException`**: Quando uma string não está no formato esperado (ex.: tentar converter "abc" para um número).
    - **`DivideByZeroException`**: Específica para divisões por zero em operações aritméticas.
    - **`IndexOutOfRangeException`**: Quando você tenta acessar um índice inválido em uma coleção, como uma lista ou array.
    - **`NullReferenceException`**: Uma das mais comuns, lançada ao tentar acessar um membro de um objeto que é `null`.
    - **`FileNotFoundException`**: Quando um arquivo ou diretório não é encontrado.
    - **`IOException`**: Para erros gerais de entrada/saída, como falhas ao ler/escrever arquivos.

Essa hierarquia permite que você capture exceções de forma granular: por exemplo, capture `ArgumentNullException` para tratar argumentos nulos e caia em um `catch (ArgumentException)` para outros argumentos inválidos, antes de um `catch (Exception)` genérico.

**Dica didática**: Imagine a hierarquia como uma árvore familiar. `Exception` é o "avô" de todas, `SystemException` é um "pai" para exceções do sistema, e tipos como `ArgumentException` são "filhos" especializados. Ao capturar um "filho", você trata casos específicos; capturar o "avô" trata tudo, mas de forma menos precisa.

## Quando e Como Usar Tipos Específicos de Exceções

Usar tipos específicos permite tratamentos personalizados, tornando o código mais robusto e fácil de depurar. Vamos explorar cada tipo com detalhes, incluindo quando lançá-los (`throw`), como capturá-los e exemplos práticos.

### 1. `Exception` (Genérica)

Use como base para exceções personalizadas ou como captura final. Não lance diretamente `new Exception()` sem motivo; prefira tipos mais específicos.

#### Exemplo: Captura Genérica em uma Operação Bancária

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Simulando uma operação que pode falhar
            int valor = 100;
            int divisor = 0;
            int resultado = valor / divisor; // Gera DivideByZeroException
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro genérico: {ex.Message}");
            Console.WriteLine($"Rastreamento: {ex.StackTrace}");
        }
    }
}
```

**Saída**:
```
Erro genérico: Tentativa de divisão por zero.
Rastreamento: [detalhes da pilha]
```

**Exemplo do dia a dia**: Em um aplicativo de transferências, usar um `catch (Exception)` como último recurso para registrar erros inesperados, como falhas na conexão com o banco de dados.

### 2. `ArgumentException` e Subtipos

Ideal para validar argumentos em métodos. Sempre forneça uma mensagem clara e, se possível, o nome do parâmetro inválido.

#### Exemplo: Validando Argumentos em um Método de Cadastro

```csharp
using System;

class CadastroCliente
{
    public void Registrar(string nome, int idade)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentNullException(nameof(nome), "O nome não pode ser nulo ou vazio.");
        }
        if (idade < 18)
        {
            throw new ArgumentOutOfRangeException(nameof(idade), "A idade deve ser maior ou igual a 18.");
        }
        Console.WriteLine($"Cliente {nome} registrado com idade {idade}.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        CadastroCliente cadastro = new CadastroCliente();

        try
        {
            cadastro.Registrar(null, 15); // Gera ArgumentNullException
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Erro de argumento nulo: {ex.Message} (Parâmetro: {ex.ParamName})");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Erro de intervalo: {ex.Message} (Parâmetro: {ex.ParamName})");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro de argumento genérico: {ex.Message}");
        }
    }
}
```

**Saída**:
```
Erro de argumento nulo: O nome não pode ser nulo ou vazio. (Parâmetro: nome)
```

**Explicação detalhada**: Aqui, `ArgumentNullException` é lançado quando `nome` é nulo, com `nameof(nome)` identificando o parâmetro. Isso ajuda na depuração. `ArgumentOutOfRangeException` verifica o intervalo da idade.

**Exemplo do dia a dia**: Em um sistema de abertura de contas bancárias, validar que o nome do cliente não é vazio e a idade é maior de 18 anos antes de prosseguir com o registo.

### 3. `InvalidOperationException`

Use quando o estado do objeto não permite a operação.

#### Exemplo: Operação Inválida em uma Conta Bancária

```csharp
using System;

class ContaBancaria
{
    public bool Ativa { get; set; }
    public double Saldo { get; set; }

    public ContaBancaria(double saldo)
    {
        Saldo = saldo;
        Ativa = false; // Conta inicia inativa
    }

    public void Depositar(double valor)
    {
        if (!Ativa)
        {
            throw new InvalidOperationException("A conta deve ser ativada antes de realizar depósitos.");
        }
        Saldo += valor;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContaBancaria conta = new ContaBancaria(0);

        try
        {
            conta.Depositar(5000.00); // Gera InvalidOperationException
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Operação inválida: {ex.Message}");
        }
    }
}
```

**Saída**:
```
Operação inválida: A conta deve ser ativada antes de realizar depósitos.
```

**Explicação detalhada**: A exceção é lançada porque a conta não está ativa, prevenindo operações em estados inválidos.

**Exemplo do dia a dia**: Em um aplicativo de banco móvel, impedir depósitos em uma conta suspensa ou não ativada.

### 4. `FormatException`

Lançada ao tentar converter strings para outros tipos com formato inválido.

#### Exemplo: Convertendo Valor Monetário

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string valorString = "5000,00 Kz"; // Formato inválido para double.Parse

        try
        {
            double valor = double.Parse(valorString);
            Console.WriteLine($"Valor convertido: {valor:F2} Kz");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Erro de formato: {ex.Message}. Use ponto para decimais (ex.: 5000.00).");
        }
    }
}
```

**Saída**:
```
Erro de formato: A cadeia de caracteres de entrada não estava em um formato correto. Use ponto para decimais (ex.: 5000.00).
```

**Explicação detalhada**: `double.Parse` espera um formato numérico válido; vírgulas como separador decimal causam a exceção.

**Exemplo do dia a dia**: Em um sistema de pagamentos, validar o formato de um valor em kwanzas inserido pelo usuário antes de processar uma transferência.

### 5. `DivideByZeroException` e `IndexOutOfRangeException`

- `DivideByZeroException`: Para erros aritméticos.
- `IndexOutOfRangeException`: Para acessos inválidos em coleções.

#### Exemplo Combinado: Calculando Taxa de Juros

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<double> taxas = new List<double> { 0.05, 0.10 };
        int indice = 2; // Índice inválido

        try
        {
            double taxa = taxas[indice]; // Gera IndexOutOfRangeException
            double principal = 10000.00;
            double juros = principal / (1 - taxa); // Pode gerar DivideByZero se taxa = 1
            Console.WriteLine($"Juros calculados: {juros:F2} Kz");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Erro de índice: {ex.Message}. O índice deve estar entre 0 e {taxas.Count - 1}.");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Erro de divisão: {ex.Message}. Evite divisões por zero.");
        }
    }
}
```

**Saída**:
```
Erro de índice: O índice estava fora dos limites da matriz. O índice deve estar entre 0 e 1.
```

**Explicação detalhada**: `IndexOutOfRangeException` previne acessos inválidos; `DivideByZeroException` trata erros matemáticos.

**Exemplo do dia a dia**: Em um calculador de empréstimos, evitar divisões por zero ao calcular prestações e garantir que índices de taxas de juros sejam válidos.

### 6. `NullReferenceException`

Lançada ao acessar membros de objetos nulos.

#### Exemplo: Acessando Dados de Cliente

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

        try
        {
            Console.WriteLine($"Nome: {cliente.Nome}"); // Gera NullReferenceException
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine($"Erro de referência nula: {ex.Message}. Verifique se o objeto foi inicializado.");
        }
    }
}
```

**Saída**:
```
Erro de referência nula: Referência de objeto não definida para uma instância de um objeto. Verifique se o objeto foi inicializado.
```

**Explicação detalhada**: Sempre verifique se objetos são nulos antes de acessá-los para evitar essa exceção comum.

**Exemplo do dia a dia**: Em um sistema de cadastro, garantir que dados de cliente sejam carregados antes de exibi-los, evitando erros ao consultar informações nulas.

## Criando Exceções Personalizadas

Para cenários específicos, crie classes derivadas de `Exception`.

#### Exemplo: Exceção para Transação Inválida

```csharp
using System;

class TransacaoInvalidaException : Exception
{
    public double ValorTentado { get; }
    public double SaldoDisponivel { get; }

    public TransacaoInvalidaException(string message, double valor, double saldo) : base(message)
    {
        ValorTentado = valor;
        SaldoDisponivel = saldo;
    }
}

class ContaBancaria
{
    public double Saldo { get; set; }

    public void Transferir(double valor)
    {
        if (valor > Saldo)
        {
            throw new TransacaoInvalidaException("Transação inválida: saldo insuficiente.", valor, Saldo);
        }
        Saldo -= valor;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContaBancaria conta = new ContaBancaria { Saldo = 5000.00 };

        try
        {
            conta.Transferir(6000.00);
        }
        catch (TransacaoInvalidaException ex)
        {
            Console.WriteLine($"{ex.Message} Valor tentado: {ex.ValorTentado:F2} Kz, Saldo disponível: {ex.SaldoDisponivel:F2} Kz");
        }
    }
}
```

**Saída**:
```
Transação inválida: saldo insuficiente. Valor tentado: 6000,00 Kz, Saldo disponível: 5000,00 Kz
```

**Explicação detalhada**: A exceção personalizada inclui propriedades extras para detalhes, tornando o tratamento mais informativo.

**Exemplo do dia a dia**: Em um sistema de pagamentos móveis, lançar uma exceção personalizada para transações que excedem o saldo, fornecendo valores exatos para o usuário.

## Boas Práticas para Trabalhar com Tipos de Exceções

- **Seja específico ao capturar**: Sempre priorize `catch` para tipos específicos (ex.: `ArgumentException`) antes de genéricos, para tratamentos precisos.
- **Forneça mensagens claras**: Ao lançar exceções, inclua detalhes úteis, como valores envolvidos ou passos para corrigir.
- **Use `nameof` para parâmetros**: Em `ArgumentException`, use `nameof(parametro)` para identificar o argumento inválido automaticamente.
- **Evite capturar `NullReferenceException` rotineiramente**: Em vez disso, verifique nulos com `if (obj != null)` para prevenir a exceção.
- **Crie exceções personalizadas quando necessário**: Para erros específicos do domínio, como "SaldoInsuficiente", derive de `Exception` e adicione propriedades relevantes.
- **Registre exceções**: Em aplicações reais, use logging (ex.: com `Console.WriteLine` ou bibliotecas como Serilog) para rastrear `Message` e `StackTrace`.
- **Não use exceções para fluxo de controle**: Exceções são para erros excepcionais; use condicionais (`if`) para lógica normal.
- **Teste exceções**: Escreva testes unitários que lancem e capturem exceções para garantir que o tratamento funcione.

## Conclusão

Nesta aula, mergulhamos nos tipos de exceções em C#, explorando a hierarquia desde `Exception` até tipos específicos como `ArgumentException`, `FormatException` e `InvalidOperationException`. Vimos como cada tipo representa uma categoria de erro, permitindo tratamentos precisos e mensagens informativas. Com exemplos detalhados, você aprendeu a lançar, capturar e personalizar exceções, tornando seu código mais robusto e fácil de manter.

Lembre-se: exceções não são inimigas, mas ferramentas para lidar com o imprevisível. Ao usar tipos específicos, você responde melhor a erros, melhorando a experiência do usuário.

**Próximos passos**: Tente criar um programa que valide uma transferência bancária, lançando exceções como `ArgumentOutOfRangeException` para valores negativos e `InvalidOperationException` para contas inativas. Experimente capturá-las e exibir mensagens personalizadas. Quanto mais você praticar, mais confiante ficará em gerenciar exceções!
