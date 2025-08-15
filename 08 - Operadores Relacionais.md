Operadores relacionais são símbolos que verificam a relação entre duas espreções. 
As operações de relação são as seguintes:

1. Igualdade: ' == '
2. Diferença: '!='
3. Extremamente Diferente: '!== '
4. Menor: '<'
5. Maior: '>'
6. Menor ou igual: '<='
7. Maior ou igual: '>='

Ex.:
```cs 
var idade = 0;
const var ano_atual = 2025;
dynamic ano_nasci;
dynamic resultado;

Console.Write("Digite a sua idade: ");
idade = Convert.ToInt32(Console.ReadLine())

ano_nasci = ano_atual - idade;

if(idade == 10)
{
	resultado = "Ou, vc tem apenas " + idade.ToString() + " de idade";
}
else if (idade >= 18 )
{
	resultado = "Ou, vc é maior de idade, com " + idade.ToString() + " de idade";
}
else if (idade < 6 )
{
	resultado = "Ou, vc é um BB, tens " + idade.ToString() + " de idade";
}
else if (idade > 6 )
{
	resultado = "Vc não é mas criança, tens " + idade.ToString() + " de idade";
}
else if (idade <= 12 )
{
	resultado = "Ou, vc nem é adolescente, tens " + idade.ToString() + " de idade";
}
else if (idade != 6 )
{
	resultado = "Ou, vc tem apenas " + idade.ToString() + " de idade";
}
else if (idade !== 17 )
{
	resultado = "Vc nasceu me " + ano_nasci.ToString() + " de idade";
}
else{resultado = "Molou!";}
Console.WriteLine(resultado);
```
