/*
    Esta classe será o molde para a criação de vários computadores em uma loja.
    
    Objetivo.: Praticar construtores simples em C#.

*/

namespace Estudo24;

class Computador
{
    // Atributos da Classe
    private string _tipo;
    private string _marca;
    private string _modelo;
    private int _geracao;
    private string _cpu;
    private string _gpu;
    private string _ram;
    private string _tamanho;
    private string _cor;

    // Construtor da Classe
    public Computador()
    {
        _tipo = "DeskTop";
        _marca = "HP";
        _modelo = "EliteDesktop";
        _geracao = 2;
        _cpu = "Dual Core 4 Trads";
        _gpu = "Intel Padron";
        _ram = "DDR1 2x2GB";
        _tamanho = "Médio";
        _cor = "Preto";

        Console.WriteLine("Novo PC criado...");
    }

    // Propriedade da classe
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
    public int Geracao
    {
        get { return _geracao; }
        set
        {
            if (value > 0)
                _geracao = value;
        }
    }
    public string CPU
    {
        get { return _cpu; }
        set { _cpu = value; }
    }
    public string GPU
    {
        get { return _gpu; }
        set { _gpu = value; }
    }
    public string RAM
    {
        get { return _ram; }
        set { _ram = value; }
    }
    public string Tamanho
    {
        get { return _tamanho; }
        set { _tamanho = value; }
    }
    public string Cor
    {
        get { return _cor; }
        set { _cor = value; }
    }

    // Método para exibir os valores dos atributos
    public void ApresentrPC()
    {
        Console.WriteLine("\n\n------------------Apresentando o PC------------------\n");
        Console.WriteLine($"Tipo.: {Tipo}");
        Console.WriteLine($"Marca.: {Marca}");
        Console.WriteLine($"Modelo.: {Modelo}");
        Console.WriteLine($"Geração.: {Geracao}");
        Console.WriteLine($"CPU.: {CPU}");
        Console.WriteLine($"GPU.: {GPU}");
        Console.WriteLine($"RAM.: {RAM}");
        Console.WriteLine($"Tamanho.: {Tamanho}");
        Console.WriteLine($"Cor.: {Cor}");
    }
    

}