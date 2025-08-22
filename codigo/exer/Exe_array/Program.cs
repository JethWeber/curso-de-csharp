public class Program
{
    public static void Main(string[] args)
    {
        //array --- unidimencional
        string[] nomes = new string[6];
        nomes[0] = "Paulo";
        nomes[1] = "João";
        nomes[2] = "Venácios";
        nomes[3] = "Felipe";
        nomes[4] = "Dadão";
        nomes[5] = "Morgoth";

        int i = 0;
        foreach (var nome in nomes)
        {
            Console.WriteLine(nome[i]);
            i++;
        }


        // tipo_dados[] nome = {dado1, dado2, dado3, dado4};
        // tipo_dados[] nome = new tipo_dados[4];
        // tipo_dados[,] nome = new tipo_dados[4,4];

        string[] nomess = new string[5];
        int[] idades = new int[5];
        float[] peso = new float[5];

        nomess.Append("João Paulo");
        idades.Append(19);


        dynamic[] dadoss = new dynamic[2];
        dynamic[] dados2 = { "João", 19, 1.9, 'M', Convert.ToDecimal(12.23) };
        dadoss[0] = "João Paulo";
        dadoss[1] = 19;


        Console.Clear();
        foreach (dynamic dado in dadoss)
        {
            Console.WriteLine(dado.ToString());
        }

        Console.Clear();
        foreach (dynamic dado2 in dados2)
        {
            Console.WriteLine(dado2.ToString());
        }
        //array multidimen
        dynamic[,] dados = new dynamic[3, 3];

        dados[0, 0] = "1";
        dados[0, 1] = "2";
        dados[0, 2] = "3";
        dados[1, 0] = "4";
        dados[1, 1] = "5";
        dados[1, 2] = "6";
        dados[2, 0] = "7";
        dados[2, 1] = "8";
        dados[2, 2] = "9";

        Console.Clear();

        // foreach (dynamic dado3 in dados)
        // {
        //     Console.WriteLine($"{dado3}");
        // }
        
        for (int iq = 0; iq < dados.GetLength(0); iq++) // Itera sobre as linhas
        {
            for (int j = 0; j < dados.GetLength(1); j++) // Itera sobre as colunas
            {
                Console.Write($"{dados[iq, j],-4}"); // Exibe o elemento com alinhamento
            }
            Console.WriteLine(); // Nova linha após cada linha da matriz
        }

    }
}