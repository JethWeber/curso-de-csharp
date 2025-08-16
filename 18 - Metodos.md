
# Fundamentos Da Linguagem C#

## **Aula 18 - Declaração e Uso de Métodos em C#**

### **O que é um método?**
Um **método** em C# é como uma receita: ele tem um nome, faz uma tarefa específica e você pode chamá-lo sempre que precisar. Métodos ajudam a organizar o código, evitando repetições, e tornam o programa mais fácil de entender.

Por exemplo:
- Um método pode dizer "Olá, mundo!" na tela.
- Outro método pode somar dois números e te dar o resultado.

---

#### **1. Como criar um método?**
Um método tem uma estrutura básica:
```csharp
static tipoDeRetorno NomeDoMetodo(parâmetros)
{
    // Código do método
}
```
- **static**: Usamos isso porque estamos dentro de um programa simples (explicarei mais no futuro, não se preocupe agora).
- **tipoDeRetorno**: O que o método devolve (ex.: `int`, `string`, ou `void` se não devolve nada).
- **NomeDoMetodo**: Um nome que você escolhe (use nomes claros, como `Somar` ou `MostrarNome`).
- **parâmetros**: Dados que o método precisa para funcionar (opcional).
- `{}`: Onde vai o código do método.

---

#### **2. Método sem parâmetros e sem retorno**
Um método com `void` significa que ele **não devolve nada**, apenas faz algo. Se não tiver parâmetros, ele não precisa de informações extras para funcionar.

**Exemplo:**
```csharp
static void DizerOla()
{
    Console.WriteLine("Olá, mundo!");
}
```
- **Como chamar?** Basta usar o nome do método:
```csharp
DizerOla(); // Mostra: Olá, mundo!
```

---

#### **3. Método com parâmetros**
Parâmetros são como "ingredientes" que você passa para o método fazer algo com eles. Você define os parâmetros entre parênteses, com o tipo e o nome.

**Exemplo:**
```csharp
static void MostrarNome(string nome)
{
    Console.WriteLine("Olá, " + nome + "!");
}
```
- `string nome`: O método espera uma palavra (string) chamada `nome`.
- **Como chamar?**
```csharp
MostrarNome("Ana"); // Mostra: Olá, Ana!
MostrarNome("João"); // Mostra: Olá, João!
```

---

#### **4. Método com retorno**
Um método pode devolver um valor (como um número ou texto) usando um tipo de retorno (ex.: `int`, `string`) em vez de `void`. Use a palavra `return` para devolver o valor.

**Exemplo:**
```csharp
static int Somar(int numero1, int numero2)
{
    return numero1 + numero2;
}
```
- `int`: O método devolve um número inteiro.
- `numero1` e `numero2`: São os parâmetros (dois números).
- `return`: Devolve o resultado da soma.

**Como chamar?**
```csharp
int resultado = Somar(5, 3);
Console.WriteLine("Soma de 5 + 3 = " + resultado); // Mostra: 8
```

Você também pode usar o resultado diretamente:
```csharp
Console.WriteLine("Soma de 5 + 3 = " + Somar(5, 3)); // Mostra: 8
```

---

#### **5. Sobrecarga de métodos**
**Sobrecarga** é quando você cria vários métodos com o **mesmo nome**, mas com **parâmetros diferentes** (em número ou tipo). O C# sabe qual método chamar com base nos parâmetros que você passa.

**Exemplo:**
```csharp
static int CalcularArea(int lado) // Para um quadrado
{
    return lado * lado;
}

static int CalcularArea(int comprimento, int largura) // Para um retângulo
{
    return comprimento * largura;
}
```
- O primeiro método calcula a área de um quadrado (1 parâmetro).
- O segundo calcula a área de um retângulo (2 parâmetros).

**Como chamar?**
```csharp
Console.WriteLine("Área de um quadrado: " + CalcularArea(4)); // Mostra: 16
Console.WriteLine("Área de um retângulo: " + CalcularArea(4, 6)); // Mostra: 24
```

- O C# escolhe o método certo baseado no número de parâmetros (1 ou 2).

---

#### **6. Dicas para criar métodos**
- **Nome claro**: Use nomes que descrevam o que o método faz (ex.: `Somar`, `MostrarNome`).
- **Evite métodos muito longos**: Se o método tiver muitas linhas, tente dividi-lo em métodos menores.
- **Teste os parâmetros**: Certifique-se de passar os tipos certos (ex.: não passe uma palavra para um método que espera um número).
- **Use retorno quando precisar**: Se o método só mostra algo na tela, use `void`. Se precisar de um resultado, use um tipo como `int` ou `string`.

---

#### **7. Exercício prático**
Crie um método que receba uma idade (número) e devolva `true` se a pessoa for maior de idade (18 ou mais) ou `false` se for menor.

**Solução (já incluída no código acima):**
```csharp
static bool VerificarMaioridade(int idade)
{
    return idade >= 18;
}
```
- **Como chamar?**
```csharp
bool eMaior = VerificarMaioridade(20);
Console.WriteLine("20 anos é maior de idade? " + eMaior); // Mostra: True
eMaior = VerificarMaioridade(15);
Console.WriteLine("15 anos é maior de idade? " + eMaior); // Mostra: False
```

---

#### **8. Resumo**
- **Método sem parâmetros e sem retorno**: Usa `void` e não precisa de dados (ex.: `DizerOla()`).
- **Método com parâmetros**: Recebe dados para trabalhar (ex.: `MostrarNome(string nome)`).
- **Método com retorno**: Devolve um valor com `return` (ex.: `Somar(int a, int b)`).
- **Sobrecarga**: Mesmos nomes, parâmetros diferentes (ex.: `CalcularArea` com 1 ou 2 parâmetros).
- **Como chamar?** Use o nome do método e passe os parâmetros certos.

---

Essa aula foi bem básica, focada só em métodos, com exemplos simples para você entender parâmetros, retorno e sobrecarga. O código acima tem tudo pronto para testar.
