A estrutura condicional if-else é usado para os programas tomarem 'decisões'.
```cs 
if(true)
{
	//este comando ou bloco é executado
}
else 
{
	//se a condição acima não for verdadeiro ese bloco é executado
}
```
Ex.:
```cs 
int x = 23; 

if (!x.IsEmpty())
	Console.WriteLine("Variavel tem o valor " + x.ToString())
else
	Console.WriteLine("Variavel vazia!")
```