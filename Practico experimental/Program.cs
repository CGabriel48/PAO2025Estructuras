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
}