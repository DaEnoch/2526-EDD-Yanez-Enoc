
using System;
using System.Collections.Generic;

public class Ejercicio4
{
    public void Ejecutar()
    {
        List<int> numeros = new List<int>();

        Console.WriteLine("Ingrese los números ganadores de la lotería (6 números):");
        for (int i = 0; i < 6; i++)
        {
            Console.Write($"Número {i + 1}: ");
            int valor = Convert.ToInt32(Console.ReadLine());
            numeros.Add(valor);
        }

        numeros.Sort();

        Console.WriteLine("\nNúmeros ganadores ordenados:");
        Console.WriteLine(string.Join(", ", numeros));
    }
}
