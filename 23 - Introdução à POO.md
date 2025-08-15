# Programação Orientada a Objetos em C#: Classes e Objetos

## Introdução à Programação Orientada a Objetos

Parabéns por chegar à Programação Orientada a Objetos (POO)! Agora que você já domina os fundamentos de C#, como variáveis, métodos e loops, é hora de aprender a organizar seu código de forma mais inteligente. POO é como construir uma casa com blocos reutilizáveis: cada bloco (objeto) tem uma função específica, e você pode usá-los para criar algo maior e mais organizado.

Nesta aula, vamos focar em **classes e objetos**, que são o coração da POO. Usaremos exemplos do dia a dia, como uma loja ou uma cozinha, para tornar tudo mais claro.

### Objetivo

Entender o que são classes e objetos, como criá-los em C# e como usá-los para resolver problemas de forma prática e organizada.

## O que é uma Classe?

Pense em uma classe como um **molde** ou uma **planta de uma casa**. Ela define como algo deve ser: quais características (atributos) e comportamentos (métodos) esse "algo" terá. Por exemplo, uma classe "Carro" pode definir que todo carro tem uma cor, um modelo e pode acelerar.

```csharp
// Definindo uma classe chamada Carro
class Carro
{
    // Atributos (características)
    public string Cor;
    public string Modelo;
    public int Velocidade;

    // Método (comportamento)
    public void Acelerar()
    {
        Velocidade += 10;
        Console.WriteLine($"O carro {Modelo} está agora a {Velocidade} km/h!");
    }
}
```

**Exemplo do dia a dia**: Uma classe é como a receita de um bolo. A receita diz os ingredientes (atributos, como farinha e açúcar) e os passos (métodos, como misturar e assar). Mas a receita não é o bolo – ela só descreve como fazer um.

## O que é um Objeto?

Um objeto é o **produto final** criado a partir do molde (classe). Se a classe é a receita, o objeto é o bolo pronto. Você pode criar vários bolos (objetos) a partir da mesma receita (classe), cada um com suas próprias características.

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Criando objetos da classe Carro
        Carro meuCarro = new Carro();
        meuCarro.Cor = "Vermelho";
        meuCarro.Modelo = "Fusca";
        meuCarro.Velocidade = 0;

        Carro carroAmigo = new Carro();
        carroAmigo.Cor = "Azul";
        carroAmigo.Modelo = "Civic";
        carroAmigo.Velocidade = 0;

        // Usando o método Acelerar
        meuCarro.Acelerar(); // Exibe: O carro Fusca está agora a 10 km/h!
        carroAmigo.Acelerar(); // Exibe: O carro Civic está agora a 10 km/h!
    }
}
```

**Exemplo do dia a dia**: Imagine que você usa a receita de bolo para fazer dois bolos: um de chocolate e outro de baunilha. Ambos são bolos (objetos), mas cada um tem características diferentes (sabor, cobertura), mesmo seguindo a mesma receita (classe).

## Atributos e Propriedades

Os atributos são as **características** de uma classe, como a cor ou o modelo de um carro. Em C#, usamos **propriedades** para controlar melhor o acesso aos atributos, tornando o código mais seguro.

```csharp
class Carro
{
    // Atributos privados
    private string cor;
    private string modelo;
    private int velocidade;

    // Propriedades públicas
    public string Cor
    {
        get { return cor; }
        set { cor = value; }
    }

    public string Modelo
    {
        get { return modelo; }
        set { modelo = value; }
    }

    public int Velocidade
    {
        get { return velocidade; }
        set
        {
            if (value >= 0) // Garante que a velocidade não seja negativa
                velocidade = value;
            else
                Console.WriteLine("Velocidade não pode ser negativa!");
        }
    }

    public void Acelerar()
    {
        Velocidade += 10;
        Console.WriteLine($"O carro {Modelo} está agora a {Velocidade} km/h!");
    }
}
```

**Exemplo do dia a dia**: É como uma máquina de café. Você não mexe diretamente nos grãos (atributos privados), mas usa botões (propriedades públicas) para configurar o tipo de café ou a quantidade de açúcar. As propriedades garantem que você não coloque valores inválidos, como uma velocidade negativa.

## Métodos

Métodos são os **comportamentos** de uma classe. Eles definem o que um objeto pode fazer. No exemplo acima, o método `Acelerar` aumenta a velocidade do carro.

**Exemplo prático**: Vamos criar uma classe para uma conta bancária, algo bem comum no dia a dia.

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
        get { return saldo; }
        set { saldo = value; }
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
            Console.WriteLine("Valor inválido para depósito!");
        }
    }

    public void Sacar(double valor)
    {
        if (valor > 0 && valor <= Saldo)
        {
            Saldo -= valor;
            Console.WriteLine($"Saque de R${valor} realizado. Novo saldo: R${Saldo}");
        }
        else
        {
            Console.WriteLine("Saque inválido: valor inválido ou saldo insuficiente!");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContaBancaria minhaConta = new ContaBancaria();
        minhaConta.Titular = "João";
        minhaConta.Saldo = 1000.0;

        minhaConta.Depositar(500.0); // Exibe: Depósito de R$500 realizado. Novo saldo: R$1500
        minhaConta.Sacar(200.0); // Exibe: Saque de R$200 realizado. Novo saldo: R$1300
        minhaConta.Sacar(2000.0); // Exibe: Saque inválido: valor inválido ou saldo insuficiente!
    }
}
```

**Exemplo do dia a dia**: É como usar um caixa eletrônico. Você insere um valor (parâmetro) para depositar ou sacar (métodos), e o sistema verifica se a operação é válida antes de atualizar o saldo.

## Boas Práticas

- **Nomes claros**: Use nomes que descrevam bem a classe, como `Carro` ou `ContaBancaria`, e evite nomes genéricos como `Classe1`.
- **Encapsulamento**: Use atributos privados (`private`) e propriedades públicas (`public`) para proteger os dados.
- **Métodos simples**: Cada método deve fazer uma coisa específica, como `Depositar` ou `Sacar`.
- **Comentários úteis**: Explique o propósito do código, mas evite comentários óbvios.

```csharp
// Bom comentário
// Verifica se o valor do depósito é válido antes de atualizar o saldo
public void Depositar(double valor)
{
    if (valor > 0)
    {
        Saldo += valor;
    }
}

// Comentário redundante (evite)
public void Depositar(double valor) // Método para depositar
{
    // Adiciona valor ao saldo
    Saldo += valor;
}
```

## Conclusão

Você agora entende o que são classes e objetos em C#! Classes são como moldes que definem características e comportamentos, enquanto objetos são as instâncias criadas a partir desses moldes. Com POO, você pode organizar seu código de forma mais clara e reutilizável, como construir uma cidade com blocos bem projetados.

**Próximos passos**: Tente criar sua própria classe, como uma `Loja` que gerencia produtos ou uma `Pessoa` com nome, idade e métodos como `Cumprimentar`. Quanto mais você praticar, mais natural a POO vai parecer!