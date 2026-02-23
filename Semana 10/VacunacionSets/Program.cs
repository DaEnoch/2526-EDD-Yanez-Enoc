using System;
using System.Collections.Generic;
using System.Linq;

class Program
{

    static void Main()
    {
        // #Bloque: Generación de datos 
        var todos = new HashSet<string>(
            Enumerable.Range(1, 500).Select(i => $"Ciudadano {i}")
        );

        // #Bloque: Conjunto Pfizer 
        var pfizer = new HashSet<string>(
            Enumerable.Range(1, 75).Select(i => $"Ciudadano {i}")
        );

        // #Bloque: Conjunto AstraZeneca 
        var astra = new HashSet<string>(
            Enumerable.Range(51, 75).Select(i => $"Ciudadano {i}")
        );

        // #Bloque: Operaciones de teoría de conjuntos

        // Ambas dosis = intersección
        var ambasDosis = new HashSet<string>(pfizer);
        ambasDosis.IntersectWith(astra);

        // Solo Pfizer = Pfizer - AstraZeneca
        var soloPfizer = new HashSet<string>(pfizer);
        soloPfizer.ExceptWith(astra);

        // Solo AstraZeneca = AstraZeneca - Pfizer
        var soloAstra = new HashSet<string>(astra);
        soloAstra.ExceptWith(pfizer);

        // No vacunados = Universo - (Pfizer ∪ AstraZeneca)
        var unionVacunados = new HashSet<string>(pfizer);
        unionVacunados.UnionWith(astra);

        var noVacunados = new HashSet<string>(todos);
        noVacunados.ExceptWith(unionVacunados);

        // #Bloque: Impresión de resultados (listados solicitados)

        ImprimirListado("CIUDADANOS NO VACUNADOS", noVacunados);
        ImprimirListado("CIUDADANOS CON AMBAS DOSIS", ambasDosis);
        ImprimirListado("CIUDADANOS SOLO PFIZER", soloPfizer);
        ImprimirListado("CIUDADANOS SOLO ASTRAZENECA", soloAstra);

        // #Fin de secuencia
    }

    // #Bloque: Utilidad para imprimir un conjunto con su total
    static void ImprimirListado(string titulo, HashSet<string> conjunto)
    {
        Console.WriteLine(new string('=', 60));
        Console.WriteLine($"{titulo} (Total: {conjunto.Count})");
        Console.WriteLine(new string('=', 60));
        foreach (var c in conjunto.OrderBy(x => Numero(x)))
        {
            Console.WriteLine(c);
        }
        Console.WriteLine();
    }

    // #Bloque: Extra simple para ordenar por número (opcional, solo para que se vea prolijo)
    static int Numero(string nombre)
    {
        // Espera formato "Ciudadano X"
        var partes = nombre.Split(' ');
        if (partes.Length == 2 && int.TryParse(partes[1], out int n)) return n;
        return int.MaxValue;
    }
}
