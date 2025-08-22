public class Program
{
    public static void Main(string[] args)
    {
        const string constante = "Valor Padrão";

        Console.WriteLine("Constante: " + constante);

        dynamic dinamico = "Arroz";
        Console.WriteLine("1º Valor Dinamico : " + dinamico);

        dinamico = "Feijão";
        Console.WriteLine("2º Valor Dinamico : " + dinamico);

        dinamico = 13;
        Console.WriteLine("3º Valor Dinamico : " + dinamico);
    }
}