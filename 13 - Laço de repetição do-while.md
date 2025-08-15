O laço de repetição do-while é similar ao while, o while executa o laço depois de verificar se a condição é verdadeira, já o do-while primeiro executa e só depois verifica se a condição é verdadeira.
Ex.:
```cs 
int i = 1;

do {
	Console.WriteLine("Olá Mundo!");
	Console.Write("\n\nDigite 1 para continuar e 0 para parar.: ");
	i = Convert.ToInt32(Console.ReadLine());

	Console.Clear();

	if(i == 0)
		brek;
} while(!(i==0));
```