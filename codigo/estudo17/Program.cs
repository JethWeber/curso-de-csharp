public class Program
{
    public static void Main(string[] args)
    {
        List<int> numeros = new List<int>(); //Criada
        numeros.Add(82); //adicionando intem
        numeros.Add(5);
        numeros.Add(4);
        numeros.Add(7);
        numeros.Add(4);
        numeros.Add(54);
        numeros.Add(34);

        

        foreach (int numero in numeros)
        {
            Console.WriteLine($" {numero}" );
        }
        numeros.Remove(82); //removendo item

         foreach (int numero in numeros)
        {
            Console.WriteLine($"N {numero}" );
        }
    }
}