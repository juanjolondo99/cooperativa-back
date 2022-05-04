using System;

using Cooperativa.Infraestructura.Datos.Contextos;

namespace Cooperativa.Infraestructura.Datos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando la DB si no existe...");
            CooperativaContexto db = new CooperativaContexto();
            db.Database.EnsureCreated();
            Console.WriteLine("DB creada");
            Console.ReadKey();
        }
    }
}
