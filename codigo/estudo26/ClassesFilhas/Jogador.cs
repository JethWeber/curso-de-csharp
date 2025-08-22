// Classe filha para pessoa

namespace Estudo26;

class Jogador : Pessoa
{
    private double _peso;
    private double _altura;
    public string Ala { get; }
    public string Team { get; set; }

    public Jogador(string nomeInicial, string generoInicial, string nacionalidadeInicial, int idadeInicial, double alturaInicial, double pesoInicial, string alaInicial, string teamInicial)
        : base(nomeInicial, generoInicial, nacionalidadeInicial, idadeInicial)
    {
        _peso = pesoInicial;
        _altura = alturaInicial;
        Ala = alaInicial;
        Team = teamInicial;
    }

    public double Peso
    {
        get { return _peso; }
        set
        {
            if (value > 0)
                _peso = value;
            else
                Console.WriteLine("O peso não pode ser negativo...");
        }
    }

    public double Altura
    {
        get { return _altura; }
        set
        {
            if (value > 0)
                _altura = value;
            else
                Console.WriteLine("A altura não pode ser negativo...");
        }
    }

    
    // Este método sobreescreve o método 'Crescer()' da classe 'Pessoa' que é a classe pai. Isso é feito pelo termo 'override'
    public override void Crescer(int anosCrescido)
    {
        _idade += anosCrescido - 2;
        Console.WriteLine($"Cresci um ano, agora tenho {_idade} anos de idde.");
    }
}