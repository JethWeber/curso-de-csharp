public class Program
{
    public static void Main(string[] args)
    {
        int x = 12;
        int y = 20;

        Console.WriteLine(x == 10 && y == 20); //falso
        Console.WriteLine(y == 10 || y == 20); //verdadeiro
        Console.WriteLine(!(y == x)); //verdadeiro
    }
}