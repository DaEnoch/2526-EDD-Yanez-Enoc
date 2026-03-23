using System;

// Clase del nodo
class Nodo
{
    public int Valor;        // aqui se guarda el valor
    public Nodo Izq;         // hijo izquierdo
    public Nodo Der;         // hijo derecho

    public Nodo(int valor)
    {
        Valor = valor;       // constructor simple
    }
}

// Clase del Árbol Binario de Búsqueda
class BST
{
    public Nodo Raiz;        // aqui guardamos la raiz

    // Insertar un valor
    public void Insertar(int valor)
    {
        Raiz = InsertarRec(Raiz, valor);  // llamada a recursivo
    }

    private Nodo InsertarRec(Nodo actual, int valor)
    {
        if (actual == null)
        {
            return new Nodo(valor); // aqui se crea un nodo
        }

        if (valor < actual.Valor)
            actual.Izq = InsertarRec(actual.Izq, valor);  // va a izquierda
        else if (valor > actual.Valor)
            actual.Der = InsertarRec(actual.Der, valor);  // va a derecha

        return actual;
    }

    // Buscar un valor
    public bool Buscar(int valor)
    {
        return BuscarRec(Raiz, valor) != null; // si devuelve algo existe
    }

    private Nodo BuscarRec(Nodo actual, int valor)
    {
        if (actual == null || actual.Valor == valor)
            return actual; // aqui se encontró

        if (valor < actual.Valor)
            return BuscarRec(actual.Izq, valor);

        return BuscarRec(actual.Der, valor);
    }

    // Eliminar un valor
    public void Eliminar(int valor)
    {
        Raiz = EliminarRec(Raiz, valor);
    }

    private Nodo EliminarRec(Nodo actual, int valor)
    {
        if (actual == null) return actual; // no existe

        if (valor < actual.Valor)
            actual.Izq = EliminarRec(actual.Izq, valor); 
        else if (valor > actual.Valor)
            actual.Der = EliminarRec(actual.Der, valor);
        else
        {
            // aqui se elimina
            if (actual.Izq == null)
                return actual.Der;
            else if (actual.Der == null)
                return actual.Izq;

            // buscar el mínimo del subárbol derecho
            actual.Valor = Minimo(actual.Der);
            actual.Der = EliminarRec(actual.Der, actual.Valor);
        }

        return actual;
    }

    // Obtener mínimo
    public int Minimo(Nodo actual)
    {
        while (actual.Izq != null)
            actual = actual.Izq;  // ir a la izquierda
        return actual.Valor;
    }

    // Obtener máximo
    public int Maximo(Nodo actual)
    {
        while (actual.Der != null)
            actual = actual.Der; // ir a derecha
        return actual.Valor;
    }

    // Altura del árbol
    public int Altura(Nodo actual)
    {
        if (actual == null) return -1; // aqui definimos altura vacía

        int izq = Altura(actual.Izq);
        int der = Altura(actual.Der);

        return Math.Max(izq, der) + 1;  // altura mayor + 1
    }

    // Recorrido Preorden
    public void Preorden(Nodo actual)
    {
        if (actual == null) return;

        Console.Write(actual.Valor + " ");      // visita raiz
        Preorden(actual.Izq);
        Preorden(actual.Der);
    }

    // Recorrido Inorden
    public void Inorden(Nodo actual)
    {
        if (actual == null) return;

        Inorden(actual.Izq);
        Console.Write(actual.Valor + " ");      // visita nodo
        Inorden(actual.Der);
    }

    // Recorrido Postorden
    public void Postorden(Nodo actual)
    {
        if (actual == null) return;

        Postorden(actual.Izq);
        Postorden(actual.Der);
        Console.Write(actual.Valor + " ");      // visita al final
    }

    // Limpiar árbol
    public void Limpiar()
    {
        Raiz = null;     // aqui limpiamos todo
    }
}

class Program
{
    static void Main(string[] args)
    {
        BST arbol = new BST(); 
        int opcion = 0;

        while (opcion != 8)
        {
            Console.WriteLine("\n--- MENU BST ---");
            Console.WriteLine("1. Insertar valor");
            Console.WriteLine("2. Buscar valor");
            Console.WriteLine("3. Eliminar valor");
            Console.WriteLine("4. Mostrar recorridos");
            Console.WriteLine("5. Mostrar minimo y maximo");
            Console.WriteLine("6. Mostrar altura del arbol");
            Console.WriteLine("7. Limpiar arbol");
            Console.WriteLine("8. Salir");
            Console.Write("Opcion: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Valor a insertar: ");
                    int v1 = int.Parse(Console.ReadLine());
                    arbol.Insertar(v1);
                    break;

                case 2:
                    Console.Write("Valor a buscar: ");
                    int v2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(v2) ? "Existe" : "No existe");
                    break;

                case 3:
                    Console.Write("Valor a eliminar: ");
                    int v3 = int.Parse(Console.ReadLine());
                    arbol.Eliminar(v3);
                    break;

                case 4:
                    Console.WriteLine("Preorden:");
                    arbol.Preorden(arbol.Raiz);
                    Console.WriteLine("\nInorden:");
                    arbol.Inorden(arbol.Raiz);
                    Console.WriteLine("\nPostorden:");
                    arbol.Postorden(arbol.Raiz);
                    Console.WriteLine();
                    break;

                case 5:
                    if (arbol.Raiz != null)
                    {
                        Console.WriteLine("Minimo: " + arbol.Minimo(arbol.Raiz));
                        Console.WriteLine("Maximo: " + arbol.Maximo(arbol.Raiz));
                    }
                    else
                    {
                        Console.WriteLine("Arbol vacio");
                    }
                    break;

                case 6:
                    Console.WriteLine("Altura del arbol: " + arbol.Altura(arbol.Raiz));
                    break;

                case 7:
                    arbol.Limpiar();
                    Console.WriteLine("Arbol limpiado");
                    break;
            }
        }
    }
}
