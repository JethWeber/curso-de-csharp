
public class Program
{
    public static void Main(string[] args)
    {
        int n1 = 12; //Atribuição simples
        // int n3 = 0; //Atribuição simples

        Console.WriteLine("Atribuição e Soma: " + (n1 += 3).ToString());

        n1 = 12;
        Console.WriteLine("Atribuição e Subtração: " + (n1 -= 5).ToString());

        n1 = 12;
        Console.WriteLine("Atribuição e Multiplicação: " + (n1 *= 2).ToString());

        n1 = 12;
        Console.WriteLine("Atribuição e Divisão: " + (n1 /= 6).ToString());

        n1 = 12;
        Console.WriteLine("Atribuição e Resto: " + (n1 %= 4).ToString());

        n1 = 12;
        Console.WriteLine("Valor original : " + n1 + "\nValor Incrementado: " + n1++);

        n1 = 12;
        Console.WriteLine("Valor original : " + n1 + "\nValor Decrementado: " + n1--);
        
    }
}