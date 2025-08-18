# Programação Orientada a Objetos em C#

## Aula 27 - Introdução ao Polimorfismo

Parabéns por avançar na Programação Orientada a Objetos (POO)! Agora que você entende classes, objetos, construtores, encapsulamento e herança, é hora de explorar o **polimorfismo**, um dos pilares mais poderosos da POO. Polimorfismo significa "muitas formas" e permite que objetos de diferentes classes sejam tratados de maneira uniforme, mas com comportamentos específicos.

Nesta aula, vamos focar em dois tipos de polimorfismo: **sobrescrita** (usada com herança) e **sobrecarga** (usada dentro da mesma classe). Usaremos exemplos do dia a dia para tornar tudo mais claro.

### Objetivo

Entender o conceito de polimorfismo, como implementar sobrescrita e sobrecarga em C# e como usá-los para criar códigos flexíveis e reutilizáveis.

## O que é Polimorfismo?

Polimorfismo permite que objetos de diferentes classes respondam ao mesmo comando (método) de formas diferentes. É como pedir a várias pessoas para "cozinhar": cada uma pode fazer um prato diferente (pizza, bolo, sopa), mas todas entendem o pedido.

Em C#, polimorfismo é implementado principalmente por:

- **Sobrescrita**: Uma classe filha redefine um método da classe pai para ter um comportamento específico.
- **Sobrecarga**: Uma classe define várias versões do mesmo método com diferentes parâmetros.

## Sobrescrita de Métodos

A **sobrescrita** (ou _method overriding_) acontece quando uma classe filha altera o comportamento de um método herdado da classe pai. Para isso, usamos os modificadores `virtual` (na classe pai) e `override` (na classe filha).

### Exemplo de Sobrescrita

Vamos criar uma classe pai `Animal` e classes filhas `Cachorro` e `Gato`, cada uma com sua própria forma de "falar".

```csharp
class Animal
{
    protected string nome;

    public Animal(string nomeInicial)
    {
        nome = nomeInicial;
    }

    public virtual void Falar() // Método virtual permite sobrescrita
    {
        Console.WriteLine($"{nome} faz um som genérico.");
    }
}

class Cachorro : Animal
{
    public Cachorro(string nomeInicial) : base(nomeInicial)
    {
    }

    public override void Falar() // Sobrescreve o método
    {
        Console.WriteLine($"{nome} diz: Au au!");
    }
}

class Gato : Animal
{
    public Gato(string nomeInicial) : base(nomeInicial)
    {
    }

    public override void Falar() // Sobrescreve o método
    {
        Console.WriteLine($"{nome} diz: Miau!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Animal animal = new Animal("Bicho");
        Cachorro cachorro = new Cachorro("Rex");
        Gato gato = new Gato("Mimi");

        animal.Falar(); // Exibe: Bicho faz um som genérico.
        cachorro.Falar(); // Exibe: Rex diz: Au au!
        gato.Falar(); // Exibe: Mimi diz: Miau!
    }
}
```

**Exemplo do dia a dia**: É como pedir a diferentes membros de uma família para cantar uma música. Todos entendem o pedido de "cantar" (método `virtual`), mas cada um canta de um jeito diferente (método `override`).

### Polimorfismo com Referências da Classe Pai

O verdadeiro poder da sobrescrita aparece quando usamos uma referência da classe pai para chamar métodos de classes filhas.

```csharp
class Program
{
    static void Main(string[] args)
    {
        Animal[] animais = new Animal[2];
        animais[0] = new Cachorro("Rex");
        animais[1] = new Gato("Mimi");

        foreach (Animal animal in animais)
        {
            animal.Falar(); // Chama o método correto de cada objeto
        }
        // Exibe:
        // Rex diz: Au au!
        // Mimi diz: Miau!
    }
}
```

**Exemplo do dia a dia**: É como um maestro conduzindo uma orquestra. Ele dá o comando "tocar" (método da classe pai), mas cada instrumento (classe filha) toca de forma diferente, mesmo sendo tratado como um "instrumento" genérico.

## Sobrecarga de Métodos

A **sobrecarga** (ou _method overloading_) acontece quando uma mesma classe tem várias versões de um método com o mesmo nome, mas com diferentes parâmetros (quantidade ou tipo). Isso permite flexibilidade ao chamar o método.

### Exemplo de Sobrecarga

Vamos criar uma classe `Calculadora` com diferentes versões do método `Somar`.

```csharp
class Calculadora
{
    public int Somar(int a, int b)
    {
        return a + b;
    }

    public double Somar(double a, double b)
    {
        return a + b;
    }

    public int Somar(int a, int b, int c)
    {
        return a + b + c;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Calculadora calc = new Calculadora();
        Console.WriteLine(calc.Somar(2, 3)); // Exibe: 5
        Console.WriteLine(calc.Somar(2.5, 3.7)); // Exibe: 6.2
        Console.WriteLine(calc.Somar(1, 2, 3)); // Exibe: 6
    }
}
```

**Exemplo do dia a dia**: É como uma máquina de suco. Você pode colocar duas laranjas (dois parâmetros `int`), duas maçãs (dois parâmetros `double`) ou três frutas diferentes (três parâmetros). A máquina sabe como processar cada combinação com base no que você dá.

## Diferença entre Sobrescrita e Sobrecarga

- **Sobrescrita**:
    
    - Usada com **herança**.
    - Mesma assinatura (nome e parâmetros) do método, mas comportamento diferente.
    - Requer `virtual` e `override`.
    - Exemplo: `Cachorro` e `Gato` redefinem o método `Falar`.
- **Sobrecarga**:
    
    - Usada na **mesma classe**.
    - Mesmo nome, mas diferentes parâmetros (quantidade ou tipo).
    - Não requer `virtual` ou `override`.
    - Exemplo: Várias versões de `Somar` na classe `Calculadora`.

**Exemplo do dia a dia**: Sobrescrita é como cada filho da família cozinhar o mesmo prato de um jeito único. Sobrecarga é como a mesma pessoa cozinhar pratos diferentes dependendo dos ingredientes que recebe.

## Boas Práticas com Polimorfismo

- **Use sobrescrita com cuidado**: Só sobrescreva métodos quando o comportamento da classe filha precisar ser realmente diferente.
- **Mantenha assinaturas claras**: Na sobrecarga, certifique-se de que os diferentes métodos sejam fáceis de entender (ex.: parâmetros com nomes descritivos).
- **Evite ambiguidade**: Na sobrecarga, evite assinaturas muito parecidas que possam confundir o compilador ou o programador.
- **Use polimorfismo para flexibilidade**: Sempre que possível, use referências da classe pai para tratar objetos de classes filhas de forma genérica.

## Conclusão

Você agora entende o **polimorfismo** em C#! Com **sobrescrita**, você pode personalizar comportamentos de classes filhas, como diferentes animais fazendo sons únicos. Com **sobrecarga**, você pode criar métodos flexíveis que aceitam diferentes entradas, como uma calculadora que soma números de várias formas. Polimorfismo torna seu código mais flexível e reutilizável, como um maestro conduzindo uma orquestra de objetos.

**Próximos passos**: Tente criar uma hierarquia de classes, como `Veiculo` (pai) e `Carro` e `Moto` (filhos), com um método `virtual` (ex.: `Mover`) que cada filho sobrescreve. Ou crie uma classe com métodos sobrecarregados, como uma `Impressora` que imprime diferentes tipos de documentos. Quanto mais você praticar, mais natural será usar polimorfismo na POO!
