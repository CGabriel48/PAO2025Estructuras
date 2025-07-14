using System;
using System.Collections.Generic;

class TorreHanoi
{
    static Stack<int> torreA = new Stack<int>();
    static Stack<int> torreB = new Stack<int>();
    static Stack<int> torreC = new Stack<int>();

    static void Main()
    {
        int n;
        Console.Write("Ingrese la cantidad de discos: ");
        n = int.Parse(Console.ReadLine());

        for (int i = n; i >= 1; i--)
        {
            torreA.Push(i);
        }

        MostrarTorres();
        ResolverHanoi(n, torreA, torreC, torreB, "A", "C", "B");
    }

    static void ResolverHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, string nombreOrigen, string nombreDestino, string nombreAuxiliar)
    {
        if (n > 0)
        {
            ResolverHanoi(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);

            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
            MostrarTorres();

            ResolverHanoi(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
        }
    }

    static void MostrarTorres()
    {
        Console.WriteLine("\nEstado actual de las torres:");
        ImprimirTorre("A", torreA);
        ImprimirTorre("B", torreB);
        ImprimirTorre("C", torreC);
        Console.WriteLine("---------------------------");
    }

    static void ImprimirTorre(string nombre, Stack<int> torre)
    {
        Console.Write($"{nombre}: ");
        foreach (var disco in torre.ToArray())
        {
            Console.Write($"{disco} ");
        }
        Console.WriteLine();
    }
}
