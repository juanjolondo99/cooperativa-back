using Cooperativa.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cooperativa.Infraestructura.ServiceBus.Eventos
{
    public class EventoCola
    {
        public string tipo { get; set; }

        public Guid asociadoId { get; set; }

        public Guid productoId { get; set; }

        public List<Asociado> asociados { get; set; }

        public List<Producto> saldos { get; set; }

        public List<Movimiento> movimientos { get; set; }
    }
}
