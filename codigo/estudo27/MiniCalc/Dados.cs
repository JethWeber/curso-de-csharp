// Esta é uma classe para praticar sobrescrita de métodos

namespace Estudo27;

class Dados
{
    protected double _primeiroNumero;
    protected double _segundoNumero;
    protected double _resultado;


    public Dados(double numero1, double numero2)
    {
        _primeiroNumero = numero1;
        _segundoNumero = numero2;
    }

    protected virtual void Sucesso(string argumento)
    {
        Console.WriteLine();
    }
}