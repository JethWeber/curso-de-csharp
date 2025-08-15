### **Aula: Comentários e Boas Práticas de Código em C#**

#### **O que são comentários?**
Comentários são textos no código que **não são executados** pelo programa. Eles servem para:
- Explicar o que o código faz.
- Ajudar você ou outras pessoas a entender o código no futuro.
- Documentar partes importantes do programa.

Em C#, existem dois tipos principais de comentários:
1. **Comentário de uma linha**: Começa com `//` e vai até o fim da linha.
2. **Comentário de várias linhas**: Começa com `/*` e termina com `*/`.

**Exemplo:**
```csharp
// Este é um comentário de uma linha
int x = 10; // Define a variável x com valor 10

/* Este é um comentário
   de várias linhas.
   Útil para explicações mais longas. */
```

---

#### **1. Como usar comentários de forma eficaz?**
Comentários são como anotações em um caderno: devem ser úteis e não atrapalhar. Aqui vão algumas dicas:

##### **1.1. Explique o "porquê", não só o "o quê"**
- Evite comentários óbvios que repetem o que o código já diz.
- Explique **por que** você fez algo, especialmente se for algo complexo.

**Exemplo ruim (óbvio):**
```csharp
int idade = 25; // Define a idade como 25
```

**Exemplo bom (explica o propósito):**
```csharp
int idade = 25; // Idade do usuário para verificar maioridade
```

##### **1.2. Comente blocos de código**
Use comentários para descrever o que um trecho de código faz, como uma introdução.

**Exemplo:**
```csharp
// Calcula a média de três notas
double media = (nota1 + nota2 + nota3) / 3;
```

##### **1.3. Comente métodos**
Antes de um método, explique o que ele faz, quais parâmetros recebe e o que retorna (se houver).

**Exemplo:**
```csharp
// Calcula a média de três notas
// Parâmetros: nota1, nota2, nota3 (notas do aluno)
// Retorna: a média das notas
static double CalcularMedia(double nota1, double nota2, double nota3)
{
    return (nota1 + nota2 + nota3) / 3;
}
```

##### **1.4. Não exagere**
- Comentários demais podem poluir o código.
- Se o código é claro (ex.: nomes de variáveis bem escolhidos), você precisa de menos comentários.

**Exemplo de exagero:**
```csharp
// Define a variável x
int x = 0;
// Incrementa x por 1
x = x + 1;
```

**Melhor assim:**
```csharp
int contador = 0; // Contador de iterações
contador++; // Incrementa o contador
```

---

#### **2. Boas práticas de código**
Além de comentários, boas práticas ajudam a escrever código mais **legível**, **organizado** e **fácil de manter**. Aqui estão as principais:

##### **2.1. Use nomes claros para variáveis e métodos**
- Escolha nomes que expliquem o propósito da variável ou método.
- Evite nomes genéricos como `x`, `y`, ou `temp`.

**Exemplo ruim:**
```csharp
int n = 10; // Não explica o que é
```

**Exemplo bom:**
```csharp
int idadeDoUsuario = 10; // Nome descritivo
```

**Para métodos:**
```csharp
// Ruim
static int calc(int a, int b) { return a + b; }

// Bom
static int Somar(int numero1, int numero2) { return numero1 + numero2; }
```

##### **2.2. Organize o código com espaços e indentação**
- Use espaços e quebras de linha para separar blocos lógicos.
- Indente o código dentro de `{}` (o Visual Studio faz isso automaticamente).

**Exemplo ruim (tudo junto):**
```csharp
static void Main(){int x=10;Console.WriteLine(x);if(x>5){Console.WriteLine("Maior que 5");}}
```

**Exemplo bom (organizado):**
```csharp
static void Main()
{
    int x = 10;
    Console.WriteLine(x);
    if (x > 5)
    {
        Console.WriteLine("Maior que 5");
    }
}
```

##### **2.3. Mantenha métodos curtos e focados**
- Cada método deve fazer **uma coisa só**.
- Se um método está muito longo, divida-o em métodos menores.

**Exemplo:**
Em vez de um método que faz tudo:
```csharp
static void ProcessarAluno()
{
    // Calcula média, verifica aprovação, exibe resultado...
}
```

Divida em métodos específicos:
```csharp
static double CalcularMedia(double nota1, double nota2, double nota3)
{
    return (nota1 + nota2 + nota3) / 3;
}

static bool VerificarAprovacao(double media)
{
    return media >= 7;
}
```

##### **2.4. Evite repetição de código**
Se você está repetindo o mesmo código várias vezes, crie um método para reusá-lo.

**Exemplo ruim:**
```csharp
Console.WriteLine("A soma de 2 + 3 é: " + (2 + 3));
Console.WriteLine("A soma de 5 + 4 é: " + (5 + 4));
```

**Exemplo bom:**
```csharp
static int Somar(int a, int b)
{
    return a + b;
}

Console.WriteLine("A soma de 2 + 3 é: " + Somar(2, 3));
Console.WriteLine("A soma de 5 + 4 é: " + Somar(5, 4));
```

##### **2.5. Use constantes para valores fixos**
Se um valor não muda (ex.: o limite para aprovação), use `const` para deixá-lo claro.

**Exemplo:**
```csharp
const double MediaMinimaParaAprovacao = 7.0;

if (media >= MediaMinimaParaAprovacao)
{
    Console.WriteLine("Aprovado!");
}
```

##### **2.6. Teste seu código**
- Sempre teste com valores diferentes para garantir que o código funciona.
- Exemplo: No programa acima, teste com notas que resultem em aprovação e reprovação.

---

#### **3. Exercício prático**
Crie um programa que:
1. Calcula a média de três notas.
2. Usa comentários claros para explicar o código.
3. Segue boas práticas (nomes claros, organização, métodos separados).
4. Verifica se o aluno foi aprovado (média >= 7).

**Solução (já incluída no código acima):**
- O código calcula a média de três notas, verifica aprovação e usa:
  - Nomes claros (`nota1`, `CalcularMedia`, `VerificarAprovacao`).
  - Comentários úteis antes de métodos e variáveis.
  - Métodos curtos e organizados.
  - Indentação e espaços para legibilidade.

**Saída do código:**
```
Bem-vindo ao calculador de médias!
A média das notas é: 7.3
Aluno aprovado!
```

---

#### **4. Resumo**
- **Comentários**:
  - Use `//` para comentários de uma linha e `/* */` para várias linhas.
  - Explique o "porquê" e o propósito, não só o "o quê".
  - Comente métodos com parâmetros e retorno.
  - Evite comentários óbvios ou excessivos.
- **Boas práticas**:
  - Use nomes claros e descritivos para variáveis e métodos.
  - Organize o código com indentação e espaços.
  - Crie métodos curtos e focados.
  - Evite repetição com métodos reutilizáveis.
  - Use `const` para valores fixos.
  - Teste o código com diferentes casos.

---

Essa aula foi bem básica, focada só em comentários e boas práticas, com um código limpo e comentado para você testar. 