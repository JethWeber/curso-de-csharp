public class Program
{
    public static void Main(string[] args)
    {
        List<int> lista_numerica = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        foreach (int numero in lista_numerica)
        {
            Console.WriteLine($"Item {numero}");
        }
    }
}