Variáveis são espaços reservados na memória do computador e servem para armazenar valores que serão usados ao longo da execução do programa.

## Principais tipos de dados
string -> tipo que permite armazenar cadeia de caracteres.
int -> tipo que permite armazenar números inteiros(negativos e positivos).
double -> serve para números com vírgulas.
char -> serve para armazenar um único caracter.
bool -> valores negativos ou positivos.

Ex.:
```cs 
namespace endereco;

public class Program
{
	public static void Main(string[] args)
	{
		string nome = "Jeth Weber";
		int idade = 12;
		double altura = 1.80;
		char genero = 'M';
		bool estuda = true;
		bool namora = false;
		
		Console.WriteLine("Os dados armazenados são:\n");
		Console.WriteLine("Nome: " + nome);
		Console.WriteLine("Idade: " + idade.ToString());
		Console.WriteLine("Altura: " + altura.ToString());
		Console.WriteLine("Sexo: " + genero);
		Console.WriteLine("Estudante: " + estuda.ToString());
		Console.WriteLine("Namora: " + namora.ToString());
	}
}
```
