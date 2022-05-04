using System;
using System.Collections.Generic;
using System.Text;

namespace Cooperativa.Dominio.Modelo
{
    public class Asociado
    {
        public Guid Id { get; set; }

        public string cedula { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string telefono { get; set; }
    }
}
