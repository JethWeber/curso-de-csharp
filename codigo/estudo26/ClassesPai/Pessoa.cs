// Esta classe servirá de base para várias outras, explorando conceitos de Heranças em C#

namespace Estudo26;

class Pessoa
{
    // Os atributos com o modificador 'protected' as classes filhas podem acessa-las diretamente sem a necessidade de uma propriedade
    protected string _nome;
    protected int _idade;

    // Estes atributos não podem ser acessados por outras classes, nem mesmo as filhas ou derivadas desta
    private string _nacionalidade;
    private string _genero;

    // Construtors para inicializar os atributos de várias formas, depedendo do user
    public Pessoa(string nomeInicial, string generoInicial, string nacionalidadeInicial, int idadeInicial)
    {
        _nome = nomeInicial;
        _genero = generoInicial;
        _nacionalidade = nacionalidadeInicial;
        _idade = idadeInicial;
    }

    public Pessoa(string nomeInicial, string generoInicial, int idadeInicial)
    {
        _nome = nomeInicial;
        _genero = generoInicial;
        _nacionalidade = "Angolana";
        _idade = idadeInicial;
    }

    // Propriedades que serão acessadas por outras classes...
    public string Nome
    {
        get { return _nome; }
        set { _nome = value; }
    }

    public string Genero
    {
        get { return _genero; }
        set
        {
            if (value.ToLower().Contains("masculino") || value.ToLower().Contains("femenino"))
            {
                _genero = value;
            }
        }
    }
    public string Nacionalidade
    {
        get { return _nacionalidade; }
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

    // ESte método pode ser alterado pelas classes filhas, porque leva o modificador virtual
    public virtual void Crescer(int anosCrescido)
    {
        _idade += anosCrescido;
        Console.WriteLine($"Cresci um ano, agora tenho {_idade} anos de idde.");
    }
}