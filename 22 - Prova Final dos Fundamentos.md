# **Prova Final dos Fundamentos Da Linguagem C#**

#### **Instruções Gerais**
- Escreva cada programa dentro do método correspondente (`Programa1`, `Programa2`, etc.).
- Siga **boas práticas**: use nomes claros para variáveis e métodos, comente o código explicando o que ele faz, e mantenha a organização com indentação.
- Teste seu código com diferentes entradas para garantir que funciona corretamente.
- Use os conceitos aprendidos nos tópicos 01 a 21 (estruturas, variáveis, constantes, entrada/saída, operadores, condicionais, laços, arrays, listas, métodos, conversão de tipos, escopo, comentários).
- Descomente as chamadas dos métodos no `Main` para testar cada programa.

#### **Programa 1: Calculadora de IMC**
**Objetivo**: Crie um programa que leia o peso (em kg) e a altura (em metros) do usuário, calcule o **IMC** (Índice de Massa Corporal, fórmula: `peso / (altura * altura)`) e informe a categoria do IMC:
- Abaixo do peso: IMC < 18.5
- Normal: IMC entre 18.5 e 24.9
- Sobrepeso: IMC entre 25 e 29.9
- Obeso: IMC >= 30

**Requisitos**:
- Use **constantes** para os limites de IMC (ex.: `const double LimiteAbaixoPeso = 18.5`).
- Leia os dados com **entrada/saída** (`Console.ReadLine` e `Console.WriteLine`).
- Use **conversão de tipos** (`double.Parse` ou `double.TryParse`) para os valores inseridos.
- Use **if-else** para determinar a categoria.
- Adicione **comentários** claros e siga **boas práticas** (nomes descritivos, organização).

**Exemplo de entrada/saída**:
```
Digite seu peso (kg): 70
Digite sua altura (m): 1.75
Seu IMC é: 22.86
Categoria: Normal
```

#### **Programa 2: Contador de Números Pares**
**Objetivo**: Leia um número inteiro **N** do usuário e mostre todos os números **pares** de 1 até N.

**Requisitos**:
- Use **while** para percorrer os números.
- Use **operadores relacionais** (ex.: `<=`) e **aritméticos** (ex.: `%` para verificar paridade).
- Use **conversão de tipos** (`int.TryParse`) para ler o número com segurança.
- Se o usuário digitar um número inválido, mostre uma mensagem de erro.
- Adicione **comentários** e siga **boas práticas**.

**Exemplo de entrada/saída**:
```
Digite um número: 10
Números pares de 1 a 10:
2
4
6
8
10
```

#### **Programa 3: Média de Notas com Array**
**Objetivo**: Leia 4 notas de um aluno (armazenadas em um **array**), calcule a média e informe se o aluno foi aprovado (média >= 7).

**Requisitos**:
- Use um **array** de `double` para armazenar as 4 notas.
- Leia as notas com **entrada/saída** e **conversão de tipos** (`double.TryParse`).
- Crie um **método** com retorno para calcular a média.
- Use **for** ou **foreach** para somar as notar.
- Mostre a média e se o aluno foi aprovado (usando **if-else**).
- Siga **boas práticas** e adicione **comentários**.

**Exemplo de entrada/saída**:
```
Digite a nota 1: 7.5
Digite a nota 2: 8.0
Digite a nota 3: 6.5
Digite a nota 4: 9.0
Média: 7.75
Aluno aprovado!
```

#### **Programa 4: Lista de Nomes Favoritos**
**Objetivo**: Permita que o usuário adicione 3 nomes a uma **lista** e, depois, mostre os nomes em ordem alfabética.

**Requisitos**:
- Use uma **List** _string_ para armazenar os nomes. 
- Leia os nomes com entrada/saída (```Console.ReadLine```).
- Use o método `Add` para adicionar nomes e ```Sort``` para ordenar.
- Mostre os nomes com foreach.
- Crie um **método** para exibir a lista.
- Siga **boas práticas** e adicione **comentários**.

**Exemplo de entrada/saída**:
```
Digite o nome 1: João
Digite o nome 2: Maria
Digite o nome 3: Ana
Nomes em ordem alfabética:
Ana
João
Maria
```

#### **Programa 5: Menu Interativo com Switch**
**Objetivo**: Crie um menu interativo com 3 opções:
1. Somar dois números.
2. Multiplicar dois números.
3. Sair.
O programa deve repetir até o usuário escolher a opção 3.

**Requisitos**:
- Use **entrada/saída** para ler a opção e os números.
- Use **switch-case** para processar as opções.
- Use **do-while** para repetir o menu até escolher "Sair".
- Crie **métodos** com retorno para somar e multiplicar.
- Use **conversão de tipos** (`int.TryParse`) para ler números com segurança.
- Respeite o **escopo** (use variáveis locais nos métodos certos).
- Siga **boas práticas** e adicione **comentários**.

**Exemplo de entrada/saída**:
```
Escolha uma opção:
1) Somar
2) Multiplicar
3) Sair
Digite sua escolha: 1
Digite o primeiro número: 5
Digite o segundo número: 3
Resultado da soma: 8
Escolha uma opção:
4) Somar
5) Multiplicar
6) Sair
Digite sua escolha: 3
Programa encerrado!
```

---

#### **Dicas para Resolver a Prova**
- **Comece pelo mais fácil**: Se achar algum programa mais difícil, tente outro primeiro.
- **Teste bastante**: Use diferentes entradas (válidas e inválidas) para garantir que o código funciona.
- **Use os conceitos aprendidos**:
  - Variáveis, constantes, entrada/saída (tópicos 02, 03, 04).
  - Operadores aritméticos, relacionais e lógicos (tópicos 05, 08, 09).
  - Condicionais (`if-else`, `switch-case`) (tópicos 06, 11).
  - Laços (`while`, `do-while`, `for`, `foreach`) (tópicos 12, 13, 14, 15).
  - Arrays e listas (tópicos 16, 17).
  - Métodos, conversão de tipos, escopo (tópicos 18, 19, 20).
  - Comentários e boas práticas (tópico 21).
- **Comente o código**: Explique o que cada parte faz, como visto na aula 21.
- **Organize**: Use nomes claros, indentação e métodos curtos.
