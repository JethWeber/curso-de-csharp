
namespace estudo23;

// Classes em C#
/**
    Objetivo.: Entender o que são classes e objetos, como criá-los em C# e como usá-los para 
    resolver problemas de forma prática e organizada.
*/

class Progam
{
    public static void Main(string[] args)
    {
        Console.Clear();
        // Instansiando a classe veículo para criar um carro com uma marca específica e alterar valores de atributos da classe
        Veiculo carrinho = new Veiculo();
        carrinho.Tipo = "Esportivo";
        carrinho.Marca = "BMW";
        carrinho.Modelo = "M3";
        carrinho.Velocidade = 350.9;
        Console.WriteLine("=====Dados Do Veículo=====");
        Console.WriteLine(carrinho.DescreverVeiculo());


        Console.WriteLine("\n\n");
        // Criando um cliente apartir da classe pessoa
        Pessoa Cliente = new Pessoa();
        Cliente.Nome = "Jeth Weber";
        Cliente.Idade = 24;
        Cliente.BI = "019929292LA88";
        Cliente.Nacionalidade = "Angolana";
        Cliente.ApresentarPessoa();


        Console.WriteLine("\n\n");
        
    }
}
