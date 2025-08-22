// Classe pai para moto e carro

namespace Veiculos;


class Veiculo
{
    protected string _tipo;
    protected string _marca;
    protected string _modelo;
    protected string _motor;
    protected double _velocidadeMaxima;
    protected bool _usado;

    public Veiculo(string tipoInicial, string marcaInicial, string modeloInicial, string motorInicial, double velocidadeMaximaInicial, bool usadoInicial)
    {
        _tipo = tipoInicial;
        _marca = marcaInicial;
        _modelo = modeloInicial;
        _motor = motorInicial;
        _velocidadeMaxima = velocidadeMaximaInicial;
        _usado = usadoInicial;
    }

    public Veiculo(string tipoInicial, string marcaInicial, string modeloInicial, double velocidadeMaximaInicial)
    {
        _tipo = tipoInicial;
        _marca = marcaInicial;
        _modelo = modeloInicial;
        _motor = "V2";
        _velocidadeMaxima = velocidadeMaximaInicial;
        _usado = false;
    }

    public virtual void Descrever()
    {
        Console.WriteLine("\n\n------------------Descrição do Veículo------------------\n");
        Console.WriteLine($"Tipo.: {_tipo}");
        Console.WriteLine($"Marca.: {_marca}");
        Console.WriteLine($"Modelo.: {_modelo}");
        Console.WriteLine($"Motor.: {_motor}");
        Console.WriteLine($"Velocidade Máxima.: {_velocidadeMaxima}");
        Console.WriteLine($"É usado.: {_usado}");
    }
}
