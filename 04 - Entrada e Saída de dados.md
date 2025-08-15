
# Fundamentos Da Linguagem C#

## **Aula 04 — Entrada e Saída de Dados**

Um programa de computador é uma via de mão dupla. Ele não só processa informações, mas também se comunica com o usuário. Essa comunicação acontece através da **entrada de dados** (o usuário envia informações para o programa) e da **saída de dados** (o programa exibe informações para o usuário).

-----

### **1. Saída de Dados: Falando com o Usuário**

A saída de dados é como o programa "fala" com a gente, exibindo mensagens, resultados e instruções na tela. O comando mais comum para isso é `Console.WriteLine()`.

**Como funciona?**
Ele exibe o conteúdo que está dentro dos parênteses no terminal e pula para a próxima linha.

**Exemplo:**

```csharp
// Exibe a mensagem e vai para a linha de baixo
Console.WriteLine("Olá, bem-vindo(a) ao meu programa!");

// Você pode exibir o valor de variáveis
string nome = "Maria";
Console.WriteLine("O nome digitado foi: " + nome);
```

**Diferença entre `WriteLine` e `Write`:**
Existe também o `Console.Write()`, que faz o mesmo que o `WriteLine()`, mas **não pula para a próxima linha**. Isso é útil para criar textos contínuos.

-----

### **2. Entrada de Dados: Ouvindo o Usuário**

Para que o programa possa receber informações do usuário (como um nome ou uma idade), usamos o comando `Console.ReadLine()`.

**Como funciona?**
`Console.ReadLine()` faz o programa pausar a execução e aguardar até que o usuário digite algo e pressione `Enter`. O texto digitado é então retornado para o seu programa como um valor do tipo `string`.

**Exemplo:**

```csharp
Console.Write("Por favor, digite seu nome: ");
// O programa pausa aqui. O que for digitado é guardado na variável 'nomeUsuario'.
string nomeUsuario = Console.ReadLine();

Console.WriteLine("Obrigado, " + nomeUsuario + "!");
```

-----

### **3. Conversão de Tipos: O Desafio da Entrada**

O `Console.ReadLine()` sempre retorna um `string`. Mas e se você precisar que o usuário digite um número? A conversão é necessária.

#### **3.1. Usando a classe `Convert`**

A forma mais simples de converter é usando a classe `Convert`. Ela oferece métodos para transformar um tipo em outro.

```csharp
// Pede a idade e a armazena como string
Console.Write("Digite sua idade: ");
string idadeTexto = Console.ReadLine();

// Converte a string 'idadeTexto' para o tipo int
int idade = Convert.ToInt32(idadeTexto);

Console.WriteLine("Você tem " + idade + " anos.");
```

**Cuidado com a classe `Convert`:**
Se o usuário digitar um texto que não é um número (ex.: `"vinte"`), o programa dará um erro\! Para evitar isso, lembramos da nossa primeira aula e usamos o `TryParse`.

#### **3.2. A forma segura: `TryParse`**

Como vimos na nossa aula sobre conversão de tipos, `TryParse` é a maneira mais segura de converter a entrada do usuário, pois ele não causa um erro se a conversão falhar.

**Exemplo prático e seguro:**

```csharp
Console.Write("Digite sua idade: ");
string idadeTexto = Console.ReadLine();

// Declara a variável para guardar o resultado
int idade;

// Tenta converter a string para int.
// 'sucesso' será 'true' se der certo, ou 'false' se der errado.
bool sucesso = int.TryParse(idadeTexto, out idade);

if (sucesso)
{
    Console.WriteLine("Sua idade é: " + idade + " anos.");
}
else
{
    Console.WriteLine("Entrada inválida. Por favor, digite um número!");
}
```

-----

### **4. Resumo da Aula**

  * **Saída de Dados:** Usamos `Console.WriteLine()` para exibir informações no console.
  * **Entrada de Dados:** Usamos `Console.ReadLine()` para pegar o que o usuário digita.
  * **Conversão:** A entrada é sempre uma `string`, então precisamos convertê-la para outros tipos de dados, como `int` ou `double`.
  * **Segurança:** Use `int.TryParse()` (ou seu equivalente para outros tipos) para garantir que seu programa não dê erro caso o usuário digite algo inválido.

-----

### **5. Exercício Prático**

Crie um programa que:

1.  Pede o nome completo e a idade do usuário.
2.  Armazena o nome em uma variável `string`.
3.  Usa `int.TryParse()` para armazenar a idade em uma variável `int`.
4.  Exibe uma mensagem de boas-vindas usando o nome e a idade.
5.  Se a idade for inválida, exibe uma mensagem de erro.
