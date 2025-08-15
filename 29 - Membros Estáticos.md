# Programação Orientada a Objetos em C#: Membros Estáticos

## Introdução aos Membros Estáticos

Parabéns por continuar avançando na Programação Orientada a Objetos (POO)! Depois de aprender sobre classes, objetos, construtores, encapsulamento, herança, polimorfismo, classes abstratas e interfaces, é hora de explorar **membros estáticos** (ou `static`). Membros estáticos são como ferramentas compartilhadas em uma casa: todos os moradores podem usá-las sem precisar criar uma nova ferramenta para cada pessoa.

Nesta aula, vamos entender o que são membros estáticos, como usá-los em C# e por que são úteis, com exemplos claros do dia a dia.

### Objetivo

Entender o conceito de membros estáticos, como declarar atributos e métodos estáticos em C# e como usá-los para compartilhar dados ou funcionalidades entre objetos ou sem precisar de objetos.

## O que são Membros Estáticos?

Membros estáticos são atributos ou métodos que pertencem à **classe** em vez de pertencerem a um **objeto** específico. Isso significa que você pode acessá-los diretamente pelo nome da classe, sem precisar criar uma instância (objeto) com `new`.

Pense em membros estáticos como uma impressora compartilhada em um escritório. Todos os funcionários (ou nenhum) podem usá-la sem precisar ter sua própria impressora. Já atributos e métodos não estáticos (de instância) são como canetas pessoais: cada funcionário tem a sua.

### Características de Membros Estáticos

- Declarados com a palavra-chave `static`.
- Pertencem à classe, não a objetos específicos.
- Podem ser acessados usando o nome da classe (ex.: `Classe.Membro`).
- São úteis para compartilhar dados ou funcionalidades comuns a todos os objetos de uma classe.
- Não podem acessar membros de instância diretamente (como atributos ou métodos não estáticos).

## Atributos Estáticos

Um **atributo estático** é uma variável compartilhada por todos os objetos de uma classe. Se um objeto altera esse atributo, a mudança afeta todos os outros objetos.

### Exemplo de Atributo Estático

Vamos criar uma classe `ContaBancaria` com um atributo estático para contar o número total de contas criadas.

```csharp
class ContaBancaria
{
    private string titular;
    private double saldo;
    public static int TotalContas = 0; // Atributo estático

    public ContaBancaria(string titularInicial, double saldoInicial)
    {
        titular = titularInicial;
        saldo = saldoInicial;
        TotalContas++; // Incrementa o contador ao criar uma conta
    }

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
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Total de contas: {ContaBancaria.TotalContas}"); // Exibe: 0
        ContaBancaria conta1 = new ContaBancaria("João", 1000);
        Console.WriteLine($"Total de contas: {ContaBancaria.TotalContas}"); // Exibe: 1
        ContaBancaria conta2 = new ContaBancaria("Maria", 500);
        Console.WriteLine($"Total de contas: {ContaBancaria.TotalContas}"); // Exibe: 2
    }
}
```

**Exemplo do dia a dia**: O atributo `TotalContas` é como um quadro no banco que mostra o número total de contas abertas. Cada nova conta (objeto) atualiza o quadro, e todos podem ver o mesmo número.

## Métodos Estáticos

Um **método estático** é uma função que pertence à classe e pode ser chamada sem criar um objeto. É útil para operações que não dependem de dados específicos de um objeto.

### Exemplo de Método Estático

Vamos adicionar um método estático à classe `ContaBancaria` para calcular juros sobre um valor qualquer.

```csharp
class ContaBancaria
{
    private string titular;
    private double saldo;
    public static int TotalContas = 0;

    public ContaBancaria(string titularInicial, double saldoInicial)
    {
        titular = titularInicial;
        saldo = saldoInicial;
        TotalContas++;
    }

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

    // Método estático
    public static double CalcularJuros(double valor, double taxa)
    {
        return valor * taxa;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContaBancaria conta = new ContaBancaria("João", 1000);
        double juros = ContaBancaria.CalcularJuros(1000, 0.05); // 5% de juros
        Console.WriteLine($"Juros calculados: R${juros}"); // Exibe: Juros calculados: R$50
        Console.WriteLine($"Total de contas: {ContaBancaria.TotalContas}"); // Exibe: 1
    }
}
```

**Exemplo do dia a dia**: O método `CalcularJuros` é como uma calculadora compartilhada no banco. Qualquer pessoa pode usá-la para calcular juros sem precisar abrir uma conta.

## Classes Estáticas

Uma **classe estática** é uma classe que só contém membros estáticos e não pode ser instanciada. É útil para agrupar funcionalidades utilitárias, como ferramentas matemáticas.

### Exemplo de Classe Estática

```csharp
static class Matematica
{
    public static double Quadrado(double numero)
    {
        return numero * numero;
    }

    public static double Cubo(double numero)
    {
        return numero * numero * numero;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Quadrado de 5: {Matematica.Quadrado(5)}"); // Exibe: Quadrado de 5: 25
        Console.WriteLine($"Cubo de 3: {Matematica.Cubo(3)}"); // Exibe: Cubo de 3: 27
        // Matematica mat = new Matematica(); // Erro: não pode instanciar classe estática
    }
}
```

**Exemplo do dia a dia**: Uma classe estática é como uma caixa de ferramentas em uma oficina. Todos usam as mesmas ferramentas (métodos estáticos), e ninguém precisa criar uma nova caixa para cada projeto.

## Limitações de Membros Estáticos

- **Acesso limitado**: Métodos estáticos não podem acessar atributos ou métodos de instância diretamente, pois não estão ligados a um objeto específico.
- **Uso cuidadoso**: Membros estáticos são compartilhados por todos os objetos, então mudanças em um atributo estático afetam todos.
- **Não use em herança**: Membros estáticos não são herdados e não participam de polimorfismo.

### Exemplo de Limitação

```csharp
class ContaBancaria
{
    private double saldo;
    public static int TotalContas = 0;

    public double Saldo
    {
        get { return saldo; }
        set { saldo = value; }
    }

    public static void ExibirSaldo()
    {
        // Console.WriteLine(saldo); // Erro: não pode acessar atributo de instância
        Console.WriteLine("Método estático não acessa saldo de uma conta específica.");
    }
}
```

**Exemplo do dia a dia**: É como tentar usar a calculadora do banco para saber o saldo de uma conta específica. Ela não tem acesso às contas individuais, apenas a informações gerais.

## Boas Práticas com Membros Estáticos

- **Use para funcionalidades compartilhadas**: Como contadores globais (ex.: `TotalContas`) ou utilitários (ex.: `Math.PI`).
- **Evite excesso**: Membros estáticos não devem substituir a lógica de instância; use-os apenas quando fizer sentido compartilhar dados ou funções.
- **Nomes claros**: Use nomes que indiquem o propósito, como `CalcularJuros` ou `TotalContas`.
- **Proteja atributos estáticos**: Considere usar propriedades estáticas para encapsulamento, como:

```csharp
static class Configuracao
{
    private static string idioma = "Português";
    public static string Idioma
    {
        get { return idioma; }
        set { idioma = value; }
    }
}
```

## Conclusão

Você agora entende **membros estáticos** em C#! Eles são como ferramentas compartilhadas que pertencem à classe, não a objetos individuais. Atributos estáticos guardam dados comuns (como um contador de contas), métodos estáticos oferecem funcionalidades gerais (como calcular juros), e classes estáticas agrupam utilitários (como operações matemáticas). Usados corretamente, tornam seu código mais eficiente e organizado.

**Próximos passos**: Tente criar uma classe `Biblioteca` com um atributo estático para contar o total de livros e um método estático para calcular multas por atraso. Ou crie uma classe estática `Conversor` com métodos para converter unidades (ex.: metros para centímetros). Quanto mais você praticar, mais natural será usar membros estáticos na POO!