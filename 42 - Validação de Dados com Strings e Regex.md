# Manipulação de Strings e Expressões Regulares em C#

## Aula 42 - Validação de Dados com Strings e Regex

Bem-vindo ao capítulo de Manipulação de Strings e Expressões Regulares em C#! Após explorarmos métodos de string, formatação, `StringBuilder` e expressões regulares (`Regex`), é hora de nos aprofundarmos na **validação de dados** usando strings e `Regex`. A validação de dados é essencial para garantir que entradas como números de telefone, bilhetes de identidade ou endereços sejam corretas antes de serem processadas.

Nesta aula, vamos aprender como combinar métodos de string e expressões regulares para validar dados, com exemplos práticos adaptados ao contexto local, como validar números de telefone móveis ou formatos de bilhete de identidade.

### Objetivo

Entender como usar métodos de string e a classe `Regex` para validar dados em C#, aplicando essas técnicas em cenários reais do dia a dia, como validação de números de telefone, bilhetes de identidade ou endereços.

## O que é Validação de Dados?

**Validação de dados** é o processo de verificar se uma entrada atende a critérios específicos, como formato, tamanho ou conteúdo. Em C#, podemos usar métodos de string (ex.: `Contains`, `Length`) para validações simples e `Regex` para validações mais complexas, como formatos de e-mail ou números de telefone.

No dia a dia, a validação de dados é crucial em sistemas como cadastros bancários, formulários de registo civil ou aplicações de comércio eletrônico que lidam com kwanzas e informações locais.

### Características da Validação

- **Métodos de string**: Úteis para validações simples, como verificar comprimento ou presença de caracteres.
- **Expressões regulares**: Ideais para validar padrões complexos, como números de telefone ou bilhetes de identidade.
- **Namespace `System.Text.RegularExpressions`**: Requer `using System.Text.RegularExpressions;` para `Regex`.
- **Contexto local**: Validações podem incluir números de telefone (ex.: +244 923 XXX XXX), formatos de bilhete de identidade ou nomes de bairros.

## Validação com Métodos de String

Métodos de string como `Length`, `Contains`, `StartsWith`, `Trim` e `IsNullOrWhiteSpace` são úteis para validações básicas.

### Exemplo: Validando Nome de Cliente

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string nome = "  José dos Santos  ";

        // Validação básica
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Erro: O nome não pode estar vazio.");
        }
        else
        {
            nome = nome.Trim(); // Remove espaços
            if (nome.Length < 3)
            {
                Console.WriteLine("Erro: O nome deve ter pelo menos 3 caracteres.");
            }
            else if (!nome.Contains(" "))
            {
                Console.WriteLine("Erro: O nome deve incluir nome e apelido.");
            }
            else
            {
                Console.WriteLine($"Nome válido: {nome}");
            }
        }
        // Exibe: Nome válido: José dos Santos
    }
}
```

**Exemplo do dia a dia**: Validar o nome completo de um cliente em um formulário de registo num banco para garantir que inclui nome e apelido, como em um cadastro no BPC.

## Validação com `Regex`

Expressões regulares são ideais para validar padrões complexos, como números de telefone ou bilhetes de identidade.

### Exemplo 1: Validando Número de Telefone Móvel

Números de telefone móveis geralmente seguem o padrão `+244 9XX XXX XXX` (ex.: +244 923 456 789).

```csharp
using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string telefone = "+244 923 456 789";
        string pattern = @"^\+244\s9[1-4]\d\s\d{3}\s\d{3}$";

        // Validando o número
        bool isValid = Regex.IsMatch(telefone, pattern);
        Console.WriteLine($"Número de telefone válido? {isValid}"); // Exibe: Número de telefone válido? True

        // Testando número inválido
        telefone = "+244 823 456 789"; // Prefixo inválido (8 não é usado)
        isValid = Regex.IsMatch(telefone, pattern);
        Console.WriteLine($"Número de telefone válido? {isValid}"); // Exibe: Número de telefone válido? False
    }
}
```

**Explicação do padrão**:
- `^\+244` : Começa com "+244".
- `\s` : Espaço em branco.
- `9[1-4]` : Dígito 9 seguido de 1, 2, 3 ou 4 (prefixos móveis comuns).
- `\d` : Um dígito.
- `\s\d{3}\s\d{3}$` : Espaço, três dígitos, espaço, três dígitos no final.

**Exemplo do dia a dia**: Validar números de telefone em um formulário de registo para serviços móveis, como numa operadora de telecomunicações.

### Exemplo 2: Validando Bilhete de Identidade

O bilhete de identidade tem um formato como `123456789LA123` (9 dígitos, 2 letras, 3 dígitos).

```csharp
using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string bilhete = "123456789LA123";
        string pattern = @"^\d{9}[A-Z]{2}\d{3}$";

        // Validando o bilhete
        bool isValid = Regex.IsMatch(bilhete, pattern);
        Console.WriteLine($"Bilhete válido? {isValid}"); // Exibe: Bilhete válido? True

        // Testando bilhete inválido
        bilhete = "12345678LA123"; // Menos de 9 dígitos iniciais
        isValid = Regex.IsMatch(bilhete, pattern);
        Console.WriteLine($"Bilhete válido? {isValid}"); // Exibe: Bilhete válido? False
    }
}
```

**Explicação do padrão**:
- `^\d{9}` : Começa com 9 dígitos.
- `[A-Z]{2}` : Exatamente 2 letras maiúsculas.
- `\d{3}$` : Termina com 3 dígitos.

**Exemplo do dia a dia**: Validar bilhetes de identidade em um sistema de registo civil ou num banco para abertura de contas.

## Combinando Métodos de String e `Regex`

Métodos de string e `Regex` podem ser combinados para validações mais robustas.

### Exemplo: Validando Endereço

```csharp
using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string endereco = "Bairro Talatona, Kilamba";

        // Validação com métodos de string
        endereco = endereco.Trim();
        if (string.IsNullOrWhiteSpace(endereco))
        {
            Console.WriteLine("Erro: Endereço não pode estar vazio.");
            return;
        }
        if (endereco.Length < 10)
        {
            Console.WriteLine("Erro: Endereço deve ter pelo menos 10 caracteres.");
            return;
        }

        // Validação com Regex: deve conter "Talatona" ou "Kilamba"
        string pattern = @"Talatona|Kilamba";
        if (!Regex.IsMatch(endereco, pattern))
        {
            Console.WriteLine("Erro: Endereço deve incluir 'Talatona' ou 'Kilamba'.");
            return;
        }

        Console.WriteLine($"Endereço válido: {endereco}");
        // Exibe: Endereço válido: Bairro Talatona, Kilamba
    }
}
```

**Exemplo do dia a dia**: Validar endereços em um sistema de entregas, garantindo que o endereço contém bairros conhecidos como Talatona ou Kilamba, comum em serviços de entrega de encomendas.

## Validação com Objetos Personalizados

A validação pode ser aplicada a propriedades de objetos personalizados, combinando strings e `Regex`.

```csharp
using System;
using System.Text.RegularExpressions;

class Cliente
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Bilhete { get; set; }

    public Cliente(string nome, string telefone, string bilhete)
    {
        Nome = nome;
        Telefone = telefone;
        Bilhete = bilhete;
    }

    public bool Validar()
    {
        // Validando nome
        if (string.IsNullOrWhiteSpace(Nome) || Nome.Trim().Length < 3 || !Nome.Contains(" "))
        {
            Console.WriteLine("Erro: Nome inválido.");
            return false;
        }

        // Validando telefone (+244 9XX XXX XXX)
        string telefonePattern = @"^\+244\s9[1-4]\d\s\d{3}\s\d{3}$";
        if (!Regex.IsMatch(Telefone, telefonePattern))
        {
            Console.WriteLine("Erro: Telefone inválido.");
            return false;
        }

        // Validando bilhete (123456789LA123)
        string bilhetePattern = @"^\d{9}[A-Z]{2}\d{3}$";
        if (!Regex.IsMatch(Bilhete, bilhetePattern))
        {
            Console.WriteLine("Erro: Bilhete inválido.");
            return false;
        }

        return true;
    }

    public override string ToString()
    {
        return $"Cliente: {Nome}, Telefone: {Telefone}, Bilhete: {Bilhete}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Cliente cliente = new Cliente("Ana Maria Silva", "+244 923 456 789", "123456789LA123");
        if (cliente.Validar())
        {
            Console.WriteLine(cliente); // Exibe: Cliente: Ana Maria Silva, Telefone: +244 923 456 789, Bilhete: 123456789LA123
        }

        // Testando cliente inválido
        Cliente clienteInvalido = new Cliente("Ana", "+244 823 456 789", "12345678LA123");
        if (!clienteInvalido.Validar())
        {
            Console.WriteLine("Cliente inválido.");
        }
        // Exibe:
        // Erro: Nome inválido.
        // Erro: Telefone inválido.
        // Erro: Bilhete inválido.
        // Cliente inválido.
    }
}
```

**Exemplo do dia a dia**: Validar informações de clientes em um sistema de microcrédito em Luanda, garantindo que nome, telefone e bilhete de identidade estejam corretos antes de aprovar um empréstimo no BAI.

## Boas Práticas para Validação de Dados

- **Combine métodos de string e `Regex`**: Use métodos de string para validações simples (ex.: `Length`, `IsNullOrWhiteSpace`) e `Regex` para padrões complexos.
- **Forneça mensagens claras**: Informe o usuário exatamente o que está errado (ex.: "Telefone deve seguir o formato +244 9XX XXX XXX").
- **Teste padrões de `Regex`**: Use ferramentas como Regex101.com para validar expressões antes de usá-las.
- **Evite validações excessivamente rígidas**: Permita alguma flexibilidade (ex.: espaços extras) usando `Trim` ou `RegexOptions.IgnoreCase`.
- **Valide cedo**: Verifique as entradas logo no início do processamento para evitar erros downstream.
- **Documente padrões**: Comente o propósito de cada padrão de `Regex` para facilitar manutenção.

## Conclusão

Você agora entende como validar dados em C# usando métodos de string e expressões regulares (`Regex`). Combinando essas ferramentas, você pode verificar entradas como nomes, números de telefone e bilhetes de identidade, garantindo que os dados sejam consistentes e corretos. Essas técnicas são úteis em sistemas bancários, registos civis ou plataformas de comércio eletrônico que operam com kwanzas.

**Próximos passos**: Tente criar um programa que valide um formulário de registo, como um cadastro para uma operadora de telecomunicações, verificando telefone, bilhete de identidade e endereço com métodos de string e `Regex`. Quanto mais você praticar, mais natural será validar dados!
