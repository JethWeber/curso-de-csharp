Esta estrutura é similar ao if-else, só que esta usamos para fazer escolha diante de muitas opções, como no exemplo abaixo.
Ex.: 
```cs 
int dia;
string dia_semana;

Console.Clear();

Console.Write("De 1 a 7, digite um número.: ");
dia = Convert.ToInt32(Console.ReadLine());

switch (dia)
{
    case 1:
        dia_semana = "Domingo";
        break;
    case 2:
        dia_semana = "Segunda";
        break;
    case 3:
        dia_semana = "Terça";
        break;
    case 4:
        dia_semana = "Quarta";
        break;
    case 5:
        dia_semana = "Quinta";
        break;
    case 6:
        dia_semana = "Sexta";
        break;
    case 7:
        dia_semana = "Sábado";
        break;
    default:
        dia_semana = "Dia Inválido!";
        break;

}

Console.WriteLine(dia_semana);

```

