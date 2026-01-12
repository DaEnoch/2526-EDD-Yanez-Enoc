
using System;
using System.Collections.Generic;

public class Ejercicio3
{
    public void Ejecutar()
    {
        List<string> asignaturas = new List<string>
        { "Matemáticas", "Física", "Química", "Historia", "Lengua" };

        List<double> notas = new List<double>();

        Console.WriteLine("Ingrese la nota (0 a 10) para cada asignatura:");
        foreach (var a in asignaturas)
        {
            Console.Write($"{a}: ");
            double n = Convert.ToDouble(Console.ReadLine());
            notas.Add(n);
        }

        Console.WriteLine("\nResultados:");
        for (int i = 0; i < asignaturas.Count; i++)
        {
            Console.WriteLine($"En {asignaturas[i]} has sacado {notas[i]}");
        }
    }
}
