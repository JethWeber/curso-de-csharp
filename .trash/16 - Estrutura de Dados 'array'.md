Arreys são variáveis que podem possuir mais de um valor, cada valor é referenciado por um índice.
Declaração:
```cs 
string[] nomes = {"Weber's Trade" , "Jeth Weber" , "Hidden Haacker" , "Lopes" , "Jones" , "Rafael"};
```

Para acessar cada item de de um arrey, podemos chamar ele e passar como parâmetro a posição do item no array.
```cs 
Console.WriteLine(nomes[1]); //retorna Jeth Weber
Console.WriteLine(nomes.Length); //retorna o número de índices no array
```

Ou ainda pode ser acessado com um loop para varrer todos os dados que estão presentes.
```cs 
foreach(string nome in nomes)
	Console.WriteLine(nome);
```

Na declaração do array 'nomes' já atribuímos os seus valores, mas também podemos fazer uma declaração sem atribuirmos nada, mas devemos informar o número de índices que deve ter no mesmo.
```cs 
int[] numeros = new int[6];//array com 6 posições possíveis

```
