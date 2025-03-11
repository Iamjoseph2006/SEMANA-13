using System;

class Program
{
    static void Main()
    {
        // Declaramos un array de 10 posiciones para almacenar los títulos de las revistas
        string[] catalogo = new string[10];

        // Solicitamos al usuario que ingrese los 10 títulos de revistas
        Console.WriteLine("Ingrese 10 títulos de revistas:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Título {i + 1}: "); // Pedimos cada título
            catalogo[i] = Console.ReadLine();  // Guardamos el título en el array
        }

        // Bucle infinito para mostrar el menú hasta que el usuario decida salir
        while (true)
        {
            // Mostramos el menú de opciones
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Buscar un título (Iterativa)");
            Console.WriteLine("2. Buscar un título (Recursiva)");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            // Leemos la opción ingresada por el usuario
            int opcion = int.Parse(Console.ReadLine());

            // Si la opción es 3, terminamos el programa
            if (opcion == 3) break;

            // Pedimos al usuario el título que desea buscar
            Console.Write("Ingrese el título a buscar: ");
            string titulo = Console.ReadLine();

            // Variable para almacenar si el título fue encontrado o no
            bool encontrado = false;

            // Dependiendo de la opción elegida, usamos búsqueda iterativa o recursiva
            switch (opcion)
            {
                case 1:
                    encontrado = BusquedaIterativa(catalogo, titulo); // Llamamos a la búsqueda iterativa
                    break;
                case 2:
                    encontrado = BusquedaRecursiva(catalogo, titulo, 0); // Llamamos a la búsqueda recursiva
                    break;
                default:
                    Console.WriteLine("Opción no válida."); // Si la opción no es válida, lo indicamos
                    continue; // Volvemos al inicio del menú
            }

            // Mostramos si el título fue encontrado o no
            Console.WriteLine(encontrado ? "Encontrado" : "No encontrado");
        }
    }

    // Método para realizar la búsqueda iterativa
    static bool BusquedaIterativa(string[] catalogo, string titulo)
    {
        // Recorremos cada elemento del catálogo
        foreach (string item in catalogo)
        {
            // Comparamos el título ignorando mayúsculas y minúsculas
            if (item.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true; // Si encontramos el título, retornamos true
            }
        }
        return false; // Si no encontramos el título, retornamos false
    }

    // Método para realizar la búsqueda recursiva
    static bool BusquedaRecursiva(string[] catalogo, string titulo, int indice)
    {
        // Si llegamos al final del array sin encontrar el título, retornamos false
        if (indice >= catalogo.Length) return false;

        // Comparamos el título actual con el buscado
        if (catalogo[indice].Equals(titulo, StringComparison.OrdinalIgnoreCase)) return true;

        // Llamamos recursivamente a la función con el siguiente índice
        return BusquedaRecursiva(catalogo, titulo, indice + 1);
    }
}
