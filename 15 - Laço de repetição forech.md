Este laço de repetição é popularmente utilisado para percorrer uma dada coleção de valores.
Ex.:
```cs 
public class Program
{
    public static void Main(string[] args)
    {
        List<int> lista_numerica = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8};

        foreach (int numero in lista_numerica)
        {
            Console.WriteLine($"Item {numero}");
        }
    }
}
```