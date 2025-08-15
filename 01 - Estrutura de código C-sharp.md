
-----
# Fundamentos da Linguagem C#

### **Aula 01 — Estrutura de Código C\# e Configuração do Ambiente**

Se esta é sua primeira vez lidando com programação, parabéns por dar esse passo\! 🎉
Nesta aula, vamos conhecer a linguagem **C\#**, entender para que ela serve e configurar o ambiente para começar a escrever nossos primeiros códigos.

-----

### **1. O que é C\# e por que usá-la?**

C\# (pronuncia-se "C-sharp") é uma linguagem de programação moderna, desenvolvida pela Microsoft como parte da plataforma .NET. Ela é amplamente utilizada para construir uma variedade de aplicações, como:

  * **Aplicativos de desktop** para Windows;
  * **Jogos** com a popular engine Unity;
  * **Aplicações web e serviços de backend** com ASP.NET;
  * **Aplicações mobile** para iOS e Android com a ferramenta Xamarin.

> 🧠 **Pense nela como uma linguagem versátil que você usa para dar vida às suas ideias no mundo digital. Por ser uma linguagem "tipada", ela é mais segura e ajuda a evitar erros, o que a torna excelente para iniciantes.**

-----

### **2. Preparando o Ambiente: Nossas Ferramentas de Trabalho**

Antes de começar a programar, precisamos de algumas ferramentas essenciais.

  * **SDK (.NET SDK):** É o Kit de Desenvolvimento de Software. Ele contém tudo o que você precisa para criar e rodar um programa em C\#, incluindo o compilador (que traduz seu código para a linguagem do computador) e o runtime (que executa o programa). É a ferramenta mais importante.
  * **Editor de Código (Visual Studio Code):** É onde você irá escrever seu código. O Visual Studio Code é um editor leve, poderoso e popular, com muitas extensões que facilitam o desenvolvimento. Ele é diferente do "Visual Studio" completo, que é um ambiente de desenvolvimento (IDE) mais robusto.
  * **Extensão C\#:** Um "plugin" para o VS Code que adiciona recursos inteligentes, como autocompletar, realçar erros e ajudar a organizar o código.

#### **2.1. Como instalar no seu sistema**

  * **Para Windows, macOS e Linux:** Baixe o [.NET SDK](https://dotnet.microsoft.com/en-us/download) e o [Visual Studio Code](https://code.visualstudio.com/) em seus respectivos sites.
  * No VS Code, vá na aba de extensões (ícone de quadrado) e pesquise por **"C\#"** para instalar o plugin.

-----

### **3. Criando seu Primeiro Projeto: Organizando o Trabalho**

Vamos usar o terminal para criar um projeto simples. A organização é fundamental na programação.

  * **Solução (`sln`):** Pense na solução como uma pasta principal para um grande projeto. Ela pode conter vários sub-projetos relacionados. Por exemplo, um jogo pode ter um projeto para o servidor e outro para o cliente, ambos dentro da mesma solução.
  * **Projeto (`csproj`):** É a pasta que contém o código-fonte, referências a bibliotecas e configurações específicas. É a unidade de um programa.

#### **Passos no Terminal**

1.  **Crie a pasta da solução:**
    ```sh
    dotnet new sln -o MinhaSolucao
    cd MinhaSolucao
    ```
2.  **Crie o projeto dentro da solução:**
    ```sh
    dotnet new console -o MeuProjeto
    dotnet sln add MeuProjeto
    ```
3.  **Abra o projeto no VS Code:**
    ```sh
    code .
    ```

-----

### **4. Estrutura de Código: Desvendando o Esqueleto**

Depois de abrir o VS Code, você verá o arquivo `Program.cs`. Vamos entender a estrutura dele:

```csharp
// 1. O namespace funciona como uma "caixa" para o seu código.
//    Ele ajuda a evitar conflitos de nomes com outros códigos.
namespace MeuProjeto;

// 2. A "classe" é a planta ou o molde para criar objetos.
//    Neste caso, a classe 'Program' é onde nosso código vai viver.
public class Program
{
    // 3. O método Main é a porta de entrada.
    //    Quando você executa o programa, o computador sempre procura por este método.
    public static void Main()
    {
        // 4. Esta é a linha que faz o programa funcionar.
        //    Console.WriteLine é um comando que exibe algo na tela (no terminal).
        Console.WriteLine("Olá, Mundo!");
    }
}
```

  * `//` : Linha de comentário. O compilador ignora tudo o que vem depois de `//`. Isso serve para você deixar anotações no código.

-----

### **5. Resumo da Aula**

  * **C\#** é uma linguagem versátil e segura para criar diversos tipos de aplicações.
  * Configuramos o **.NET SDK** (o motor da linguagem) e o **Visual Studio Code** (nosso editor de texto).
  * Aprendemos a organizar nossos arquivos em **soluções** e **projetos** usando o terminal.
  * Desvendamos a estrutura básica de um programa C\#, entendendo o papel de `namespace`, `class` e `Main()`.

-----

### **6. Próximos Passos**

Agora que o ambiente está configurado e você entendeu a estrutura básica, é hora de fazer o seu programa fazer algo de verdade\! Na próxima aula, vamos aprender sobre **variáveis**, as "caixinhas" que usamos para guardar e manipular informações.

> 💡 **Dica:** Não se preocupe em entender tudo de uma vez. O mais importante agora é conseguir criar e executar um projeto simples. Aos poucos, cada conceito fará mais sentido\!
