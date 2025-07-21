using System;
using System.Collections.Generic;

public class Persona
{
    public string Nombre { get; set; }
    public int Asiento { get; set; }

    public Persona(string nombre, int asiento)
    {
        Nombre = nombre;
        Asiento = asiento;
    }
}

public class Atraccion
{
    private Queue<Persona> cola;
    private int capacidad;

    public Atraccion(int capacidad)
    {
        this.capacidad = capacidad;
        cola = new Queue<Persona>();
    }

    public void AgregarPersona(string nombre)
    {
        if (cola.Count < capacidad)
        {
            int asiento = cola.Count + 1; // Asignar asiento en orden
            Persona nuevaPersona = new Persona(nombre, asiento);
            cola.Enqueue(nuevaPersona);
            Console.WriteLine($"Persona {nombre} ha sido añadida a la cola con asiento {asiento}.");
        }
        else
        {
            Console.WriteLine("No hay asientos disponibles. La atracción está llena.");
        }
    }

    public void MostrarCola()
    {
        if (cola.Count == 0)
        {
            Console.WriteLine("La cola está vacía.");
            return;
        }
        Console.WriteLine("\n--- Personas en la cola ---");
        int i = 1;
        foreach (var persona in cola)
        {
            Console.WriteLine($"{i}. Nombre: {persona.Nombre}, Asiento Asignado: {persona.Asiento}");
            i++;
        }
        Console.WriteLine("---------------------------\n");
    }

    public void AtenderSiguientePersona()
    {
        if (cola.Count > 0)
        {
            Persona personaAtendida = cola.Dequeue();
            Console.WriteLine($"Persona {personaAtendida.Nombre} (Asiento {personaAtendida.Asiento}) ha subido a la atracción.");
        }
        else
        {
            Console.WriteLine("No hay personas en la cola para atender.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Atraccion atraccion = new Atraccion(30); // Capacidad de 30 asientos

        Console.WriteLine("Simulación de Asignación de Asientos en Atracción (Capacidad: 30)");

        // Simulación de agregar personas hasta llenar la capacidad
        for (int i = 1; i <= 30; i++)
        {
            atraccion.AgregarPersona($"Visitante_{i}");
        }

        // Intentar agregar una persona más allá de la capacidad
        atraccion.AgregarPersona("Visitante_31");

        // Mostrar la cola actual
        atraccion.MostrarCola();

        // Simulación de atender algunas personas
        Console.WriteLine("\n--- Atendiendo personas ---");
        atraccion.AtenderSiguientePersona();
        atraccion.AtenderSiguientePersona();
        atraccion.MostrarCola(); // Mostrar cola después de atender
        atraccion.AtenderSiguientePersona();
        atraccion.MostrarCola();

        // Llenar la cola nuevamente para demostrar el ciclo
        Console.WriteLine("\n--- Agregando más personas después de atender ---");
        atraccion.AgregarPersona("Nuevo_Visitante_1");
        atraccion.AgregarPersona("Nuevo_Visitante_2");
        atraccion.MostrarCola();
    }
}
