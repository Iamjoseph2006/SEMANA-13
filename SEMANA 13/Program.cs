using System;  // Importa el espacio de nombres para entrada/salida estándar

// Clase que representa un nodo del árbol binario
public class Nodo
{
    public string Valor;  // Almacena el valor del nodo (título de la revista)
    public Nodo Izquierdo, Derecho;  // Referencias a los hijos izquierdo y derecho

    // Constructor que inicializa el nodo con un valor y sin hijos
    public Nodo(string valor)
    {
        Valor = valor;
        Izquierdo = Derecho = null;
    }
}

// Clase que representa un Árbol Binario de Búsqueda (ABB)
public class ArbolBinarioBusqueda
{
    private Nodo raiz;  // Raíz del árbol

    // Método para insertar un nuevo título en el árbol
    public void Insertar(string valor)
    {
        raiz = InsertarRecursivo(raiz, valor);  // Llama al método recursivo de inserción
    }

    // Método recursivo para insertar un nodo en el árbol
    private Nodo InsertarRecursivo(Nodo nodo, string valor)
    {
        if (nodo == null)  // Si el nodo está vacío, se crea uno nuevo con el valor
            return new Nodo(valor);

        int comparacion = string.Compare(valor, nodo.Valor, StringComparison.OrdinalIgnoreCase);

        if (comparacion < 0)  // Si el valor es menor, se inserta en el subárbol izquierdo
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);
        else if (comparacion > 0)  // Si el valor es mayor, se inserta en el subárbol derecho
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);

        return nodo;  // Retorna el nodo actualizado
    }

    // Método público para buscar un título en el árbol de forma recursiva
    public bool BuscarRecursivo(string valor)
    {
        return BuscarRec(raiz, valor);  // Llama al método privado de búsqueda recursiva
    }

    // Método recursivo para buscar un título
    private bool BuscarRec(Nodo nodo, string valor)
    {
        if (nodo == null)  // Si el nodo es nulo, el valor no está en el árbol
            return false;

        int comparacion = string.Compare(valor, nodo.Valor, StringComparison.OrdinalIgnoreCase);

        if (comparacion == 0)  // Si el valor coincide con el nodo actual, se encontró
            return true;
        else if (comparacion < 0)  // Si el valor es menor, buscar en el subárbol izquierdo
            return BuscarRec(nodo.Izquierdo, valor);
        else  // Si el valor es mayor, buscar en el subárbol derecho
            return BuscarRec(nodo.Derecho, valor);
    }

    // Método público para buscar un título en el árbol de forma iterativa
    public bool BuscarIterativo(string valor)
    {
        Nodo actual = raiz;  // Se inicia la búsqueda desde la raíz
        while (actual != null)  // Mientras haya nodos en el árbol
        {
            int comparacion = string.Compare(valor, actual.Valor, StringComparison.OrdinalIgnoreCase);

            if (comparacion == 0)  // Si el valor coincide, se encontró
                return true;
            else if (comparacion < 0)  // Si el valor es menor, moverse al subárbol izquierdo
                actual = actual.Izquierdo;
            else  // Si el valor es mayor, moverse al subárbol derecho
                actual = actual.Derecho;
        }
        return false;  // Si el bucle termina, el valor no está en el árbol
    }

    // Método para mostrar los títulos en orden alfabético
    public void MostrarOrdenado()
    {
        MostrarEnOrden(raiz);  // Llama al método privado de recorrido en orden
    }

    // Método recursivo para recorrer el árbol en orden
    private void MostrarEnOrden(Nodo nodo)
    {
        if (nodo != null)  // Si el nodo no es nulo
        {
            MostrarEnOrden(nodo.Izquierdo);  // Recorrer el subárbol izquierdo
            Console.WriteLine(nodo.Valor);  // Imprimir el valor del nodo
            MostrarEnOrden(nodo.Derecho);  // Recorrer el subárbol derecho
        }
    }
}

// Clase principal del programa
class Program
{
    static void Main()
    {
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();  // Crea un árbol binario de búsqueda

        // Pedir al usuario que ingrese 10 títulos de revistas
        Console.WriteLine("Ingrese 10 títulos de revistas:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Título {i + 1}: ");
            string titulo = Console.ReadLine();  // Captura el título ingresado por el usuario
            arbol.Insertar(titulo);  // Inserta el título en el árbol
        }

        // Mostrar los títulos ordenados alfabéticamente
        Console.WriteLine("\nRevistas ordenadas:");
        arbol.MostrarOrdenado();

        // Menú interactivo para búsqueda de títulos
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\nSeleccione una opción:");
            Console.WriteLine("1. Buscar un título (Recursivo)");
            Console.WriteLine("2. Buscar un título (Iterativo)");
            Console.WriteLine("3. Salir");
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el título a buscar: ");
                    string buscarRec = Console.ReadLine();
                    if (arbol.BuscarRecursivo(buscarRec))  // Llama a la búsqueda recursiva
                        Console.WriteLine("Título encontrado.");
                    else
                        Console.WriteLine("Título no encontrado.");
                    break;

                case "2":
                    Console.Write("Ingrese el título a buscar: ");
                    string buscarIter = Console.ReadLine();
                    if (arbol.BuscarIterativo(buscarIter))  // Llama a la búsqueda iterativa
                        Console.WriteLine("Título encontrado.");
                    else
                        Console.WriteLine("Título no encontrado.");
                    break;

                case "3":
                    continuar = false;  // Sale del bucle y termina el programa
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }
}
