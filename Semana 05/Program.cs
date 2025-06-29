
//Ejercicio 4
//Escibir un programa que pida al usuario una palabra y muestre
//en la pantalla si es un palindromo

using System;
namespace Ejercicio4
{
    class Palindromo
    {
        public string Palabra { get; set; }

        public Palindromo(string palabra)
        {
            Palabra = palabra.ToLower();
        }

        public bool EsPalindromo()
        {
            string inversa = new string(Palabra.Reverse().ToArray());
            return Palabra == inversa;
        }

        public void MostrarResultado()
        {
            if (EsPalindromo())
                Console.WriteLine("Es un palíndromo.");
            else
                Console.WriteLine("No es un palíndromo.");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Ingrese una palabra: ");
            string entrada = Console.ReadLine();

            Palindromo palabra = new Palindromo(entrada);
            palabra.MostrarResultado();
        }
    }
}
