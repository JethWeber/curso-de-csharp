# Programação Orientada a Objetos em C#

## Aula 26 - Introdução à Herança

Parabéns por avançar na Programação Orientada a Objetos (POO)! Agora que você entende classes, objetos, construtores e encapsulamento, é hora de aprender sobre **herança**, um conceito poderoso que permite reutilizar código de forma eficiente. Herança é como uma família: os filhos herdam características e comportamentos dos pais, mas podem ter suas próprias particularidades.

Nesta aula, vamos explorar o que é herança, como implementá-la em C# e por que ela é útil, usando exemplos simples do dia a dia.

### Objetivo

Entender o conceito de herança, como criar classes derivadas em C# e como usá-las para organizar e reutilizar código de maneira prática.

## O que é Herança?

Herança é a capacidade de uma classe (chamada **classe filha** ou **derivada**) herdar atributos e métodos de outra classe (chamada **classe pai** ou **base**). A classe filha pode usar tudo o que a classe pai oferece e ainda adicionar ou modificar comportamentos específicos.

Pense na herança como uma receita de bolo que sua família passa de geração em geração. O bolo básico (classe pai) tem uma receita padrão, mas você (classe filha) pode adicionar chocolate ou cobertura (novos atributos ou métodos) sem precisar reescrever a receita toda.

### Benefícios da Herança

- **Reutilização de código**: Evita repetir código comum.
- **Organização**: Agrupa características compartilhadas em uma classe pai.
- **Flexibilidade**: Permite personalizar ou estender comportamentos nas classes filhas.

## Criando uma Classe Pai e Filha

Vamos criar uma classe pai `Veiculo` e uma classe filha `Carro` que herda dela.

```csharp
class Veiculo
{
    private string marca;
    private int velocidade;

    public Veiculo(string marcaInicial)
    {
        marca = marcaInicial;
        velocidade = 0;
    }

    public string Marca
    {
        get { return marca; }
        set { marca = value; }
    }

    public int Velocidade
    {
        get { return velocidade; }
        set { velocidade = value; }
    }

    public void Acelerar()
    {
        Velocidade += 10;
        Console.WriteLine($"O veículo {Marca} está a {Velocidade} km/h!");
    }
}

class Carro : Veiculo // Herança: Carro herda de Veiculo
{
    private int numeroPortas;

    public Carro(string marcaInicial, int portas) : base(marcaInicial)
    {
        numeroPortas = portas;
    }

    public int NumeroPortas
    {
        get { return numeroPortas; }
        set { numeroPortas = value; }
    }

    // Novo método específico de Carro
    public void AbrirPorta()
    {
        Console.WriteLine($"Abrindo uma das {NumeroPortas} portas do carro {Marca}!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Carro meuCarro = new Carro("Toyota", 4);
        meuCarro.Acelerar(); // Herdado de Veiculo
        // Exibe: O veículo Toyota está a 10 km/h!
        meuCarro.AbrirPorta(); // Específico de Carro
        // Exibe: Abrindo uma das 4 portas do carro Toyota!
    }
}
```

**Exemplo do dia a dia**: Pense em uma família de veículos. Todos os veículos (classe pai) têm uma marca e podem acelerar. Um carro (classe filha) herda essas características, mas também tem portas, algo que nem todo veículo tem (como uma bicicleta). A herança permite que o carro reuse o código de aceleração e adicione algo próprio, como abrir portas.

## Usando o Construtor da Classe Pai

Na herança, o construtor da classe filha precisa chamar o construtor da classe pai usando `: base()`. Isso garante que os atributos da classe pai sejam inicializados corretamente.

No exemplo acima, o construtor de `Carro` chama o construtor de `Veiculo` com `: base(marcaInicial)` para inicializar a marca.

## Modificador `protected`

Às vezes, você quer que a classe filha acesse diretamente os atributos da classe pai, mas ainda assim protegê-los de acesso externo. Para isso, usamos o modificador `protected`.

```csharp
class Veiculo
{
    protected string marca; // Acessível apenas pela classe e suas filhas
    protected int velocidade;

    public Veiculo(string marcaInicial)
    {
        marca = marcaInicial;
        velocidade = 0;
    }

    public void Acelerar()
    {
        velocidade += 10;
        Console.WriteLine($"O veículo {marca} está a {velocidade} km/h!");
    }
}

class Moto : Veiculo
{
    private bool temSidecar;

    public Moto(string marcaInicial, bool sidecar) : base(marcaInicial)
    {
        temSidecar = sidecar;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Moto {marca} com sidecar: {temSidecar}"); // Acessa marca diretamente
    }
}

class Program
{
    static void Main(string[] args)
    {
        Moto minhaMoto = new Moto("Honda", true);
        minhaMoto.Acelerar(); // Exibe: O veículo Honda está a 10 km/h!
        minhaMoto.ExibirDetalhes(); // Exibe: Moto Honda com sidecar: True
    }
}
```

**Exemplo do dia a dia**: É como uma receita de família onde os ingredientes principais (atributos `protected`) podem ser usados pelos filhos, mas estranhos não têm acesso direto à despensa.

## Sobrescrita de Métodos (Polimorfismo Básico)

Às vezes, a classe filha quer mudar o comportamento de um método herdado. Para isso, usamos os modificadores `virtual` (na classe pai) e `override` (na classe filha). Isso é um introdução ao polimorfismo, que veremos em detalhes em outra aula.

```csharp
class Veiculo
{
    protected string marca;
    protected int velocidade;

    public Veiculo(string marcaInicial)
    {
        marca = marcaInicial;
        velocidade = 0;
    }

    public virtual void Acelerar() // Permite sobrescrita
    {
        velocidade += 10;
        Console.WriteLine($"O veículo {marca} está a {velocidade} km/h!");
    }
}

class Carro : Veiculo
{
    public Carro(string marcaInicial) : base(marcaInicial)
    {
    }

    public override void Acelerar() // Sobrescreve o método
    {
        velocidade += 15; // Carro acelera mais rápido
        Console.WriteLine($"O carro {marca} acelera rápido e está a {velocidade} km/h!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Carro meuCarro = new Carro("Fiat");
        meuCarro.Acelerar(); // Exibe: O carro Fiat acelera rápido e está a 15 km/h!
    }
}
```

**Exemplo do dia a dia**: É como cada membro da família fazer o bolo de um jeito diferente. A receita básica (método `virtual`) é a mesma, mas o filho pode adicionar um toque especial (método `override`), como mais chocolate.

## Boas Práticas com Herança

- **Use herança com moderação**: Só use herança quando há uma relação clara de "é um" (ex.: um carro _é um_ veículo). Para outras relações, prefira composição (veremos isso depois).
- **Proteja os dados**: Use `private` ou `protected` para atributos da classe pai.
- **Evite heranças profundas**: Muitas camadas de herança (classe filha da filha da filha) podem complicar o código.
- **Nomes claros**: Escolha nomes que reflitam a hierarquia, como `Veiculo` e `Carro`.

## Conclusão

Você agora entende **herança** em C#! Ela permite que classes filhas herdem atributos e métodos de uma classe pai, como uma família que compartilha características. Com herança, você pode reutilizar código, organizar melhor seu programa e personalizar comportamentos.

**Próximos passos**: Tente criar uma hierarquia de classes, como `Animal` (pai) e `Cachorro` e `Gato` (filhos), com atributos e métodos herdados e personalizados. Experimente usar `protected` e sobrescrita de métodos. Quanto mais você praticar, mais natural será usar herança na POO!
