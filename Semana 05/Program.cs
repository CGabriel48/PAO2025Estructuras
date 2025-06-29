
//Ejercicio 2 
//Escibir un programa que pregunte por una muestra de números 
//,separados por comas, los guarde en una lista y muestre
//por pantalla su media y desviacion tipica
using System;
using System.Collections.Generic;

namespace Ejercicio2
{
    class Loteria
    {
        public List<int> Numeros { get; private set; }

        public Loteria()
        {
            Numeros = new List<int>();
        }

        public void LeerNumeros()
        {
            Console.WriteLine("Ingrese los 6 números ganadores de la lotería:");
            for (int i = 0; i < 6; i++)
            {
                Console.Write($"Número {i + 1}: ");
                int num = int.Parse(Console.ReadLine());
                Numeros.Add(num);
            }
        }

        public void MostrarOrdenados()
        {
            Numeros.Sort();
            Console.WriteLine("Números ordenados:");
            foreach (int n in Numeros)
            {
                Console.Write($"{n} ");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            Loteria loteria = new Loteria();
            loteria.LeerNumeros();
            loteria.MostrarOrdenados();
        }
    }
}
