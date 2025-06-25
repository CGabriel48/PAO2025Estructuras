using System;
using System.Collections.Generic;

namespace AgendaTurnosClinica
{
    // Clase que representa un paciente (registro)
    class Paciente
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Especialidad { get; set; }

        public Paciente(string cedula, string nombre, string fecha, string hora, string especialidad)
        {
            Cedula = cedula;
            Nombre = nombre;
            Fecha = fecha;
            Hora = hora;
            Especialidad = especialidad;
        }

        public override string ToString()
        {
            return $"{Nombre} - {Cedula} - {Fecha} - {Hora} - {Especialidad}";
        }
    }

    // Clase que representa la agenda de turnos
    class AgendaTurnos
    {
        private List<Paciente> turnos = new List<Paciente>();

        public void AgregarTurno(Paciente paciente)
        {
            turnos.Add(paciente);
        }

        public void MostrarTurnos()
        {
            if (turnos.Count == 0)
            {
                Console.WriteLine("No hay turnos registrados.");
                return;
            }

            Console.WriteLine("\nListado de turnos:");
            foreach (var paciente in turnos)
            {
                Console.WriteLine(paciente);
            }
        }

        public void BuscarPorCedula(string cedula)
        {
            var encontrado = turnos.Find(p => p.Cedula == cedula);

            if (encontrado != null)
            {
                Console.WriteLine("Turno encontrado:");
                Console.WriteLine(encontrado);
            }
            else
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }
    }

}