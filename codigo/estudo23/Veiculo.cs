namespace estudo23;

class Veiculo
{
    // Os atributos são privados para serem acessados via propriedade
    private string tipo;
    private string marca;
    private string modelo;
    private double velocidade;

    // Propriedades da classe
    public string Tipo
    {
        get { return tipo; }
        set { tipo = value; }
    }
    public string Marca
    {
        get { return marca; }
        set { marca = value; }
    }
    public string Modelo
    {
        get { return modelo; }
        set { modelo = value; }
    }
    public double Velocidade
    {
        get { return velocidade; }
        set
        {
            if (value > 0)
                velocidade = value;
        }
    }
    public string DescreverVeiculo()
    {
        return $"O Veículo é.: {tipo},\nDa Marca.: {marca},\nModelo.: {modelo}\nAtinge.: {velocidade} Km/h";
    }
    
}
