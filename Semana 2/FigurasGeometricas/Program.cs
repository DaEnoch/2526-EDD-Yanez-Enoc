
using System;

namespace FigurasGeometricas
{
    public class Circulo
    {
        private double radio;
        public Circulo(double radio)
        {
            if (radio <= 0) throw new ArgumentException("El radio debe ser mayor que cero.");
            this.radio = radio;
        }
        public double Radio => radio;
        public double CalcularArea() => Math.PI * radio * radio;
        public double CalcularPerimetro() => 2 * Math.PI * radio;
    }

    public class Cuadrado
    {
        private double lado;
        public Cuadrado(double lado)
        {
            if (lado <= 0) throw new ArgumentException("El lado debe ser mayor que cero.");
            this.lado = lado;
        }
        public double Lado => lado;
        public double CalcularArea() => lado * lado;
        public double CalcularPerimetro() => 4 * lado;
    }

    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("CALCULADORA DE FIGURAS GEOMETRICAS\n");

            var c = new Circulo(5);
            Console.WriteLine("CIRCULO");
            Console.WriteLine($"Radio: {c.Radio} | Área: {c.CalcularArea():F2} | Perímetro: {c.CalcularPerimetro():F2}\n");

            var q = new Cuadrado(4);
            Console.WriteLine("CUADRADO");
            Console.WriteLine($"Lado: {q.Lado} | Área: {q.CalcularArea():F2} | Perímetro: {q.CalcularPerimetro():F2}\n");

            Console.WriteLine("Programa terminado.");
        }
    }
}

