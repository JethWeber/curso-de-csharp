
namespace Veiculos;

class Moto : Veiculo
{
    private int _cilindrada;

    public Moto(int cilindradaInicial, string marcaInicial, string modeloInicial, double velocidadeMaximaInicial)
        : base("Moto", marcaInicial, modeloInicial, velocidadeMaximaInicial)
    {
        _cilindrada = cilindradaInicial;
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

    public double VelocidadeMax
    {
        get { return _velocidadeMaxima; }
    }

    public bool Udado
    {
        get { return _usado; }
    }

    public int Cilindro
    {
        get { return _cilindrada; }
    }

    public override void Descrever()
    {
        Console.WriteLine("\n\n------------------Descrição do Veículo------------------\n");
        Console.WriteLine($"Tipo.: {_tipo}");
        Console.WriteLine($"Marca.: {_marca}");
        Console.WriteLine($"Modelo.: {_modelo}");
        Console.WriteLine($"Motor.: {_motor}");
        Console.WriteLine($"Velocidade Máxima.: {_velocidadeMaxima}");
        Console.WriteLine($"Cavalo de Potência.: {_cilindrada}");
        Console.WriteLine($"É usado.: {_usado}");
    }

}