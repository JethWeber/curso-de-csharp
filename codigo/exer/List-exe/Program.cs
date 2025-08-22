using System;
public class Program
{
    public static void Main(string[] args)
    {
        // aula sobre listas em C#

        //declaração de uma lista
        List<string> nomes = new List<string>();
        List<int> numeros = new List<int>();

        // inicializando uma lista com valores
        List<string> frutas = new List<string>
        {
            "Manga",
            "Pera",
            "Abacaxi",
            "Morango",
            "Limão"
        };

        //adicionando elementos à lista
        nomes.Add("Jeth Weber");
        nomes.Add("Jeth Boy");
        nomes.Add("Hidden Hacker");
        nomes.Add("Borleth Homer");
        nomes.Add("Hugo Boss");
        nomes.Add("Alert Masck");


        //exibindo os elementos da lista
        Console.WriteLine("Nomes da Lista: ");
        foreach (string nome in nomes)
        {
            Console.WriteLine($"{nomes.IndexOf(nome).ToString()} {nome}");
        }

        //exibindo os elementos da lista de frutas
        Console.WriteLine("\nFrutas da Lista: ");
        foreach (string fruta in frutas)
        {
            Console.WriteLine($"{frutas.IndexOf(fruta).ToString()} {fruta}");
        }

        //adicionando números à lista
        numeros.Add(8128);
        numeros.Add(122);
        numeros.Add(34);
        numeros.Add(4565);
        numeros.Add(3434);
        numeros.Add(322);
        numeros.Add(43);

        //exibindo os números da lista
        Console.WriteLine("\nNúmeros da Lista: ");
        foreach (int numero in numeros)
            Console.WriteLine($"{numeros.IndexOf(numero).ToString()} {numero}");

        //contando coisas na lista
        Console.WriteLine($"\nTotal de Nomes: {nomes.Count}");
        Console.WriteLine($"Total de Frutas: {frutas.Count}");
        Console.WriteLine($"Total de Números: {numeros.Count}");


        //eliminando itens na lista
        Console.WriteLine("\nEliminando o item 'Hidden Hacker' da lista de nomes.");
        nomes.Remove("Hidden Hacker");

        Console.WriteLine("Eliminando o item 'Abacaxi' da lista de frutas.");
        frutas.Remove("Abacaxi");

        Console.WriteLine("Eliminando o item '4565' da lista de números.");
        numeros.Remove(4565);

        //exibindo os elementos restantes
        Console.WriteLine("\nNomes restantes na Lista: ");
        Console.WriteLine(string.Join(", ", nomes));

        Console.WriteLine("\nFrutas restantes na Lista: ");
        Console.WriteLine(string.Join(", ", frutas));

        Console.WriteLine("\nNúmeros restantes na Lista: ");
        Console.WriteLine(string.Join(", ", numeros));

        if (nomes.Contains("Jeth Weber"))
        {
            Console.WriteLine("\nO nome 'Jeth Weber' está na lista.");
        }
        else
        {
            Console.WriteLine("\nO nome 'Jeth Weber' não está na lista.");
        }

        // Ordenando a lista de nomes
        nomes.Sort();
        Console.WriteLine("\nNomes ordenados: ");
        Console.WriteLine(string.Join(", ", nomes));
        
    }
}