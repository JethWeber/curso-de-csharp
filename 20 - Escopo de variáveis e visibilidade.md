### **Aula: Escopo e Visibilidade de Variáveis em C#**

#### **O que é escopo?**
O **escopo** de uma variável é a parte do programa onde ela pode ser usada. Pense como uma "área de validade" da variável: fora dessa área, ela não existe ou não pode ser acessada.

Por exemplo:
- Se você cria uma variável dentro de um método, ela só funciona dentro dele.
- Se criar uma variável dentro de um `if`, ela só existe dentro daquele `if`.

#### **O que é visibilidade?**
A **visibilidade** está ligada a onde a variável pode ser acessada e quem pode usá-la. Em C#, isso depende de onde a variável foi declarada (ex.: dentro de um método, na classe, etc.) e de modificadores como `public` ou `private` (mas vamos focar só no básico por agora, sem modificadores avançados).

---

#### **1. Tipos de escopo**

##### **1.1. Escopo de classe (variáveis globais/campos)**
Uma variável declarada **fora de qualquer método**, diretamente na classe, é chamada de **campo** ou variável global. Ela pode ser usada em qualquer método da classe.

**Exemplo:**
```csharp
static int numeroGlobal = 100; // Variável global (escopo de classe)
```

- `numeroGlobal` pode ser usada em qualquer método dentro da classe `Program`.

##### **1.2. Escopo de método (variáveis locais)**
Uma variável declarada **dentro de um método** só existe dentro dele. Ela é chamada de **variável local**.

**Exemplo:**
```csharp
static void Main()
{
    int numeroLocal = 10; // Variável local
    Console.WriteLine(numeroLocal); // Mostra: 10
}
```
- `numeroLocal` só existe dentro do método `Main`. Se tentar usá-la em outro método, dá erro.

##### **1.3. Escopo de bloco**
Uma variável declarada dentro de um **bloco** (ex.: dentro de um `if`, `for`, ou `{}`) só existe dentro desse bloco.

**Exemplo:**
```csharp
if (true)
{
    int numeroBloco = 200; // Só existe dentro do if
    Console.WriteLine(numeroBloco); // Mostra: 200
}
// Console.WriteLine(numeroBloco); // ERRO! A variável não existe aqui
```

- `numeroBloco` só pode ser usado dentro do `if`. Fora do bloco, ela "desaparece".

---

#### **2. Como funciona a visibilidade?**
- **Variáveis globais** (campos): Podem ser vistas por todos os métodos da classe.
- **Variáveis locais**: Só são vistas dentro do método ou bloco onde foram declaradas.
- **Parâmetros de métodos**: São como variáveis locais, mas só existem enquanto o método está sendo executado.

**Exemplo com parâmetros:**
```csharp
static int Somar(int x, int y)
{
    int resultado = x + y; // x, y e resultado são locais ao método
    return resultado;
}
```
- `x`, `y` e `resultado` só existem dentro do método `Somar`.

---

#### **3. Variáveis com mesmo nome**
Você pode ter variáveis com o mesmo nome em escopos diferentes, e o C# usa a variável do escopo mais "próximo".

**Exemplo:**
```csharp
static int numeroGlobal = 100;

static void Main()
{
    int numero = 50; // Variável local com mesmo nome
    Console.WriteLine("Variável local: " + numero); // Mostra: 50
    Console.WriteLine("Variável global: " + numeroGlobal); // Mostra: 100
}
```

- A variável local `numero` "esconde" a variável global `numeroGlobal` dentro do método `Main`.

---

#### **4. Cuidados com escopo**
- **Não use uma variável fora do seu escopo**: Se tentar acessar uma variável local fora do método ou bloco onde ela foi declarada, o C# dá erro (`CS0103: The name does not exist in the current context`).
- **Evite variáveis globais desnecessárias**: Variáveis globais podem tornar o código confuso. Use variáveis locais sempre que possível.
- **Nomes claros**: Dê nomes que façam sentido (ex.: `idade` em vez de `x`) para evitar confusão.

---

#### **5. Exercício prático**
Crie um programa que:
1. Declare uma variável global chamada `contador` com valor 0.
2. Crie um método que incrementa `contador` e mostra seu valor.
3. No método `Main`, declare uma variável local com o mesmo nome `contador` e mostre os dois valores.

**Solução (modificada para o exercício completo):**
```csharp
using System;

class Program
{
    static int contador = 0; // Variável global

    static void Main()
    {
        int contador = 10; // Variável local
        Console.WriteLine("Contador local em Main: " + contador); // Mostra: 10
        IncrementarContador();
        Console.WriteLine("Contador global após incrementar: " + contador); // Mostra: 10 (local)
        Console.WriteLine("Contador global real: " + Program.contador); // Mostra: 1
    }

    static void IncrementarContador()
    {
        contador++; // Usa a variável global
        Console.WriteLine("Contador global em IncrementarContador: " + contador); // Mostra: 1
    }
}
```

**Saída:**
```
Contador local em Main: 10
Contador global em IncrementarContador: 1
Contador global após incrementar: 10
Contador global real: 1
```

- Aqui, a variável local `contador` em `Main` não afeta a variável global `contador`.

---

#### **6. Resumo**
- **Escopo**: Define onde uma variável pode ser usada.
  - **Classe**: Variáveis globais (campos) são vistas por todos os métodos da classe.
  - **Método**: Variáveis locais só existem dentro do método.
  - **Bloco**: Variáveis dentro de `{}` (ex.: `if`, `for`) só existem ali.
- **Visibilidade**: Depende do escopo. Variáveis locais são "escondidas" fora do seu método ou bloco.
- **Nomes iguais**: Uma variável local pode ter o mesmo nome de uma global, e a local "vence" no seu escopo.
- **Cuidado**: Sempre declare variáveis no escopo certo para evitar erros.

---

Essa aula foi bem básica, focada só em escopo e visibilidade de variáveis, com exemplos simples para você entender. O código acima tem tudo pronto para testar. 