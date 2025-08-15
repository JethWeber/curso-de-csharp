
# Fundamentos Da Linguagem C#

## **Aula 03 — Constantes e Tipos Dinâmicos (`var` e `dynamic`)**

Na aula anterior, aprendemos sobre variáveis e como elas armazenam informações. Agora, vamos explorar outras formas de guardar dados: as **constantes** (que nunca mudam) e os **tipos dinâmicos** (que se adaptam ao valor que recebem).

-----

### **1. Constantes: Valores que não mudam**

Uma constante é como uma variável, mas com uma regra fundamental: **seu valor não pode ser alterado depois de declarado**. Elas são perfeitas para valores fixos, como números matemáticos, impostos ou IDs que não se modificam.

**Por que usar constantes?**

  * **Legibilidade:** Deixa o código mais fácil de ler. Em vez de usar um número "mágico" como `3.14159`, você usa um nome claro como `pi`.
  * **Manutenção:** Se o valor precisar ser atualizado, você muda em apenas um lugar. Imagine ter que trocar o valor de `3.14159` em 50 lugares diferentes no código\!

**Como declarar:**
Use a palavra-chave `const` antes do tipo de dado. O valor deve ser atribuído no momento da declaração.

```csharp
const double pi = 3.14159;
const int diasNaSemana = 7;
const string sitePrincipal = "www.exemplo.com";

// Tentar alterar o valor de uma constante causará um erro:
// pi = 3.14; // Isso não é permitido!
```

-----

### **2. `var`: O tipo "implícito"**

A palavra-chave `var` permite que o C\# descubra o tipo de dado da variável automaticamente, baseado no valor que você atribui a ela.

**Características:**

  * **O tipo não precisa ser declarado:** O compilador (o programa que traduz seu código) "adivinha" o tipo.
  * **O tipo não muda:** Embora você não escreva o tipo, a variável continua sendo do mesmo tipo para o resto do programa. Se ela for criada como um `string`, ela sempre será um `string`.

**Exemplos:**

```csharp
// O C# "vê" que "Jeth Weber" é uma string, então 'nome' se torna uma string.
var nome = "Jeth Weber";

// O C# "vê" que 29304 é um int, então 'idade' se torna um int.
var idade = 29304;

// O C# "vê" que 12.32 é um double, então 'altura' se torna um double.
var altura = 12.32;

// O tipo de 'nome' é string e não pode ser alterado:
// nome = 10; // Isso causará um erro!
```

**Quando usar `var`?**
Use `var` quando o tipo da variável for óbvio e o código se tornar mais limpo, como em declarações simples. Evite usar `var` quando o tipo não for claro, pois isso pode dificultar a leitura do código por outras pessoas (ou por você mesmo no futuro).

-----

### **3. `dynamic`: O tipo "dinâmico" de verdade**

Diferente do `var`, a palavra-chave `dynamic` cria uma variável cujo tipo pode **mudar durante a execução do programa**. O compilador não verifica o tipo, deixando a verificação para o momento da execução.

**Características:**

  * **Sem verificação de tipo:** O C\# não se importa com o tipo do valor que você atribui a ela.
  * **Flexibilidade total:** O mesmo `dynamic` pode ser um `string`, depois um `int`, depois um `bool`.

**Exemplos:**

```csharp
dynamic variavel = "Jeth Weber"; // 'variavel' é do tipo string
Console.WriteLine(variavel);

variavel = 29304; // Agora, 'variavel' é do tipo int
Console.WriteLine(variavel);

variavel = 12.32; // E agora, 'variavel' é do tipo double
Console.WriteLine(variavel);

variavel = true; // Por fim, 'variavel' é do tipo bool
Console.WriteLine(variavel);
```

**Quando usar `dynamic`?**
O uso de `dynamic` é mais avançado e geralmente é evitado em códigos mais simples e comuns, pois pode causar erros em tempo de execução que seriam pegos pelo compilador com `var` ou com um tipo explícito. É mais útil em cenários específicos, como quando se trabalha com bibliotecas que não usam C\#. Para iniciantes, é importante conhecer, mas não é recomendado usar com frequência.

-----

### **4. Resumo da Aula**

  * **Constantes:** Use `const` para valores que nunca mudam. Deixa o código mais seguro e fácil de manter.
  * **`var` (Tipo Implícito):** Use quando o tipo da variável é óbvio. O compilador infere o tipo e o fixa.
  * **`dynamic` (Tipo Dinâmico):** Use apenas em casos específicos. O tipo da variável pode mudar durante a execução, o que pode levar a erros inesperados.

-----

### **5. Exercício Prático**

Crie um novo projeto no seu computador e pratique o que aprendemos:

1.  Declare uma constante com o valor de pi.
2.  Declare uma variável usando `var` para o seu nome completo.
3.  Tente reatribuir um valor numérico para a variável `var` do seu nome e veja o erro que o compilador te mostra.
4.  Crie uma variável `dynamic` e atribua a ela um texto, depois um número inteiro e por fim um valor booleano, exibindo o valor no console a cada alteração.

-----

### **Próximos Passos**

Agora que você domina como armazenar dados, o próximo passo é a interação com o usuário\! Na próxima aula, vamos aprofundar no **`Console.ReadLine()`**, que nos permite pegar dados digitados no terminal.
