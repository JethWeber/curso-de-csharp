// Métodos Comuns
// • Length: Retorna o número total de elementos no array.
// • Clear(): Define um intervalo de elementos como zero, nulo ou falso.
// • Copy(): Copia elementos de um array para outro.
// • IndexOf(): Retorna o índice da primeira ocorrência de um valor.
// • Reverse(): Inverte a ordem dos elementos.
// • Sort(): Ordena os elementos em ordem crescente.

public class Program
{
    public static void Main(string[] args)
    {
        //neste documento criaremos exemplos de uso dos métodos comuns de arrays
        int[] numeros = { 1, 2, 3, 4, 5 };

        // Exemplo de Length
        Console.WriteLine($"Testando o método Legth(): {numeros.Length}");

        // Exemplo de Clear
        Array.Clear(numeros, 1, 2); // Elimina os itens nos índices 1 e 2 (valores 2 e 3)
        Console.WriteLine("Array após Array.Clear(numeros, 1, 2):");
        foreach (var n in numeros)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();

        // Exemplo de Copy
        int[] numerosCopia = new int[5];
        Array.Copy(numeros, numerosCopia, numeros.Length);
        Console.WriteLine("Array após Array.Copy(numerosCopia, numeros):");
        foreach (var n in numerosCopia)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
        
        // Exemplo de IndexOf
        int indice = Array.IndexOf(numerosCopia, 4);
        Console.WriteLine($"O índice do valor 4 no array é: {indice}");
    }
}
