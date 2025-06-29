// Ejerciocio 1 
//Edscribir un programa que almacene las asignaturas de un curso en
//en una lista y la muestre por panta el mensaje  Yo estudio <asignatura>,
//donde <asignatura> es cada una de las asignaturas de la lista. 
using System;
using System.Collections.Generic;

namespace Ejercicio1
{
    class Asignatura
    {
        public string Nombre { get; set; }

        public Asignatura(string nombre)
        {
            Nombre = nombre;
        }

        public void Mostrar()
        {
            Console.WriteLine($"Yo estudio {Nombre}");
        }
    }

    class Program
    {
        static void Main()
        {
            List<Asignatura> lista = new List<Asignatura>
            {
                new Asignatura("Matemáticas"),
                new Asignatura("Física"),
                new Asignatura("Química"),
                new Asignatura("Historia"),
                new Asignatura("Lengua")
            };

            foreach (var asignatura in lista)
            {
                asignatura.Mostrar();
            }
        }
    }
}
