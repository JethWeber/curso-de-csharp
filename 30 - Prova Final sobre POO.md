# Prova Final: Programação Orientada a Objetos em C# 

## Introdução

Esta prova final testa seus conhecimentos em Programação Orientada a Objetos em C#, cobrindo Classes e Objetos, Métodos Construtores, Encapsulamento, Herança, Polimorfismo (sobrescrita e sobrecarga), Classes Abstratas e Interfaces, e Membros Estáticos. A prova inclui questões teóricas (múltipla escolha e verdadeiro/falso) e exercícios práticos de código.

**Instruções**:

- Responda às questões teóricas marcando a alternativa correta.
- Para os exercícios práticos, escreva o código C# solicitado. Você pode testar em um ambiente como Visual Studio ou online.
- Tempo sugerido: 60 minutos.
- Pontuação total: 100 pontos (distribuídos por questão).

Boa sorte!

## Parte 1: Questões Teóricas (40 pontos)

### Questão 1: Classes e Objetos (5 pontos)

Qual é a diferença principal entre uma classe e um objeto?  
a) Uma classe é uma instância da linguagem, enquanto um objeto é um molde.  
b) Uma classe é um molde (blueprint) para criar objetos, enquanto um objeto é uma instância da classe.  
c) Uma classe é estática, e um objeto é dinâmico.  
d) Não há diferença; são sinônimos.

### Questão 2: Métodos Construtores (5 pontos)

Verdadeiro ou Falso: Um construtor sempre deve ter parâmetros e retornar um valor.  
a) Verdadeiro  
b) Falso

### Questão 3: Encapsulamento (5 pontos)

Qual modificador de acesso é usado para tornar um atributo acessível apenas dentro da classe, promovendo encapsulamento?  
a) public  
b) protected  
c) private  
d) static

### Questão 4: Herança (5 pontos)

Em herança, o que significa o termo "classe base"?  
a) A classe filha que herda propriedades.  
b) A classe pai da qual outras classes herdam.  
c) Uma classe abstrata sem métodos.  
d) Uma classe que não pode ser herdada.

### Questão 5: Polimorfismo (5 pontos)

Qual é a diferença entre sobrescrita (override) e sobrecarga (overload)?  
a) Sobrescrita ocorre na mesma classe, sobrecarga em classes diferentes.  
b) Sobrescrita redefine um método em uma classe filha, sobrecarga cria múltiplas versões de um método na mesma classe.  
c) Ambas são iguais, apenas nomes diferentes.  
d) Sobrescrita usa parâmetros, sobrecarga não.

### Questão 6: Classes Abstratas e Interfaces (5 pontos)

Verdadeiro ou Falso: Uma classe pode herdar de múltiplas classes abstratas, mas implementar apenas uma interface.  
a) Verdadeiro  
b) Falso

### Questão 7: Membros Estáticos (5 pontos)

Qual é uma característica chave de um método estático?  
a) Pode acessar atributos de instância diretamente.  
b) Pertence à classe, não a objetos, e é chamado pelo nome da classe.  
c) É sempre abstrato.  
d) Pode ser sobrescrito em classes filhas.

### Questão 8: Conceitos Gerais (5 pontos)

Qual pilar da POO permite que um objeto de uma classe filha seja tratado como um objeto da classe pai?  
a) Encapsulamento  
b) Herança  
c) Polimorfismo  
d) Abstração

## Parte 2: Exercícios Práticos (60 pontos)

### Exercício 1: Classes e Objetos com Construtores e Encapsulamento (15 pontos)

Crie uma classe `Pessoa` com:

- Atributos privados: `nome` (string) e `idade` (int).
- Propriedades públicas para acessar e modificar esses atributos, com validação para que a idade não seja negativa.
- Um construtor que inicialize nome e idade.
- Um método `Apresentar` que exiba: "Olá, meu nome é [nome] e tenho [idade] anos."

No método `Main`, crie dois objetos de `Pessoa` e chame o método `Apresentar` para cada um.

### Exercício 2: Herança e Polimorfismo (15 pontos)

Crie uma classe base `Forma` com um método virtual `CalcularArea()` que retorna 0.  
Crie duas classes filhas:

- `Retangulo` com atributos `largura` e `altura`, construtor para inicializá-los, e sobrescrita de `CalcularArea()` para retornar largura * altura.
- `Circulo` com atributo `raio`, construtor para inicializá-lo, e sobrescrita de `CalcularArea()` para retornar Math.PI * raio * raio.

No `Main`, use um array de `Forma` para armazenar um retângulo e um círculo, e chame `CalcularArea()` para cada um usando um loop.

### Exercício 3: Classes Abstratas e Interfaces (15 pontos)

Crie uma interface `IImprimivel` com um método `Imprimir()`.  
Crie uma classe abstrata `Documento` com um atributo protegido `titulo` e um construtor para inicializá-lo.  
Crie uma classe `Relatorio` que herde de `Documento` e implemente `IImprimivel`, onde `Imprimir()` exibe: "Imprimindo relatório: [titulo]".

No `Main`, crie um objeto de `Relatorio` e chame `Imprimir()`.

### Exercício 4: Membros Estáticos e Sobrecarga (15 pontos)

Crie uma classe `Utilitarios` com:

- Um atributo estático `Contador` inicializado em 0.
- Um método estático sobrecarregado `Incrementar()`: uma versão sem parâmetros que incrementa `Contador` em 1, e outra com um parâmetro int que incrementa `Contador` pelo valor passado.
- Um método estático `ExibirContador()` que exibe o valor de `Contador`.

No `Main`, chame as versões de `Incrementar()` várias vezes e exiba o contador.