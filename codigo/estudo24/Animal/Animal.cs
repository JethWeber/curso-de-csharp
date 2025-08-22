// Classe para explorar outros temas de construtores

namespace Estudo24;

class Animal
{
    private string _especie;
    private string _raca;
    private string _nome;
    private int _idade;
    private double _peso;

    // Nesta parte veremos sobrecarga de construtores

    // Construtor padrão
    public Animal()
    {
        _especie = "Sem Especie";
        _raca = "Não informada";
        _nome = "Não informada";
        _idade = 0;
        _peso = 0.0;

        Console.WriteLine("Construtor Padrão foi Chamado!");
    }

    // Construtor com parâmetro
    public Animal(string especie, string nome, int idade, double peso)
    {
        _especie = especie;
        _raca = "Não Informado";
        _nome = nome;
        _idade = idade;
        _peso = peso;

        Console.WriteLine("Construtor sem o Parâmetro 'raça' foi Chamado!");
    }

    // Construtor com parâmetro
    public Animal(string especie, string nome)
    {
        _especie = especie;
        _raca = "Não Informado";
        _nome = nome;
        _idade = 0;
        _peso = 0.0;

        Console.WriteLine("Construtor sem os Parâmetros 'idade e peso' foi Chamado!");
    }

    // Propriedade da classe
    public string Especie
    {
        get { return _especie; }
        set { _especie = value; }
    }
    public string Raca
    {
        get { return _raca; }
        set { _raca = value; }
    }
    public string Nome
    {
        get { return _nome; }
        set { _nome = value; }
    }
    public int Idade
    {
        get { return _idade; }
        set
        {
            if (value > 0)
                _idade = value;
        }
    }
    public double Peso
    {
        get { return _peso; }
        set
        {
            if (value > 0)
                _peso = value;
        }
    }

    // Exibindo os dados coletados independentemente do construtor escolhido...
    public void MostrarAnimal()
    {
        Console.WriteLine("\n\n--------------------Dados do Animal--------------------\n");
        Console.WriteLine($"Especie.: {Especie}");
        Console.WriteLine($"Raca.: {Raca}");
        Console.WriteLine($"Nome.: {Nome}");
        Console.WriteLine($"Idade.: {Idade}");
        Console.WriteLine($"Peso.: {Peso}");
        Console.WriteLine("\n\n");
    }

} 