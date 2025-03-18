using System;

class Nodo
{
    public string Clave;  // La clave es el título de la revista
    public Nodo Izquierdo, Derecho;  // Referencias a los subárboles izquierdo y derecho

    public Nodo(string clave)
    {
        Clave = clave;  // Asigna el título al nodo
        Izquierdo = Derecho = null;  // Inicializa los hijos como nulos
    }
}

class ArbolBinarioBusqueda
{
    private Nodo raiz;  // Nodo raíz del árbol

    // Método para insertar un nuevo título en el árbol
    public void Insertar(string clave)
    {
        raiz = InsertarRec(raiz, clave);
    }

    // Método recursivo para insertar un nodo en la posición correcta
    private Nodo InsertarRec(Nodo nodo, string clave)
    {
        if (nodo == null)  // Si el nodo actual es nulo, crea un nuevo nodo con la clave
            return new Nodo(clave);

        // Compara el título con el nodo actual para decidir en qué subárbol insertarlo
        if (string.Compare(clave, nodo.Clave, StringComparison.OrdinalIgnoreCase) < 0)
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, clave);  // Inserta en el subárbol izquierdo si es menor
        else if (string.Compare(clave, nodo.Clave, StringComparison.OrdinalIgnoreCase) > 0)
            nodo.Derecho = InsertarRec(nodo.Derecho, clave);  // Inserta en el subárbol derecho si es mayor

        return nodo;  // Retorna el nodo actualizado
    }

    // Método para mostrar los títulos ordenados (Recorrido Inorden)
    public void MostrarOrdenados()
    {
        Console.WriteLine("\nTítulos de revistas ordenados:");
        Inorden(raiz);
        Console.WriteLine();
    }

    // Método recursivo para recorrer el árbol en orden (izquierda - raíz - derecha)
    private void Inorden(Nodo nodo)
    {
        if (nodo != null)
        {
            Inorden(nodo.Izquierdo);  // Recorre el subárbol izquierdo
            Console.WriteLine(nodo.Clave);  // Muestra el título del nodo actual
            Inorden(nodo.Derecho);  // Recorre el subárbol derecho
        }
    }

    // Método para buscar un título en el árbol
    public bool Buscar(string clave)
    {
        return BuscarRec(raiz, clave);
    }

    // Método recursivo para buscar un título en el árbol
    private bool BuscarRec(Nodo nodo, string clave)
    {
        if (nodo == null)
            return false;  // El título no fue encontrado

        // Compara el título con el nodo actual para decidir en qué subárbol buscarlo
        if (string.Compare(clave, nodo.Clave, StringComparison.OrdinalIgnoreCase) < 0)
            return BuscarRec(nodo.Izquierdo, clave);  // Busca en el subárbol izquierdo si es menor
        else if (string.Compare(clave, nodo.Clave, StringComparison.OrdinalIgnoreCase) > 0)
            return BuscarRec(nodo.Derecho, clave);  // Busca en el subárbol derecho si es mayor
        else
            return true;  // El título fue encontrado
    }
}

class Program
{
    static void Main()
    {
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();  // Crea el árbol binario

        // Ingresar 10 títulos de revistas
        Console.WriteLine("Ingrese 10 títulos de revistas:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Título {i + 1}: ");
            string clave = Console.ReadLine();  // Captura el título ingresado por el usuario
            arbol.Insertar(clave);  // Inserta el título en el árbol
        }

        // Mostrar los títulos ordenados
        arbol.MostrarOrdenados();

        // Menú de búsqueda
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\nSeleccione una opción:");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    // Buscar un título
                    Console.Write("Ingrese el título a buscar: ");
                    string buscarTitulo = Console.ReadLine();
                    if (arbol.Buscar(buscarTitulo))
                        Console.WriteLine("Título encontrado.");
                    else
                        Console.WriteLine("Título no encontrado.");
                    break;

                case "2":
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }
}