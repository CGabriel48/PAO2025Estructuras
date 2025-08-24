
public class Ciudadano
{
    public string Nombre { get; set; }
    public bool VacunadoConPfizer { get; set; }
    public bool VacunadoConAstraZeneca { get; set; }

    public Ciudadano(string nombre)
    {
        Nombre = nombre;
        VacunadoConPfizer = false;
        VacunadoConAstraZeneca = false;
    }
}

public class Program
{
    public static void Main()
    {
        List<Ciudadano> ciudadanos = new List<Ciudadano>();
        Random random = new Random();

        // Generar 500 ciudadanos
        for (int i = 1; i <= 500; i++)
        {
            var ciudadano = new Ciudadano($"Ciudadano {i}");
            ciudadanos.Add(ciudadano);
        }

        // Vacunar 75 ciudadanos con Pfizer
        for (int i = 0; i < 75; i++)
        {
            int index;
            do
            {
                index = random.Next(0, 500);
            } while (ciudadanos[index].VacunadoConPfizer || ciudadanos[index].VacunadoConAstraZeneca);

            ciudadanos[index].VacunadoConPfizer = true;
        }

        // Vacunar 75 ciudadanos con AstraZeneca
        for (int i = 0; i < 75; i++)
        {
            int index;
            do
            {
                index = random.Next(0, 500);
            } while (ciudadanos[index].VacunadoConPfizer || ciudadanos[index].VacunadoConAstraZeneca);

            ciudadanos[index].VacunadoConAstraZeneca = true;
        }

        // Listados solicitados
        var noVacunados = ciudadanos.Where(c => !c.VacunadoConPfizer && !c.VacunadoConAstraZeneca).ToList();
        var vacunadosAmbasDosis = ciudadanos.Where(c => c.VacunadoConPfizer && c.VacunadoConAstraZeneca).ToList();
        var soloPfizer = ciudadanos.Where(c => c.VacunadoConPfizer && !c.VacunadoConAstraZeneca).ToList();
        var soloAstraZeneca = ciudadanos.Where(c => !c.VacunadoConPfizer && c.VacunadoConAstraZeneca).ToList();

        // Mostrar resultados
        Console.WriteLine($"Ciudadanos no vacunados: {noVacunados.Count}");
        Console.WriteLine($"Ciudadanos vacunados con ambas dosis: {vacunadosAmbasDosis.Count}");
        Console.WriteLine($"Ciudadanos solo vacunados con Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Ciudadanos solo vacunados con AstraZeneca: {soloAstraZeneca.Count}");
    }
}

