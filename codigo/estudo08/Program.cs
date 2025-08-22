public class Program
{
    public static void Main(string[] args)
    {
        var idade = 0;
        const int ano_atual = 2025;
        dynamic ano_nasci;
        dynamic resultado;

        Console.Write("Digite a sua idade: ");
        idade = Convert.ToInt32(Console.ReadLine());

        ano_nasci = ano_atual - idade;

        if(idade == 10)
        {
            resultado = "Ou, vc tem apenas " + idade.ToString() + " de idade";
        }
        else if (idade >= 18 )
        {
            resultado = "Ou, vc é maior de idade, nasceu em " + ano_nasci.ToString() + "!";
        }
        else if (idade < 6 )
        {
            resultado = "Ou, vc é um BB, tens " + idade.ToString() + " de idade";
        }
        else if (idade > 6 )
        {
            resultado = "Vc não é mas criança, tens " + idade.ToString() + " de idade";
        }
        else if (idade <= 12 )
        {
            resultado = "Ou, vc nem é adolescente, tens " + idade.ToString() + " de idade";
        }
        else if (idade != 6 )
        {
            resultado = "Ou, vc tem apenas " + idade.ToString() + " de idade";
        }
        else{resultado = "Molou!";}
        Console.WriteLine(resultado);
    }
}