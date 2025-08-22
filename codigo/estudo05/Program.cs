public class Program
{
    public static void Main(string[] args)
    {

        Console.Write("Digite o primeiro numero: ");
        int var1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite o segundo numero: ");
        int var2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Soma: " + (var1+var2).ToString());
        Console.WriteLine("Subtração: " + (var1-var2).ToString());
        Console.WriteLine("Multiplicação: " + (var1*var2).ToString());
        Console.WriteLine("Divisão: " + (var1/var2).ToString());
        Console.WriteLine("Resto da divisão: " + (var1%var2).ToString());
        Console.WriteLine("Potência: " + (var1^var2).ToString());
    }    
}