public class Program{
    public static void Main(string[] args)
    {
        Console.WriteLine("Digite seu nome: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite sua idade: ");
        int idade = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Olá " + nome + ", você tem " + idade.ToString() + " anos de idade.");

    }
}