Operadores lógicos são espreções símbolos ou espreções usada para comparar duas espreções no sentido lógico.

Operador and (e): ' && ' ==> retorna verdadeiro se as duas operações forem verdadeiras.
Operador or (ou): ' || ' ==>retorna verdadeiro se uma das expeções for verdadeiras.
Operador not (não): ' ! ' ==> nega uma operação, retornando um valor lógico oposto à expreção.

Ex.:
```cs 
int x = 12;
int y = 20;

Console.WriteLine(x == 10 && y == 20) //falso
Console.WriteLine(y == 10 || y == 20) //verdadeiro
Console.WriteLine(!(y == x)) //verdadeiro


```