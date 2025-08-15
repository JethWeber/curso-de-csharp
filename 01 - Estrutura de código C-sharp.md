Criando o projecto no .NET CLI.
1. Primeiro cria-se  uma solução
	```sh 
	dotnet new sln -o nome_solucao
	cd nome_solucao
	```
2. Criar o projeto
	```sh 
	dotnet new console -o projeto #cria o projeto
	dotnet sln add projeto # add o projeto à solução
	```
3. Estrutura
A linguagem oferece a seguinte estrutura básica.
```cs 
namespace Projeto01;

public class Program{
	puplic static void Main(){
		
	}
}
```
Onde.:
>namespace -> é o indereço da classe.
>public class Program -> é a classe principal onde começa a execução
>public static void Main -> o método principal.

Esta aula foi apenas sobre cada elemento da estrutura básica de um projeto .NET com C#.