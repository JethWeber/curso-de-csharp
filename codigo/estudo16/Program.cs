class Program
{
    static void Main(string[] args)
    {
        string[] nomes = {"Jeth Weber" , "Albert" , "Slowrs"};
        Console.WriteLine(nomes[2]);

        Console.Clear();
        foreach (string nome in nomes)
        {
            Console.WriteLine(nome);
        }

        //declarando sem atribuição
        int[] numeros = new int[9];

        Console.WriteLine(numeros.Length);
        
        for (int i = 0; i < 9; i++)
        {
            numeros[i] = i^2;
            Console.WriteLine($"Adicionando o Número {i^2} na posição {i}");
        }
    }
}