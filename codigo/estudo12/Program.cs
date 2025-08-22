public class Programa{
    public static void Main(string[] args)
    {
        int dia, i = 1;
        string dia_semana;

        Console.Clear();

        while (!(i==0))
        {
            Console.Write("De 1 a 7, digite um número.: ");
            dia = Convert.ToInt32(Console.ReadLine());

            switch (dia)
            {
                case 1:
                    dia_semana = "Domingo";
                    break;
                case 2:
                    dia_semana = "Segunda";
                    break;
                case 3:
                    dia_semana = "Terça";
                    break;
                case 4:
                    dia_semana = "Quarta";
                    break;
                case 5:
                    dia_semana = "Quinta";
                    break;
                case 6:
                    dia_semana = "Sexta";
                    break;
                case 7:
                    dia_semana = "Sábado";
                    break;
                default:
                    dia_semana = "Dia Inválido!";
                    break;

            }
            Console.Clear();

            Console.WriteLine("\n\n" + dia_semana);

            Console.Write("\nDigite 1 para continuar ou 0 para parar.: ");
            i = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            if (i == 0)
                break;
        }

    }
}