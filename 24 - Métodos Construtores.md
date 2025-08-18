# Programação Orientada a Objetos em C#

## Aula 24 - Introdução aos Métodos Construtores 

Agora que você já sabe criar **classes** e **objetos** em C#, é hora de aprender sobre **métodos construtores**, um conceito essencial na Programação Orientada a Objetos (POO). Construtores são como as instruções iniciais para montar um brinquedo novo: eles garantem que o objeto comece com tudo no lugar certo, pronto para ser usado.

Nesta aula, vamos explorar o que são construtores, como usá-los e por que são importantes, usando exemplos simples e do dia a dia para facilitar o aprendizado.

### Objetivo

Entender o que são métodos construtores, como declará-los em C# e como usá-los para inicializar objetos de forma prática e segura.

## O que é um Método Construtor?

Um **construtor** é um método especial em uma classe que é chamado automaticamente quando você cria um objeto com a palavra-chave `new`. Ele serve para **inicializar** os atributos do objeto, garantindo que ele comece com valores válidos.

Pense no construtor como o momento em que você monta uma bicicleta nova. Antes de usá-la, você precisa ajustar o guidão, colocar as rodas e verificar os freios. O construtor faz isso para um objeto, definindo seus valores iniciais.

### Características de um Construtor

- **Nome**: Tem o mesmo nome da classe.
- **Sem retorno**: Não retorna nada (nem mesmo `void`).
- **Chamada automática**: É executado quando você cria um objeto com `new`.
- **Pode ter parâmetros**: Você pode passar valores para configurar o objeto.

## Criando um Construtor Simples

Vamos criar uma classe `Carro` com um construtor que define a cor e o modelo do carro.

```csharp
class Carro
{
    private string cor;
    private string modelo;
    private int velocidade;

    // Construtor
    public Carro()
    {
        cor = "Branco";
        modelo = "Modelo Padrão";
        velocidade = 0;
        Console.WriteLine("Um novo carro foi criado!");
    }

    // Propriedades
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
        set { velocidade = value; }
    }

    public void Acelerar()
    {
        Velocidade += 10;
        Console.WriteLine($"O carro {Modelo} está agora a {Velocidade} km/h!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Carro meuCarro = new Carro(); // Chama o construtor automaticamente
        Console.WriteLine($"Carro criado: {meuCarro.Modelo}, cor {meuCarro.Cor}");
        // Exibe: Um novo carro foi criado!
        // Exibe: Carro criado: Modelo Padrão, cor Branco
    }
}
```

**Exemplo do dia a dia**: É como comprar um celular novo. Quando você o tira da caixa, ele já vem com configurações padrão (como idioma ou brilho da tela). O construtor é como essas configurações iniciais.

## Construtores com Parâmetros

Você pode criar construtores que aceitam parâmetros para personalizar o objeto no momento da criação. Isso é como pedir uma pizza: você escolhe os ingredientes (parâmetros) antes de ela ser feita.

```csharp
class Carro
{
    private string cor;
    private string modelo;
    private int velocidade;

    // Construtor com parâmetros
    public Carro(string corInicial, string modeloInicial)
    {
        cor = corInicial;
        modelo = modeloInicial;
        velocidade = 0;
        Console.WriteLine($"Carro {modelo} criado com cor {cor}!");
    }

    // Propriedades
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
        set { velocidade = value; }
    }

    public void Acelerar()
    {
        Velocidade += 10;
        Console.WriteLine($"O carro {Modelo} está agora a {Velocidade} km/h!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Carro meuCarro = new Carro("Vermelho", "Fusca");
        // Exibe: Carro Fusca criado com cor Vermelho!
        meuCarro.Acelerar();
        // Exibe: O carro Fusca está agora a 10 km/h!
    }
}
```

**Exemplo do dia a dia**: É como pedir um café no balcão e dizer se quer com ou sem açúcar. O construtor usa os parâmetros para "montar" o objeto do jeito que você quer.

## Sobrecarga de Construtores

Você pode ter vários construtores na mesma classe, desde que tenham parâmetros diferentes. Isso é chamado de **sobrecarga**. É como uma pizzaria que oferece opções: uma pizza padrão, uma com ingredientes específicos ou uma com tamanho e ingredientes personalizados.

```csharp
class ContaBancaria
{
    private string titular;
    private double saldo;

    // Construtor padrão
    public ContaBancaria()
    {
        titular = "Anônimo";
        saldo = 0.0;
        Console.WriteLine("Conta padrão criada!");
    }

    // Construtor com titular
    public ContaBancaria(string titularInicial)
    {
        titular = titularInicial;
        saldo = 0.0;
        Console.WriteLine($"Conta criada para {titular}!");
    }

    // Construtor com titular e saldo inicial
    public ContaBancaria(string titularInicial, double saldoInicial)
    {
        titular = titularInicial;
        saldo = saldoInicial;
        Console.WriteLine($"Conta criada para {titular} com saldo inicial de R${saldo}!");
    }

    // Propriedades
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
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContaBancaria conta1 = new ContaBancaria(); // Usa construtor padrão
        // Exibe: Conta padrão criada!

        ContaBancaria conta2 = new ContaBancaria("Maria"); // Usa construtor com titular
        // Exibe: Conta criada para Maria!

        ContaBancaria conta3 = new ContaBancaria("João", 1000.0); // Usa construtor com titular e saldo
        // Exibe: Conta criada para João com saldo inicial de R$1000!
        
        conta3.Depositar(500.0); // Exibe: Depósito de R$500 realizado. Novo saldo: R$1500
    }
}
```

**Exemplo do dia a dia**: É como escolher entre comprar um carro básico (construtor padrão), um carro com cor específica (construtor com um parâmetro) ou um carro com cor e acessórios personalizados (construtor com vários parâmetros).

## Boas Práticas com Construtores

- **Inicialize todos os atributos**: Garanta que o objeto comece em um estado válido, como um saldo inicial de 0 em uma conta bancária.
- **Evite lógica complexa**: Construtores devem ser simples, apenas configurando valores iniciais. Deixe operações complexas para métodos.
- **Use nomes claros**: Embora o construtor tenha o mesmo nome da classe, certifique-se de que os parâmetros sejam descritivos, como `corInicial` em vez de `c`.
- **Valide parâmetros**: Se possível, inclua verificações para evitar valores inválidos.

```csharp
public ContaBancaria(string titularInicial, double saldoInicial)
{
    if (string.IsNullOrEmpty(titularInicial))
        titular = "Anônimo";
    else
        titular = titularInicial;

    if (saldoInicial >= 0)
        saldo = saldoInicial;
    else
        saldo = 0.0;

    Console.WriteLine($"Conta criada para {titular} com saldo inicial de R${saldo}!");
}
```

**Exemplo do dia a dia**: É como garantir que uma pizza não seja feita sem ingredientes ou com quantidades negativas. O construtor verifica isso antes de "entregar" o objeto.

## Conclusão

Você agora entende os **métodos construtores** em C#! Eles são essenciais para criar objetos com valores iniciais corretos, como configurar um celular novo ou montar uma bicicleta. Com construtores, você pode personalizar objetos no momento da criação e garantir que eles estejam prontos para uso.

**Próximos passos**: Tente criar uma classe, como `Livro`, com construtores que definam título, autor e número de páginas. Experimente usar sobrecarga para oferecer diferentes formas de criar um livro. Quanto mais você praticar, mais natural será usar construtores na POO!
