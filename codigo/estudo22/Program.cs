class Program
{
    /**
        Este arquivo foi escrito com o objetivo de mostrar e executar progrmas criado com base no conhecimento
        que foi obtido no capítulo dos fundamentos da Linguagem C#. 

        Aqui serão criados 5 programas separados em métodos, em cada um desses métodos se explorará 
        conhecimentos obtidos ao longo do capítulo.
    
    */


    public static void Programa01_CalculadoraIMC()
    {
        // PROGRAMA 01 - CALCULADORA DE IMC
        /**
            Objetivo.: Criai um progrma que leia o peso (em kg) e a altura (em metros), calcule o IMC com a formula
            'peso / (altura * altura) e informe a categoria do IMC encontrado:
                - Abaixo do peso : IMC < 18.5
                - Normal : IMC entre 18.5 e 24.9
                - Sobrepeso : IMC entre 25 e 29.9
                - Obeso : IMC >= 30
            
            Requisitos
            {   - Use **constantes** para os limites de IMC (ex.: `const double LimiteAbaixoPeso = 18.5`).
                - Leia os dados com **entrada/saída** (`Console.ReadLine` e `Console.WriteLine`).
                - Use **conversão de tipos** (`double.Parse` ou `double.TryParse`) para os valores inseridos.
                - Use **if-else** para determinar a categoria.
                - Adicione **comentários** claros e siga **boas práticas** (nomes descritivos, organização).
            }
        */

        // Variaveis e contsntes que serão usadas para efetuar as operações.
        const double LimiteBaixoPeso = 18.5;
        string resultado = "";
        string nomePaciente = "";
        double peso = 0.0;
        double altura = 0.0;
        double ValorIMC = 0.0;


        while (true)
        {

            // Menu de boasvindas e colheita de dados
            Console.WriteLine(Banner_BoasVindas("Benvindo A Calculadora de IMC"));

            Console.Write("Digite o seu nome.: ");
            nomePaciente = Console.ReadLine();

            Console.Write($"{nomePaciente}, digite o seu peso (em kg).: ");
            if (double.TryParse(Console.ReadLine(), out peso) == false)
            {
                Console.WriteLine($"{nomePaciente.Normalize()}, o valor digitado é inválido, tenta novamente...");
                Environment.Exit(0);
            }

            Console.Write($"{nomePaciente}, digite a sua altura (em metro).: ");
            if (double.TryParse(Console.ReadLine(), out altura) == false)
            {
                Console.WriteLine($"{nomePaciente.Normalize()}, o valor digitado é inválido, tenta novamente...");
                Environment.Exit(0);
            }

            // Efetuando o cáluco para a obtensão do IMC
            ValorIMC = peso / (altura * altura);

            // Tomando a decisão
            if (ValorIMC < LimiteBaixoPeso)
            {
                resultado = "Baixo";
            }
            else if (ValorIMC >= LimiteBaixoPeso && ValorIMC <= 24.9)
            {
                resultado = "Normal";
            }
            else if (ValorIMC >= 25 && ValorIMC <= 29.9)
            {
                resultado = "Sobrepeso";
            }
            else
            {
                resultado = "Obeso";
            }

            // Exibindo o Resultado Final
            Console.Clear();

            Console.WriteLine("\n\n==== RESULTADO FINAL ====\n");
            Console.WriteLine("Nome.: " + nomePaciente);
            Console.WriteLine("Peso (em kg).: " + peso);
            Console.WriteLine("Altura (em metro).: " + altura);
            Console.WriteLine("IMC.: " + ValorIMC);
            Console.WriteLine("Situação.: " + resultado);
            Console.WriteLine();

            Console.Write("Deseja Continuar?! (s/n).: ");
            if (Console.ReadLine().ToLower() == "n")
            {
                Console.WriteLine("Tenha um bom dia...\n\n\n");
                Environment.Exit(0);
            }
        }

    }

    public static void Programa02_Contador_de_Numero()
    {
        // Programa 02 - Contador de Números
        /**
            Objetivo.: Receber um número do usuário e exibir todos os números pares de 1 té N(o número recebido).

            Requisitos
            {
                - Use **while** para percorrer os números.
                - Use **operadores relacionais** (ex.: `<=`) e **aritméticos** (ex.: `%` para verificar paridade).
                - Use **conversão de tipos** (`int.TryParse`) para ler o número com segurança.
                - Se o usuário digitar um número inválido, mostre uma mensagem de erro.
                - Adicione **comentários** e siga **boas práticas**.
            }
        */

        int numero, contador = 1;

        // Boasvindas, recebendo e tratando o valor recebido
        Console.Clear();
        Console.WriteLine(Banner_BoasVindas("Benvindo ao contador de números pares"));

        Console.Write("Digite o número desejado.: ");
        if (int.TryParse(Console.ReadLine(), out numero) == false)
        {
            Console.WriteLine("Número inválido, digite um inteiro(1, 6, 4, 10...)");
            Environment.Exit(0);
        }

        while (contador <= numero)
        {
            if (contador % 2 == 0)
            {
                Console.WriteLine("Número.: " + contador);
            }
            contador++;
        }

        Console.WriteLine("\nFim da execução do programa...\n\n\n");
    }

    public static void Programa03_Media_de_Notas_Com_Array()
    {
        // Programa 03 - Média de Notas Com Array
        /**
            Objetivo.: Ler quatro notas de um aluno(armazenar em um array), calcule a média e informe:
            media < 7: Reprovado
            media entre 7 e 9: Recurso
            media > 9: Aprovado

            Requisitos
            {
                - Use um **array** de `double` para armazenar as 4 notas.
                - Leia as notas com **entrada/saída** e **conversão de tipos** (`double.TryParse`).
                - Crie um **método** com retorno para calcular a média.
                - Use **for** ou **foreach** para somar as notar.
                - Mostre a média e se o aluno foi aprovado (usando **if-else**).
                - Siga **boas práticas** e adicione **comentários**.
            }
        */

        // Variáveis do programa
        double[] notas = new double[4];
        string situacao = "";


        // Boasvindas
        Console.WriteLine(Banner_BoasVindas("Benvindo a calculadora de médias de notas"));

        // Coletando os dados do usuário
        Console.Write("Digite o seu nome.: ");
        string nome = Console.ReadLine();

        Console.Write($"{nome}, digite a primeira nota.: ");
        if (double.TryParse(Console.ReadLine(), out notas[0]) == false)
        {
            Console.WriteLine($"{nome.Normalize()}, digite uma nota válida...\n");
            Environment.Exit(0);
        }

        Console.Write($"{nome}, digite a segunda nota.: ");
        if (double.TryParse(Console.ReadLine(), out notas[1]) == false)
        {
            Console.WriteLine($"{nome.Normalize()}, digite uma nota válida...\n");
            Environment.Exit(0);
        }

        Console.Write($"{nome}, digite a terceira nota.: ");
        if (double.TryParse(Console.ReadLine(), out notas[2]) == false)
        {
            Console.WriteLine($"{nome.Normalize()}, digite uma nota válida...\n");
            Environment.Exit(0);
        }

        Console.Write($"{nome}, digite a quarta nota.: ");
        if (double.TryParse(Console.ReadLine(), out notas[3]) == false)
        {
            Console.WriteLine($"{nome.Normalize()}, digite uma nota válida...\n");
            Environment.Exit(0);
        }

        // Analizando a média
        double media = _calcular_media(notas[0], notas[1], notas[2], notas[3]);

        if (media < 7)
        {
            situacao = "Reprovado";
        }
        else if (media >= 7 && media <= 9)
        {
            situacao = "Recurso";
        }
        else
        {
            situacao = "Aprovado";
        }


        // Exibindo a saida formatada
        Console.Clear();

        Console.WriteLine("=========RESULTADO FINAL=========");
        Console.WriteLine("Nome.: " + nome);
        Console.WriteLine("Primeira nota.: " + notas[0]);
        Console.WriteLine("Segunda nota.: " + notas[1]);
        Console.WriteLine("Terceira nota.: " + notas[2]);
        Console.WriteLine("Quarta nota.: " + notas[3]);
        Console.WriteLine("Média Final.: " + media);
        Console.WriteLine($"\n-----{situacao}-----".ToUpper());
        Console.WriteLine("\n\n");

    }

    public static void Programa04_Lista_de_Nomes_Favoritos()
    {
        // Programa 04 - Lista de Nomes Favoritos
        /**
            Objetivo.: Permita que o usuário adicione 3 nomes a uma **lista** e, depois, mostre os nomes em ordem alfabética.

            Requisitos
            {
                - Use uma **List** _string_ para armazenar os nomes. 
                - Leia os nomes com entrada/saída (```Console.ReadLine```).
                - Use o método `Add` para adicionar nomes e ```Sort``` para ordenar.
                - Mostre os nomes com foreach.
                - Crie um **método** para exibir a lista.
                - Siga **boas práticas** e adicione **comentários**.
            }
        */

        // Variáveis do programa
        List<string> nomes = new List<string>(3);

        // Boasvindas
        Console.WriteLine(Banner_BoasVindas("Benvindo a lista dos seus nomes favoritos"));

        // Recebendo os dados do usuario e adicionando os ao array
        Console.Write("Digite o primeiro nome.: ");
        nomes.Add(Console.ReadLine());

        Console.Write("Digite o segundo nome.: ");
        nomes.Add(Console.ReadLine());

        Console.Write("Digite o terceiro nome.: ");
        nomes.Add(Console.ReadLine());

        nomes.Sort();

        _exibir_lista(nomes);

        Console.WriteLine("\n\nAté a próxima...\n\n\n");

    }

    public static void Programa05_Menu_Interativo()
    {
        // Menu Interativo Para Escolha de Operações Matemáticas
        /**
            **Objetivo**: Crie um menu interativo com 3 opções:
            1. Somar dois números.
            2. Multiplicar dois números.
            3. Sair.
            O programa deve repetir até o usuário escolher a opção 3.

            **Requisitos
            {
                - Use **entrada/saída** para ler a opção e os números.
                - Use **switch-case** para processar as opções.
                - Use **do-while** para repetir o menu até escolher "Sair".
                - Crie **métodos** com retorno para somar e multiplicar.
                - Use **conversão de tipos** (`int.TryParse`) para ler números com segurança.
                - Respeite o **escopo** (use variáveis locais nos métodos certos).
                - Siga **boas práticas** e adicione **comentários**.            
            }
        */

        // Variáveis do programa
        int opcao;
        string resultado;

        do
        {
            // boas vindas
            Console.WriteLine(Banner_BoasVindas("Benvindo ao menu intertivo"));

            // Exibindo o menu e recebendo a interação do user
            Console.WriteLine("1 - Somar dois números.");
            Console.WriteLine("2 - Multiplicar dois números.");
            Console.WriteLine("3 - Sair.");

            Console.Write("Informe a opção.: ");
            int.TryParse(Console.ReadLine(), out opcao);

            switch (opcao)
            {
                case 1:
                    Somar_numeros();
                    break;
                case 2:
                    Multiplicar_numeros();
                    break;
                case 3:
                    Somar_numeros();
                    break;
                default:
                    Console.WriteLine("Opção inválida...");
                    break;
            }

            if (true)
            {
                
            }




        } while (!(opcao == 0));




    }
    public static void Main(string[] args)
    {
        // Programa01_CalculadoraIMC();
        // Programa02_Contador_de_Numero();
        // Programa03_Media_de_Notas_Com_Array();
        // Programa04_Lista_de_Nomes_Favoritos();
        Programa05_Menu_Interativo();
    }

    // Metodo para exibir o banner de boasvindas
    public static string Banner_BoasVindas(string titulo)
    {
        Console.Clear();
        return $"\n\n\n================{titulo}================\n".ToUpper();
    }

    // Métodos auxiliar ao programa 03
    public static double _calcular_media(double nota1, double nota2, double nota3, double nota4)
    {
        double media = (nota1 + nota2 + nota3 + nota4) / 4;
        return media;
    }

    // Método auxiliar ao programa 04
    public static void _exibir_lista(List<string> nomes)
    {
        Console.Clear();

        Console.WriteLine("\n\n-----------A TUALISTA CONTÊM-----------\n");
        foreach (var item in nomes)
        {
            Console.WriteLine($"{nomes.IndexOf(item) + 1} - {item}");
        }
        Console.WriteLine("\nFim da lista");
    }

    // Método auxiliar ao programa 05
    public static int Somar_numeros()
    {
        int numero1;
        int numero2;

        Console.WriteLine(Banner_BoasVindas("Somar numeros"));

        Console.Write("Digite o primeiro numero.: ");
        if (!int.TryParse(Console.ReadLine(), out numero1))
        {
            Console.WriteLine("Número inválido...");
            Environment.Exit(0);
        }

        Console.Write("Digite o segundo numero.: ");
        if (!int.TryParse(Console.ReadLine(), out numero2))
        {
            Console.WriteLine("Número inválido...");
            Environment.Exit(0);
        }


        return numero1 + numero2;
    }

    // Método auxiliar ao programa 05
    public static int Multiplicar_numeros()
    {
        int numero1;
        int numero2;

        Console.WriteLine(Banner_BoasVindas("Somar numeros"));

        Console.Write("Digite o primeiro numero.: ");
        if (!int.TryParse(Console.ReadLine(), out numero1))
        {
            Console.WriteLine("Número inválido...");
            Environment.Exit(0);
        }

        Console.Write("Digite o segundo numero.: ");
        if (!int.TryParse(Console.ReadLine(), out numero2))
        {
            Console.WriteLine("Número inválido...");
            Environment.Exit(0);
        }


        return numero1 * numero2;
    }

}