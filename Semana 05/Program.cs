
//Ejercicio 3
//Escibir un programa que pregunte por una muestra de números 
//,separados por comas, los guarde en una lista y
//lista y los muestre por pantalla ordenados de menor a mayor

using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio3
{
    class Estadisticas
    {
        public List<double> Numeros { get; set; }

        public Estadisticas(string entrada)
        {
            Numeros = entrada.Split(',').Select(double.Parse).ToList();
        }

        public double CalcularMedia()
        {
            return Numeros.Average();
        }

        public double CalcularDesviacionTipica()
        {
            double media = CalcularMedia();
            double suma = Numeros.Sum(n => Math.Pow(n - media, 2));
            return Math.Sqrt(suma / Numeros.Count);
        }

        public void MostrarResultados()
        {
            Console.WriteLine($"Media: {CalcularMedia():0.00}");
            Console.WriteLine($"Desviación típica: {CalcularDesviacionTipica():0.00}");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Ingrese números separados por comas: ");
            string input = Console.ReadLine();

            Estadisticas est = new Estadisticas(input);
            est.MostrarResultados();
        }
    }
}
