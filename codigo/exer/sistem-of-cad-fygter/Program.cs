public class Program
{
    public static void Main(string[] args)
    {
        // Sistema de cadastro de lutadores
        List<string> lutadores = new List<string>();
        int cont = 1, op = 0;


        while (!(cont == 0))
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==============Bem-vindo ao sistema de cadastro de lutadores!==============\n");

            Console.WriteLine("01 - Cadastrar Lutador");
            Console.WriteLine("02 - Consultar Lutador");
            Console.WriteLine("03 - Eliminar Lutador");
            Console.WriteLine("04 - Listar Lutadores");
            Console.WriteLine("00 - Sair do sistema");
            Console.Write("\nDigite a opção desejada: ");
            op = int.Parse(Console.ReadLine());

            Console.WriteLine();

            if (op == 01 || op == 1)
            {
                Console.Clear();
                Console.WriteLine("=======================Cadastro de Lutadores=======================\n");
                Console.Write("Digite o nome do lutador: ");
                string lutador = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(lutador) && !lutadores.Contains(lutador))
                {
                    lutadores.Add(lutador);
                    Console.Clear();
                    Console.WriteLine("\nLutador cadastrado com sucesso!\nPressione qualquer tecla para continuar...");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nLutador inválido ou já cadastrado!\nPressione qualquer tecla para continuar...");
                    Console.ReadLine();
                }
            }
            else if (op == 02 || op == 2)
            {
                Console.Clear();
                Console.WriteLine("=======================Consulta de Lutadores=======================\n");
                Console.Write("Digite o nome do lutador: ");
                string lutador = Console.ReadLine();

                if (lutadores.Contains(lutador))
                {
                    Console.Clear();
                    Console.WriteLine($"\n======== RESULTADO DA BUSCA ========\n");
                    Console.WriteLine($"ID: {lutadores.IndexOf(lutador)}");
                    Console.WriteLine($"Nome: {lutador}");
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nLutador não encontrado!\nPressione qualquer tecla para continuar...");
                    Console.ReadLine();
                }
            }
            else if (op == 03 || op == 3)
            {
                Console.Clear();
                Console.WriteLine("=======================Eliminação de Lutadores=======================\n");
                Console.Write("Digite o nome do lutador: ");
                string lutador = Console.ReadLine();

                if (lutadores.Contains(lutador))
                {
                    lutadores.Remove(lutador);
                    Console.Clear();
                    Console.WriteLine("\nLutador eliminado com sucesso!\nPressione qualquer tecla para continuar...");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nLutador não encontrado!\nPressione qualquer tecla para continuar...");
                    Console.ReadLine();
                }
            }
            else if (op == 04 || op == 4)
            {
                Console.Clear();
                Console.WriteLine("=======================Lista de Lutadores=======================\n");
                if (lutadores.Count > 0)
                {
                    for (int i = 0; i < lutadores.Count; i++)
                    {
                        Console.WriteLine($"ID: {i} - Nome: {lutadores[i]}");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum lutador cadastrado.");
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadLine();
            }
            else if (op == 00 || op == 0)
            {
                cont = 0;
                Console.Clear();
                Console.WriteLine("Saindo do sistema. Até logo!");
                Console.WriteLine("Pressione qualquer tecla para sair...");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção inválida! Tente novamente.\nPressione qualquer tecla para continuar...");
                Console.ReadLine();
            }
        }

    }                                                                           
}