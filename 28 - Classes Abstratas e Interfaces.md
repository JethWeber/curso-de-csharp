# Programação Orientada a Objetos em C#

## Aula 28 - Introdução às Classes Abstratas e Interfaces

Parabéns por avançar na Programação Orientada a Objetos (POO)! Agora que você entende classes, objetos, construtores, encapsulamento, herança e polimorfismo, é hora de explorar **classes abstratas** e **interfaces**, dois conceitos poderosos que ajudam a estruturar e organizar seu código. Eles são como as regras de uma cozinha profissional: classes abstratas fornecem uma base comum para pratos semelhantes, enquanto interfaces garantem que todos sigam um padrão, mesmo sendo diferentes.

Nesta aula, vamos aprender o que são classes abstratas e interfaces, como implementá-las em C# e quando usá-las, com exemplos claros do dia a dia.

### Objetivo

Entender os conceitos de classes abstratas e interfaces, como implementá-los em C# e como usá-los para criar códigos flexíveis, organizados e reutilizáveis.

## O que é uma Classe Abstrata?

Uma **classe abstrata** é uma classe que não pode ser instanciada diretamente (ou seja, você não pode criar objetos dela com `new`). Ela serve como uma **base** para outras classes, definindo atributos e métodos comuns, mas deixando alguns comportamentos para as classes filhas implementarem. Pense em uma classe abstrata como um molde geral para uma família de objetos, como uma receita básica de bolo que precisa de detalhes específicos (como sabor) para ser usada.

### Características de uma Classe Abstrata

- Declarada com a palavra-chave `abstract`.
- Pode conter métodos **abstratos** (sem implementação, apenas a assinatura) e métodos **concretos** (com implementação).
- Classes filhas devem implementar todos os métodos abstratos usando `override`.
- Não pode ser instanciada diretamente, apenas herdada.

### Exemplo de Classe Abstrata

Vamos criar uma classe abstrata `Veiculo` com um método abstrato `Mover` que as classes filhas (`Carro` e `Bicicleta`) devem implementar.

```csharp
abstract class Veiculo
{
    protected string marca;

    public Veiculo(string marcaInicial)
    {
        marca = marcaInicial;
    }

    public string Marca
    {
        get { return marca; }
        set { marca = value; }
    }

    // Método abstrato (sem implementação)
    public abstract void Mover();

    // Método concreto (com implementação)
    public void ExibirMarca()
    {
        Console.WriteLine($"Marca do veículo: {Marca}");
    }
}

class Carro : Veiculo
{
    public Carro(string marcaInicial) : base(marcaInicial)
    {
    }

    public override void Mover()
    {
        Console.WriteLine($"O carro {Marca} está dirigindo na estrada!");
    }
}

class Bicicleta : Veiculo
{
    public Bicicleta(string marcaInicial) : base(marcaInicial)
    {
    }

    public override void Mover()
    {
        Console.WriteLine($"A bicicleta {Marca} está pedalando na ciclovia!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Veiculo veiculo = new Veiculo("Toyota"); // Erro: não pode instanciar classe abstrata
        Carro carro = new Carro("Toyota");
        Bicicleta bicicleta = new Bicicleta("Caloi");

        carro.ExibirMarca(); // Exibe: Marca do veículo: Toyota
        carro.Mover(); // Exibe: O carro Toyota está dirigindo na estrada!
        bicicleta.ExibirMarca(); // Exibe: Marca do veículo: Caloi
        bicicleta.Mover(); // Exibe: A bicicleta Caloi está pedalando na ciclovia!
    }
}
```

**Exemplo do dia a dia**: Uma classe abstrata é como uma receita genérica de "prato principal" em um restaurante. Ela diz que todo prato deve ter um nome e um método de preparo, mas cada prato (como macarrão ou bife) define seu próprio jeito de ser preparado.

## O que é uma Interface?

Uma **interface** é como um **contrato** que uma classe deve seguir. Ela define métodos (e, às vezes, propriedades) que a classe deve implementar, mas não fornece nenhuma implementação. Diferente de uma classe abstrata, uma interface não pode ter código implementado ou atributos com valores.

Pense em uma interface como as regras de um clube. Para ser membro, você precisa seguir certas regras (métodos), mas o clube não diz _como_ você deve cumpri-las.

### Características de uma Interface

- Declarada com a palavra-chave `interface`.
- Contém apenas assinaturas de métodos, propriedades ou eventos (sem implementação).
- Classes que implementam a interface devem fornecer a implementação de todos os membros.
- Uma classe pode implementar várias interfaces, mas herdar de apenas uma classe.

### Exemplo de Interface

Vamos criar uma interface `INotificavel` que define um método para enviar notificações, implementada por classes como `Email` e `SMS`.

```csharp
interface INotificavel
{
    void EnviarNotificacao(string mensagem);
}

class Email : INotificavel
{
    private string endereco;

    public Email(string enderecoInicial)
    {
        endereco = enderecoInicial;
    }

    public void EnviarNotificacao(string mensagem)
    {
        Console.WriteLine($"Enviando e-mail para {endereco}: {mensagem}");
    }
}

class SMS : INotificavel
{
    private string numero;

    public SMS(string numeroInicial)
    {
        numero = numeroInicial;
    }

    public void EnviarNotificacao(string mensagem)
    {
        Console.WriteLine($"Enviando SMS para {numero}: {mensagem}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        INotificavel email = new Email("joao@email.com");
        INotificavel sms = new SMS("123456789");

        email.EnviarNotificacao("Bem-vindo ao sistema!"); // Exibe: Enviando e-mail para joao@email.com: Bem-vindo ao sistema!
        sms.EnviarNotificacao("Sua conta foi ativada!"); // Exibe: Enviando SMS para 123456789: Sua conta foi ativada!
    }
}
```

**Exemplo do dia a dia**: Uma interface é como um padrão de tomada elétrica. Qualquer aparelho (classe) que siga o padrão (interface) pode se conectar à energia, mas cada aparelho (como uma TV ou um liquidificador) funciona de maneira diferente.

## Combinando Classes Abstratas e Interfaces

Às vezes, você pode usar classes abstratas e interfaces juntas. Por exemplo, uma classe abstrata fornece uma base comum, enquanto uma interface adiciona um contrato extra.

```csharp
interface INotificavel
{
    void EnviarNotificacao(string mensagem);
}

abstract class Veiculo
{
    protected string marca;

    public Veiculo(string marcaInicial)
    {
        marca = marcaInicial;
    }

    public abstract void Mover();
}

class Carro : Veiculo, INotificavel
{
    public Carro(string marcaInicial) : base(marcaInicial)
    {
    }

    public override void Mover()
    {
        Console.WriteLine($"O carro {marca} está dirigindo!");
    }

    public void EnviarNotificacao(string mensagem)
    {
        Console.WriteLine($"Notificação do carro {marca}: {mensagem}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Carro carro = new Carro("Fiat");
        carro.Mover(); // Exibe: O carro Fiat está dirigindo!
        carro.EnviarNotificacao("Manutenção agendada!"); // Exibe: Notificação do carro Fiat: Manutenção agendada!
    }
}
```

**Exemplo do dia a dia**: É como um carro que segue as regras de um veículo (classe abstrata, como ter rodas) e também as regras de um sistema de notificação (interface, como enviar alertas ao motorista).

## Diferença entre Classes Abstratas e Interfaces

- **Classe Abstrata**:
    
    - Pode ter métodos com implementação e atributos.
    - Usada para definir uma base comum para classes relacionadas (ex.: `Veiculo` para `Carro` e `Bicicleta`).
    - Só permite herança única (uma classe herda de apenas uma classe abstrata).
    - Ideal para compartilhar código comum.
- **Interface**:
    
    - Contém apenas assinaturas, sem implementação.
    - Usada para definir um contrato que várias classes podem seguir (ex.: `INotificavel` para `Email` e `SMS`).
    - Permite implementação múltipla (uma classe pode implementar várias interfaces).
    - Ideal para garantir comportamentos padronizados.

**Exemplo do dia a dia**: Uma classe abstrata é como a receita base de um restaurante que todos os pratos principais seguem. Uma interface é como um selo de qualidade que qualquer prato pode ter, desde que siga certas regras.

## Boas Práticas

- **Use classes abstratas para hierarquias**: Quando as classes filhas compartilham características e comportamentos comuns (ex.: `Veiculo` para `Carro` e `Moto`).
- **Use interfaces para contratos**: Quando você quer garantir que classes diferentes sigam um padrão (ex.: `INotificavel` para sistemas de notificação).
- **Mantenha interfaces pequenas**: Cada interface deve ter poucos métodos, focada em um propósito específico.
- **Nomes claros**: Use nomes que reflitam o propósito, como `Veiculo` para classes abstratas ou `INotificavel` para interfaces.
- **Evite complexidade**: Não crie classes abstratas ou interfaces desnecessárias; use-as apenas quando fizerem sentido.

## Conclusão

Você agora entende **classes abstratas** e **interfaces** em C#! Classes abstratas são como moldes gerais que fornecem uma base para classes relacionadas, enquanto interfaces são contratos que garantem comportamentos padronizados. Juntos, eles tornam seu código mais organizado, flexível e reutilizável, como um restaurante com receitas bem definidas e padrões de qualidade.

**Próximos passos**: Tente criar uma classe abstrata `Animal` com um método abstrato `FazerSom` e classes filhas como `Cachorro` e `Pato`. Adicione uma interface `IMovivel` com um método `Mover` que ambas implementem. Experimente combinar esses conceitos em um programa simples. Quanto mais você praticar, mais natural será usar classes abstratas e interfaces na POO!
