
using System;
using System.Collections.Generic;

public class Ejercicio2
{
    public void Ejecutar()
    {
        List<string> asignaturas = new List<string>
        { "Matemáticas", "Física", "Química", "Historia", "Lengua" };

        foreach (var a in asignaturas)
        {
            Console.WriteLine($"Yo estudio {a}");
        }
    }
}
