O Laço de repetição While, repete um bloco de código enquanto uma dada condição for verdadeira. 
Ex.: Enquanto 'i' for diferente de 0, Printa olá Mundo.

```cs 
int i = 1;

while(!(i==0)){
	Console.WriteLine("Olá Mundo!");
	Console.Write("\n\nDigite 1 para continuar e 0 para parar.: ");
	i = Convert.ToInt32(Console.ReadLine());

	Console.Clear();

	if(i == 0)
		brek;
}
```
