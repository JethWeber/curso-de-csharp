

// Neste arquivo vamos focar no encapsulamento com Método


namespace Estudo25;

class Arma
{
    // Propriedades autoimplementadas
    public string Tipo { get; set; }
    public string Marca { get; set; }
    public int Calibre { get; set; }
    private int _serieCode;


    public Arma(string inicialTipo, string inicialMarca, int inicialCalibre, int serie)
    {
        Tipo = inicialTipo;
        Marca = inicialMarca;
        Calibre = inicialCalibre;
        _serieCode = serie;
    }

    // Propriedade para retornar apenas o Código de Serie, ele não altera o valor dele.
    public int Serie
    {
        get { return _serieCode; }
    }


    // O único que consegue alterar o valor do atributo _serieCode
    public void AdicionarSerie(int serieAdicionar)
    {
        _serieCode = serieAdicionar;
        Console.WriteLine("Adicionada...");
    }

}