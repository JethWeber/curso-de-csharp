
# Fundamentos Da Linguagem C#

## **Aula 02 — Variáveis**

Seja bem-vindo à segunda aula\! Agora que você já configurou o ambiente, vamos começar a dar vida aos nossos programas. Nesta aula, vamos entender o que são **variáveis** e como elas nos ajudam a manipular dados.

-----

### **1. O que são variáveis?**

Variáveis são como caixinhas rotuladas que guardam informações na memória do computador. Elas nos permitem armazenar, ler e modificar dados enquanto nosso programa está em execução.

**Para que servem?**
Imagine que você precisa guardar a idade de uma pessoa, o nome de um usuário ou o preço de um produto. Em vez de usar os valores diretamente no código, você os guarda em variáveis, o que torna o programa mais flexível e fácil de ler.

-----

### **2. Conhecendo os Tipos de Dados**

Em C\#, toda variável precisa de um **tipo de dado** para saber que tipo de informação ela pode guardar. Isso é como escolher o tipo de embalagem certo para o que você vai guardar.

| Tipo de Dado | O que Armazena | Exemplo |
| :--- | :--- | :--- |
| `string` | Textos, palavras ou frases inteiras. | `"Jeth Weber"`, `"Olá, mundo!"` |
| `int` | Números inteiros (sem decimais). | `12`, `1000`, `-5` |
| `double` | Números com vírgula ou decimais. | `1.80`, `3.14`, `9.99` |
| `char` | Um único caractere, entre aspas simples. | `'M'`, `'a'`, `'?'` |
| `bool` | Um valor lógico: verdadeiro ou falso. | `true`, `false` |

-----

### **3. Criando e Usando Variáveis na Prática**

A sintaxe para criar uma variável é sempre a mesma: **`tipo nomeDaVariavel = valor;`**

Vamos usar o código que você me enviou para detalhar cada parte. Crie um novo arquivo `Program.cs` no seu projeto ou edite o existente, e digite o código abaixo.

```csharp
namespace Endereco;

public class Program
{
    public static void Main()
    {
        // 1. Declarando e inicializando variáveis
        string nome = "Jeth Weber"; // 'string' é o tipo, 'nome' é o nome da variável
        int idade = 12;            // 'int' para número inteiro
        double altura = 1.80;      // 'double' para número com decimal
        char genero = 'M';         // 'char' para um único caractere
        bool estuda = true;        // 'bool' para um valor verdadeiro
        bool namora = false;       // 'bool' para um valor falso

        // 2. Exibindo os valores no terminal
        Console.WriteLine("Os dados armazenados são:");
        Console.WriteLine("Nome: " + nome);
        Console.WriteLine("Idade: " + idade);
        Console.WriteLine("Altura: " + altura);
        Console.WriteLine("Gênero: " + genero);
        Console.WriteLine("Estudante: " + estuda);
        Console.WriteLine("Namora: " + namora);
    }
}
```

**Observações:**

  * `Main()`: O método principal foi simplificado na versão mais recente do C\# e não precisa mais do `string[] args`. Vamos usar essa versão mais limpa daqui para frente para focar no que importa.
  * **Concatenação:** O sinal de `+` é usado para "somar" textos (strings). Quando você faz `"Idade: " + idade`, o C\# automaticamente converte o número `12` para o texto `"12"` antes de juntar tudo. Por isso, na maioria dos casos, o método `.ToString()` é opcional ao exibir no console.

-----

### **4. Exercício Prático: O Cartão de Visitas Digital**

Vamos criar um programa que se comporta como um cartão de visitas digital.

**O objetivo é:**

1.  Declarar variáveis para o seu nome, sua idade e sua profissão.
2.  Atribuir valores a essas variáveis.
3.  Imprimir cada valor no console para simular um cartão de visitas.

**Solução:**

```csharp
// Solução do exercício
string meuNome = "Seu Nome Aqui";
int minhaIdade = 25;
string minhaProfissao = "Programador(a)";

Console.WriteLine("-------------------------");
Console.WriteLine("  Meu Cartão de Visitas  ");
Console.WriteLine("-------------------------");
Console.WriteLine("Nome: " + meuNome);
Console.WriteLine("Idade: " + minhaIdade + " anos");
Console.WriteLine("Profissão: " + minhaProfissao);
Console.WriteLine("-------------------------");
```

-----

### **5. Resumo da Aula**

  * **Variáveis:** São espaços na memória para armazenar dados.
  * **Tipos de Dados:** Cada variável deve ter um tipo (`string`, `int`, `double`, `char`, `bool`) para definir o que ela pode guardar.
  * **Sintaxe:** A forma de declarar uma variável é `tipo nome = valor;`.
  * **Impressão:** Usamos `Console.WriteLine()` e o operador `+` para exibir o conteúdo das variáveis.

-----

### **6. Próximos Passos**

Agora que você sabe como armazenar informações, a próxima etapa é aprender a pegar informações do usuário\! Na próxima aula, vamos falar sobre **`Console.ReadLine()`**, que nos permite ler dados digitados no terminal.

> 💡 **Dica:** O nome das variáveis deve ser claro e descritivo. Por exemplo, `idade` é muito melhor do que `x` ou `a`. Isso torna seu código mais fácil de entender no futuro.
