
namespace Veiculos;

class Carro : Veiculo
{
    private int _cp;

    public Carro(int _cpInicial, string marcaInicial, string modeloInicial, string motorInicial, double velocidadeMaximaInicial, bool usadoInicial)
        : base("Carro", marcaInicial, modeloInicial, motorInicial, velocidadeMaximaInicial, usadoInicial)
    {
        _cp = _cpInicial;
    }

    public string Tipo
    {
        get { return _tipo; }
        set { _tipo = value; }
    }

    public string Marca
    {
        get { return _marca; }
        set { _marca = value; }
    }
    public string Modelo
    {
        get { return _modelo; }
        set { _modelo = value; }
    }
    public string Motor
    {
        get { return _motor; }
        set { _motor = value; }
    }
    public double VelocidadeMax
    {
        get { return _velocidadeMaxima; }
    }

    public bool Udado
    {
        get { return _usado; }
    }

    public int Cavalo
    {
        get { return _cp; }
    }

    public override void Descrever()
    {
        Console.WriteLine("\n\n------------------Descrição do Veículo------------------\n");
        Console.WriteLine($"Tipo.: {_tipo}");
        Console.WriteLine($"Marca.: {_marca}");
        Console.WriteLine($"Modelo.: {_modelo}");
        Console.WriteLine($"Motor.: {_motor}");
        Console.WriteLine($"Velocidade Máxima.: {_velocidadeMaxima}");
        Console.WriteLine($"Cavalo de Potência.: {_cp}");
        Console.WriteLine($"É usado.: {_usado}");
    }
}