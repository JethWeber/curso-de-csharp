
# 🧠 Fundamentos de Programação em C#

## 📦 Aula 02 — Variáveis

Variáveis são espaços reservados na memória do computador.  
Servem para armazenar valores que serão usados durante a execução do programa.

---

## 🔠 Tipos de Dados

| Tipo     | Descrição                             | Exemplo        |
|----------|----------------------------------------|----------------|
| `string` | Texto ou cadeia de caracteres          | `"Jeth Weber"` |
| `int`    | Números inteiros                       | `12`           |
| `double` | Números com vírgula (decimais)         | `1.80`         |
| `char`   | Um único caractere                     | `'M'`          |
| `bool`   | Verdadeiro ou falso (lógico)           | `true`         |

---

## 🧾 Exemplo

```csharp
namespace Endereco;

public class Program
{
    public static void Main(string[] args)
    {
        string nome = "Jeth Weber";
        int idade = 12;
        double altura = 1.80;
        char genero = 'M';
        bool estuda = true;
        bool namora = false;

        Console.WriteLine("Os dados armazenados são:\n");
        Console.WriteLine("Nome: " + nome);
        Console.WriteLine("Idade: " + idade.ToString());
        Console.WriteLine("Altura: " + altura.ToString());
        Console.WriteLine("Sexo: " + genero);
        Console.WriteLine("Estudante: " + estuda.ToString());
        Console.WriteLine("Namora: " + namora.ToString());
    }
}
```

---

## 🔍 Explicação

- `string` guarda textos.
- `int` guarda números inteiros.
- `double` guarda números com vírgula.
- `char` guarda um único caractere.
- `bool` guarda verdadeiro (`true`) ou falso (`false`).
- `Console.WriteLine()` exibe os valores no terminal.
- `.ToString()` converte o valor para texto.

---

## ✅ Resumo

- Variáveis são usadas para guardar informações.
- Cada tipo de dado tem uma função específica.
- O programa acima mostra como declarar e exibir variáveis.

---
