using System;
using System.Collections.Generic;

class Navegador
{
    private Stack<string> historial = new Stack<string>();

    public void VisitarPagina(string pagina)
    {
        historial.Push(pagina);
        Console.WriteLine("Página actual: " + pagina);
    }

    public void Retroceder()
    {
        if (historial.Count > 1)
        {
            historial.Pop();
            Console.WriteLine("Retrocediendo...");
            Console.WriteLine("Página actual: " + historial.Peek());
        }
        else
        {
            Console.WriteLine("No hay páginas anteriores.");
        }
    }

    public void MostrarHistorial()
    {
        Console.WriteLine("Historial de navegación:");
        foreach (var pagina in historial)
        {
            Console.WriteLine(pagina);
        }
    }
}

class Program
{
    static void Main()
    {
        Navegador nav = new Navegador();

        nav.VisitarPagina("Inicio");
        nav.VisitarPagina("Noticias");
        nav.VisitarPagina("Contacto");

        nav.Retroceder();
        nav.MostrarHistorial();
    }
}