// Arquivo criado para estudar herança de classes em C#

namespace Estudo26;

class Program 
{
    public static void Main(string[] args)
    {
        Console.Clear();

        Jogador jogador1 = new Jogador("Jeth", "Masculino", "Angolana", 23, 1.91, 69, "Direita", "Weber FCB");
        jogador1.Crescer(23);

    }
}