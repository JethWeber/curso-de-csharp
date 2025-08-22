public class Program{
    public static void Main(string[] args)
    {
        int i = 1;

        do {
        Console.WriteLine("Olá Mundo!");
        Console.Write("\n\nDigite 1 para continuar e 0 para parar.: ");
        i = Convert.ToInt32(Console.ReadLine());

        Console.Clear();

        // if(i == 0)
        //     brek;
        } while(!(i==0));
    }
}