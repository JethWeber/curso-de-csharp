
---

```markdown
# 🧠 Fundamentos de Programação em C#

## 👋 Aula 01 — Estrutura de Código C# e Configuração do Ambiente

Se esta é sua primeira vez lidando com programação, parabéns por dar esse passo! 🎉  
Nesta aula, vamos conhecer a linguagem **C#**, entender como ela funciona e configurar o ambiente para começar a escrever nossos primeiros códigos.

---

## 💬 O que é C#?

C# (pronuncia-se "C-sharp") é uma linguagem de programação moderna, criada pela Microsoft.  
Ela é usada para criar aplicativos de computador, jogos, sites e muito mais.

> 🧠 Pense nela como uma linguagem que você usa para conversar com o computador e dizer o que ele deve fazer.

---

## 🧰 Preparando o Ambiente

Antes de começar a programar, precisamos instalar algumas ferramentas.  
Isso é como montar sua bancada de trabalho antes de começar a construir algo.

### 🖥️ Para Windows

1. Instale o [.NET SDK](https://dotnet.microsoft.com/en-us/download)
2. Instale o [Visual Studio Code](https://code.visualstudio.com/)
3. No VS Code, instale a extensão **C#** (ícone de quadrado → "Extensions" → procure por "C#")

### 🍏 Para macOS

1. Instale o .NET SDK pelo link acima
2. Instale o Visual Studio Code
3. Instale a extensão **C#** no VS Code

### 🐧 Para Linux (Linux Mint)

1. Abra o terminal e execute:
   ```sh
   sudo apt update
   sudo apt install dotnet-sdk-7.0
   ```
2. Instale o Visual Studio Code:
   ```sh
   sudo snap install code --classic
   ```
3. Abra o VS Code e instale a extensão **C#**

---

## 🏗️ Criando seu Primeiro Projeto

Vamos usar o terminal para criar um projeto simples em C#.  
Isso é como abrir um caderno novo para começar a escrever.

### 1️⃣ Criar uma solução

A solução é como uma pasta principal que pode conter vários projetos.

```sh
dotnet new sln -o MinhaSolucao
cd MinhaSolucao
```

### 2️⃣ Criar o projeto

O projeto é onde o código realmente fica.

```sh
dotnet new console -o MeuProjeto
dotnet sln add MeuProjeto
```

---

## 🧱 Estrutura Básica de um Código C#

Aqui está o esqueleto de um programa em C#:

```csharp
namespace MeuProjeto;

public class Program
{
    public static void Main()
    {
        // Aqui começa a execução do programa
    }
}
```

### 🔍 Explicando Cada Parte

| Elemento | Significado | Exemplo do dia a dia |
|---------|-------------|----------------------|
| `namespace MeuProjeto` | É como o endereço do seu código | Como o nome da rua onde sua casa está |
| `public class Program` | É a classe principal | Como o nome da sua casa |
| `public static void Main()` | É o método principal, o ponto de partida | Como a porta de entrada — tudo começa por aqui |

---

## 🧪 O que Aprendemos

- O que é C# e para que serve
- Como configurar o ambiente no Windows, Mac e Linux
- Como criar uma solução e um projeto usando o terminal
- Como funciona a estrutura básica de um código C#

---

## 🚀 Próximos Passos

Na próxima aula, vamos aprender sobre **variáveis** — que são como caixinhas onde guardamos informações.  
Prepare-se para começar a escrever códigos que fazem coisas de verdade!

> 💡 Dica: Se algo parecer confuso, volte e releia com calma. Programar é como aprender uma nova língua — no começo parece estranho, mas com prática tudo começa a fazer sentido.
