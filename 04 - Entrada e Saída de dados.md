Um programa é feito para a interação entre máquina e o Homem, para que essa interação aconteça é necessário um fluxo de informação, este fluxo é feito com entrada e saída de informações. 

## Saída de Dados
A Saída de dados em C# é feita principalmente com o comando:
```cs 
Console.WriteLine("Mensagem fica aqui!");
```

## Entrada de Dados
Enquanto a entrada é feita da seguinte forma.:
```cs 
string variavel = Console.ReadLine();
```

O método ReadLine() retorna uma string, para armazenar em vars de outros tipos de dados devemos converter para o tipo da variavel.:
```cs 
int variavel1 = Convert.ToInt32(Console.ReadLine());
boll variavel2 = Convert.ToBool(Console.ReadLine());
```
