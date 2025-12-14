using System;

namespace Semana03ArraysMatrices
{
    // ---- Definición de clase: Estudiante ----
    // La clase encapsula datos básicos y un array para teléfonos.
    public class Estudiante
    {
        // Propiedades auto-implementadas para datos simples.
        public string Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }

        // Array de 3 teléfonos (requisito de la tarea).
        // Se usan strings para permitir formatos con guiones, prefijos, etc.
        public string[] Telefonos { get; set; } = new string[3];

        // Constructor vacío (opcional).
        public Estudiante() { }

        // Constructor con parámetros para inicializar rápidamente.
        public Estudiante(string id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;

            // Validamos que lleguen exactamente 3 teléfonos.
            if (telefonos == null || telefonos.Length != 3)
                throw new ArgumentException("Debe proporcionar exactamente 3 números de teléfono.");
            Telefonos = telefonos;
        }

        // Método de utilidad: muestra el perfil del estudiante.
        public void MostrarFicha()
        {
            Console.WriteLine("----- Ficha del Estudiante -----");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"  [{i}] {Telefonos[i]}");
            }
            Console.WriteLine("--------------------------------");
        }

        // Método que verifica si algún teléfono está vacío o nulo.
        public bool TelefonosCompletos()
        {
            foreach (var t in Telefonos)
            {
                if (string.IsNullOrWhiteSpace(t))
                    return false;
            }
            return true;
        }
    }

    // ---- Programa principal ----
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Semana 03 - Arrays y Matrices (Registro de Estudiante)";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Registro de Estudiante - C# + Arrays");
            Console.ResetColor();

            // 1) Captura de datos desde consola
            var estudiante = CapturarEstudianteDesdeConsola();

            // 2) Impresión de la ficha
            estudiante.MostrarFicha();

            // 3) Validación simple de teléfonos
            Console.WriteLine(estudiante.TelefonosCompletos()
                ? "Todos los teléfonos fueron ingresados correctamente."
                : "Faltan teléfonos: revise los campos vacíos.");

            // 4) Demostración opcional de matrices (tema general)
            // Creamos una matriz 2x3 y la mostramos; sirve para evidenciar manejo básico.
            int[,] notasEjemplo = new int[2, 3] { { 8, 9, 7 }, { 10, 6, 9 } };
            Console.WriteLine("\nMatriz de notas (2x3):");
            MostrarMatriz(notasEjemplo);

            // Calculamos promedio simple de la matriz para ilustrar operación
            double promedio = PromedioMatriz(notasEjemplo);
            Console.WriteLine($"Promedio de la matriz: {promedio:F2}");

            Console.WriteLine("\nFin del programa. Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }

        // ---- Función: captura de datos de estudiante ----
        static Estudiante CapturarEstudianteDesdeConsola()
        {
            Console.Write("ID: ");
            string id = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Nombres: ");
            string nombres = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Apellidos: ");
            string apellidos = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Dirección: ");
            string direccion = Console.ReadLine()?.Trim() ?? "";

            // Capturamos exactamente 3 teléfonos usando un array.
            string[] telefonos = new string[3];
            for (int i = 0; i < telefonos.Length; i++)
            {
                Console.Write($"Teléfono [{i}]: ");
                telefonos[i] = Console.ReadLine()?.Trim() ?? "";
            }

            // Devolvemos instancia poblada.
            return new Estudiante(id, nombres, apellidos, direccion, telefonos);
        }

        // ---- Utilidad: impresión de matriz int[,] ----
        static void MostrarMatriz(int[,] matriz)
        {
            int filas = matriz.GetLength(0);
            int columnas = matriz.GetLength(1);
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Console.Write($"{matriz[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        // ---- Utilidad: promedio de todos los elementos de una matriz ----
        static double PromedioMatriz(int[,] matriz)
        {
            int filas = matriz.GetLength(0);
            int columnas = matriz.GetLength(1);
            int suma = 0;
            int total = filas * columnas;

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    suma += matriz[i, j];
                }
            }
            return (double)suma / total;
        }
    }
}
