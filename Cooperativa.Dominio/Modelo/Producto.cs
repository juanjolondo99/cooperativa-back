using System;
using System.Collections.Generic;
using System.Text;

using Cooperativa.Dominio.Modelo.Enums;

namespace Cooperativa.Dominio.Modelo
{
    public class Producto
    {
        public Guid Id { get; set; }

        public Guid asociadoId { get; set; }

        public TipoProductoEnum TipoServicio { get; set; }

        public decimal saldo { get; set; }
 
    } 
}
