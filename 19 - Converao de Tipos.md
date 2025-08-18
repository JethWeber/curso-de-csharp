# Fundamentos da Linguagem C#

## **Aula 19 - Conversão de Tipos em C# (Cast, Parse, TryParse)**

#### **O que é conversão de tipos?**
Em C#, cada dado tem um **tipo** (ex.: `int` para números inteiros, `double` para números com decimal, `string` para texto). Às vezes, você precisa transformar um tipo em outro, como:
- Converter um texto `"123"` em um número `123`.
- Transformar um número com decimal (`9.75`) em um número inteiro (`9`).

Existem três formas principais de fazer isso: **cast**, **Parse** e **TryParse**. Vamos aprender cada uma delas!

---

#### **1. Cast (conversão entre tipos numéricos)**
O **cast** é usado para transformar um tipo numérico em outro, como de `int` para `double` ou de `double` para `int`.

##### **1.1. Conversão implícita**
Acontece automaticamente quando não há risco de perder dados (ex.: de `int` para `double`, já que `double` suporta números maiores e com decimais).

**Exemplo:**
```csharp
int numeroInteiro = 42;
double numeroDouble = numeroInteiro; // Conversão automática
Console.WriteLine("int " + numeroInteiro + " vira double " + numeroDouble); // Mostra: int 42 vira double 42
```

- Aqui, o `int` (42) vira um `double` (42.0) sem problemas.

##### **1.2. Conversão explícita (cast)**
Quando há risco de perda de dados (ex.: de `double` para `int`), você precisa usar um **cast** colocando o tipo desejado entre parênteses `(tipo)`.

**Exemplo:**
```csharp
double valorDouble = 9.75;
int valorInteiro = (int)valorDouble; // Faz o cast, perde a parte decimal
Console.WriteLine("double " + valorDouble + " vira int " + valorInteiro); // Mostra: double 9.75 vira int 9
```

- O cast `(int)` corta a parte decimal (`.75`), então `9.75` vira `9`.
- **Cuidado**: O cast não arredonda, apenas descarta os decimais.

---

#### **2. Parse (convertendo texto para outro tipo)**
O método `Parse` é usado para transformar uma `string` (texto) em outro tipo, como `int`, `double`, etc. Cada tipo tem seu próprio método `Parse` (ex.: `int.Parse`, `double.Parse`).

**Exemplo:**
```csharp
string textoNumero = "123";
int numeroConvertido = int.Parse(textoNumero);
Console.WriteLine("string '" + textoNumero + "' vira int " + numeroConvertido); // Mostra: string '123' vira int 123
```

- Aqui, o texto `"123"` vira o número `123`.

**Problema do Parse**:
Se a string não for válida (ex.: `"abc"` em vez de um número), o programa dá erro (`FormatException`).

**Exemplo com erro:**
```csharp
string textoInvalido = "abc";
int numero = int.Parse(textoInvalido); // Isso causa um erro!
```

Por isso, usamos o **TryParse** para evitar erros.

---

#### **3. TryParse (conversão segura de texto)**
O **TryParse** é uma versão mais segura do `Parse`. Ele tenta converter uma `string` em outro tipo, mas não dá erro se falhar. Em vez disso, retorna:
- `true` se a conversão der certo.
- `false` se a conversão falhar.

Além disso, usa um parâmetro `out` para guardar o resultado.

**Exemplo:**
```csharp
string textoValido = "456";
int resultado;
bool sucesso = int.TryParse(textoValido, out resultado);
Console.WriteLine("TryParse com '" + textoValido + "': Sucesso? " + sucesso + ", Resultado: " + resultado);
// Mostra: TryParse com '456': Sucesso? True, Resultado: 456
```

- `int.TryParse(textoValido, out resultado)`:
  - Tenta converter `"456"` em um número.
  - Se der certo, `sucesso` é `true` e `resultado` recebe `456`.
  - O `out` é uma forma de o método devolver o valor convertido.

**Exemplo com texto inválido:**
```csharp
string textoInvalido = "abc";
bool sucesso = int.TryParse(textoInvalido, out resultado);
Console.WriteLine("TryParse com '" + textoInvalido + "': Sucesso? " + sucesso + ", Resultado: " + resultado);
// Mostra: TryParse com 'abc': Sucesso? False, Resultado: 0
```

- Aqui, `"abc"` não é um número, então `sucesso` é `false` e `resultado` fica `0` (valor padrão).

---

#### **4. Quando usar cada um?**
- **Cast**: Use para converter entre tipos numéricos (ex.: `int` para `double` ou vice-versa).
  - **Implícito**: Quando não há perda de dados (ex.: `int` para `double`).
  - **Explícito**: Quando há risco de perda (ex.: `double` para `int`).
- **Parse**: Use para converter `string` em outro tipo, quando você tem certeza que o texto é válido.
- **TryParse**: Use para converter `string` em outro tipo quando o texto pode ser inválido, para evitar erros.

---

#### **5. Exercício prático**
Crie um programa que:
1. Recebe uma string com uma idade (ex.: `"25"`).
2. Usa `TryParse` para converter a string em `int`.
3. Se a conversão der certo, verifica se a pessoa é maior de idade (18 ou mais).
4. Se falhar, mostra uma mensagem de erro.

**Solução (já incluída no código acima):**
```csharp
string idadeTexto = "25";
if (int.TryParse(idadeTexto, out int idade))
{
    Console.WriteLine("Idade convertida: " + idade + " anos");
    if (idade >= 18)
    {
        Console.WriteLine("É maior de idade!");
    }
    else
    {
        Console.WriteLine("É menor de idade!");
    }
}
else
{
    Console.WriteLine("Erro: A idade não é um número válido!");
}
```

**Saída:**
```
Idade convertida: 25 anos
É maior de idade!
```

**Teste com texto inválido:**
```csharp
string idadeTexto = "abc";
if (int.TryParse(idadeTexto, out int idade))
{
    Console.WriteLine("Idade convertida: " + idade + " anos");
}
else
{
    Console.WriteLine("Erro: A idade não é um número válido!");
}
```

**Saída:**
```
Erro: A idade não é um número válido!
```

---

#### **6. Dicas importantes**
- **Use TryParse para entradas do usuário**: Se o usuário digitar algo (ex.: em um `Console.ReadLine()`), use `TryParse` para evitar erros com textos inválidos.
- **Cuidado com perda de dados no cast**: Converter `double` para `int` corta os decimais, então pense bem antes de fazer.
- **Outros tipos**: Além de `int`, você pode usar `double.Parse`, `float.Parse`, `bool.Parse`, etc., e seus equivalentes `TryParse`.
- **Teste seus programas**: Sempre experimente com valores válidos e inválidos para garantir que o código funciona bem.

---

#### **7. Resumo**
- **Cast**:
  - **Implícito**: Automático, sem perda de dados (ex.: `int` para `double`).
  - **Explícito**: Usa `(tipo)` com possível perda de dados (ex.: `(int)9.75` vira `9`).
- **Parse**: Converte `string` em outro tipo (ex.: `int.Parse("123")` vira `123`). Dá erro se a string for inválida.
- **TryParse**: Converte `string` com segurança, retornando `true` ou `false` e usando `out` para o resultado (ex.: `int.TryParse("abc", out int resultado)`).

---

Essa aula foi bem básica, focada só em conversão de tipos, com exemplos simples para você entender **cast**, **Parse** e **TryParse**. O código acima tem tudo pronto para testar. 
