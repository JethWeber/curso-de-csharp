public class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        // Saudar();
        // Saudar("Jeth Weber");

        Console.WriteLine(Somar(192, 234));
        Console.WriteLine(CalcularArea(Convert.ToDecimal(23.23)));
        Console.WriteLine(CalcularArea(Convert.ToDecimal(2132133.23), Convert.ToDecimal(1323.9)));

    }


    //método sem retorno nem parâmetro
    public static void Saudar()
    {
        Console.Clear();
        Console.WriteLine("Saída do método sem parâmetro: Olá, como estás?!\n");
    }


    //método sem retorno com parâmetro
    public static void Saudar(string nome)
    {
        // Console.Clear();
        Console.WriteLine($"\nSaída do método com parâmetro: Olá, como estás {nome}?!\n");
    }

    // Método com Retorno
    static string Somar(int numero1, int numero2)
    {
        return $"Soma: {numero1} + {numero2} = {(numero1 + numero2).ToString()}";
    }


    // Sobrecarga - criar métodos com o memo nome, parâmetros diferentes(em numeros ou tipos)
    static string CalcularArea(decimal lado)
    {
        return $"A área do Quadrado {lado} x {lado} é  {lado*lado}Cm";
    }  

    static string CalcularArea(decimal comprimento, decimal largura)
    {
        return $"A área do Triângulo {comprimento}cm x {largura}cm é  {comprimento*largura}cm2";
    }
}
