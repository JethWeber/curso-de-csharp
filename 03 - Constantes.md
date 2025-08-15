Constantes são espaços reservados na memória usado durante a execução do nosso programa mas o seu valor é imutável.
Esta declara-se usando a palavra reservada _const_, o tipo de dados, nome e o seu valor padrão. 

Ex.:
```cs
const string bi = "0000LC433AO4"
```

Além das constantes e variáveis que informamos um tipo de dados na declaração, existem os tipos dinâmicos, isso é não precisamos lhe 'dizer' qual é o seu tipo, ela será tipada com o tipo do valor que ela estiver recebendo.

1. 'var' recebe o tipo do valor que lhe é atribuido, mas o seu tipo não é mutável ao longo do programa. 
Ex.:

```cs
var variavel1 = "Jeth Weber";
var variavel2 = 29304;
var variavel3 = 12.32;
```

2. 'dynamic' recebe o tipo do valor que lhe é atribuido, mas o seu tipo é mutável ao longo do programa. 
Ex.:

```cs
dynamic variavel = "Jeth Weber";
variavel = 29304;
variavel = 12.32;
variavel = true;
```
