namespace estudo23;

class Pessoa
{
    // Definindo os atributos da classe como privado
    private string _nome;
    private int _idade;
    private string _bi;
    private string _nacionalidade;

    // Definindo as propriedades da classe como publicas para serem acessadas de quaisquer parte, estes é que acessam os atributos da classe
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
    public string BI
    {
        get { return _bi; }
        set { _bi = value; }
    }
    public string Nacionalidade
    {
        get { return _nacionalidade; }
        set
        {
            _nacionalidade = value;
        }
    }

    // Definindo o método da classe para retornar ou fazer a exibição dos dados coletados
    public void ApresentarPessoa()
    {
        // Console.Clear();

        Console.WriteLine("=====Dados Da Pessoa=====");

        Console.WriteLine($"Nome.: {Nome.Normalize()}");
        Console.WriteLine($"Idade.: {Idade}");
        Console.WriteLine($"BI.: {BI}");
        Console.WriteLine($"Nacionalidade.: {Nacionalidade}");
    }
}

