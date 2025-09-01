using System.Text;
using System.Text.RegularExpressions;

class TraductorBasico
{
    // Diccionarios para traducción inglés -> español y español -> inglés
    static Dictionary<string, string> inglesAEspanol = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    static Dictionary<string, string> espanolAingles = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    static void Main()
    {
        InicializarDiccionarios();

        while (true)
        {
            Console.WriteLine("==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    TraducirFrase();
                    break;
                case "2":
                    AgregarPalabra();
                    break;
                case "0":
                    Console.WriteLine("Saliendo...");
                    return;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void InicializarDiccionarios()
    {
        // Lista base de palabras sugeridas en la plataforma
        var basePalabras = new List<(string ingles, string espanol)>
        {
            ("time", "tiempo"),
            ("person", "persona"),
            ("year", "año"),
            ("way", "camino"),
            ("day", "día"),
            ("thing", "cosa"),
            ("man", "hombre"),
            ("world", "mundo"),
            ("life", "vida"),
            ("hand", "mano"),
            ("part", "parte"),
            ("child", "niño"),
            ("eye", "ojo"),
            ("woman", "mujer"),
            ("place", "lugar"),
            ("work", "trabajo"),
            ("week", "semana"),
            ("case", "caso"),
            ("point", "punto"),
            ("government", "gobierno"),
            ("company", "empresa")
        };

        foreach (var (ingles, espanol) in basePalabras)
        {
            if (!inglesAEspanol.ContainsKey(ingles))
                inglesAEspanol.Add(ingles, espanol);
            if (!espanolAingles.ContainsKey(espanol))
                espanolAingles.Add(espanol, ingles);
        }
    }

    static void TraducirFrase()
    {
        Console.Write("Ingrese la frase a traducir: ");
        string frase = Console.ReadLine();

        // Preguntar a que idioma traducir
        Console.WriteLine("Seleccione dirección de traducción:");
        Console.WriteLine("1. Inglés -> Español");
        Console.WriteLine("2. Español -> Inglés");
        Console.Write("Opción: ");
        string direccion = Console.ReadLine();

        Dictionary<string, string> diccionario;
        if (direccion == "1")
            diccionario = inglesAEspanol;
        else if (direccion == "2")
            diccionario = espanolAingles;
        else
        {
            Console.WriteLine("Dirección inválida. Se usará Inglés -> Español por defecto.");
            diccionario = inglesAEspanol;
        }

        string traduccion = Traducir(frase, diccionario);
        Console.WriteLine("Traducción parcial:");
        Console.WriteLine(traduccion);
    }

    static string Traducir(string frase, Dictionary<string, string> diccionario)
    {
        // Usamos regex para separar palabras y signos de puntuación
        var regex = new Regex(@"\w+|[^\w\s]", RegexOptions.Compiled);
        var matches = regex.Matches(frase);

        StringBuilder resultado = new StringBuilder();

        foreach (Match match in matches)
        {
            string token = match.Value;

            // verificar si es palabra
            if (Regex.IsMatch(token, @"^\w+$"))
            {
                // Guardar la forma original para respetar mayúsculas
                string original = token;
                string minuscula = token.ToLower();

                if (diccionario.TryGetValue(minuscula, out string traduccion))
                {
                    // Respetar mayúsculas iniciales o todo mayúsculas
                    if (EsTodoMayusculas(original))
                        traduccion = traduccion.ToUpper();
                    else if (EsPrimeraMayuscula(original))
                        traduccion = Capitalizar(traduccion);

                    resultado.Append(traduccion);
                }
                else
                {
                    // si no está en el diccionario, se mantiene
                    resultado.Append(original);
                }
            }
            else
            {
                // No es palabra, puede ser espacio o puntuación
                resultado.Append(token);
            }
        }

        return resultado.ToString();
    }

    static bool EsPrimeraMayuscula(string palabra)
    {
        if (string.IsNullOrEmpty(palabra)) return false;
        return char.IsUpper(palabra[0]) && palabra.Substring(1).ToLower() == palabra.Substring(1);
    }

    static bool EsTodoMayusculas(string palabra)
    {
        return palabra.ToUpper() == palabra;
    }

    static string Capitalizar(string palabra)
    {
        if (string.IsNullOrEmpty(palabra)) return palabra;
        return char.ToUpper(palabra[0]) + palabra.Substring(1).ToLower();
    }

    static void AgregarPalabra()
    {
        Console.WriteLine("Agregar nueva palabra al diccionario.");

        Console.Write("Ingrese la palabra en inglés: ");
        string ingles = Console.ReadLine().Trim().ToLower();

        Console.Write("Ingrese la palabra en español: ");
        string espanol = Console.ReadLine().Trim().ToLower();

        if (string.IsNullOrEmpty(ingles) || string.IsNullOrEmpty(espanol))
        {
            Console.WriteLine("No se permiten palabras vacías.");
            return;
        }

        if (inglesAEspanol.ContainsKey(ingles))
        {
            Console.WriteLine($"La palabra '{ingles}' ya existe en el diccionario con traducción '{inglesAEspanol[ingles]}'.");
        }
        else
        {
            inglesAEspanol.Add(ingles, espanol);
            Console.WriteLine($"Palabra '{ingles}' agregada con traducción '{espanol}'.");
        }

        if (espanolAingles.ContainsKey(espanol))
        {
            Console.WriteLine($"La palabra '{espanol}' ya existe en el diccionario con traducción '{espanolAingles[espanol]}'.");
        }
        else
        {
            espanolAingles.Add(espanol, ingles);
        }
    }
}