// Nesta aula exploraremos conseitos de polimorfismo na linguagem C#.

using Veiculos;

namespace Estudo27;
class Program
{
    public static void Main(string[] args)
    {
        Carro carro = new Carro(1200, "Jesco", "Havera", "V12", 450, false);
        Moto[] motos = new Moto[10];

        motos[0] = new Moto(50, "LingKen", "Cinquentinha", 120);
        motos[1] = new Moto(180, "TVS", "Lisdond", 200);
        motos[2] = new Moto(20, "Jog", "Unic", 80);
        motos[3] = new Moto(890, "Yamaha", "Cisdom", 220);
        
        foreach (Moto moto in motos)
        {
            moto.Descrever();
        }
    }
}