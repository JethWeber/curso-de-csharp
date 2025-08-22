/**
    Objetivo.: Entender o que são métodos construtores, como declará-los em C# e 
    como usá-los para inicializar objetos de forma prática e segura.
*/

namespace Estudo24;

class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();

        // Criando o primeiro Computador(objeto)
        // Computador pc1 = new Computador();
        // pc1.Tipo = "Notebook";
        // pc1.Marca = "HP";
        // pc1.Modelo = "EliteBook 2560p";
        // pc1.Geracao = 1;
        // pc1.CPU = "Intel i7";
        // pc1.GPU = "Integrated DX06";
        // pc1.RAM = "DDR4 6GB";
        // pc1.Tamanho = "Grande";
        // pc1.Cor = "Cinza";
        // pc1.ApresentrPC();


        // Instanciando com o construtor padrão
        Animal MeuAnimal = new Animal();
        MeuAnimal.Especie = "Cão";
        MeuAnimal.Raca = "Pastor Alemão";
        MeuAnimal.Nome = "Drácula";
        MeuAnimal.Idade = 2;
        MeuAnimal.Peso = 36.92;

        // Instanciando com o construtor sem a raca
        Animal AnimalVizinho = new Animal("Cobra", "Janaina" , 3, 2.9);

        // Instanciando com o construtor com raça e nome
        Animal AnimalDesconhecido = new Animal("Cobra", "Janaina");


        // Exibindo os dados de todos osconstrutores
        MeuAnimal.MostrarAnimal();
        AnimalVizinho.MostrarAnimal();
        AnimalDesconhecido.MostrarAnimal();

        Console.WriteLine("\n\n");
    }
}
