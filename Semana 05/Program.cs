
//Ejercicio 5
//Escibir un programa que almacene el abecedario en una lista
//elimine de la lista las letras que ocupen posiciones multiplos
//de 3 y muestre por pantalla la ista resultante

using System;
using System.Collections.Generic;

namespace Ejercicio5
{
    class Abecedario
    {
        public List<char> Letras { get; set; }

        public Abecedario()
        {
            Letras = new List<char>();
            for (char c = 'A'; c <= 'Z'; c++)
                Letras.Add(c);
        }

        public void EliminarMultiplo3()
        {
            for (int i = Letras.Count - 1; i >= 0; i--)
            {
                if ((i + 1) % 3 == 0)
                    Letras.RemoveAt(i);
            }
        }

        public void Mostrar()
        {
            Console.WriteLine("Abecedario modificado:");
            foreach (var letra in Letras)
            {
                Console.Write(letra + " ");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            Abecedario abc = new Abecedario();
            abc.EliminarMultiplo3();
            abc.Mostrar();
        }
    }
}
