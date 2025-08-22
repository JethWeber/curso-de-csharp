
// Aula 25 - Este programa é para explorar os conceitos de encapsulamento na Linguagem C#.

namespace Estudo25;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Jeth Weber");

        // Usuario user1;
        // user1 = new Usuario("Jeth", "099222");

        // Usuario user2 = new Usuario("Adão", "09233");


        // List<Usuario> usuarios = new List<Usuario>() { user1, user2 };

        // foreach (var item in usuarios)
        // {
        //     Console.WriteLine($"Nome -> {item.Nome} |Senha -> {item.Senha}");
        // }


        Arma arma1 = new Arma("Fuzil", "AKM", 90, 2973378);
        Arma arma2 = new Arma("Fuzil", "RPG7", 21, 78237327);
        Arma arma3 = new Arma("Revolver", "Magnun", 507, 9282211);
        Arma arma4 = new Arma("Fuzil", "Berrety", 190, 21312312);
        Arma arma5 = new Arma("Pistola", "Glok", 9, 9128921);
        Arma arma6 = new Arma("Pistola", "Macarof", 22, 2343634);
        Arma arma7 = new Arma("Revolver", "Spy Strofsk", 16, 099283);
        Arma arma8 = new Arma("Fuzil", "AK47", 32, 93939);
        Arma arma9 = new Arma("Rifle", "M15", 21, 989383);
        Arma arma10 = new Arma("Fuzil", "F36", 12, 01922);

        Arma[] armas = new Arma[]
        {arma1, arma2, arma3, arma4, arma5, arma6, arma7, arma8, arma9, arma10};

        foreach (Arma arma in armas)
        {
            Console.WriteLine($"Tipo -> {arma.Tipo} | Marca -> {arma.Marca} | Calibre -> {arma.Calibre} | Serie -> {arma.Serie}");
        }

    }
}
