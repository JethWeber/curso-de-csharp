# Programação Orientada a Objetos em C#: Encapsulamento

## Introdução ao Encapsulamento

Parabéns por avançar na Programação Orientada a Objetos (POO)! Agora que você sabe criar classes, objetos e construtores, é hora de aprender sobre **encapsulamento**, um dos pilares da POO. Encapsulamento é como guardar seus objetos pessoais em uma caixa trancada: você controla quem pode acessar ou modificar o que está dentro, mantendo tudo seguro e organizado.

Nesta aula, vamos explorar o que é encapsulamento, como implementá-lo em C# e por que ele é importante, usando exemplos simples do dia a dia.

### Objetivo

Entender o conceito de encapsulamento, como usar modificadores de acesso e propriedades em C# para proteger os dados de uma classe e garantir que sejam usados corretamente.

## O que é Encapsulamento?

Encapsulamento é a prática de **esconder os detalhes internos** de uma classe e permitir que os dados sejam acessados ou modificados apenas de maneira controlada. Isso é feito usando **modificadores de acesso** (como `private` e `public`) e **propriedades** para proteger os atributos da classe.

Pense no encapsulamento como uma máquina de café. Você não mexe diretamente nos grãos ou na água dentro da máquina (os atributos), mas usa botões (métodos ou propriedades) para fazer o café. Isso evita que alguém coloque algo errado, como açúcar no lugar da água.

### Por que usar encapsulamento?

- **Segurança**: Evita que os dados sejam alterados de forma incorreta.
- **Organização**: Mantém o código claro, separando o que é interno da classe do que é externo.
- **Flexibilidade**: Permite mudar a implementação interna sem afetar quem usa a classe.

## Modificadores de Acesso

Em C#, usamos modificadores de acesso para controlar quem pode ver ou alterar atributos e métodos:

- **`public`**: Qualquer um pode acessar.
- **`private`**: Apenas a própria classe pode acessar.
- **`protected`**: A classe e suas subclasses podem acessar (veremos isso em aulas futuras).
- **`internal`**: Apenas classes no mesmo projeto podem acessar.

Por padrão, atributos devem ser `private` para protegê-los, e você cria métodos ou propriedades públicas para acessá-los.

## Usando Atributos Privados

Vamos criar uma classe `ContaBancaria` sem encapsulamento para mostrar o problema:

```csharp
class ContaBancaria
{
    public string Titular;
    public double Saldo;

    public void Depositar(double valor)
    {
        Saldo += valor;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContaBancaria conta = new ContaBancaria();
        conta.Titular = "João";
        conta.Saldo = 1000;

        conta.Saldo = -500; // Problema: saldo negativo!
        Console.WriteLine($"Saldo: R${conta.Saldo}"); // Exibe: Saldo: R$-500
    }
}
```

**Problema**: Como `Saldo` é `public`, qualquer um pode alterá-lo diretamente, até para valores inválidos, como um saldo negativo. Isso é como deixar sua carteira aberta para qualquer um mexer.

## Implementando Encapsulamento com Propriedades

Para corrigir isso, usamos atributos `private` e **propriedades** para controlar o acesso. Propriedades são como "portas" que permitem ler ou escrever atributos de forma segura.

```csharp
class ContaBancaria
{
    private string titular; // Atributo privado
    private double saldo;   // Atributo privado

    // Propriedade para Titular
    public string Titular
    {
        get { return titular; } // Permite ler o atributo
        set { titular = value; } // Permite modificar o atributo
    }

    // Propriedade para Saldo com validação
    public double Saldo
    {
        get { return saldo; }
        set
        {
            if (value >= 0) // Garante que o saldo não seja negativo
                saldo = value;
            else
                Console.WriteLine("Erro: Saldo não pode ser negativo!");
        }
    }

    public void Depositar(double valor)
    {
        if (valor > 0)
        {
            Saldo += valor;
            Console.WriteLine($"Depósito de R${valor} realizado. Novo saldo: R${Saldo}");
        }
        else
        {
            Console.WriteLine("Erro: Valor de depósito inválido!");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContaBancaria conta = new ContaBancaria();
        conta.Titular = "João";
        conta.Saldo = 1000;

        conta.Saldo = -500; // Exibe: Erro: Saldo não pode ser negativo!
        conta.Depositar(500); // Exibe: Depósito de R$500 realizado. Novo saldo: R$1500
        Console.WriteLine($"Saldo final: R${conta.Saldo}"); // Exibe: Saldo final: R$1500
    }
}
```

**Exemplo do dia a dia**: É como um caixa eletrônico. Você não pode acessar diretamente o dinheiro dentro do banco (atributos privados), mas usa a interface do caixa (propriedades ou métodos) para sacar ou depositar, com regras que garantem a segurança.

## Propriedades Autoimplementadas

Se você não precisa de validações, pode usar **propriedades autoimplementadas**, que são mais curtas:

```csharp
class ContaBancaria
{
    public string Titular { get; set; } // Propriedade autoimplementada
    private double saldo;

    public double Saldo
    {
        get { return saldo; }
        set
        {
            if (value >= 0)
                saldo = value;
            else
                Console.WriteLine("Erro: Saldo não pode ser negativo!");
        }
    }

    public void Depositar(double valor)
    {
        if (valor > 0)
            Saldo += valor;
    }
}
```

**Exemplo do dia a dia**: É como uma gaveta com uma fechadura simples para o titular (sem validação) e uma fechadura mais complexa para o saldo (com validação).

## Encapsulamento com Métodos

Além de propriedades, você pode usar métodos para controlar o acesso aos atributos. Por exemplo, em vez de permitir alterar o saldo diretamente, você cria métodos como `Depositar` e `Sacar`.

```csharp
class ContaBancaria
{
    private string titular;
    private double saldo;

    public string Titular
    {
        get { return titular; }
        set { titular = value; }
    }

    public double Saldo
    {
        get { return saldo; } // Apenas leitura, sem set
    }

    public void Depositar(double valor)
    {
        if (valor > 0)
        {
            saldo += valor;
            Console.WriteLine($"Depósito de R${valor} realizado. Novo saldo: R${saldo}");
        }
        else
        {
            Console.WriteLine("Erro: Valor de depósito inválido!");
        }
    }

    public void Sacar(double valor)
    {
        if (valor > 0 && valor <= saldo)
        {
            saldo -= valor;
            Console.WriteLine($"Saque de R${valor} realizado. Novo saldo: R${saldo}");
        }
        else
        {
            Console.WriteLine("Erro: Saque inválido ou saldo insuficiente!");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContaBancaria conta = new ContaBancaria();
        conta.Titular = "Maria";
        conta.Depositar(1000); // Exibe: Depósito de R$1000 realizado. Novo saldo: R$1000
        conta.Sacar(300); // Exibe: Saque de R$300 realizado. Novo saldo: R$700
        // conta.Saldo = 500; // Erro: não pode modificar Saldo diretamente
        Console.WriteLine($"Saldo final: R${conta.Saldo}"); // Exibe: Saldo final: R$700
    }
}
```

**Exemplo do dia a dia**: É como um cofre em casa. Você não abre o cofre diretamente (atributo privado), mas usa chaves específicas (métodos `Depositar` e `Sacar`) para adicionar ou retirar dinheiro, com regras para evitar problemas.

## Boas Práticas com Encapsulamento

- **Use `private` para atributos**: Sempre declare atributos como `private` para protegê-los.
- **Controle com propriedades ou métodos**: Use propriedades para acesso simples e métodos para operações complexas.
- **Valide dados**: Inclua verificações para garantir que os valores sejam válidos, como um saldo não negativo.
- **Propriedades de só leitura**: Se um atributo não deve ser modificado diretamente, omita o `set` ou use métodos.
- **Nomes claros**: Use nomes que reflitam o propósito, como `Saldo` ou `Depositar`.

## Conclusão

Você agora entende o **encapsulamento** em C#! Ele é como uma caixa forte que protege os dados de uma classe, permitindo acesso apenas por meios controlados, como propriedades e métodos. Isso torna seu código mais seguro, organizado e fácil de manter.

**Próximos passos**: Tente criar uma classe, como `Celular`, com atributos privados (como bateria ou número de telefone) e propriedades ou métodos para controlá-los. Experimente usar encapsulamento para garantir que a bateria nunca seja negativa, por exemplo. Quanto mais você praticar, mais natural será usar encapsulamento na POO!
