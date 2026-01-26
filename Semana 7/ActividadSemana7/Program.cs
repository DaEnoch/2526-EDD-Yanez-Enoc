using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<int> origen = new Stack<int>();
        Stack<int> auxiliar = new Stack<int>();
        Stack<int> destino = new Stack<int>();

        int discos = 3;

        // Se cargan los discos en la torre origen
        for (int i = discos; i >= 1; i--)
            origen.Push(i);

        ResolverHanoi(discos, origen, destino, auxiliar);
    }

    static void ResolverHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar)
    {
        if (n == 1)
        {
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine("Mover disco " + disco);
            return;
        }

        ResolverHanoi(n - 1, origen, auxiliar, destino);
        ResolverHanoi(1, origen, destino, auxiliar);
        ResolverHanoi(n - 1, auxiliar, destino, origen);
    }
}