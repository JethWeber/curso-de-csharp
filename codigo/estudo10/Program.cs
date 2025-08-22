public class Program
{
    public static void Main()
    {
        Console.Clear();

        dynamic operador;
        dynamic resultado;

        Console.Write("Digite o Primeiro número: ");
        Decimal numero1 = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Digite o Primeiro número: ");
        Decimal numero2 = Convert.ToDecimal(Console.ReadLine());

        Console.Clear();

        Console.Write("\nEscolha a operação\n".ToUpper());
        Console.WriteLine("00 - Soma".ToUpper());
        Console.WriteLine("01 - Subtração".ToUpper());
        Console.WriteLine("02 - Multiplicação".ToUpper());
        Console.WriteLine("03 - Divisão".ToUpper());
        Console.WriteLine("04 - Resto da Divisão".ToUpper());
        Console.WriteLine("05 - Potência\n".ToUpper());
        Console.Write("Digite Aqui.: ");
        operador = Console.ReadLine();

        if (operador == "0" || operador == "00")
        {
            resultado = "A soma de " + numero1.ToString() + " + " + numero2.ToString() + " = " + (numero1 + numero2).ToString();
        }
        else if (operador == "1" || operador == "01")
        {
            resultado = "A Subtração de " + numero1.ToString() + " - " + numero2.ToString() + " = " + (numero1 - numero2).ToString();
        }
        else if (operador == "2" || operador == "02")
        {
            resultado = "A Multiplicação de " + numero1.ToString() + " X " + numero2.ToString() + " = " + (numero1 * numero2).ToString();
        }
        else if (operador == "3" || operador == "03")
        {
            resultado = "A Divisão de " + numero1.ToString() + " / " + numero2.ToString() + " = " + (numero1 / numero2).ToString();
        }
        else if (operador == "4" || operador == "04")
        {
            resultado = "O Resto da Divisão de " + numero1.ToString() + " % " + numero2.ToString() + " = " + (numero1 % numero2).ToString();
        }
        else if (operador == "5" || operador == "05")
        {
            resultado = "A Potência de " + numero1.ToString() + " ^ " + numero2.ToString() + " = " + (Math.Pow(Convert.ToDouble(numero1), Convert.ToDouble(numero2))).ToString();
        }
        else
            resultado = "Operação Inválida";

        Console.Clear();
        Console.WriteLine(resultado);

    }
}