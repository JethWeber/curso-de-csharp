
# **Fundamentos Da Linguagem C#**

### **Aula 17 - O que é uma lista?**
Uma lista em C# é como uma "caixa mágica" que pode guardar várias coisas (números, palavras, etc.) e que cresce ou diminui conforme você adiciona ou tira itens. Diferente de um array, que tem tamanho fixo, a lista é flexível.

Por exemplo:
- Um array é como um armário com 5 gavetas: você não pode adicionar mais gavetas.
- Uma lista é como uma mochila: você pode colocar mais coisas ou tirar coisas quando quiser.

A lista em C# é chamada de `List<T>`, onde o `T` é o tipo de coisa que você quer guardar (ex.: `int` para números, `string` para palavras).

---

#### **1. Como começar a usar uma lista?**
Para usar listas, você precisa incluir uma linha no topo do seu código que "ativa" as ferramentas de listas. Essa linha é:

```csharp
using System.Collections.Generic;
```

Depois disso, você pode criar uma lista. Vamos ver como:

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Criando uma lista de números
        List<int> numeros = new List<int>();

        // Criando uma lista de palavras
        List<string> nomes = new List<string>();

        // Criando uma lista com itens já dentro
        List<string> frutas = new List<string> { "Maçã", "Banana", "Laranja" };
    }
}
```

- `List<int>`: Uma lista que só guarda números inteiros.
- `List<string>`: Uma lista que só guarda palavras (textos).
- `{ "Maçã", "Banana", "Laranja" }`: Você pode já começar a lista com itens.

---

#### **2. Adicionando coisas na lista**
Você pode adicionar itens na lista com o método `Add`. Ele coloca o item no final da lista.

**Exemplo:**
```csharp
List<string> frutas = new List<string>();
frutas.Add("Maçã");  // A lista agora tem: [Maçã]
frutas.Add("Banana"); // A lista agora tem: [Maçã, Banana]
frutas.Add("Laranja"); // A lista agora tem: [Maçã, Banana, Laranja]

Console.WriteLine(frutas[0]); // Mostra: Maçã
Console.WriteLine(frutas[1]); // Mostra: Banana
Console.WriteLine(frutas[2]); // Mostra: Laranja
```

- Cada item na lista tem uma posição (índice), começando do 0.
- `frutas[0]` é o primeiro item, `frutas[1]` é o segundo, e assim por diante.

---

#### **3. Contando quantos itens estão na lista**
Para saber quantos itens a lista tem, use a propriedade `Count`. É como perguntar: "Quantas coisas tem na minha mochila?"

**Exemplo:**
```csharp
List<string> frutas = new List<string> { "Maçã", "Banana", "Laranja" };
Console.WriteLine("Quantas frutas tenho? " + frutas.Count); // Mostra: Quantas frutas tenho? 3
```

---

#### **4. Removendo coisas da lista**
Você pode tirar itens da lista de duas formas principais:
- `Remove(item)`: Tira o item específico que você indicar (só a primeira vez que ele aparece).
- `RemoveAt(índice)`: Tira o item que está em uma posição específica.

**Exemplo:**
```csharp
List<string> frutas = new List<string> { "Maçã", "Banana", "Laranja" };
frutas.Remove("Banana"); // Tira "Banana"
Console.WriteLine(string.Join(", ", frutas)); // Mostra: Maçã, Laranja

frutas.RemoveAt(0); // Tira o item na posição 0 (Maçã)
Console.WriteLine(string.Join(", ", frutas)); // Mostra: Laranja
```

- O `string.Join(", ", frutas)` é só uma forma de mostrar todos os itens da lista separados por vírgula.

---

#### **5. Vendo todos os itens da lista**
Para mostrar ou usar todos os itens, você pode "percorrer" a lista com um `foreach`. É como abrir a mochila e olhar cada coisa dentro dela.

**Exemplo:**
```csharp
List<string> frutas = new List<string> { "Maçã", "Banana", "Laranja" };
foreach (string fruta in frutas)
{
    Console.WriteLine("Fruta: " + fruta);
}
```

**Saída:**
```
Fruta: Maçã
Fruta: Banana
Fruta: Laranja
```

---

#### **6. Verificando se algo está na lista**
Você pode perguntar se um item está na lista usando o método `Contains`. Ele responde `true` (verdadeiro) ou `false` (falso).

**Exemplo:**
```csharp
List<string> frutas = new List<string> { "Maçã", "Banana", "Laranja" };
if (frutas.Contains("Banana"))
{
    Console.WriteLine("Tem banana na lista!");
}
else
{
    Console.WriteLine("Não tem banana na lista!");
}
```

**Saída:** `Tem banana na lista!`

---

#### **7. Ordenando a lista**
Se quiser colocar os itens em ordem (alfabética para palavras ou numérica para números), use o método `Sort`.

**Exemplo:**
```csharp
List<string> frutas = new List<string> { "Laranja", "Maçã", "Banana" };
frutas.Sort(); // Coloca em ordem alfabética
Console.WriteLine(string.Join(", ", frutas)); // Mostra: Banana, Laranja, Maçã
```

**Outro exemplo com números:**
```csharp
List<int> numeros = new List<int> { 30, 10, 20 };
numeros.Sort(); // Coloca em ordem numérica
Console.WriteLine(string.Join(", ", numeros)); // Mostra: 10, 20, 30
```

---

#### **8. Exemplo completo: Montando um programa**
Vamos juntar tudo em um programinha que usa listas. Ele vai:
- Criar uma lista de nomes.
- Adicionar nomes.
- Mostrar quantos nomes tem.
- Remover um nome.
- Mostrar todos os nomes em ordem.

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Criando uma lista de nomes
        List<string> nomes = new List<string>();

        // Adicionando nomes
        nomes.Add("João");
        nomes.Add("Maria");
        nomes.Add("Ana");

        // Mostrando quantos nomes
        Console.WriteLine("Quantos nomes? " + nomes.Count); // Mostra: 3

        // Removendo um nome
        nomes.Remove("Maria");
        Console.WriteLine("Depois de remover Maria, quantos nomes? " + nomes.Count); // Mostra: 2

        // Ordenando
        nomes.Sort();

        // Mostrando todos os nomes
        Console.WriteLine("Nomes na lista:");
        foreach (string nome in nomes)
        {
            Console.WriteLine(nome);
        }
    }
}
```

**Saída:**
```
Quantos nomes? 3
Depois de remover Maria, quantos nomes? 2
Nomes na lista:
Ana
João
```

---

#### **9. Dicas importantes**
- **Cuidado com índices**: Se tentar acessar `frutas[10]` em uma lista com 3 itens, vai dar erro (`IndexOutOfRangeException`). Sempre cheque o `Count` antes!
- **Listas vazias**: Se a lista estiver vazia, `Count` será 0, e tentar usar `frutas[0]` também dá erro.
- **Pratique muito**: Tente criar listas com números, palavras ou até misturar operações (adicionar, remover, ordenar).

---

#### **10. Exercício para praticar**
Crie um programa que:
1. Faça uma lista de números.
2. Adicione 4 números (ex.: 5, 10, 15, 20).
3. Remova o número 10.
4. Mostre todos os números em ordem crescente.

**Tente fazer sozinho antes de ver a solução!**

**Solução:**
```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numeros = new List<int>();
        numeros.Add(5);
        numeros.Add(10);
        numeros.Add(15);
        numeros.Add(20);

        numeros.Remove(10);
        numeros.Sort();

        Console.WriteLine("Números na lista:");
        foreach (int numero in numeros)
        {
            Console.WriteLine(numero);
        }
    }
}
```

**Saída:**
```
Números na lista:
5
15
20
```

---

#### **11. Resumo dos comandos que usamos**
- `Add(item)`: Coloca um item no final da lista.
- `Remove(item)`: Tira a primeira vez que o item aparece.
- `RemoveAt(índice)`: Tira o item na posição indicada.
- `Count`: Diz quantos itens a lista tem.
- `Contains(item)`: Checa se o item está na lista.
- `Sort()`: Coloca a lista em ordem.
- `foreach`: Usado para mostrar ou usar cada item da lista.
