using System.Reflection.Metadata;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(ConversaoImplicita(19));
        Console.WriteLine(ConversaoExplicita(273.29));
        Console.WriteLine(ParseInt("23"));
        Console.WriteLine(ParseDecimal("23,99"));
        Console.WriteLine(ParseDouble("23,21"));
        Console.WriteLine(ParseBool("true"));
        Console.WriteLine(TryParse("ab"));

    }

    // Cast - Conversão entre tipos inteiros

    // 1.1 - Conversão Implícita
    static string ConversaoImplicita(int inteiro)
    {
        double real = inteiro;
        return $"O número inteiro {inteiro} foi convertido para real {real}";
    }


    // 1.2 - Conversão Explícita
    static string ConversaoExplicita(double real)
    {
        int inteiro = (int)real;
        return $"O número real {real} foi convertido para inteiro {inteiro}";
    }

    // 2 - Parse - Texto para outro tipo
    static string ParseInt(string texto)
    {
        int inteiro = int.Parse(texto);
        return $"O texto '{texto}' foi convertido para o número inteiro: {inteiro}";
    }

    static string ParseDouble(string texto)
    {
        double real = double.Parse(texto);
        return $"O texto '{texto}' foi convertido para o número double: {real}";
    }

    static string ParseDecimal(string texto)
    {
        decimal decimale = decimal.Parse(texto);
        return $"O texto '{texto}' foi convertido para o número decimal: {decimale}";
    }

    static string ParseBool(string texto)
    {
        bool boleano = bool.Parse(texto);
        return $"O texto '{texto}' foi convertido para o boleano {boleano}";
    }

    // 3 - TryParse - Converão segura de Texto

    static string TryParse(string texto)
    {
        int inteiro;

        return $"O texto '{texto}' foi convertido para inteiro  com o TryParse: {int.TryParse(texto, out inteiro)}";
    }
}