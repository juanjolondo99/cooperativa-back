using System;
using System.Collections.Generic;
using System.Text;

using Cooperativa.Dominio.Modelo.Enums;

namespace Cooperativa.Dominio.Modelo
{
    public class Movimiento
    {
        public Guid Id { get; set; }

        public Guid asociadoId { get; set; }

        public Guid productoId { get; set; }

        public DateTime fecha { get; set; }

        public string descripcion { get; set; }

        public TipoMovimientoEnum tipoMovimiento { get; set; }

        public decimal valor { get; set; }

    }
}
