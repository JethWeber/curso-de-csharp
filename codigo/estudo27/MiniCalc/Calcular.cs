// Esta é a classe que vai ser filha

namespace Estudo27;

class Calcular : Dados
{
    public Calcular(double numero1, double numero2) : base(numero1, numero2) { }

    public double PrimeiroNumero
    {
        get { return _primeiroNumero; }
        set { _primeiroNumero = value; }
    }

    public double SegundoNumero
    {
        get { return _segundoNumero; }
        set { _segundoNumero = value; }
    }

    public double Somar()
    {
        Sucesso("Soma");
        return _primeiroNumero + _segundoNumero;
    }
    public double Somar(double segundoNumero)
    {
        Sucesso("Soma");
        return _primeiroNumero + segundoNumero;
    }
    public double Subtrair()
    {
        Sucesso("Subitração");
        return _primeiroNumero + _segundoNumero;
    }
    public double Dividir()
    {
        if (_primeiroNumero != 0 && _segundoNumero != 0)
            _resultado = _primeiroNumero / _segundoNumero;
            Sucesso("Divisão");
        return _resultado;
    }
    public double Multiplica()
    {
        Sucesso("Multiplicação");
        return _primeiroNumero * _segundoNumero;
    }
    public double Resto()
    {
        Sucesso("Resto");
        return _primeiroNumero % _segundoNumero;
    }
    public double Potencia()
    {
        Sucesso("Potência");
        return Math.Pow(_primeiroNumero, _segundoNumero);
    }

    protected override void Sucesso(string argumento)
    {
        Console.WriteLine($"{argumento} Efetuada com êxito!");
    }
}
